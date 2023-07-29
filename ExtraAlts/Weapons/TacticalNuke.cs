using Atlas.Modules.Guns;
using HarmonyLib;
using UnityEngine;

namespace WafflesWeapons.Weapons
{
    public class TacticalNuke : Gun
    {
        public static GameObject NukeRl;

        public static void LoadAssets()
        {
            NukeRl = Core.Assets.LoadAsset<GameObject>("Rocket Launcher SLF.prefab");
            Core.Harmony.PatchAll(typeof(TacticalNuke));
        }

        public override GameObject Create(Transform parent)
        {
            base.Create(parent);

            GameObject thing = GameObject.Instantiate(NukeRl, parent);
            OrderInSlot = GunSetter.Instance.CheckWeaponOrder("rock")[3];
            StyleHUD.Instance.weaponFreshness.Add(thing, 10);

            return thing;
        }

        public override int Slot()
        {
            return 4;
        }

        public override string Pref()
        {
            return "rock4";
        }

        [HarmonyPatch(typeof(Grenade), nameof(Grenade.Explode))]
        [HarmonyPostfix]
        public static void IncreaseIfBig(Grenade __instance, bool harmless, bool super = false, GameObject exploderWeapon = null)
        {
            if (!harmless && __instance.rocket && exploderWeapon == null && __instance.GetComponent<HomingRocket>()) //null is if it is exploded by an enemy
            {
                float change = 0;
                if (super)
                {
                    change += 2f;
                }
                else
                {
                    change += 1f;
                }

                foreach (TacticalNukeBehaviour tnb in TacticalNukeBehaviour.Instances)
                {
                    tnb.WindUp += change;
                }

                WaffleWeaponCharges.Instance.SLFCharge += change;
            }
        }
    }

    public class TacticalNukeBehaviour : GunBehaviour<TacticalNukeBehaviour>
    {
        private GunControl gc;
        private RocketLauncher rock;
        [HideInInspector] public float WindUp = 0;
        [HideInInspector] public static float MaxWind = 4;
        float Target = 0;
        public GameObject HugeRocket;
        public AudioSource ChargeUp;
        private float HeldTime;

        public void Start()
        {
            gc = GunControl.Instance;
            rock = GetComponent<RocketLauncher>();
        }

        public void Update()
        {
            if (ULTRAKILL.Cheats.NoWeaponCooldown.NoCooldown)
            {
                WindUp = MaxWind;
            }

            if (WindUp > MaxWind)
            {
                WindUp = MaxWind;
            }

            Target = Mathf.MoveTowards(Target, WindUp / MaxWind, Time.deltaTime * 5);
            rock.timerArm.localRotation = Quaternion.Euler(0f, 0f, Mathf.Lerp(360f, 0f, Target - HeldTime / MaxWind));
            rock.timerMeter.fillAmount = Target - HeldTime / MaxWind;

            if (gc.activated)
            {
                if (Gun.OnAltFireReleased())
                {
                    if ((int)HeldTime >= 1)
                    {
                        rock.anim.speed *= 10;
                        for (int i = 0; i < 2 * (int)HeldTime; i++)
                        {
                            Invoke("Shoot", rock.wid.delay + (i * 0.15f));
                        }
                        rock.anim.speed /= 10;
                        WindUp -= (int)HeldTime;
                    }
                }

                if (Gun.OnAltFireHeld())
                {
                    HeldTime = Mathf.MoveTowards(HeldTime, WindUp, Time.deltaTime * MaxWind);
                }
                else
                {
                    HeldTime = Mathf.MoveTowards(HeldTime, 0, Time.deltaTime * MaxWind * 2);
                }
            }
        }

        public void OnEnable()
        {
            WindUp = WaffleWeaponCharges.Instance.SLFCharge;
        }

        public void OnDisable()
        {
            WaffleWeaponCharges.Instance.SLFCharge = WindUp;
        }

        public void Shoot()
        {
            var old = rock.rocket;
            rock.rocket = HugeRocket;
            rock.Shoot();
            rock.rocket = old;
        }
    }

    public class HomingRocket : MonoBehaviour
    {
        private LayerMask enemyLayerMask;
        private LayerMask pierceLayerMask;
        private LayerMask ignoreEnemyTrigger;
        public void Start()
        {
            enemyLayerMask |= 1024;
            enemyLayerMask |= 2048;
            pierceLayerMask |= 256;
            pierceLayerMask |= 16777216;
            pierceLayerMask |= 67108864;

            ignoreEnemyTrigger = enemyLayerMask | pierceLayerMask;
        }

        public void Update()
        {
            if (GunControl.Instance.activated)
            {
                RaycastHit hit;
                Quaternion oldRot = transform.rotation;
                Quaternion newRot;

                if (Physics.Raycast(CameraController.Instance.transform.position, CameraController.Instance.transform.forward, out hit, float.PositiveInfinity, ignoreEnemyTrigger))
                {
                    transform.LookAt(hit.point);
                    newRot = transform.rotation;
                }
                else
                {
                    transform.LookAt(CameraController.Instance.transform.forward * 10000);
                    newRot = transform.rotation;
                }

                transform.rotation = Quaternion.RotateTowards(oldRot, newRot, Time.deltaTime * 720);
            }
        }
    }
}
