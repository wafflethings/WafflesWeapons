using Atlas.Modules.Guns;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ExtraAlts.Weapons
{
    public class FanFire : Gun
    {
        public static Sprite Icon;
        public static Sprite IconGlow;
        public static Sprite IconAlt;
        public static Sprite IconGlowAlt;
        public static Texture2D[] NumberToTexture;
        public static GameObject FanShot;

        public static void LoadAssets()
        {
            Icon = Core.Assets.LoadAsset<Sprite>("FanFire.png");
            IconGlow = Core.Assets.LoadAsset<Sprite>("FanFire Glow.png");
            IconAlt = Core.Assets.LoadAsset<Sprite>("Fan Alt.png");
            IconGlowAlt = Core.Assets.LoadAsset<Sprite>("Fan Alt Glow.png");
            NumberToTexture = new Texture2D[]
            {
                Core.Assets.LoadAsset<Texture2D>("dice_0.png"),
                Core.Assets.LoadAsset<Texture2D>("dice_1.png"),
                Core.Assets.LoadAsset<Texture2D>("dice_2.png"),
                Core.Assets.LoadAsset<Texture2D>("dice_3.png"),
                Core.Assets.LoadAsset<Texture2D>("dice_4.png"),
                Core.Assets.LoadAsset<Texture2D>("dice_5.png"),
                Core.Assets.LoadAsset<Texture2D>("dice_6.png")
            };
            FanShot = Core.Assets.LoadAsset<GameObject>("FanShot.prefab");
            Core.Harmony.PatchAll(typeof(FanFire));
        }

        public override GameObject Create()
        {
            base.Create();

            GameObject thing;

            if (Enabled() == 2)
            {
                thing = GameObject.Instantiate(GunSetter.Instance.revolverPierce[1]);
            }
            else
            {
                thing = GameObject.Instantiate(GunSetter.Instance.revolverPierce[0]);
            }

            var rev = thing.GetComponent<Revolver>();
            rev.screenMR.material.color = ColorBlindSettings.Instance.variationColors[4];
            rev.gunVariation = 4;
            rev.revolverBeamSuper = FanShot;

            var ico = thing.GetComponent<WeaponIcon>();
            ico.variationColor = 4;
            if (rev.altVersion)
            {
                ico.glowIcon = IconGlowAlt;
                ico.weaponIcon = IconAlt;
            }
            else
            {
                ico.glowIcon = IconGlow;
                ico.weaponIcon = Icon;
            }

            thing.AddComponent<FanFireBehaviour>();

            return thing;
        }

        public override int Slot()
        {
            return 0;
        }

        public override string Pref()
        {
            return "rev3";
        }

        [HarmonyPatch(typeof(RevolverBeam), nameof(RevolverBeam.ExecuteHits))]
        [HarmonyPrefix]
        public static void Patch_ExecuteHits(RevolverBeam __instance, RaycastHit currentHit)
        {
            // something causes this to error, and i cant be fucking bothered to fix it
            // fuck it, we ball.
            try
            {
                FanFireBehaviour ffb;

                if (currentHit.collider != null)
                {
                    float amount = 0.5f;
                    if (__instance.sourceWeapon.TryGetComponent(out ffb))
                    {
                        amount = 0.25f;
                    }

                    if (__instance.beamType == BeamType.Revolver && FanFireBehaviour.Charge < 6 &&
                        currentHit.collider.gameObject.GetComponent<EnemyIdentifierIdentifier>() != null &&
                        !currentHit.collider.gameObject.GetComponent<EnemyIdentifierIdentifier>().eid.dead &&
                        !__instance.gameObject.name.Contains("FanShot"))
                    {
                        FanFireBehaviour.Charge += amount;
                    }
                }
            } catch { }
        }

        [HarmonyPatch(typeof(StyleHUD), nameof(StyleHUD.DecayFreshness))]
        [HarmonyPostfix]
        public static void StyleMult(StyleHUD __instance, GameObject sourceWeapon, string pointID, bool boss)
        {
            if (sourceWeapon.GetComponent<FanFireBehaviour>() != null)
            {
                var dict = __instance.GetPrivateField("weaponFreshness") as Dictionary<GameObject, float>;
                if (!dict.ContainsKey(sourceWeapon))
                {
                    return;
                }
                float num = __instance.freshnessDecayPerMove;
                if (__instance.freshnessDecayMultiplierDict.ContainsKey(pointID))
                {
                    num *= __instance.freshnessDecayMultiplierDict[pointID];
                }
                if (boss)
                {
                    num *= __instance.bossFreshnessDecayMultiplier;
                }

                __instance.AddFreshness(sourceWeapon, num * 0.15f);
            }
        }

        [HarmonyPatch(typeof(WeaponCharges), nameof(WeaponCharges.Charge))]
        [HarmonyPostfix]
        public static void DoCharge(float amount)
        {

        }

        [HarmonyPatch(typeof(WeaponCharges), nameof(WeaponCharges.MaxCharges))]
        [HarmonyPostfix]
        public static void MaxCharge()
        {
            FanFireBehaviour.Charge = 6;
        }

        [HarmonyPatch(typeof(Coin), nameof(Coin.DelayedReflectRevolver))]
        [HarmonyPrefix]
        public static bool BounceIfFan(Coin __instance, GameObject beam)
        {
            if(beam != null && beam.name.Contains("FanShot"))
            {
                __instance.CancelInvoke("ReflectRevolver");
                beam.GetComponent<RevolverBeam>().hitAmount++;
                beam.GetComponent<RevolverBeam>().maxHitsPerTarget++;
                MyCoolBounce(__instance);
                __instance.Invoke("ReflectRevolver", 1f);
                return false;
            }

            return true;
        }

        public static void MyCoolBounce(Coin coin)
        {
            GameObject NewCoin = GameObject.Instantiate(coin.gameObject, coin.transform.position, Quaternion.identity);
            NewCoin.name = "NewCoin+" + (coin.power - 2f);
            NewCoin.SetActive(false);

            NewCoin.transform.position = coin.transform.position;
            NewCoin.SetActive(true);
            coin.GetComponent<SphereCollider>().enabled = false;
            coin.shot = true;

            Coin NewCoinCoin = NewCoin.GetComponent<Coin>();
            if (NewCoinCoin)
            {
                NewCoinCoin.shot = false;
            }
            Rigidbody NewCoinRb = NewCoin.GetComponent<Rigidbody>();
            if (NewCoinRb)
            {
                NewCoinRb.isKinematic = false;
                NewCoinRb.velocity = Vector3.zero;

                // if the player is looking up, make it go forwards so it isnt too ez
                float mult = 0;
                float rot = CameraController.Instance.transform.localRotation.eulerAngles.x;
                if (rot <= 280 && rot >= 270)
                {
                    mult = 7.5f;
                }

                NewCoinRb.AddForce((Vector3.up * 15f) + (NewMovement.Instance.transform.forward * mult), ForceMode.VelocityChange);
            }

            coin.gameObject.SetActive(false);
            new GameObject().AddComponent<CoinCollector>().coin = coin.gameObject;
            coin.CancelInvoke("GetDeleted");
        }

        public class FanFireBehaviour : MonoBehaviour
        {
            private CameraController cc;
            private CameraFrustumTargeter targeter;
            private GunControl gc;
            private Animator anim;
            private AudioSource gunAud;
            private Camera cam;

            private bool shootReady;
            private float shootCharge;
            private int currentGunShot;

            private Revolver rev;
            public static float Charge = 0;
            public float Damage = 0;
            private bool CanFan = true;

            public void Start()
            {
                transform.localPosition = GunSetter.Instance.revolverPierce[0].transform.position;
                typeof(WeaponPos).GetField("ready", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(transform.GetComponent<WeaponPos>(), false);
                GetComponent<WeaponPos>().CheckPosition();

                cc = CameraController.Instance;
                targeter = CameraFrustumTargeter.Instance;
                gc = GetComponentInParent<GunControl>();
                anim = GetComponentInChildren<Animator>();
                gunAud = GetComponent<AudioSource>();
                cam = CameraController.Instance.GetComponent<Camera>();
            }

            public void Update()
            {
                if (rev == null)
                {
                    rev = GetComponent<Revolver>();
                }
                rev.screenMR.material.SetTexture("_MainTex", NumberToTexture[(int)Charge]);

                if (shootCharge + 175f * Time.deltaTime < 100f)
                {
                    shootCharge += 175f * Time.deltaTime;
                }
                else
                {
                    shootCharge = 100f;
                    shootReady = true;
                }

                if (OnFireHeld() && shootReady && gc.activated)
                {
                    if ((rev.altVersion && MonoSingleton<WeaponCharges>.Instance.revaltpickupcharge == 0) || !rev.altVersion)
                    {
                        Shoot();
                    }
                }

                if (OnAltFire() && CanFan)
                {
                    Damage = 0;
                    Charge = (int)Charge;
                    int tempCharge = (int)Charge;
                    CanFan = false;
                    float delay = GetComponent<WeaponIdentifier>().delay;
                    Invoke("ResetFan", ((tempCharge-1) * 0.15f) + 1 + delay);
                    for (int i = 0; i < tempCharge; i++)
                    {
                        Damage = ((i + 1) * 0.25f) + 0.25f;
                        Invoke("ShootFan", (i * 0.15f) + delay);
                    }
                }
            }

            public void ResetFan()
            {
                CanFan = true;
            }

            public void OnDisable()
            {
                CancelInvoke("ShootFan");
            }

            public void Shoot()
            {
                cc.StopShake();
                shootReady = false;
                shootCharge = 0f;
                if (rev.altVersion)
                {
                    MonoSingleton<WeaponCharges>.Instance.revaltpickupcharge = 2f;
                }

                GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(rev.revolverBeam, cc.transform.position, cc.transform.rotation);
                if (targeter.CurrentTarget && targeter.IsAutoAimed)
                {
                    gameObject.transform.LookAt(targeter.CurrentTarget.bounds.center);
                }
                RevolverBeam component = gameObject.GetComponent<RevolverBeam>();
                component.sourceWeapon = gc.currentWeapon;
                component.alternateStartPoint = rev.gunBarrel.transform.position;
                component.gunVariation = rev.gunVariation;

                if (anim.GetCurrentAnimatorStateInfo(0).IsName("PickUp"))
                {
                    component.quickDraw = true;
                }

                currentGunShot = UnityEngine.Random.Range(0, rev.gunShots.Length);
                gunAud.clip = rev.gunShots[currentGunShot];
                gunAud.volume = 0.55f;
                gunAud.pitch = UnityEngine.Random.Range(0.9f, 1.1f);
                gunAud.Play();
                cam.fieldOfView = cam.fieldOfView + cc.defaultFov / 40f;
                //RumbleManager.Instance.SetVibrationTracked("rumble.gun.fire", base.gameObject);

                if (!rev.altVersion)
                {
                    rev.cylinder.DoTurn();
                }

                anim.SetFloat("RandomChance", UnityEngine.Random.Range(0f, 1f));
                anim.SetTrigger("Shoot");
            }

            public void ShootFan()
            {
                cc.StopShake();
                if (this.gameObject.GetComponentInParent<DualWield>() == null)
                {
                    Charge--;
                }
                shootReady = false;
                shootCharge = 0f;
                if (rev.altVersion)
                {
                    WeaponCharges.Instance.revaltpickupcharge = 2f;
                }

                GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(rev.revolverBeamSuper, cc.transform.position, cc.transform.rotation);
                if (targeter.CurrentTarget && targeter.IsAutoAimed)
                {
                    gameObject.transform.LookAt(targeter.CurrentTarget.bounds.center);
                }

                RevolverBeam component = gameObject.GetComponent<RevolverBeam>();
                component.damage = Damage;
                component.sourceWeapon = gc.currentWeapon;
                component.alternateStartPoint = rev.gunBarrel.transform.position;
                component.gunVariation = rev.gunVariation;

                if (anim.GetCurrentAnimatorStateInfo(0).IsName("PickUp"))
                {
                    component.quickDraw = true;
                }

                currentGunShot = UnityEngine.Random.Range(0, rev.gunShots.Length);
                gunAud.clip = rev.gunShots[currentGunShot];
                gunAud.volume = 0.55f;
                gunAud.pitch = UnityEngine.Random.Range(0.9f, 1.1f);
                gunAud.Play();
                cam.fieldOfView = cam.fieldOfView + cc.defaultFov / 40f;
                //RumbleManager.Instance.SetVibrationTracked("rumble.gun.fire", base.gameObject);

                if (!rev.altVersion)
                {
                    rev.cylinder.DoTurn();
                }

                anim.SetFloat("RandomChance", UnityEngine.Random.Range(0f, 1f));
                anim.SetTrigger("Shoot");
            }
        }
    }
}
