using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;
using UnityEngine;

namespace WafflesWeapons.Weapons;

[HarmonyPatch]
public static class RevolverBeamExtension
{
    public delegate void BeamHitEnemy(RevolverBeam beam, EnemyIdentifier enemy, float damage);
    public delegate void BeamHitAny(RevolverBeam beam, GameObject gameObject);
    
    private static Dictionary<RevolverBeam?, List<BeamHitEnemy>> s_preEnemyHitCallbacks = new();
    private static Dictionary<RevolverBeam?, List<BeamHitEnemy>> s_postEnemyHitCallbacks = new();
    private static Dictionary<RevolverBeam?, List<BeamHitAny>> s_anyHitCallbacks = new();

    public static void AddBeforeEnemyHit(this RevolverBeam beam, BeamHitEnemy callback)
    {
        if (s_preEnemyHitCallbacks.ContainsKey(beam))
        {
            s_preEnemyHitCallbacks[beam].Add(callback);
            return;
        }

        s_preEnemyHitCallbacks.Add(beam, [callback]);
    } 
    
    public static void RemoveBeforeEnemyHit(this RevolverBeam beam, BeamHitEnemy callback) => s_preEnemyHitCallbacks[beam].Remove(callback);
    
    private static void RunPreEnemyHitCallback(RevolverBeam beam, EnemyIdentifier enemy, float damage)
    {
        if (!s_preEnemyHitCallbacks.TryGetValue(beam, out List<BeamHitEnemy> callbacks))
        {
            return;
        }
        
        ClearDestroyed(ref s_preEnemyHitCallbacks);

        foreach (BeamHitEnemy callback in callbacks)
        {
            callback.Invoke(beam, enemy, damage);
        }
    }
    
    public static void AddOnEnemyHit(this RevolverBeam beam, BeamHitEnemy callback)
    {
        if (s_postEnemyHitCallbacks.ContainsKey(beam))
        {
            s_postEnemyHitCallbacks[beam].Add(callback);
            return;
        }

        s_postEnemyHitCallbacks.Add(beam, [callback]);
    } 
    
    public static void RemoveOnEnemyHit(this RevolverBeam beam, BeamHitEnemy callback) => s_postEnemyHitCallbacks[beam].Remove(callback);
    
    private static void RunPostEnemyHitCallback(RevolverBeam beam, EnemyIdentifier enemy, float damage)
    {
        if (!s_postEnemyHitCallbacks.TryGetValue(beam, out List<BeamHitEnemy> callbacks))
        {
            return;
        }
        
        ClearDestroyed(ref s_postEnemyHitCallbacks);

        foreach (BeamHitEnemy callback in callbacks)
        {
            callback.Invoke(beam, enemy, damage);
        }
    }
    
    public static void AddOnAnyHit(this RevolverBeam beam, BeamHitAny callback)
    {
        if (s_anyHitCallbacks.ContainsKey(beam))
        {
            s_anyHitCallbacks[beam].Add(callback);
            return;
        }

        s_anyHitCallbacks.Add(beam, [callback]);
    } 
    
    public static void RemoveOnAnyHit(this RevolverBeam beam, BeamHitAny callback) => s_anyHitCallbacks[beam].Remove(callback);
    
    [HarmonyPatch(typeof(RevolverBeam), nameof(RevolverBeam.HitSomething)), HarmonyPostfix]
    private static void RunAnyHitCallbackSingleHit(RevolverBeam __instance, RaycastHit hit)
    {
        if (!s_anyHitCallbacks.TryGetValue(__instance, out List<BeamHitAny> callbacks))
        {
            return;
        }
        
        ClearDestroyed(ref s_anyHitCallbacks);
        
        foreach (BeamHitAny callback in callbacks)
        {
            callback.Invoke(__instance, hit.collider.gameObject);
        }
    }
    
    [HarmonyPatch(typeof(RevolverBeam), nameof(RevolverBeam.PiercingShotCheck)), HarmonyPostfix]
    private static void RunAnyHitCallbackMultiHit(RevolverBeam __instance)
    {
        if (!s_anyHitCallbacks.TryGetValue(__instance, out List<BeamHitAny> callbacks))
        {
            return;
        }
        
        ClearDestroyed(ref s_anyHitCallbacks);

        if (__instance.hitList.Count == 0)
        {
            return;
        }
        RaycastHit currentHit = __instance.hitList[__instance.enemiesPierced].rrhit;
        Plugin.Log.LogMessage($"Hit2 {__instance.enemiesPierced} of {__instance.hitList.Count} {currentHit.collider.gameObject}");
        
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
        MethodInfo preEnemyHitMethod = AccessTools.Method(typeof(RevolverBeamExtension), nameof(RunPreEnemyHitCallback));
        MethodInfo postEnemyHitMethod = AccessTools.Method(typeof(RevolverBeamExtension), nameof(RunPostEnemyHitCallback));
        
        foreach (CodeInstruction instruction in instructions)
        {
            if (instruction.OperandIs(deliverDamageMethod))
            {
                yield return new CodeInstruction(OpCodes.Ldarg_0);
                yield return new CodeInstruction(OpCodes.Ldloc_S, 8); // enemy
                yield return new CodeInstruction(OpCodes.Ldloc_S, 11); // damage number
                yield return new CodeInstruction(OpCodes.Call, preEnemyHitMethod);
                
                yield return instruction;
                
                yield return new CodeInstruction(OpCodes.Ldarg_0);
                yield return new CodeInstruction(OpCodes.Ldloc_S, 8); // enemy
                yield return new CodeInstruction(OpCodes.Ldloc_S, 11); // damage number
                yield return new CodeInstruction(OpCodes.Call, postEnemyHitMethod);
                
                continue;
            }
            
            yield return instruction;
        }
    }

}
