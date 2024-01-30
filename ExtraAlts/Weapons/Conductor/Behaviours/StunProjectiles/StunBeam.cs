using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using AtlasLib.Utils;
using HarmonyLib;
using UnityEngine;
using UnityEngine.AddressableAssets;
using WafflesWeapons.Weapons.Singularity;

namespace WafflesWeapons.Weapons.Conductor.StunProjectiles
{
    [PatchThis($"{Plugin.GUID}.StunBeam")]
    public class StunBeam : MonoBehaviour, IStunProjectile
    {
        public AssetReferenceGameObject FullyChargedExplosion;
        [HideInInspector] public GameObject Source;
        [HideInInspector] public float ChargeLength;
        
        public void Initialize(ConductorBehaviour source, float chargeLength)
        {
            ChargeLength = chargeLength;
            Source = source.gameObject;
            
            RevolverBeam beam = GetComponent<RevolverBeam>();
            
            if (chargeLength == 1)
            {
                HudMessageReceiver.Instance.SendHudMessage("FIX ME :3");
                //beam.hitParticle = FullyChargedExplosion;
                //foreach (Explosion explosion in (beam.hitParticle.Asset as GameObject ?? beam.hitParticle.ToAsset()).GetComponentsInChildren<Explosion>(true))
                //{
                //    Debug.Log("setting to " + source);
                //explosion.sourceWeapon = source.gameObject;
                //}
            }
            
            Debug.Log("1");
            beam.alternateStartPoint = source.Nailgun.shootPoints[0].transform.position;
            Debug.Log("2");
            beam.damage *= chargeLength;
            beam.sourceWeapon = source.gameObject;
            Debug.Log("3");
            beam.enemyLayerMask |= (1 << 14); // have to add the Projectile layer, but can't use rb.canHitProjectiles as it will cause the sharpshooter behaviour
            
            Debug.Log("what guh");
            foreach (LineRenderer lr in beam.GetComponentsInChildren<LineRenderer>())
            {
                Debug.Log(lr);
                lr.startWidth *= 2 * chargeLength;
            }
        }

        private GameObject GetExplosionObject()
        {
            return FullyChargedExplosion.Asset != null ? FullyChargedExplosion.Asset as GameObject : FullyChargedExplosion.LoadAssetAsync().Result;
        }

        public void HitEnemy(EnemyIdentifier enemy)
        {
            Stunner.EnsureAndStun(enemy, ChargeLength);
        }

        public void HitMagnet(Breakable magnet)
        {
            magnet.StartCoroutine(MagnetElecEffect(magnet.transform));

            Debug.Log("Source has CB");

            float distance = ChargeLength * 30f;

            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy").Where(enemy => !enemy.GetComponent<EnemyIdentifier>().dead && 
                Vector3.Distance(enemy.transform.position, magnet.transform.position) <= distance).ToArray();
            
            TimeController.Instance.ParryFlash();

            if (enemies.Length == 0)
            {
                return;
            }
            
            foreach (GameObject enemy in enemies)
            {
                EnemyIdentifier eid = enemy.GetComponent<EnemyIdentifier>();
                eid.hitterAttributes.Add(HitterAttribute.Electricity);
                eid.hitter = "magnet_zap";
                eid.DeliverDamage(eid.gameObject, Vector3.zero, eid.transform.position, 5 * ChargeLength, false, 0, Source);
                Stunner.EnsureAndStun(eid, 1);

                SingularityBallLightning sbl = Instantiate(Conductor.MagnetZap).GetComponent<SingularityBallLightning>();
                sbl.enemy = eid.weakPoint ? eid.weakPoint : enemy;
                sbl.ball = magnet.gameObject;
            }
            
            StyleCalculator.Instance.AddPoints(50 * enemies.Length, $"<color=cyan>GROUNDED</color> x{enemies.Length}",
                enemies[0].GetComponent<EnemyIdentifier>(), Source);
        }
        
        private IEnumerator MagnetElecEffect(Transform t)
        {
            GameObject effect = GameObject.Instantiate(Conductor.MagnetZapEffect, t);
            effect.transform.localPosition = Vector3.zero;
            effect.transform.rotation = t.rotation;

            yield return new WaitForSeconds(1);

            effect.GetComponent<ParticleSystem>().Stop();
        }
        
        [HarmonyPatch(typeof(RevolverBeam), nameof(RevolverBeam.ExecuteHits)), HarmonyPostfix]
        private static void StunHitEnemies(RevolverBeam __instance, RaycastHit currentHit)
        {
            if (__instance.TryGetComponent(out StunBeam stunBeam) && currentHit.transform.GetComponentInParent<EnemyIdentifierIdentifier>())
            {
                EnemyIdentifier enemy = currentHit.transform.GetComponentInParent<EnemyIdentifierIdentifier>().eid;
                
                if (enemy != null)
                {
                    stunBeam.HitEnemy(enemy);
                }
            }
        }
        
        [HarmonyPatch(typeof(RevolverBeam), nameof(RevolverBeam.ExecuteHits)), HarmonyPrefix]
        private static void EditHitProjectiles(RevolverBeam __instance, RaycastHit currentHit)
        {
            if (__instance.GetComponent<StunBeam>() == null)
            {
                return;
            }

            if (currentHit.transform == null)
            {
                return;
            }

            GameObject hitObject = currentHit.transform.gameObject;
            if (hitObject.layer == LayerMask.NameToLayer("Projectile") && hitObject.TryGetComponent(out Projectile projectile) && projectile.speed != 0f)
            {
                TimeController.Instance.ParryFlash();
                projectile.transform.forward = CameraController.Instance.transform.forward;
                projectile.friendly = true;
                projectile.homingType = HomingType.None;
                projectile.explosionEffect = Conductor.ShotProjectileExplosion;

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
        
        // prevents stun explosions being created when the beam hits a nail
        private static MethodInfo m_Conductor_InstantiateReplacement = typeof(StunBeam).GetMethod(nameof(InstantiateReplacement));

        [HarmonyPatch(typeof(RevolverBeam), nameof(RevolverBeam.PiercingShotCheck)), HarmonyTranspiler]
        private static IEnumerable<CodeInstruction> DisableHitParticle(IEnumerable<CodeInstruction> instructions)
        {
            foreach (CodeInstruction instruction in instructions)
            {
                if (instruction.operand != null && instruction.operand.GetType().IsSubclassOf(typeof(MethodInfo)))
                {
                    Debug.Log(((MethodInfo)instruction.operand).Name);

                    if (((MethodInfo)instruction.operand).Name == "Instantiate")
                    {
                        //yield return new CodeInstruction(OpCodes.Ldarg_0);
                        //instruction.operand = m_Conductor_InstantiateReplacement;
                    }
                }

                yield return instruction;
            }
        }

        public GameObject InstantiateReplacement(GameObject gameObject, Vector3 position, Quaternion rotation, RevolverBeam rb)
        {
            Debug.Log($"Instantiate Replacement: {gameObject} @ {position} {rotation}");

            if (rb.sourceWeapon != null && rb.sourceWeapon.GetComponent<ConductorBehaviour>() && rb.hitList[rb.enemiesPierced].rrhit.collider.GetComponent<Nail>())
            {
                Debug.Log("Not instantiating, is nail.");
                return null;
            }

            return Instantiate(gameObject, position, rotation);
        } 
        
        private static MethodInfo m_Grenade_Explode = typeof(Grenade).GetMethod(nameof(Grenade.Explode));
        private static MethodInfo m_Conductor_ExplodeReplacement = typeof(StunBeam).GetMethod(nameof(ExplodeReplacement));

        [HarmonyPatch(typeof(RevolverBeam), nameof(RevolverBeam.ExecuteHits)), HarmonyTranspiler]
        private static IEnumerable<CodeInstruction> ReplaceGrenadeExplode(IEnumerable<CodeInstruction> instructions)
        {
            foreach (CodeInstruction instruction in instructions)
            {
                Debug.Log(instruction);
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

            if (revolverBeam.sourceWeapon.GetComponent<StunBeam>() != null)
            {
                if (grenade.GetComponent<StunRocket>() == null)
                {
                    grenade.gameObject.AddComponent<StunRocket>();
                }
            }
            else
            {
                grenade.Explode(big, harmless, super, sizeMultiplier, ultrabooster, exploderWeapon);
            }
        }
        
        private static MethodInfo m_Breakable_Break = typeof(Breakable).GetMethod(nameof(Breakable.Break));
        private static MethodInfo m_Conductor_BreakReplacement = typeof(StunBeam).GetMethod(nameof(BreakReplacement));

        [HarmonyPatch(typeof(RevolverBeam), nameof(RevolverBeam.PiercingShotCheck)), HarmonyTranspiler]
        private static IEnumerable<CodeInstruction> ReplaceBreak(IEnumerable<CodeInstruction> instructions)
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

            if (revolverBeam.TryGetComponent(out StunBeam stunBeam))
            {
                stunBeam.HitMagnet(breakable);
            }
            else
            {
                breakable.Break();
            }
        }
    }
}
