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
    public class Rocket : Gun
    {
        public static Sprite Icon;
        public static Sprite IconGlow;

        public static void LoadAssets()
        {
            Icon = Core.Assets.LoadAsset<Sprite>("Thermo.png");
            IconGlow = Core.Assets.LoadAsset<Sprite>("Thermo Glow.png");

            Core.Harmony.PatchAll(typeof(Rocket));
        }

        public override GameObject Create()
        {
            base.Create();

            GameObject thing = GameObject.Instantiate(GunSetter.Instance.rocketBlue[0]);

            var rock = thing.GetComponent<RocketLauncher>();
            rock.variation = 4;

            var ico = thing.GetComponent<WeaponIcon>();
            ico.variationColor = 4;
            ico.glowIcon = IconGlow;
            ico.weaponIcon = Icon;

            thing.AddComponent<RocketBehaviour>();

            thing.name = "Temp Rocket";

            return thing;
        }

        public override int Slot()
        {
            return 4;
        }

        public override string Pref()
        {
            return "sho1";
        }

        public class RocketBehaviour : MonoBehaviour
        {
            private GunControl gc;
            private RocketLauncher rock;

            public void Start()
            {
                transform.localPosition = GunSetter.Instance.rocketBlue[0].transform.position;
                typeof(WeaponPos).GetField("ready", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(transform.GetComponent<WeaponPos>(), false);
                GetComponent<WeaponPos>().CheckPosition();

                gc = GetComponentInParent<GunControl>();
            }

            public void Update()
            {
                if (rock == null)
                {
                    rock = GetComponent<RocketLauncher>();
                }
            }
        }
    }
}
