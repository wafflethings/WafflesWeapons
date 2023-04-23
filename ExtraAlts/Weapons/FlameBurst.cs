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

namespace WafflesWeapons.Weapons
{
    public class FlameBurst : Gun
    {
        public static Sprite Icon;
        public static Sprite IconGlow;
        public static GameObject Burst;
        public static GameObject BurstVis;

        public static void LoadAssets()
        {
            Icon = Core.Assets.LoadAsset<Sprite>("Flame.png");
            IconGlow = Core.Assets.LoadAsset<Sprite>("Flame Glow.png");
            Burst = Core.Assets.LoadAsset<GameObject>("FireBurst.prefab");
            BurstVis = Core.Assets.LoadAsset<GameObject>("FireBurst Visual.prefab");

            Burst.ChildByName("Cube").AddComponent<FlameBurstBehaviour.ProjectileDestroyer>();

            Core.Harmony.PatchAll(typeof(FlameBurst));
        }

        public override GameObject Create(Transform parent)
        {
            base.Create(parent);

            GameObject thing = GameObject.Instantiate(GunSetter.Instance.shotgunGrenade[0], parent);

            var sho = thing.GetComponent<Shotgun>();
            sho.variation = 5;

            var ico = thing.GetComponent<WeaponIcon>();
            ico.variationColor = 5;
            ico.glowIcon = IconGlow;
            ico.weaponIcon = Icon;

            foreach (GameObject imgs in thing.GetComponentInChildren<Slider>().transform.parent.gameObject.ChildrenList())
            {
                if (imgs.name.Contains("Image"))
                {
                    imgs.SetActive(false);
                }
            }

            thing.AddComponent<FlameBurstBehaviour>();

            thing.name = "Flame Shotgun";

            StyleHUD.Instance.weaponFreshness.Add(thing, 10);

            return thing;
        }

        public override int Slot()
        {
            return 1;
        }

        public override string Pref()
        {
            return "sho4";
        }

        [HarmonyPatch(typeof(WeaponCharges), nameof(WeaponCharges.MaxCharges))]
        [HarmonyPostfix]
        public static void MaxCharge()
        {
            FlameBurstBehaviour.bloodGauge = FlameBurstBehaviour.maxGauge;
        }

        [HarmonyPatch(typeof(Bloodsplatter), nameof(Bloodsplatter.OnTriggerEnter))]
        [HarmonyPostfix]
        public static void ChargeGauge(Bloodsplatter __instance, Collider other)
        {
            if (__instance.ready && other.gameObject.CompareTag("Player") && NewMovement.Instance != null && NewMovement.Instance.hp >= 100 && 
                GunControl.Instance.currentWeapon.GetComponent<FlameBurstBehaviour>() != null)
            {
                FlameBurstBehaviour.bloodGauge += __instance.hpAmount;
            }
        }

        public class FlameBurstBehaviour : MonoBehaviour
        {
            private GunControl gc;
            private Shotgun sho;
            private Slider slider;
            private Image fill;

            public const float maxGauge = 400;
            public const float perSecond = 300;
            public static float bloodGauge = 0;

            private GameObject currentVis;
            private GameObject currentBurst;
            private AudioSource currentSource;

            private bool Bursting = false;

            public void Start()
            {
                gc = GunControl.Instance;
                sho = GetComponent<Shotgun>();
                fill = GetComponentInChildren<Slider>().fillRect.GetComponent<Image>();
                slider = GetComponentInChildren<Slider>();
                fill.color = ColorBlindSettings.Instance.variationColors[5];

                bloodGauge = 0;
                slider.maxValue = maxGauge;
            }

            public void Update()
            {
                slider.value = bloodGauge;

                if (OnAltFire() && bloodGauge > 0 && currentVis == null)
                {
                    Bursting = true;
                    currentVis = Instantiate(BurstVis, gameObject.transform);
                    currentVis.transform.parent = CameraController.Instance.transform;
                    currentSource = currentVis.GetComponent<AudioSource>();
                    currentBurst = Instantiate(Burst, CameraController.Instance.transform);
                }

                if (Bursting)
                {
                    bloodGauge -= perSecond * Time.deltaTime;
                    currentSource.volume = (bloodGauge / maxGauge) * 0.75f;
                    if (bloodGauge <= 0)
                    {
                        bloodGauge = 0;
                        DestroyBurst();
                    }
                }
            }

            public void OnDisable()
            {
                currentSource.Stop();
                DestroyBurst();
            }

            public void DestroyBurst() 
            {
                if (currentBurst != null && currentVis != null && Bursting)
                {
                    Bursting = false;
                    currentVis.GetComponentInChildren<ParticleSystem>().Stop();
                    Destroy(currentBurst);
                    Invoke("DestroyVis", 2f);
                } 
            }

            public void DestroyVis()
            {
                Destroy(currentVis);
            }

            public class ProjectileDestroyer : MonoBehaviour
            {
                public void OnTriggerEnter(Collider col)
                {
                    if (col.GetComponentInChildren<Projectile>() != null)
                    {
                        Projectile proj = col.GetComponentInChildren<Projectile>();

                        if (proj.explosive)
                        {
                            proj.Explode();
                        }
                        else
                        {
                            if (proj.keepTrail)
                            {
                                proj.KeepTrail();
                            }
                            proj.CreateExplosionEffect();
                            GameObject.Destroy(proj.gameObject);
                        }
                    }
                }
            }
        }
    }
}
