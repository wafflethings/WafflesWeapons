using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using AtlasLib.Utils;
using HarmonyLib;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Serialization;
using WafflesWeapons.Weapons.Singularity;

namespace WafflesWeapons.Weapons.Conductor.StunProjectiles;

[HarmonyPatch]
public class StunBeam : MonoBehaviour, IStunProjectile
{
    public GameObject MagnetZapLine;
    [SerializeField] private GameObject _shotProjectileExplosion;
    [SerializeField] private GameObject _fullyChargedExplosion;
    [SerializeField] private GameObject _rocketStunExplosion;
    [SerializeField] private GameObject _magnetZapBall;
    private GameObject _source;
    private float _chargeLength;
        
    public void Initialize(ConductorBehaviour source, float chargeLength)
    {
        _chargeLength = chargeLength;
        _source = source.gameObject;
            
        RevolverBeam beam = GetComponent<RevolverBeam>();
            
        if (Mathf.Approximately(chargeLength, 1))
        {
            beam.hitParticle = _fullyChargedExplosion;
            foreach (Explosion explosion in beam.hitParticle.GetComponentsInChildren<Explosion>(true))
            {
                explosion.sourceWeapon = source.gameObject;
            }
        }
        
        beam.alternateStartPoint = source.Nailgun.shootPoints[0].transform.position;
        beam.damage *= chargeLength;
        beam.sourceWeapon = source.gameObject;
        beam.enemyLayerMask |= (1 << 14); // have to add the Projectile layer, but can't use rb.canHitProjectiles as it will cause the sharpshooter behaviour
        
        foreach (LineRenderer lr in beam.GetComponentsInChildren<LineRenderer>())
        {
            lr.startWidth *= 2 * chargeLength;
        }
    }

    public void HitEnemy(EnemyIdentifier enemy)
    {
        Stunner.EnsureAndStun(enemy, _chargeLength);
    }

    public void HitMagnet(Breakable magnet)
    {
        magnet.StartCoroutine(MagnetBallEffect(magnet.transform));
        
        float distance = _chargeLength * 30f;

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
            eid.DeliverDamage(eid.gameObject, Vector3.zero, eid.transform.position, 5 * _chargeLength, false, 0, _source);
            Stunner.EnsureAndStun(eid, 1);

            SingularityBallLightning sbl = Instantiate(MagnetZapLine).GetComponent<SingularityBallLightning>();
            sbl.enemy = eid.weakPoint ? eid.weakPoint : enemy;
            sbl.ball = magnet.gameObject;
        }
            
        StyleCalculator.Instance.AddPoints(50 * enemies.Length, $"<color=cyan>GROUNDED</color> x{enemies.Length}",
            enemies[0].GetComponent<EnemyIdentifier>(), _source);
    }
        
    private IEnumerator MagnetBallEffect(Transform t)
    {
        GameObject effect = Instantiate(_magnetZapBall, t);
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
        if (!__instance.TryGetComponent(out StunBeam stunBeam))
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
            projectile.explosionEffect = stunBeam._shotProjectileExplosion;

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
    private static MethodInfo s_conductorInstantiateReplacement = typeof(StunBeam).GetMethod(nameof(InstantiateReplacement));

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
        
    private static MethodInfo s_grenadeExplode = typeof(Grenade).GetMethod(nameof(Grenade.Explode));
    private static MethodInfo s_conductorExplodeReplacement = typeof(StunBeam).GetMethod(nameof(ExplodeReplacement));

    [HarmonyPatch(typeof(RevolverBeam), nameof(RevolverBeam.ExecuteHits)), HarmonyTranspiler]
    private static IEnumerable<CodeInstruction> ReplaceGrenadeExplode(IEnumerable<CodeInstruction> instructions)
    {
        foreach (CodeInstruction instruction in instructions)
        {
            Debug.Log(instruction);
            if (instruction.opcode == OpCodes.Callvirt && instruction.OperandIs(s_grenadeExplode))
            {
                yield return new CodeInstruction(OpCodes.Ldarg_0);
                yield return new CodeInstruction(OpCodes.Call, s_conductorExplodeReplacement);
            }
            else
            {
                yield return instruction;
            }
        }
    }

    public static void ExplodeReplacement(Grenade grenade, bool big, bool harmless, bool super, float sizeMultiplier, bool ultrabooster, GameObject exploderWeapon, bool fup, RevolverBeam revolverBeam)
    {
        Debug.Log($"ExplodeReplacement called! Grenade {grenade}, RevolverBeam {revolverBeam}.");

        if (!revolverBeam.sourceWeapon.TryGetComponent(out StunBeam stunBeam))
        {
            grenade.Explode(big, harmless, super, sizeMultiplier, ultrabooster, exploderWeapon, fup);
            return;
        }

        if (grenade.GetComponent<StunRocket>() == null)
        {
            grenade.gameObject.AddComponent<StunRocket>().Initialize(stunBeam._rocketStunExplosion, stunBeam._magnetZapBall);
        }
    }
        
    private static MethodInfo s_breakableBreak = typeof(Breakable).GetMethod(nameof(Breakable.Break));
    private static MethodInfo s_conductorBreakReplacement = typeof(StunBeam).GetMethod(nameof(BreakReplacement));

    [HarmonyPatch(typeof(RevolverBeam), nameof(RevolverBeam.PiercingShotCheck)), HarmonyTranspiler]
    private static IEnumerable<CodeInstruction> ReplaceBreak(IEnumerable<CodeInstruction> instructions)
    {
        foreach (CodeInstruction instruction in instructions)
        {
            if (instruction.opcode == OpCodes.Callvirt && instruction.OperandIs(s_breakableBreak))
            {
                yield return new CodeInstruction(OpCodes.Ldarg_0);
                yield return new CodeInstruction(OpCodes.Call, s_conductorBreakReplacement);
            }
            else
            {
                yield return instruction;
            }
        }
    }

    public static void BreakReplacement(Breakable breakable, RevolverBeam revolverBeam)
    {
        if (revolverBeam.TryGetComponent(out StunBeam stunBeam))
        {
            stunBeam.HitMagnet(breakable);
            return;
        }
        breakable.Break();
    }
}
