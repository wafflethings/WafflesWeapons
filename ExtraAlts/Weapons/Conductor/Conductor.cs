using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Atlas.Modules.Guns;
using HarmonyLib;
using UnityEngine;
using WafflesWeapons.Components;

namespace WafflesWeapons.Weapons.Conductor
{
    public class Conductor : Gun
    {
        public static GameObject ConductorNail;
        public static GameObject ConductorSaw;
        public static GameObject MagnetZapEffect;
        public static GameObject FullExplosion;
        public static GameObject SawExplosion;
        public static GameObject RocketExplosion;
        public static GameObject HitProjectileExplosion;
        public static GameObject MagnetZap;

        static Conductor()
        {
            ConductorNail = Core.Assets.LoadAsset<GameObject>("Nailgun Conductor.prefab");
            ConductorSaw = Core.Assets.LoadAsset<GameObject>("Sawblade Launcher Conductor.prefab");
            MagnetZapEffect = Core.Assets.LoadAsset<GameObject>("Magnet Zap Effect.prefab");
            FullExplosion = Core.Assets.LoadAsset<GameObject>("Fully Charged Beam Explosion.prefab");
            SawExplosion = Core.Assets.LoadAsset<GameObject>("Fully Charged Saw Explosion.prefab");
            RocketExplosion = Core.Assets.LoadAsset<GameObject>("Shot Rocket Explosion.prefab");
            HitProjectileExplosion = Core.Assets.LoadAsset<GameObject>("Shot Projectile Explosion.prefab");
            MagnetZap = Core.Assets.LoadAsset<GameObject>("Magnet Zap.prefab");
            Core.Harmony.PatchAll(typeof(Conductor));
        }

        public override GameObject Create(Transform parent)
        {
            base.Create(parent);

            GameObject thing;
            if (Enabled() == 2)
            {
                thing = GameObject.Instantiate(ConductorSaw, parent);
            }
            else
            {
                thing = GameObject.Instantiate(ConductorNail, parent);
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

        [HarmonyPatch(typeof(RevolverBeam), nameof(RevolverBeam.ExecuteHits)), HarmonyPostfix]
        public static void StunHitEnemies(RevolverBeam __instance, RaycastHit currentHit)
        {
            if (__instance.sourceWeapon == null)
            {
                return;
            }

            if (currentHit.transform != null && __instance.sourceWeapon.TryGetComponent(out ConductorBehaviour c) && currentHit.transform.GetComponentInParent<EnemyIdentifierIdentifier>())
            {
                EnemyIdentifier eid = currentHit.transform.GetComponentInParent<EnemyIdentifierIdentifier>().eid;
                if (eid != null)
                {
                    Stunner.EnsureAndStun(eid, c.LastCharge * StunMult(eid));
                }
            }
        }

        [HarmonyPatch(typeof(Nail), nameof(Nail.HitEnemy)), HarmonyPostfix]
        public static void StunSaws(Nail __instance, EnemyIdentifierIdentifier eidid)
        {
            if (__instance.GetComponent<StunTag>() && EnemyHitTracker.CheckAndHit(__instance.gameObject, eidid.eid))
            {
                Stunner.EnsureAndStun(eidid.eid, (__instance.damage / 3) * StunMult(eidid.eid));

                if (__instance.sawBounceEffect == SawExplosion)
                {
                    GameObject.Instantiate(__instance.sawBounceEffect, __instance.transform.position, __instance.transform.rotation);
                }
            }
        }

        [HarmonyPatch(typeof(RevolverBeam), nameof(RevolverBeam.ExecuteHits)), HarmonyPrefix]
        public static void EditHitProjectiles(RevolverBeam __instance, RaycastHit currentHit)
        {
            if (__instance.sourceWeapon?.GetComponent<ConductorBehaviour>() == null)
            {
                return;
            }

            if (currentHit.transform != null && currentHit.transform.gameObject.layer == 14 && 
                currentHit.transform.gameObject.TryGetComponent(out Projectile projectile) && (projectile.speed != 0f || projectile.decorative))
            {
                TimeController.Instance.ParryFlash();
                projectile.transform.forward = CameraController.Instance.transform.forward;
                projectile.friendly = true;
                projectile.homingType = HomingType.None;
                projectile.explosionEffect = HitProjectileExplosion;

                if (projectile.TryGetComponent(out Rigidbody rb))
                {
                    rb.useGravity = false;
                }

                if (projectile.speed < 50)
                {
                    projectile.speed = 50;
                }
            }
        }

        [HarmonyPatch(typeof(Explosion), nameof(Explosion.Collide)), HarmonyPrefix]
        public static void StunEnemiesHitByExplosion(Explosion __instance, Collider other)
        {
            if (__instance.canHit == AffectedSubjects.PlayerOnly || __instance.GetComponent<StunTag>() == null)
            {
                return;
            }

            if (other.gameObject.layer == 10 || other.gameObject.layer == 11)
            {
                EnemyIdentifierIdentifier eidid = other.GetComponentInParent<EnemyIdentifierIdentifier>();
                if (eidid != null && eidid.eid != null && EnemyHitTracker.CheckAndHit(__instance.gameObject, eidid.eid, 0.5f))
                {
                    Stunner.EnsureAndStun(eidid.eid, 1 * StunMult(eidid.eid));
                }
            }
        }

        private static MethodInfo m_Breakable_Break = typeof(Breakable).GetMethod("Break");
        private static MethodInfo m_Conductor_BreakReplacement = typeof(Conductor).GetMethod("BreakReplacement");

        [HarmonyPatch(typeof(RevolverBeam), nameof(RevolverBeam.PiercingShotCheck)), HarmonyTranspiler]
        public static IEnumerable<CodeInstruction> ReplaceBreak(IEnumerable<CodeInstruction> instructions)
        {
            foreach (CodeInstruction instruction in instructions)
            {
                if (instruction.opcode == OpCodes.Callvirt && instruction.OperandIs(m_Breakable_Break))
                {
                    yield return new CodeInstruction(OpCodes.Ldarg_0);
                    yield return new CodeInstruction(OpCodes.Call, m_Conductor_BreakReplacement);
                }
                else
                {
                    yield return instruction;
                }
            }
        }

        public static void BreakReplacement(Breakable breakable, RevolverBeam revolverBeam)
        {
            Debug.Log($"BreakReplacement called! Breakable {breakable}, RevolverBeam {revolverBeam}.");

            if (revolverBeam.sourceWeapon.TryGetComponent(out ConductorBehaviour cb))
            {
                breakable.StartCoroutine(MagnetElecEffect(breakable.transform));

                Debug.Log("Source has CB");

                float length = cb.LastCharge * 30f;

                GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy").Where(enemy => !enemy.GetComponent<EnemyIdentifier>().dead && 
                    Vector3.Distance(enemy.transform.position, breakable.transform.position) <= length).ToArray();

                Debug.Log($"{enemies.Length} enemies in {length} radius");

                if (enemies.Length > 0)
                {
                    foreach (GameObject enemy in enemies)
                    {
                        EnemyIdentifier eid = enemy.GetComponent<EnemyIdentifier>();
                        eid.hitterAttributes.Add(HitterAttribute.Electricity);
                        eid.hitter = "magnet_zap";
                        eid.DeliverDamage(eid.gameObject, Vector3.zero, eid.transform.position, revolverBeam.damage, false, 0, ConductorBehaviour.Instances[0].gameObject);
                        Stunner.EnsureAndStun(eid, 1 * StunMult(eid));

                        SingularityBallLightning sbl = GameObject.Instantiate(MagnetZap).GetComponent<SingularityBallLightning>();
                        sbl.enemy = eid.weakPoint ? eid.weakPoint : enemy;
                        sbl.ball = breakable.gameObject;
                    }
                    StyleCalculator.Instance.AddPoints(50 * enemies.Length, $"<color=cyan>GROUNDED</color> x{enemies.Length}", enemies[0].GetComponent<EnemyIdentifier>(), revolverBeam.sourceWeapon);
                }

                TimeController.Instance.ParryFlash();
            }
            else
            {
                breakable.Break();
            }
        }

        public static IEnumerator MagnetElecEffect(Transform t)
        {
            GameObject effect = GameObject.Instantiate(MagnetZapEffect, t);
            effect.transform.localPosition = Vector3.zero;
            effect.transform.rotation = t.rotation;

            yield return new WaitForSeconds(1);

            effect.GetComponent<ParticleSystem>().Stop();
        }

        private static MethodInfo m_Conductor_InstantiateReplacement = typeof(Conductor).GetMethod("InstantiateReplacement");

        [HarmonyPatch(typeof(RevolverBeam), nameof(RevolverBeam.PiercingShotCheck)), HarmonyTranspiler]
        public static IEnumerable<CodeInstruction> DisableHitParticle(IEnumerable<CodeInstruction> instructions)
        {
            foreach (CodeInstruction instruction in instructions)
            {
                if (instruction.operand != null && instruction.operand.GetType().IsSubclassOf(typeof(MethodInfo)))
                {
                    Debug.Log(((MethodInfo)instruction.operand).Name);

                    if (((MethodInfo)instruction.operand).Name == "Instantiate")
                    {
                        yield return new CodeInstruction(OpCodes.Ldarg_0);
                        instruction.operand = m_Conductor_InstantiateReplacement;
                    }
                }

                yield return instruction;
            }
        }

        public static GameObject InstantiateReplacement(GameObject gameObject, Vector3 position, Quaternion rotation, RevolverBeam rb)
        {
            Debug.Log($"Instantiate Replacement: {gameObject} @ {position} {rotation}");

            if (rb.sourceWeapon != null && rb.sourceWeapon.GetComponent<ConductorBehaviour>() && rb.hitList[rb.enemiesPierced].rrhit.collider.GetComponent<Nail>())
            {
                Debug.Log("Not instantiating, is particle.");
                return null;
            }

            return UnityEngine.Object.Instantiate(gameObject, position, rotation);
        } 

        private static MethodInfo m_Grenade_Explode = typeof(Grenade).GetMethod("Explode");
        private static MethodInfo m_Conductor_ExplodeReplacement = typeof(Conductor).GetMethod("ExplodeReplacement");

        [HarmonyPatch(typeof(RevolverBeam), nameof(RevolverBeam.ExecuteHits)), HarmonyTranspiler]
        public static IEnumerable<CodeInstruction> ReplaceGrenadeExplode(IEnumerable<CodeInstruction> instructions)
        {
            foreach (CodeInstruction instruction in instructions)
            {
                if (instruction.opcode == OpCodes.Callvirt && instruction.OperandIs(m_Grenade_Explode))
                {
                    yield return new CodeInstruction(OpCodes.Ldarg_0);
                    yield return new CodeInstruction(OpCodes.Call, m_Conductor_ExplodeReplacement);
                }
                else
                {
                    yield return instruction;
                }
            }
        }

        public static void ExplodeReplacement(Grenade grenade, bool big, bool harmless, bool super, float sizeMultiplier, bool ultrabooster, GameObject exploderWeapon, RevolverBeam revolverBeam)
        {
            Debug.Log($"ExplodeReplacement called! Grenade {grenade}, RevolverBeam {revolverBeam}.");

            if (revolverBeam.sourceWeapon.TryGetComponent(out ConductorBehaviour cb))
            {
                if (grenade.harmlessExplosion != RocketExplosion)
                {
                    GameObject effect = GameObject.Instantiate(MagnetZapEffect, grenade.transform);
                    effect.transform.localScale *= 1.5f;
                    ParticleSystem.EmissionModule emit = effect.GetComponent<ParticleSystem>().emission;
                    emit.rateOverTimeMultiplier *= 2;

                    if (grenade.rocket)
                    {
                        grenade.rocketSpeed *= 2f;
                    }
                }

                grenade.harmlessExplosion = RocketExplosion;
                grenade.explosion = RocketExplosion;
                grenade.superExplosion = RocketExplosion;
            }
            else
            {
                grenade.Explode(big, harmless, super, sizeMultiplier, ultrabooster, exploderWeapon);
            }
        }

        public static float StunMult(EnemyIdentifier eid)
        {
            return (eid.GetComponent<BossIdentifier>() ? 0.65f : 1.25f);
        }
    }
}
