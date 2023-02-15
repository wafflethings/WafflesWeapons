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
    public class Malevolent : Gun
    {
        public static Sprite Icon;
        public static Sprite IconGlow;
        public static Sprite IconAlt;
        public static Sprite IconGlowAlt;
        public static GameObject MalevBeam;
        public static GameObject MalevBeamAlt;
        public static Material Charge;

        public static void LoadAssets()
        {
            Icon = Core.Assets.LoadAsset<Sprite>("Malevolent.png");
            IconGlow = Core.Assets.LoadAsset<Sprite>("Malevolent Glow.png");
            IconAlt = Core.Assets.LoadAsset<Sprite>("Malevolent Alt.png");
            IconGlowAlt = Core.Assets.LoadAsset<Sprite>("Malevolent Glow Alt.png");
            MalevBeam = Core.Assets.LoadAsset<GameObject>("MalevBeam.prefab");
            MalevBeamAlt = Core.Assets.LoadAsset<GameObject>("MalevBeam Alt.prefab");
            Charge = Core.Assets.LoadAsset<Material>("MalCharge.mat");
            Core.Harmony.PatchAll(typeof(Malevolent));
        }

        public override GameObject Create()
        {
            base.Create();

            Guns.Clear();
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
            rev.screenMR.material.color = ColorBlindSettings.Instance.variationColors[5];
            rev.gunVariation = 5;
            if (!rev.altVersion)
            {
                rev.revolverBeamSuper = MalevBeam;
            } else
            {
                rev.revolverBeamSuper = MalevBeamAlt;
            }

            var ico = thing.GetComponent<WeaponIcon>();
            ico.variationColor = 5;
            if (rev.altVersion)
            {
                ico.glowIcon = IconGlowAlt;
                ico.weaponIcon = IconAlt;
            } else
            {
                ico.glowIcon = IconGlow;
                ico.weaponIcon = Icon;
            }

            Guns.Add(thing.AddComponent<MalevolentBehaviour>());
            return thing;
        }

        public override int Slot()
        {
            return 0;
        }

        public override string Pref()
        {
            return "rev4";
        }

        [HarmonyPatch(typeof(StyleHUD), nameof(StyleHUD.DecayFreshness))]
        [HarmonyPostfix]
        public static void StyleMult(StyleHUD __instance, GameObject sourceWeapon, string pointID, bool boss)
        {
            if (sourceWeapon.GetComponent<MalevolentBehaviour>() != null)
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

                if(pointID == "ultrakill.explosionhit")
                {
                    num *= 0.33f;
                } else
                {
                    num *= 0.5f;
                }

                __instance.AddFreshness(sourceWeapon, num);
            }
        }

        public static List<MalevolentBehaviour> Guns = new List<MalevolentBehaviour>();

        [HarmonyPatch(typeof(WeaponCharges), nameof(WeaponCharges.Charge))]
        [HarmonyPostfix]
        public static void DoCharge(float amount)
        {
            foreach(MalevolentBehaviour gun in Guns)
            {
                gun.DoCharge();
            }
        }

        [HarmonyPatch(typeof(WeaponCharges), nameof(WeaponCharges.MaxCharges))]
        [HarmonyPostfix]
        public static void MaxCharge()
        {
            foreach (MalevolentBehaviour gun in Guns)
            {
                gun.MaxCharge();
            }
        }

        public class MalevolentBehaviour : MonoBehaviour
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
            private bool pierceReady = false;
            private bool chargingPierce = false;
            private AudioSource screenAud;
            private AudioSource ceaud;
            private Light celight;
            private WeaponPos wpos;

            private Revolver rev;

            public void OnDestroy()
            {
                Guns.Remove(this);
            }

            public void DoCharge()
            {
                if (rev != null)
                {
                    float num = 1f;
                    if (rev.altVersion)
                    {
                        num = 0.5f;
                    }

                    if (rev.pierceCharge + 30f * Time.deltaTime < 100f)
                    {
                        rev.pierceCharge += 30f * Time.deltaTime * num;
                    }
                    else
                    {
                        if (!pierceReady)
                        {
                            screenAud.clip = rev.chargedSound;
                            screenAud.loop = false;
                            screenAud.volume = 0.35f;
                            screenAud.pitch = UnityEngine.Random.Range(1f, 1.1f);
                            screenAud.Play();
                        }

                        rev.pierceCharge = 100f;
                        pierceReady = true;
                    }
                }
            }

            public void MaxCharge()
            {
                if (rev != null)
                {
                    rev.pierceCharge = 100;
                    pierceReady = true;
                }
            }

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
                wpos = GetComponent<WeaponPos>();
            }

            public void Update()
            {
                if (rev == null)
                {
                    rev = GetComponent<Revolver>();
                    screenAud = rev.screenMR.gameObject.GetComponent<AudioSource>();
                    rev.chargeEffect.transform.localPosition += new Vector3(0, -0.25f, 0);
                    rev.chargeEffect.GetComponent<MeshRenderer>().material = Charge;
                    rev.chargeEffect.GetComponent<ParticleSystemRenderer>().material = Charge;
                    rev.chargeEffect.GetComponent<Light>().color = new Color(1, 0.5f, 0.25f);
                }

                if (celight == null)
                {
                    ceaud = rev.chargeEffect.GetComponent<AudioSource>();
                    celight = rev.chargeEffect.GetComponent<Light>();
                }
                //
                //rev.screenMR.material.SetTexture("_MainTex", NumberToTexture[(int)Charge]);

                if (shootCharge + 150f * Time.deltaTime < 100f)
                {
                    shootCharge += 150f * Time.deltaTime;
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
                        if (!rev.altVersion)
                        {
                            Invoke("Shoot", 0);
                            Invoke("Shoot", 0.1f);
                            Invoke("Shoot", 0.2f);
                        }
                        else
                        {
                            Invoke("Shoot", 0);
                            Invoke("Shoot", 0.25f);
                            Invoke("Shoot", 0.5f);
                        }
                    }
                }

                rev.chargeEffect.transform.localScale = Vector3.one * rev.pierceShotCharge * 0.02f;
                ceaud.volume = 0.25f + rev.pierceShotCharge * 0.005f;
                ceaud.pitch = rev.pierceShotCharge * 0.005f;
                celight.range = rev.pierceShotCharge * 0.01f;

                if (OnAltFireReleased() && pierceReady && shootReady && rev.pierceShotCharge == 100f && gc.activated)
                {
                    Shoot2();
                }

                if (rev.pierceCharge < 50f)
                {
                    rev.screenMR.material.SetTexture("_MainTex", rev.batteryLow);
                    //rev.screenMR.material.color = Color.red;
                }
                else
                {
                    if (rev.pierceCharge < 100f)
                    {
                        rev.screenMR.material.SetTexture("_MainTex", rev.batteryMid);
                        //rev.screenMR.material.color = Color.yellow;
                    }
                    else
                    {
                        rev.screenMR.material.SetTexture("_MainTex", rev.batteryFull);
                    }
                }

                if (gc.activated)
                {
                    if (InputManager.Instance.InputSource.Fire2.IsPressed && shootReady && pierceReady)
                    {
                        chargingPierce = true;
                        if (rev.pierceShotCharge + 175f * Time.deltaTime < 100f)
                        {
                            rev.pierceShotCharge += 175f * Time.deltaTime;
                        }
                        else
                        {
                            rev.pierceShotCharge = 100f;
                        }
                    }
                    else
                    {
                        chargingPierce = false;
                        if (rev.pierceShotCharge - 175f * Time.deltaTime > 0f)
                        {
                            rev.pierceShotCharge -= 175f * Time.deltaTime;
                        }
                        else
                        {
                            rev.pierceShotCharge = 0f;
                        }
                    }
                }

                if (rev.pierceShotCharge != 0f)
                {;
                    if (rev.pierceShotCharge < 50f)
                    {
                        rev.screenMR.material.SetTexture("_MainTex", rev.batteryCharges[0]);
                    }
                    else
                    {
                        if (rev.pierceShotCharge < 100f)
                        {
                            rev.screenMR.material.SetTexture("_MainTex", rev.batteryCharges[1]);
                        }
                        else
                        {
                            rev.screenMR.material.SetTexture("_MainTex", rev.batteryCharges[2]);
                        }
                    }

                    transform.localPosition = new Vector3(wpos.currentDefault.x + rev.pierceShotCharge / 250f *
                        UnityEngine.Random.Range(-0.05f, 0.05f), wpos.currentDefault.y + rev.pierceShotCharge / 250f *
                        UnityEngine.Random.Range(-0.05f, 0.05f), wpos.currentDefault.z + rev.pierceShotCharge / 250f *
                        UnityEngine.Random.Range(-0.05f, 0.05f));
                }

                rev.cylinder.spinSpeed = rev.pierceShotCharge;
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
                component.damage *= 0.5f;
                component.critDamageOverride = 1;
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

            public void Shoot2()
            {
                cc.StopShake();
                shootReady = false;
                shootCharge = 0f;
                if (rev.altVersion)
                {
                    MonoSingleton<WeaponCharges>.Instance.revaltpickupcharge = 2f;
                }

                GameObject beam = UnityEngine.Object.Instantiate<GameObject>(rev.revolverBeamSuper, cc.transform.position, cc.transform.rotation);
                if (targeter.CurrentTarget && targeter.IsAutoAimed)
                {
                    beam.transform.LookAt(targeter.CurrentTarget.bounds.center);
                }
                RevolverBeam component = beam.GetComponent<RevolverBeam>();
                component.sourceWeapon = gameObject;

                component.critDamageOverride = 1;
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

                rev.pierceShotCharge = 0f;
                rev.pierceCharge = 0;
                pierceReady = false;

                screenAud.clip = rev.chargingSound;
                screenAud.loop = true;
                if (rev.altVersion)
                {
                    screenAud.pitch = 0.5f;
                }
                else
                {
                    screenAud.pitch = 0.75f;
                }
                screenAud.volume = 0.55f;
                screenAud.Play();
            }
        }
    }
}
