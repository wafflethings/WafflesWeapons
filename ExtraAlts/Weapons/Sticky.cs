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
    public class Sticky : Gun
    {
        public static Sprite Icon;
        public static Sprite IconGlow;
        public static GameObject StickyBomb;

        public static void LoadAssets()
        {
            Icon = Core.Assets.LoadAsset<Sprite>("Sticky Ico.png");
            IconGlow = Core.Assets.LoadAsset<Sprite>("Sticky Ico Glow.png");
            StickyBomb = Core.Assets.LoadAsset<GameObject>("Sticky.prefab");

            Core.Harmony.PatchAll(typeof(Sticky));
        }

        public override GameObject Create()
        {
            base.Create();

            GameObject thing = GameObject.Instantiate(GunSetter.Instance.shotgunGrenade[0]);
            StickyBehaviour.Charges = 0;

            var sho = thing.GetComponent<Shotgun>();
            sho.variation = 4;

            var ico = thing.GetComponent<WeaponIcon>();
            ico.variationColor = 4;
            ico.glowIcon = IconGlow;
            ico.weaponIcon = Icon;

            thing.AddComponent<StickyBehaviour>();

            thing.name = "Sticky Shotgun";

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

        public static Collider _other;

        [HarmonyPatch(typeof(Projectile), nameof(Projectile.Collided))]
        [HarmonyPrefix]
        public static void Patch_Col(Projectile __instance, Collider other)
        {
            _other = other;
        }

        [HarmonyPatch(typeof(Projectile), nameof(Projectile.Explode))]
        [HarmonyPrefix]
        public static bool Patch_Explosion(Projectile __instance)
        {
            if(__instance.bulletType == "silly_sticky")
            {
                if (!__instance.GetComponent<StickyBehaviour.StickyBombBehaviour>().Frozen)
                {
                    return (_other.gameObject.CompareTag("Head") || _other.gameObject.CompareTag("Body") || _other.gameObject.CompareTag("Limb") ||
                        _other.gameObject.CompareTag("EndLimb")) && !_other.gameObject.CompareTag("Armor");
                } else
                {
                    Debug.Log("frozen sticky hit w layer " + _other.gameObject.layer);
                    __instance.Invoke("CreateExplosionEffect", 0);
                    GameObject.Destroy(__instance.gameObject);
                    return false;
                }
            }
            return true;
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
            StickyBehaviour.Charges = 0;
        }

        public class StickyBehaviour : MonoBehaviour
        {
            private GunControl gc;
            private CameraController cc;
            private Shotgun sho;
            private Slider slider;
            private Image fill;

            public static int Charges = 0;

            public void Start()
            {
                transform.localPosition = GunSetter.Instance.shotgunGrenade[0].transform.position;
                typeof(WeaponPos).GetField("ready", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(transform.GetComponent<WeaponPos>(), false);
                GetComponent<WeaponPos>().CheckPosition();

                gc = GetComponentInParent<GunControl>();
                fill = GetComponentInChildren<Slider>().fillRect.GetComponent<Image>();
                slider = GetComponentInChildren<Slider>();
                fill.color = ColorBlindSettings.Instance.variationColors[4];
                cc = CameraController.Instance;
            }

            public void Update()
            {
                if(Charges < 4 && InputManager.Instance.InputSource.Fire2.WasPerformedThisFrame && gc.activated) 
                {
                    GameObject silly = Instantiate(StickyBomb, cc.transform.position + (cc.transform.forward * 0.5f), Quaternion.identity);
                    Physics.IgnoreCollision(silly.GetComponent<Collider>(), NewMovement.Instance.GetComponent<Collider>());
                    silly.AddComponent<StickyBombBehaviour>();
                }

                slider.value = 20 * (4 - (Charges + 1));
                if (20 * (4 - (Charges + 1)) != -20)
                {
                    slider.gameObject.SetActive(true);
                } else
                {
                    slider.gameObject.SetActive(false);
                }
            }

            public class StickyBombBehaviour : MonoBehaviour
            {
                public bool Frozen = false;

                public void Start()
                {
                    Debug.Log("sticky spawn");

                    GetComponent<Rigidbody>().AddForce(CameraController.Instance.transform.forward * 12f + 
                       (NewMovement.Instance.ridingRocket ? MonoSingleton<NewMovement>.Instance.ridingRocket.rb.velocity : NewMovement.Instance.rb.velocity) 
                       + (Vector3.up * 10), ForceMode.VelocityChange);

                    Charges += 1;
                    GetComponent<Projectile>().undeflectable = true;
                    Invoke("MakeParriable", 0.25f);
                    DestroyTime(5);
                }

                public void Update()
                {
                    if (Frozen)
                    {
                        if (Vector3.Distance(gameObject.transform.position, NewMovement.Instance.transform.position) < 3)
                        {
                            GetComponent<Projectile>().Explode();
                        }
                    }
                }

                public void MakeParriable()
                {
                    GetComponent<Projectile>().undeflectable = false;
                }

                public void DestroyTime(float t)
                {
                    CancelInvoke("Destroy");
                    CancelInvoke("DestroyMine");
                    Invoke("DestroyMine", t);
                }

                public void DestroyMine()
                {
                    Destroy(gameObject);
                }

                public void OnDisable()
                {
                    DestroyMine();
                }

                public void OnTriggerEnter(Collider c)
                {
                    if(c.gameObject.layer == 8 || c.gameObject.layer == 24)
                    {
                        Frozen = true;
                        CancelInvoke("MakeParriable");
                        GetComponent<Projectile>().undeflectable = true;
                        GetComponent<Rigidbody>().isKinematic = true;
                        Destroy(GetComponent<RemoveOnTime>());
                        DestroyTime(15);

                        Destroy(gameObject.ChildByName("ChargeEffect"));
                    }

                    if(Frozen)
                    {
                        Debug.Log($"just trig {c.gameObject.name}, layer {c.gameObject.layer}");

                        if(c.gameObject.layer == 23 || (c.gameObject.CompareTag("Head") || c.gameObject.CompareTag("Body") || c.gameObject.CompareTag("Limb") ||
                        c.gameObject.CompareTag("EndLimb")) && !c.gameObject.CompareTag("Armor"))
                        {
                            GetComponent<Projectile>().Explode();
                        }
                    }
                }

                public void OnCollisionEnter(Collision c)
                {
                    Debug.Log($"just col {c.gameObject.name}, layer {c.gameObject.layer}");
                }

                public void OnDestroy()
                {
                    Charges -= 1;
                }
            }
        }
    }
}
