using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;

namespace WafflesWeapons.Weapons;

[HarmonyPatch]
public static class RevolverBeamExtension
{
    public delegate void BeamHitEnemy(RevolverBeam beam, EnemyIdentifier enemy);
    
    private static Dictionary<RevolverBeam?, List<BeamHitEnemy>> s_enemyHitCallbacks = new();

    public static void AddOnEnemyHit(this RevolverBeam beam, BeamHitEnemy callback)
    {
        if (s_enemyHitCallbacks.ContainsKey(beam))
        {
            s_enemyHitCallbacks[beam].Add(callback);
            return;
        }

        s_enemyHitCallbacks.Add(beam, [callback]);
    } 
    
    public static void RemoveOnEnemyHit(this RevolverBeam beam, BeamHitEnemy callback) => s_enemyHitCallbacks[beam].Remove(callback);
    private static void RunEnemyHitCallback(RevolverBeam beam, EnemyIdentifier enemy)
    {
        if (!s_enemyHitCallbacks.TryGetValue(beam, out List<BeamHitEnemy> callbacks))
        {
            return;
        }
        
        ClearDestroyed(ref s_enemyHitCallbacks);

        foreach (BeamHitEnemy callback in callbacks)
        {
            callback.Invoke(beam, enemy);
        }
    }

    private static void ClearDestroyed<T, T2>(ref Dictionary<T, T2> dict)
    {
        List<T> toRemove = new(dict.Count);

        foreach (T key in dict.Keys)
        {
            if (key == null)
            {
                toRemove.Add(key);
            }
        }

        foreach (T key in toRemove)
        {
            dict.Remove(key);
        }
    }
    
    [HarmonyPatch(typeof(RevolverBeam), nameof(RevolverBeam.ExecuteHits)), HarmonyTranspiler]
    private static IEnumerable<CodeInstruction> AddCallbacks(IEnumerable<CodeInstruction> instructions)
    {
        MethodInfo deliverDamageMethod = AccessTools.Method(typeof(EnemyIdentifier), nameof(EnemyIdentifier.DeliverDamage));
        MethodInfo enemyHitMethod = AccessTools.Method(typeof(RevolverBeamExtension), nameof(RunEnemyHitCallback));
        
        foreach (CodeInstruction instruction in instructions)
        {
            yield return instruction;
            
            if (instruction.OperandIs(deliverDamageMethod))
            {
                yield return new CodeInstruction(OpCodes.Ldarg_0);
                yield return new CodeInstruction(OpCodes.Ldloc_S, 8);
                yield return new CodeInstruction(OpCodes.Call, enemyHitMethod);
            }
        }
    }

}
