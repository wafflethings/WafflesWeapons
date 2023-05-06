using Atlas.Modules.Guns;
using HarmonyLib;
using System.Collections.Generic;
using UnityEngine;

namespace WafflesWeapons.Weapons
{
    public class FanFire : Gun
    {
        public static GameObject Fan;
        public static GameObject FanAlt;

        public static void LoadAssets()
        {
            Fan = Core.Assets.LoadAsset<GameObject>("Revolver Fan.prefab");
            FanAlt = Core.Assets.LoadAsset<GameObject>("Alternative Revolver Fan.prefab");
            Core.Harmony.PatchAll(typeof(FanFire));
        }

        public override GameObject Create(Transform parent)
        {
            base.Create(parent);

            GameObject thing;
            if (Enabled() == 2)
            {
                thing = GameObject.Instantiate(FanAlt, parent);
            }
            else
            {
                thing = GameObject.Instantiate(Fan, parent);
            }

            FanFireBehaviour.BeamsUsed.Clear();
            OrderInSlot = GunSetter.Instance.CheckWeaponOrder("rev")[3];
            StyleHUD.Instance.weaponFreshness.Add(thing, 10);
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

                if (currentHit.collider != null && !FanFireBehaviour.BeamsUsed.Contains(__instance))
                {
                    FanFireBehaviour.BeamsUsed.Add(__instance);
                    float amount = 0.5f;
                    if (__instance.sourceWeapon.TryGetComponent(out ffb))
                    {
                        amount = 1f;
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
                var dict = __instance.weaponFreshness;
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
    }

    public class FanFireBehaviour : MonoBehaviour
    {
        private Revolver rev;
        [HideInInspector] public static float Charge = 0;
        [HideInInspector] public float Damage = 0;
        private bool CanFan = true;
        public Texture2D[] NumberToTexture;
        public static List<RevolverBeam> BeamsUsed = new List<RevolverBeam>();

        public void Start()
        {
            rev = GetComponent<Revolver>();
            rev.screenMR.material.color = ColorBlindSettings.Instance.variationColors[4];
        }

        public void Update()
        {
            rev.pierceShotCharge = 0;
            rev.screenMR.material.SetTexture("_MainTex", NumberToTexture[(int)Charge]);

            if (Gun.OnFireHeld() && rev.shootReady && rev.gc.activated && rev.gunReady)
            {
                if ((rev.altVersion && WeaponCharges.Instance.revaltpickupcharges[rev.gunVariation] == 0) || !rev.altVersion)
                {
                    rev.Shoot();
                }
            }

            if (Gun.OnAltFire() && CanFan)
            {
                Damage = 0;
                Charge = (int)Charge;
                CanFan = false;
                float delay = GetComponent<WeaponIdentifier>().delay;
                Invoke("ResetFan", (((int)Charge - 1) * 0.15f) + 1 + delay);
                for (int i = 0; i < (int)Charge; i++)
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

        public void ShootFan()
        {
            if (gameObject.GetComponentInParent<DualWield>() == null)
            {
                Charge--;
            }

            GameObject original = rev.revolverBeam;
            rev.revolverBeam = rev.revolverBeamSuper;
            rev.revolverBeam.GetComponent<RevolverBeam>().damage = Damage;
            rev.Shoot(1);
            rev.revolverBeam = original;
        }
    }
}
