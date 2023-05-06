using Atlas.Modules.Guns;
using HarmonyLib;
using System.Collections.Generic;
using UnityEngine;

namespace WafflesWeapons.Weapons
{
    public class Malevolent : Gun
    {
        public static GameObject Mal;
        public static GameObject MalAlt;

        public static void LoadAssets()
        {
            Mal = Core.Assets.LoadAsset<GameObject>("Revolver Malevolent.prefab");
            MalAlt = Core.Assets.LoadAsset<GameObject>("Alternative Revolver Malevolent.prefab");
            Core.Harmony.PatchAll(typeof(Malevolent));
        }

        public override GameObject Create(Transform parent)
        {
            base.Create(parent);

            GameObject thing;
            if (Enabled() == 2)
            {
                thing = GameObject.Instantiate(MalAlt, parent);
            }
            else
            {
                thing = GameObject.Instantiate(Mal, parent);
            }

            OrderInSlot = GunSetter.Instance.CheckWeaponOrder("rev")[4];
            StyleHUD.Instance.weaponFreshness.Add(thing, 10);
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

        [HarmonyPatch(typeof(WeaponCharges), nameof(WeaponCharges.MaxCharges))]
        [HarmonyPostfix]
        public static void MaxCharge()
        {
            foreach (MalevolentBehaviour gun in Guns)
            {
                gun.MaxCharge();
            }
        }

        [HarmonyPatch(typeof(WeaponCharges), nameof(WeaponCharges.Charge))]
        [HarmonyPostfix]
        public static void DoCharge(float amount)
        {
            foreach (MalevolentBehaviour mal in Guns)
            {
                mal.Charge();
            }
        }

        [HarmonyPatch(typeof(Revolver), nameof(Revolver.Update))]
        [HarmonyPrefix] // i blame hakita
        public static bool AAAAAAAAAAAAAAAA(Revolver __instance)
        {
            return __instance.gunVariation != 5;
        }
    }

    public class MalevolentBehaviour : MonoBehaviour
    {
        public Revolver rev;

        public void OnDestroy()
        {
            Malevolent.Guns.Remove(this);
        }

        public void MaxCharge()
        {
            if (rev != null)
            {
                rev.pierceCharge = 100;
                rev.pierceReady = true;
            }
        }

        public void Charge()
        {
            if (!rev.shootReady)
            {
                if (rev.shootCharge + 200f * Time.deltaTime < 100f)
                {
                    rev.shootCharge += 200f * Time.deltaTime;
                }
                else
                {
                    rev.shootCharge = 100f;
                    rev.shootReady = true;
                }
            }

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
                    rev.screenAud.pitch = Random.Range(1f, 1.1f);
                    rev.screenAud.Play();
                }

                rev.pierceCharge = 100f;
                rev.pierceReady = true;
            }
        }

        public void Start()
        {
            rev = GetComponent<Revolver>();
            rev.screenAud = rev.screenMR.gameObject.GetComponent<AudioSource>();
            rev.screenMR.material.color = ColorBlindSettings.Instance.variationColors[5];
            Malevolent.Guns.Add(this);
        }

        public void Update()
        {
            if (Gun.OnFireHeld() && rev.shootReady && rev.gc.activated && rev.gunReady)
            {
                if ((rev.altVersion && WeaponCharges.Instance.revaltpickupcharges[rev.gunVariation] == 0) || !rev.altVersion)
                {
                    float delay = GetComponent<WeaponIdentifier>().delay;
                    if (!rev.altVersion)
                    {
                        Debug.Log("invoking on " + gameObject.name);
                        Invoke("Shoot", 0 + delay);
                        Invoke("Shoot", 0.1f + delay);
                        Invoke("Shoot", 0.2f + delay);

                        if (rev.wid.delay != 0)
                        {
                            rev.shootCharge = 0;
                            rev.shootReady = false;
                        }
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

            if (Gun.OnAltFireReleased() && rev.pierceReady && rev.shootReady && rev.pierceShotCharge == 100f && rev.gc.activated && rev.gunReady)
            {
                Invoke("Shoot2", rev.wid.delay);
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
                if (Gun.OnAltFireHeld() && rev.shootReady && rev.pierceReady)
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
            {
                ;
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

        public void OnDisable()
        {
            CancelInvoke("Shoot");
        }

        public void Shoot()
        {
            rev.Shoot();
        }

        public void Shoot2()
        {
            rev.Shoot(2);
            rev.wc.rev2charge += (rev.altVersion ? 300 : 100); // hakita's code is pretty bad.
                                                               // instead of checking if it is the sharpshooter revolver, it checks if it isnt the piercer.
                                                               // there's no way not to make it subtract, so i just add it back. this code hurts me.
        }
    }
}
