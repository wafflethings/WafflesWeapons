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
    public class Thermo : Gun
    {
        public static Sprite Icon;
        public static Sprite IconGlow;
        public static GameObject HotBullet;
        public static GameObject ColdBullet;
        public static GameObject Click;
        public static Texture2D Thermometer;

        public static void LoadAssets()
        {
            Icon = Core.Assets.LoadAsset<Sprite>("Thermo.png");
            IconGlow = Core.Assets.LoadAsset<Sprite>("Thermo Glow.png");
            HotBullet = Core.Assets.LoadAsset<GameObject>("HotShot.prefab");
            ColdBullet = Core.Assets.LoadAsset<GameObject>("ColdShot.prefab");
            Click = Core.Assets.LoadAsset<GameObject>("SwapClick.prefab");
            Thermometer = Core.Assets.LoadAsset<Texture2D>("thermometer.png");

            Core.Harmony.PatchAll(typeof(Thermo));
        }

        public override GameObject Create()
        {
            base.Create();

            GameObject thing = GameObject.Instantiate(GunSetter.Instance.shotgunGrenade[0]);

            var sho = thing.GetComponent<Shotgun>();
            sho.variation = 4;
            sho.bullet = ColdBullet;
            sho.spread *= 0.75f;
            
            foreach(GameObject imgs in thing.GetComponentInChildren<Slider>().transform.parent.gameObject.ChildrenList())
            {
                if(imgs.name.Contains("Image"))
                {
                    imgs.SetActive(false);
                }
            }

            var ico = thing.GetComponent<WeaponIcon>();
            ico.variationColor = 4;
            ico.glowIcon = IconGlow;
            ico.weaponIcon = Icon;

            thing.AddComponent<ThermoBehaviour>();

            thing.name = "Thermo Shotgun";

            return thing;
        }

        public override int Slot()
        {
            return 1;
        }

        public override string Pref()
        {
            return "sho3";
        }

        [HarmonyPatch(typeof(EnemyIdentifier), nameof(EnemyIdentifier.Start))]
        [HarmonyPostfix]
        public static void AddThermoChecker(EnemyIdentifier __instance)
        {
            __instance.gameObject.AddComponent<ThermoBehaviour.ThermoTracker>();
        }


        [HarmonyPatch(typeof(EnemyIdentifier), nameof(EnemyIdentifier.DeliverDamage))]
        [HarmonyPostfix]
        public static void DoTemp(EnemyIdentifier __instance, GameObject target, Vector3 force, Vector3 hitPoint, float multiplier, bool tryForExplode, float critMultiplier = 0f, GameObject sourceWeapon = null)
        {
            var tt = __instance.gameObject.GetComponent<ThermoBehaviour.ThermoTracker>();
            // This way is really fucking bad and I will probably change it.
            // 0.225 cold  0.275 hot
            if (sourceWeapon.gameObject.name.Contains("Thermo Shotgun"))
            {
                if (multiplier == 0.275f)
                {
                    tt.ChangeHeat(0.1f);
                } else
                {
                    Debug.Log(multiplier + " gun?");
                    tt.ChangeHeat(-0.1f);
                }

                if (tt.Heat > 1 || tt.Heat < -1)
                {
                    __instance.SpeedBuff(1 + (tt.Heat / 30));
                    __instance.DamageBuff(1 - (tt.Heat / 30));
                }
                else
                {
                    __instance.SpeedUnbuff();
                    __instance.DamageUnbuff();
                }
            }
        }

        public class ThermoBehaviour : MonoBehaviour
        {
            private GunControl gc;
            private bool IsCold = true;
            private Shotgun sho;
            private Color col = new Color(0, 0.55f, 1);
            private Slider slider;
            private float temp = 0;
            private Image fill;
            private float TimeSinceSwap = 1.25f;

            public void Start()
            {
                transform.localPosition = GunSetter.Instance.shotgunGrenade[0].transform.position;
                typeof(WeaponPos).GetField("ready", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(transform.GetComponent<WeaponPos>(), false);
                GetComponent<WeaponPos>().CheckPosition();

                gc = GetComponentInParent<GunControl>();
                fill = GetComponentInChildren<Slider>().fillRect.GetComponent<Image>();
                slider = GetComponentInChildren<Slider>();
            }

            public void Update()
            {
                if(sho == null)
                {
                    sho = GetComponent<Shotgun>();
                }

                if(gc.activated && OnAltFire() && (bool)sho.GetPrivateField("gunReady") && TimeSinceSwap > 1.25f)
                {
                    Instantiate(Click);
                    IsCold = !IsCold;

                    if (IsCold)
                    { 
                        sho.bullet = ColdBullet;
                        col = new Color(0.55f, 0.87f, 1);
                        temp = 0;
                    }
                    else
                    {
                        sho.bullet = HotBullet;
                        col = new Color(1, 0.27f, 0);
                        temp = 50;
                    }
                }

                if(gc.activated)
                {
                    TimeSinceSwap += Time.deltaTime;
                }

                slider.value = Mathf.Lerp(slider.value, temp, Time.deltaTime * 5);
                fill.color = Color.Lerp(fill.color, col, Time.deltaTime * 5);
            }

            public class ThermoTracker : MonoBehaviour
            {
                public float Heat { get; private set; }
                private const float Max = 10;

                public void HandleProjectile(GameObject obj)
                {
                    string type = obj.GetComponent<Projectile>().bulletType;

                    if (type == "shotgun.cold")
                    {
                        ChangeHeat(-0.1f);
                    } else if (type == "shotgun.hot")
                    {
                        ChangeHeat(0.1f);
                    }
                }

                public void ChangeHeat(float f)
                {
                    Heat += f;

                    if (Heat > Max)
                        Heat = Max;

                    if (Heat < -Max)
                        Heat = -Max;
                }
            }
        }
    }
}
