using Atlas.Modules.Guns;
using HarmonyLib;
using UnityEngine;
using UnityEngine.UI;

namespace WafflesWeapons.Weapons
{
    public class Sticky : Gun
    {
        public static GameObject StickyShotgun;

        public static void LoadAssets()
        {
            StickyShotgun = Core.Assets.LoadAsset<GameObject>("Shotgun Sticky.prefab");

            Core.Harmony.PatchAll(typeof(Sticky));
        }

        public override GameObject Create(Transform parent)
        {
            base.Create(parent);
            StickyBehaviour.Charges = 0;

            GameObject thing = GameObject.Instantiate(StickyShotgun, parent);
            OrderInSlot = GunSetter.Instance.CheckWeaponOrder("sho")[3];
            StyleHUD.Instance.weaponFreshness.Add(thing, 10);

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
        public static bool Patch_Col(Projectile __instance, Collider other)
        {
            _other = other;
            if (__instance.bulletType == "silly_sticky")
            {
                if (!__instance.boosted)
                {
                    return !(other.gameObject.layer == 8 || other.gameObject.layer == 24);
                }
            }
            return true;
        }

        [HarmonyPatch(typeof(Projectile), nameof(Projectile.Explode))]
        [HarmonyPrefix]
        public static bool Patch_Explosion(Projectile __instance)
        {
            if(__instance.bulletType == "silly_sticky")
            {
                if (!__instance.GetComponent<StickyBombBehaviour>().Frozen)
                {
                    if (_other.GetComponent<EnemyIdentifierIdentifier>() != null)
                    {
                        StyleCalculator.Instance.AddPoints(150, "<color=cyan>KABLOOIE</color>", _other.GetComponent<EnemyIdentifierIdentifier>().eid, __instance.sourceWeapon);
                    }

                    return (_other.gameObject.CompareTag("Head") || _other.gameObject.CompareTag("Body") || _other.gameObject.CompareTag("Limb") ||
                        _other.gameObject.CompareTag("EndLimb")) && !_other.gameObject.CompareTag("Armor");
                }
                else
                {
                    __instance.CreateExplosionEffect();
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
    }

    public class StickyBehaviour : MonoBehaviour
    {
        private GameObject og;
        private Shotgun sho;
        [HideInInspector] public bool fromGreed;
        private float cooldown = 0;
        private float detonateTime = 0;
        [HideInInspector] public static int Charges = 0;
        private const float DETONATE_AT = 0.35f;
        public GameObject StickyBomb;
        public Slider slider;
        public Slider detonateSlider;

        public void Start()
        {
            sho = GetComponent<Shotgun>();
            fromGreed = GetComponent<WeaponIdentifier>().delay != 0;

            if (GetComponent<WeaponIdentifier>().delay == 0)
            {
                og = gameObject;
            }

            detonateSlider.maxValue = DETONATE_AT;
        }

        public void FireSticky()
        {
            GameObject silly = Instantiate(StickyBomb, sho.cc.transform.position + (sho.cc.transform.forward * 0.5f), Quaternion.identity);
            Physics.IgnoreCollision(silly.GetComponent<Collider>(), NewMovement.Instance.GetComponent<Collider>());
            StickyBombBehaviour sbb = silly.GetComponent<StickyBombBehaviour>();
            sbb.myBehaviour = this;
            sho.anim.SetTrigger("PumpFire");

            silly.GetComponent<Projectile>().explosionEffect.GetComponentInChildren<Explosion>().sourceWeapon = og;
            silly.GetComponent<Projectile>().sourceWeapon = gameObject;
        }

        public void Update()
        {
            if (sho.gc.activated)
            {
                cooldown -= Time.deltaTime;

                if (Gun.OnAltFireHeld() && Charges != 0)
                {
                    detonateTime += Time.deltaTime * (Charges == 4 ? 2 : 1);

                    if (detonateTime >= DETONATE_AT)
                    {
                        detonateTime = 0;

                        if (GetComponent<WeaponIdentifier>().delay == 0)
                        {
                            cooldown = 0.5f;
                            foreach (StickyBombBehaviour sbb in FindObjectsOfType<StickyBombBehaviour>())
                            {
                                sbb.GetComponent<Projectile>().CreateExplosionEffect();
                                GameObject.Destroy(sbb.gameObject);
                            }
                        }
                    }
                } 
                else
                {
                    detonateTime -= Time.deltaTime * 2;
                }

                detonateSlider.value = detonateTime;
                detonateTime = Mathf.Clamp(detonateTime, 0, DETONATE_AT);

                if (Gun.OnAltFire())
                {
                    if (Charges < 4)
                    {
                        if (cooldown <= 0)
                        {
                            float Delay = GetComponent<WeaponIdentifier>().delay;
                            cooldown = 0.1f;
                            Invoke("FireSticky", Delay);

                            if (Delay == 0)
                            {
                                Charges++;
                            }
                        }
                    }
                }

                slider.value = (4 - (Charges));
            }
        }
    }

    public class StickyBombBehaviour : MonoBehaviour
    {
        [HideInInspector] public bool Frozen = false;
        [HideInInspector] public StickyBehaviour myBehaviour;
        public GameObject FrozenExplosion;

        public void Start()
        {
            // :3
            // it has the collider that isnt a trigger
            Physics.IgnoreCollision(NewMovement.Instance.GetComponent<Collider>(), gameObject.ChildByName(":3").GetComponent<Collider>());

            GetComponent<Rigidbody>().AddForce(CameraController.Instance.transform.forward * 12f +
               (NewMovement.Instance.ridingRocket ? MonoSingleton<NewMovement>.Instance.ridingRocket.rb.velocity : NewMovement.Instance.rb.velocity)
               + (Vector3.up * 10), ForceMode.VelocityChange);

            GetComponent<Projectile>().undeflectable = true;
            Invoke("MakeParriable", 0.25f);
        }

        public void MakeParriable()
        {
            GetComponent<Projectile>().undeflectable = false;
        }

        public void OnDisable()
        {
            Destroy(gameObject);
        }

        public void OnTriggerEnter(Collider c)
        {
            if (c.gameObject.layer == 8 || c.gameObject.layer == 24)
            {
                transform.parent = c.transform;
                Frozen = true;
                CancelInvoke("MakeParriable");
                GetComponent<Projectile>().undeflectable = true;
                GetComponent<Projectile>().enabled = false;
                GetComponent<Projectile>().explosionEffect = FrozenExplosion;
                Destroy(GetComponent<RemoveOnTime>());
                Invoke("Kinematic", 0.01f);
                Destroy(gameObject.ChildByName("ChargeEffect"));
            }

            if (Frozen)
            {
                if (c.gameObject.layer == 23)
                {
                    GetComponent<Projectile>().Explode();
                }
            }
        }

        public void Kinematic()
        {
            GetComponent<Rigidbody>().isKinematic = true;
        }

        public void OnDestroy()
        {
            if (!myBehaviour.fromGreed)
            {
                StickyBehaviour.Charges -= 1;

                if (StickyBehaviour.Charges < 0)
                {
                    StickyBehaviour.Charges = 0;
                }
            }
        }
    }
}
