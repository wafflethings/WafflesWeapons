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
            }
            else
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
    }

    public class AirblastBehaviour : GunBehaviour<AirblastBehaviour>
    {
        private GameObject MyBlast;
        private Nailgun nail;
        [HideInInspector] public float Charge;
        [HideInInspector] public float ChargeLength;
        public GameObject sawbladeAirblast;
        public GameObject nailgunAirblast;
        public Slider chargeSlider;
        public Slider holdLengthSlider;
        private float fireRate = 0;

        public void Start()
        {
            nail = GetComponent<Nailgun>();
            fireRate = nail.fireRate;
        }

        public void Update()
        {
            if (ULTRAKILL.Cheats.NoWeaponCooldown.NoCooldown)
            {
                Charge = 1;
            }

            if (nail.gc.activated)
            {
                nail.fireRate = fireRate;
                DoCharge();

                nail.heatSlider = null;
                chargeSlider.value = Charge;
                holdLengthSlider.value = ChargeLength;

                if (Charge >= 0.1f && Gun.OnAltFireHeld())
                {
                    ChargeLength = Mathf.MoveTowards(ChargeLength, Charge, Time.deltaTime);
                }

                if (Gun.OnAltFireReleased() && Charge >= 0.1f)
                {
                    if (ChargeLength < 0.1f)
                    {
                        ChargeLength = 0.1f;
                    }

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
                        guh.ChildByName("PlayerLaunch").SetActive(!NewMovement.Instance.gc.touchingGround);

                        foreach (Explosion ex in guh.GetComponentsInChildren<Explosion>(true))
                        {
                            ex.maxSize *= ChargeLength;
                            ex.speed *= ChargeLength;
                        }

                        guh.GetComponentInChildren<ScaleNFade>().scaleSpeed *= ChargeLength;
                    }
                    else
                    {
                        guh.transform.localScale = new Vector3(ChargeLength, 15, ChargeLength);
                    }

                    Charge -= ChargeLength;
                    ChargeLength = 0;
                }
            }
        }

        public void OnEnable()
        {
            Charge = WaffleWeaponCharges.Instance.AirblastCharge;
        }

        public void OnDisable()
        {
             WaffleWeaponCharges.Instance.AirblastCharge = Charge;
        }

        public void DoCharge()
        {
            Charge = Mathf.MoveTowards(Charge, 1, Time.deltaTime * (NewMovement.Instance.gc.touchingGround ? 0.1f : 0.05f));
            if (Gun.OnFireHeld())
            {
                Charge = Mathf.MoveTowards(Charge, 1, Time.deltaTime * (NewMovement.Instance.gc.touchingGround ? 0.4f : 0.25f));
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

    public class AirblastBall : MonoBehaviour
    {
        public float speed;

        public void Update()
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
    }
}