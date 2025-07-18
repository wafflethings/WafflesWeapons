using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;
using UnityEngine;

namespace WafflesWeapons.Weapons;

[HarmonyPatch]
public static class RevolverBeamExtension
{
    public delegate void BeamHitEnemy(RevolverBeam beam, EnemyIdentifier enemy);
    public delegate void BeamHitAny(RevolverBeam beam, GameObject gameObject);
    
    private static Dictionary<RevolverBeam?, List<BeamHitEnemy>> s_enemyHitCallbacks = new();
    private static Dictionary<RevolverBeam?, List<BeamHitAny>> s_AnyHitCallbacks = new();

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
    
    public static void AddOnAnyHit(this RevolverBeam beam, BeamHitAny callback)
    {
        if (s_AnyHitCallbacks.ContainsKey(beam))
        {
            s_AnyHitCallbacks[beam].Add(callback);
            return;
        }

        s_AnyHitCallbacks.Add(beam, [callback]);
    } 
    
    public static void RemoveOnAnyHit(this RevolverBeam beam, BeamHitAny callback) => s_AnyHitCallbacks[beam].Remove(callback);
    
    [HarmonyPatch(typeof(RevolverBeam), nameof(RevolverBeam.HitSomething)), HarmonyPostfix]
    private static void RunAnyHitCallbackSingleHit(RevolverBeam __instance, RaycastHit hit)
    {
        if (!s_AnyHitCallbacks.TryGetValue(__instance, out List<BeamHitAny> callbacks))
        {
            return;
        }
        
        ClearDestroyed(ref s_enemyHitCallbacks);
        
        foreach (BeamHitAny callback in callbacks)
        {
            callback.Invoke(__instance, hit.collider.gameObject);
        }
    }
    
    [HarmonyPatch(typeof(RevolverBeam), nameof(RevolverBeam.PiercingShotCheck)), HarmonyPostfix]
    private static void RunAnyHitCallbackMultiHit(RevolverBeam __instance)
    {
        if (!s_AnyHitCallbacks.TryGetValue(__instance, out List<BeamHitAny> callbacks))
        {
            return;
        }
        
        ClearDestroyed(ref s_enemyHitCallbacks);

        if (__instance.hitList.Count == 0)
        {
            return;
        }
        RaycastHit currentHit = __instance.hitList[__instance.enemiesPierced].rrhit;
        Plugin.Log.LogMessage($"Hit {__instance.enemiesPierced} of {__instance.hitList.Count} {currentHit.collider.gameObject}");
        
        foreach (BeamHitAny callback in callbacks)
        {
            callback.Invoke(__instance, currentHit.collider.gameObject);
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
