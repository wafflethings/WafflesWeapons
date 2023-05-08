using Atlas.Modules.Guns;
using HarmonyLib;
using UnityEngine;
using UnityEngine.UI;

namespace WafflesWeapons.Weapons
{
    public class Airblast : Gun
    {
        public static GameObject AirNail;
        public static GameObject AirSaw;

        public static void LoadAssets()
        {
            AirNail = Core.Assets.LoadAsset<GameObject>("Nailgun Airblast.prefab");
            AirSaw = Core.Assets.LoadAsset<GameObject>("Sawblade Launcher Airblast.prefab");
            Core.Harmony.PatchAll(typeof(Airblast));
        }

        public override GameObject Create(Transform parent)
        {
            base.Create(parent);

            GameObject thing;
            if (Enabled() == 2)
            {
                thing = GameObject.Instantiate(AirSaw, parent);
            } else
            {
                thing = GameObject.Instantiate(AirNail, parent);
            }

            OrderInSlot = GunSetter.Instance.CheckWeaponOrder("nai")[3];
            StyleHUD.Instance.weaponFreshness.Add(thing, 10);
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

        [HarmonyPatch(typeof(Nail), nameof(Nail.HitEnemy))]
        [HarmonyPostfix]
        public static void AddForceToAir(Nail __instance, EnemyIdentifierIdentifier eidid = null)
        {
            if (eidid != null && eidid.eid != null && !eidid.eid.dead && __instance.sourceWeapon.GetComponent<AirblastBehaviour>() != null)
            {
                var eid = eidid.eid;
                eid.GetComponent<Rigidbody>().AddForce(__instance.transform.forward * (__instance.sawblade ? -15 / __instance.hitAmount : -15f), ForceMode.VelocityChange);
            }
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
    }

    public class AirblastBehaviour : MonoBehaviour
    {
        private GameObject MyBlast;
        private Nailgun nail;
        [HideInInspector] public static float Charge;
        [HideInInspector] public static GroundCheck gcc;
        public GameObject sawbladeAirblast;
        public GameObject nailgunAirblast;
        public Slider chargeSlider;
        private float fireRate = 0;

        public void Start()
        {
            gcc = FindObjectOfType<GroundCheck>();
            nail = GetComponent<Nailgun>();
            fireRate = nail.fireRate;
        }

        public void Update()
        {
            nail.fireRate = fireRate;

            if (nail.gc.activated)
            {
                nail.heatSlider = null;
                chargeSlider.value = Charge;

                if (Charge == 1 && Gun.OnAltFire())
                {
                    if (MyBlast == null)
                    {
                        CheckBlast();
                    }

                    nail.anim.SetTrigger("Shoot");

                    Quaternion rot = nail.cc.transform.rotation;
                    if (nail.altVersion)
                    {
                        rot = MyBlast.transform.rotation;
                    }

                    GameObject guh = GameObject.Instantiate(MyBlast, nail.cc.transform.position + nail.cc.transform.forward, rot);
                    if (!nail.altVersion)
                    {
                        guh.ChildByName("PlayerLaunch").SetActive(!gcc.touchingGround);
                    }
                    Charge = 0;
                }
            }
        }

        public void CheckBlast()
        {
            if (nail.altVersion)
            {
                MyBlast = sawbladeAirblast;
            }
            else
            {
                MyBlast = nailgunAirblast;
            }
        }
    }
}
