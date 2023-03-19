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
        public static Sprite Icon;
        public static Sprite IconGlow;
        public static GameObject HugeRocket;

        public static void LoadAssets()
        {
            Icon = Core.Assets.LoadAsset<Sprite>("Nuke.png");
            IconGlow = Core.Assets.LoadAsset<Sprite>("Nuke Glow.png");
            HugeRocket = Core.Assets.LoadAsset<GameObject>("HugeRocket.prefab");
            HugeRocket.AddComponent<HomingRocket>();

            Core.Harmony.PatchAll(typeof(TacticalNuke));
        }

        public override GameObject Create(Transform parent)
        {
            base.Create(parent);

            GameObject thing = GameObject.Instantiate(GunSetter.Instance.rocketBlue[0], parent);

            var rock = thing.GetComponent<RocketLauncher>();
            rock.variation = 4;

            var ico = thing.GetComponent<WeaponIcon>();
            ico.variationColor = 4;
            ico.glowIcon = IconGlow;
            ico.weaponIcon = Icon;

            thing.AddComponent<TacticalNukeBehaviour>();

            thing.name = "TacNuke Rocket";

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

        public class TacticalNukeBehaviour : MonoBehaviour
        {
            private GunControl gc;
            private RocketLauncher rock;
            public static float WindUp = 0;
            public static float MaxWind = 4;
            float Target = 0;

            public void Start()
            {
                gc = GunControl.Instance;
                WindUp = 0;
            }

            public void Update()
            {
                if (rock == null)
                {
                    rock = GetComponent<RocketLauncher>();
                }

                Target = Mathf.MoveTowards(Target, WindUp / MaxWind, Time.deltaTime * 5);
                rock.timerArm.localRotation = Quaternion.Euler(0f, 0f, Mathf.Lerp(360f, 0f, Target));
                rock.timerMeter.fillAmount = Target;

                if (WindUp == MaxWind && InputManager.Instance.InputSource.Fire2.WasPerformedThisFrame && gc.activated)
                {
                    var old = rock.rocket;
                    rock.rocket = HugeRocket;
                    rock.Shoot();
                    rock.rocket = old;
                    WindUp = 0;
                }
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
                }
            }
        }
    }
}
