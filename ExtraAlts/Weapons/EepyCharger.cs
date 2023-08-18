using Atlas.Modules.Guns;
using HarmonyLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using UnityEngine;
using WafflesWeapons.Components;

namespace WafflesWeapons.Weapons
{
    public class EepyCharger : Gun
    {
        public static GameObject EepyRl;

        static EepyCharger()
        {
            EepyRl = Core.Assets.LoadAsset<GameObject>("Rocket Launcher Eepy.prefab");
            Core.Harmony.PatchAll(typeof(EepyCharger));
        }

        public override GameObject Create(Transform parent)
        {
            base.Create(parent);

            GameObject thing = GameObject.Instantiate(EepyRl, parent);
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

        [HarmonyPatch(typeof(Grenade), nameof(Grenade.Explode)), HarmonyPostfix]
        public static void IncreaseIfBig(Grenade __instance, bool harmless, bool super = false, GameObject exploderWeapon = null)
        {
            if (!harmless && __instance.rocket && exploderWeapon == null && !__instance.GetComponent<HomingRocket>()) //null is if it is exploded by an enemy
            {
                float change = super ? 2 : 1;

                foreach (EepyChargerBehaviour epc in EepyChargerBehaviour.Instances)
                {
                    epc.WindUp += change / EepyChargerBehaviour.ChargeDivide;
                }

                WaffleWeaponCharges.Instance.EepyCharge += change;
            }
        }

        [HarmonyPatch(typeof(Grenade), nameof(Grenade.Collision)), HarmonyPrefix]
        public static bool MakeEepyIgnore(Grenade __instance, Collider other)
        {
            if (!other.TryGetComponent(out EnemyIdentifierIdentifier eidid))
            {
                return true;
            }

            if (__instance.GetComponent<EepyRocket>() != null)
            {
                __instance.StartCoroutine(IgnoreThenUnignore(__instance, other));
                bool had = EnemyHitTracker.CheckAndHit(__instance.gameObject, eidid.eid, 0.5f);
                Debug.Log(had);
                return had;
            }

            return true;
        }

        public static IEnumerator IgnoreThenUnignore(Grenade gren, Collider col)
        {
            Physics.IgnoreCollision(gren.GetComponent<Collider>(), col);
            yield return new WaitForSeconds(0.5f);
            Physics.IgnoreCollision(gren.GetComponent<Collider>(), col, false);
        }

        private static MethodInfo m_Object_Destroy = typeof(UnityEngine.Object).GetMethod(nameof(UnityEngine.Object.Destroy), new Type[] { typeof(UnityEngine.Object) } );
        private static MethodInfo m_EepyCharger_DestroyCheck = typeof(EepyCharger).GetMethod(nameof(DestroyCheck));

        [HarmonyPatch(typeof(Grenade), nameof(Grenade.Explode)), HarmonyTranspiler]
        public static IEnumerable<CodeInstruction> DontDestroyIfEepy(IEnumerable<CodeInstruction> instructions)
        {
            foreach (CodeInstruction instruction in instructions)
            {
                if (instruction.OperandIs(m_Object_Destroy))
                {
                    yield return new CodeInstruction(OpCodes.Pop);
                    yield return new CodeInstruction(OpCodes.Ldarg_0);
                    yield return new CodeInstruction(OpCodes.Ldarg_2);
                    instruction.opcode = OpCodes.Call;
                    instruction.operand = m_EepyCharger_DestroyCheck;
                }

                yield return instruction;
            }
        }

        public static void DestroyCheck(Grenade grenade, bool harmless)
        {
            if (!grenade.GetComponent<EepyRocket>())
            {
                UnityEngine.Object.Destroy(grenade.gameObject);
                return;
            }

            if (harmless)
            {
                UnityEngine.Object.Destroy(grenade.gameObject);
                return;
            }

            grenade.exploded = false;
        }

        private static MethodInfo m_EepyCharger_ScaleRocket = typeof(EepyCharger).GetMethod(nameof(ScaleRocket));

        [HarmonyPatch(typeof(RocketLauncher), nameof(RocketLauncher.Shoot)), HarmonyTranspiler]
        public static IEnumerable<CodeInstruction> ScaleEepyRockets(IEnumerable<CodeInstruction> instructions)
        {
            List<CodeInstruction> list = instructions.ToList();
            list.RemoveAt(list.Count - 1); //remove ret
            list.Add(new CodeInstruction(OpCodes.Ldarg_0)); // the launcher
            list.Add(new CodeInstruction(OpCodes.Ldloc_0)); // the rocket
            list.Add(new CodeInstruction(OpCodes.Call, m_EepyCharger_ScaleRocket));
            list.Add(new CodeInstruction(OpCodes.Ret)); // add the ret back

            return list;
        }

        public static void ScaleRocket(RocketLauncher launcher, GameObject rocket)
        {
            if (launcher.GetComponent<EepyChargerBehaviour>() != null)
            {
                rocket.GetComponent<EepyRocket>().Charge = EepyChargerBehaviour.PreviousHeldTime;
                rocket.transform.localScale *= 0.25f + (rocket.GetComponent<EepyRocket>().Charge * 0.75f);
            }
        }

        private static MethodInfo m_EepyCharger_AffectExplosion = typeof(EepyCharger).GetMethod(nameof(AffectExplosion));

        [HarmonyPatch(typeof(Grenade), nameof(Grenade.Explode)), HarmonyTranspiler]
        public static IEnumerable<CodeInstruction> ChangeExplosionByCharge(IEnumerable<CodeInstruction> instructions)
        {
            List<CodeInstruction> list = instructions.ToList();
            list.RemoveAt(list.Count - 1); //remove ret
            list.Add(new CodeInstruction(OpCodes.Ldarg_0));
            list.Add(new CodeInstruction(OpCodes.Ldloc_0)); // the explosion
            list.Add(new CodeInstruction(OpCodes.Call, m_EepyCharger_AffectExplosion));
            list.Add(new CodeInstruction(OpCodes.Ret)); // add the ret back

            foreach (CodeInstruction inst in list)
            {
                Debug.Log(inst);
            }

            return list;
        }

        public static void AffectExplosion(Grenade grenade, GameObject explosion)
        {
            if (grenade.TryGetComponent(out EepyRocket eepy))
            {
                explosion.transform.localScale *= 0.25f + (eepy.Charge * 0.75f);
                Explosion explo = explosion.GetComponentsInChildren<Explosion>().Where(x => x.damage > 0).First();
                explo.damage = (int)(explo.damage * (0.25f + (eepy.Charge * 0.75f)));
            }
        }
    }

    public class EepyChargerBehaviour : GunBehaviour<EepyChargerBehaviour>
    {
        public static float PreviousHeldTime;
        public static float ChargeDivide = 4;
        [HideInInspector] public float WindUp = 0;
        public GameObject HugeRocket;
        public AudioSource ChargeUp;
        private GunControl gc;
        private RocketLauncher rock;
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
                WindUp = 1;
            }

            WindUp = Mathf.Clamp(WindUp, 0, 1);

            rock.timerMeter.fillAmount = WindUp - HeldTime;
            rock.timerArm.localRotation = Quaternion.Euler(0f, 0f, 360 * (WindUp - HeldTime));

            if (gc.activated)
            {
                if (Gun.OnAltFireReleased() && HeldTime > 0.125f)
                {
                    StartCoroutine(Shoot(HeldTime, rock.wid.delay));
                    WindUp -= HeldTime;
                }

                if (Gun.OnAltFireHeld())
                {
                    HeldTime = Mathf.MoveTowards(HeldTime, WindUp, Time.deltaTime);
                    
                }
                else
                {
                    HeldTime = Mathf.MoveTowards(HeldTime, 0, Time.deltaTime * 2);
                }
            }
        }

        public void OnEnable()
        {
            WindUp = WaffleWeaponCharges.Instance.EepyCharge;
        }

        public void OnDisable()
        {
            WaffleWeaponCharges.Instance.EepyCharge = WindUp;
        }

        public IEnumerator Shoot(float heldTime, float time)
        {
            yield return new WaitForSeconds(time);

            Grenade hugeGrenade = HugeRocket.GetComponent<Grenade>();
            float startSpeed = hugeGrenade.rocketSpeed;
            GameObject old = rock.rocket;

            rock.rocket = HugeRocket;
            hugeGrenade.rocketSpeed = 25f + heldTime * (hugeGrenade.rocketSpeed);
            PreviousHeldTime = heldTime;
            rock.Shoot();

            hugeGrenade.rocketSpeed = startSpeed;
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
                Quaternion oldRot = transform.rotation;
                Quaternion newRot;

                if (Physics.Raycast(CameraController.Instance.transform.position, CameraController.Instance.transform.forward, out RaycastHit hit, float.PositiveInfinity, ignoreEnemyTrigger))
                {
                    transform.LookAt(hit.point);
                    newRot = transform.rotation;
                }
                else
                {
                    transform.LookAt(CameraController.Instance.transform.forward * 10000);
                    newRot = transform.rotation;
                }

                transform.rotation = Quaternion.RotateTowards(oldRot, newRot, Time.deltaTime * 360 * 4);
            }
        }
    }

    public class EepyRocket : MonoBehaviour
    {
        [HideInInspector] public float Charge;
    }
}
