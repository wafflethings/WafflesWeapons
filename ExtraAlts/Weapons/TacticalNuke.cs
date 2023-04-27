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
        public static void IncreaseIfBig(Grenade __instance, bool harmless, bool super = false)
        {

            if (!harmless && __instance.sourceWeapon.GetComponent<RocketLauncher>() != null)
            {
                if (super)
                {
                    TacticalNukeBehaviour.WindUp += 2f;
                }
                else
                {
                    TacticalNukeBehaviour.WindUp += 1f;
                }

                if (TacticalNukeBehaviour.WindUp > TacticalNukeBehaviour.MaxWind)
                {
                    TacticalNukeBehaviour.WindUp = TacticalNukeBehaviour.MaxWind;
                }
            }
        }

        [HarmonyPatch(typeof(WeaponCharges), nameof(WeaponCharges.MaxCharges))]
        [HarmonyPostfix]
        public static void MaxCharge()
        {
            TacticalNukeBehaviour.WindUp = 4;
        }

        
    }

    public class TacticalNukeBehaviour : MonoBehaviour
    {
        private GunControl gc;
        private RocketLauncher rock;
        [HideInInspector] public static float WindUp = 0;
        [HideInInspector] public static float MaxWind = 4;
        float Target = 0;
        public GameObject HugeRocket;

        public void Start()
        {
            gc = GunControl.Instance;
            rock = GetComponent<RocketLauncher>();
            WindUp = 0;
        }

        public void Update()
        {
            Target = Mathf.MoveTowards(Target, WindUp / MaxWind, Time.deltaTime * 5);
            rock.timerArm.localRotation = Quaternion.Euler(0f, 0f, Mathf.Lerp(360f, 0f, Target));
            rock.timerMeter.fillAmount = Target;

            if (WindUp == MaxWind && Gun.OnAltFire() && gc.activated)
            {
                foreach (TacticalNukeBehaviour tnb in FindObjectsOfType<TacticalNukeBehaviour>())
                {
                    tnb.Invoke("Shoot", tnb.GetComponent<WeaponIdentifier>().delay);

                    WindUp = 0;
                }
            }
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

                if (Physics.Raycast(CameraController.Instance.transform.position, CameraController.Instance.transform.forward, out hit, float.PositiveInfinity, ignoreEnemyTrigger))
                {
                    transform.LookAt(hit.point);
                }
                else
                {
                    transform.LookAt(CameraController.Instance.transform.forward * 10000);
                }
            }
        }
    }
}
