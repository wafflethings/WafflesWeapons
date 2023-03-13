using Atlas.Modules.Guns;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace ExtraAlts.Weapons
{
    public class Airblast : Gun
    {
        public static Sprite Icon;
        public static Sprite IconGlow;
        public static Sprite IconAlt;
        public static Sprite IconGlowAlt;
        public static GameObject Blast;
        public static GameObject AltBlast;
        public static GameObject AirNail;
        public static GameObject AirSaw;

        public static void LoadAssets()
        {
            Icon = Core.Assets.LoadAsset<Sprite>("Airblast ico.png");
            IconGlow = Core.Assets.LoadAsset<Sprite>("Airblast ico glow.png");
            IconAlt = Core.Assets.LoadAsset<Sprite>("AirSawIcon.png");
            IconGlowAlt = Core.Assets.LoadAsset<Sprite>("AirSawGlow.png");
            Blast = Core.Assets.LoadAsset<GameObject>("Airblast.prefab");
            AltBlast = Core.Assets.LoadAsset<GameObject>("AltBlast.prefab");
            AirNail = Core.Assets.LoadAsset<GameObject>("AirNail.prefab");
            AirSaw = Core.Assets.LoadAsset<GameObject>("AirSaw.prefab");

            Core.Harmony.PatchAll(typeof(Airblast));
        }

        public override GameObject Create(Transform parent)
        {
            base.Create(parent);

            GameObject thing;

            if(Enabled() == 2)
            {
                thing = GameObject.Instantiate(GunSetter.Instance.nailOverheat[1], parent);
            } else
            {
                thing = GameObject.Instantiate(GunSetter.Instance.nailOverheat[0], parent);
            }

            var nai = thing.GetComponent<Nailgun>();
            nai.variation = 4;
            nai.fireRate *= 0.5f;
            if (!nai.altVersion)
            {
                nai.nail = AirNail;
            } else
            {
                nai.nail = AirSaw;
            }

            var ico = thing.GetComponent<WeaponIcon>();
            ico.variationColor = 4;
            if (nai.altVersion)
            {
                ico.glowIcon = IconGlowAlt;
                ico.weaponIcon = IconAlt;
            }
            else
            {
                ico.glowIcon = IconGlow;
                ico.weaponIcon = Icon;
            }

            thing.AddComponent<AirblastBehaviour>();

            thing.name = "Airblast Nailgun";

            return thing;
        }

        public override int Slot()
        {
            return 2;
        }

        public override string Pref()
        {
            return "nai3";
        }

        [HarmonyPatch(typeof(WeaponCharges), nameof(WeaponCharges.Charge))]
        [HarmonyPostfix]
        public static void DoCharge(float amount)
        {
            if (AirblastBehaviour.gcc != null)
            {
                bool Touching = AirblastBehaviour.gcc.touchingGround;
                float TimeMult = 0.05f;
                float ShootMult = 0.25f;
                if (Touching)
                {
                    TimeMult = 0.1f;
                    ShootMult = 0.4f;
                }

                AirblastBehaviour.Charge += Time.deltaTime * TimeMult;
                if (OnFireHeld())
                {
                    AirblastBehaviour.Charge += Time.deltaTime * ShootMult;
                }
                if (AirblastBehaviour.Charge > 1)
                {
                    AirblastBehaviour.Charge = 1;
                }
            }
        }

        [HarmonyPatch(typeof(WeaponCharges), nameof(WeaponCharges.MaxCharges))]
        [HarmonyPostfix]
        public static void MaxCharge()
        {
            AirblastBehaviour.Charge = 1;
        }

        public class AirblastBehaviour : MonoBehaviour
        {
            private GameObject MyBlast;
            private Nailgun nai;
            public static float Charge;
            public static GroundCheck gcc;

            public void Start()
            {
                nai = GetComponent<Nailgun>();

                nai.heatSlider.gameObject.ChildByName("Fill Area").ChildByName("Fill").GetComponent<Image>().color = ColorBlindSettings.Instance.variationColors[4];
                nai.heatSlider.transform.parent.transform.localPosition += new Vector3(0, -4, 0);
                foreach(Image img in nai.heatSinkImages)
                {
                    img.gameObject.SetActive(false);
                }

                gcc = FindObjectOfType<GroundCheck>();

                if(nai.altVersion)
                {
                    MyBlast = AltBlast;
                } else
                {
                    MyBlast = Blast;
                }
            }

            public void Update()
            {
                if(nai == null)
                {
                    nai = GetComponent<Nailgun>();
                }

                nai.sliderBg.color = ColorBlindSettings.Instance.variationColors[4];
                if (nai.altVersion)
                {
                    nai.fireRate = 35f;
                } else
                {
                    nai.fireRate = 6f;
                }

                if (nai.gc.activated)
                {
                    bool Touching = gcc.touchingGround;
                    nai.heatSlider.value = Charge;

                    if (Charge == 1 && OnAltFire()) 
                    {
                        nai.anim.SetTrigger("Shoot");

                        Quaternion rot = nai.cc.transform.rotation;
                        if(nai.altVersion)
                        {
                            rot = MyBlast.transform.rotation;
                        }

                        GameObject guh = GameObject.Instantiate(MyBlast, nai.cc.transform.position + nai.cc.transform.forward, rot);
                        if (!nai.altVersion)
                        {
                            guh.ChildByName("PlayerLaunch").SetActive(!Touching);
                        }
                        Charge = 0;
                    }
                }
            }
        }
    }
}
