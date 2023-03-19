using Atlas.Modules.Guns;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace WafflesWeapons.Weapons
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

        public override GameObject Create(Transform parent)
        {
            base.Create(parent);

            Guns.Clear();
            GameObject thing;
             
            if (Enabled() == 2) 
            {
                 thing = GameObject.Instantiate(GunSetter.Instance.revolverPierce[1], parent);
            } 
            else 
            {
                thing = GameObject.Instantiate(GunSetter.Instance.revolverPierce[0], parent);
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
                        if (!rev.pierceReady)
                        {
                            rev.screenAud.clip = rev.chargedSound;
                            rev.screenAud.loop = false;
                            rev.screenAud.volume = 0.35f;
                            rev.screenAud.pitch = UnityEngine.Random.Range(1f, 1.1f);
                            rev.screenAud.Play();
                        }

                        rev.pierceCharge = 100f;
                        rev.pierceReady = true;
                    }
                }
            }

            public void MaxCharge()
            {
                if (rev != null)
                {
                    rev.pierceCharge = 100;
                    rev.pierceReady = true;
                }
            }

            public void Update()
            {
                if (rev == null)
                {
                    rev = GetComponent<Revolver>();
                    rev.screenAud = rev.screenMR.gameObject.GetComponent<AudioSource>();
                    rev.chargeEffect.transform.localPosition += new Vector3(0, -0.25f, 0);
                    rev.chargeEffect.GetComponent<MeshRenderer>().material = Charge;
                    rev.chargeEffect.GetComponent<ParticleSystemRenderer>().material = Charge;
                    rev.chargeEffect.GetComponent<Light>().color = new Color(1, 0.5f, 0.25f);
                }

                if (rev.celight == null)
                {
                    rev.ceaud = rev.chargeEffect.GetComponent<AudioSource>();
                    rev.celight = rev.chargeEffect.GetComponent<Light>();
                }

                if (OnFireHeld() && rev.shootReady && rev.gc.activated)
                {
                    if ((rev.altVersion && WeaponCharges.Instance.revaltpickupcharges[rev.gunVariation] == 0) || !rev.altVersion)
                    {
                        float delay = GetComponent<WeaponIdentifier>().delay;
                        if (!rev.altVersion)
                        {
                            
                            Invoke("Shoot", 0 + delay);
                            Invoke("Shoot", 0.1f + delay);
                            Invoke("Shoot", 0.2f + delay);
                        }
                        else
                        {
                            Invoke("Shoot", 0 + delay);
                            Invoke("Shoot", 0.25f + delay);
                            Invoke("Shoot", 0.5f + delay);
                        }
                    }
                }

                rev.chargeEffect.transform.localScale = Vector3.one * rev.pierceShotCharge * 0.02f;
                rev.ceaud.volume = 0.25f + rev.pierceShotCharge * 0.005f;
                rev.ceaud.pitch = rev.pierceShotCharge * 0.005f;
                rev.celight.range = rev.pierceShotCharge * 0.01f;

                if (OnAltFireReleased() && rev.pierceReady && rev.shootReady && rev.pierceShotCharge == 100f && rev.gc.activated)
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

                if (rev.gc.activated)
                {
                    if (InputManager.Instance.InputSource.Fire2.IsPressed && rev.shootReady && rev.pierceReady)
                    {
                        rev.chargingPierce = true;
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
                        rev.chargingPierce = false;
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

                    transform.localPosition = new Vector3(rev.wpos.currentDefault.x + rev.pierceShotCharge / 250f *
                        UnityEngine.Random.Range(-0.05f, 0.05f), rev.wpos.currentDefault.y + rev.pierceShotCharge / 250f *
                        UnityEngine.Random.Range(-0.05f, 0.05f), rev.wpos.currentDefault.z + rev.pierceShotCharge / 250f *
                        UnityEngine.Random.Range(-0.05f, 0.05f));
                }

                rev.cylinder.spinSpeed = rev.pierceShotCharge;
            }

            public void Shoot()
            {
                rev.cc.StopShake();
                rev.shootReady = false;
                rev.shootCharge = 0f;
                if (rev.altVersion)
                {
                    WeaponCharges.Instance.revaltpickupcharges[rev.gunVariation] = 2f;
                }

                GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(rev.revolverBeam, rev.cc.transform.position, rev.cc.transform.rotation);
                if (rev.targeter.CurrentTarget && rev.targeter.IsAutoAimed)
                {
                    gameObject.transform.LookAt(rev.targeter.CurrentTarget.bounds.center);
                }
                RevolverBeam component = gameObject.GetComponent<RevolverBeam>();
                component.damage *= 0.5f;
                component.critDamageOverride = 1;
                component.sourceWeapon = rev.gc.currentWeapon;
                component.alternateStartPoint = rev.gunBarrel.transform.position;
                component.gunVariation = rev.gunVariation;

                if (rev.anim.GetCurrentAnimatorStateInfo(0).IsName("PickUp"))
                {
                    component.quickDraw = true;
                }

                rev.currentGunShot = UnityEngine.Random.Range(0, rev.gunShots.Length);
                rev.gunAud.clip = rev.gunShots[rev.currentGunShot];
                rev.gunAud.volume = 0.55f;
                rev.gunAud.pitch = UnityEngine.Random.Range(0.9f, 1.1f);
                rev.gunAud.Play();
                rev.cam.fieldOfView = rev.cam.fieldOfView + rev.cc.defaultFov / 40f;
                //RumbleManager.Instance.SetVibrationTracked("rumble.gun.fire", base.gameObject);

                if (!rev.altVersion)
                {
                    rev.cylinder.DoTurn();
                }

                rev.anim.SetFloat("RandomChance", UnityEngine.Random.Range(0f, 1f));
                rev.anim.SetTrigger("Shoot");
            }

            public void Shoot2()
            {
                rev.cc.StopShake();
                rev.shootReady = false;
                rev.shootCharge = 0f;
                if (rev.altVersion)
                {
                   WeaponCharges.Instance.revaltpickupcharges[rev.gunVariation] = 2f;
                }

                GameObject beam = UnityEngine.Object.Instantiate<GameObject>(rev.revolverBeamSuper, rev.cc.transform.position, rev.cc.transform.rotation);
                if (rev.targeter.CurrentTarget && rev.targeter.IsAutoAimed)
                {
                    beam.transform.LookAt(rev.targeter.CurrentTarget.bounds.center);
                }
                RevolverBeam component = beam.GetComponent<RevolverBeam>();
                component.sourceWeapon = gameObject;

                component.critDamageOverride = 1;
                component.sourceWeapon = rev.gc.currentWeapon;
                component.alternateStartPoint = rev.gunBarrel.transform.position;
                component.gunVariation = rev.gunVariation;

                if (rev.anim.GetCurrentAnimatorStateInfo(0).IsName("PickUp"))
                {
                    component.quickDraw = true;
                }

                rev.currentGunShot = UnityEngine.Random.Range(0, rev.gunShots.Length);
                rev.gunAud.clip = rev.gunShots[rev.currentGunShot];
                rev.gunAud.volume = 0.55f;
                rev.gunAud.pitch = UnityEngine.Random.Range(0.9f, 1.1f);
                rev.gunAud.Play();
                rev.cam.fieldOfView = rev.cam.fieldOfView + rev.cc.defaultFov / 40f;
                //RumbleManager.Instance.SetVibrationTracked("rumble.gun.fire", base.gameObject);

                if (!rev.altVersion)
                {
                    rev.cylinder.DoTurn();
                }

                rev.anim.SetFloat("RandomChance", UnityEngine.Random.Range(0f, 1f));
                rev.anim.SetTrigger("Shoot");

                rev.pierceShotCharge = 0f;
                rev.pierceCharge = 0;
                rev.pierceReady = false;

                rev.screenAud.clip = rev.chargingSound;
                rev.screenAud.loop = true;
                if (rev.altVersion)
                {
                    rev.screenAud.pitch = 0.5f;
                }
                else
                {
                    rev.screenAud.pitch = 0.75f;
                }
                rev.screenAud.volume = 0.55f;
                rev.screenAud.Play();
            }
        }
    }
}
