using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;
using UnityEngine;
using UnityEngine.Events;

namespace WafflesWeapons.Weapons;

[HarmonyPatch]
public class CoinTarget : MonoBehaviour
{
    private static List<CoinTarget> s_targets = new();
    
    public UnityEvent<Coin>? OnHit;

    private static void RegisterTarget(CoinTarget target)
    {
        s_targets.RemoveAll(x => x == null);
        s_targets.Add(target);
    }
    
    private static void AddAll(ref List<Transform> list)
    {
        list.AddRange(s_targets.Select(x => x.transform));    
    }
    
    private static void Hit(Transform transform, Coin coin)
    {
        if (!transform.TryGetComponent(out CoinTarget target))
        {
            return;
        }
        
        target.OnHit?.Invoke(coin);
    }
    
    [HarmonyPatch(typeof(Coin), nameof(Coin.ReflectRevolver)), HarmonyTranspiler]
    private static IEnumerable<CodeInstruction> AddCustoms(IEnumerable<CodeInstruction> instructions)
    {
        CodeInstruction[] instructionArray = instructions.ToArray();
        MethodInfo addAllMethod = AccessTools.Method(typeof(CoinTarget), nameof(AddAll));
        MethodInfo tryGetGrenadeMethod = AccessTools.GetDeclaredMethods(typeof(Component)).First(x => x.Name == nameof(Component.TryGetComponent) && x.GetParameters().Length == 1).MakeGenericMethod(typeof(Grenade));
        MethodInfo hitMethod = AccessTools.Method(typeof(CoinTarget), nameof(Hit));
        
        for (int i = 0; i < instructionArray.Length; i++)
        {
            CodeInstruction instruction = instructionArray[i];
            yield return instruction;

            // List<Transform> list = new List<Transform>();
            if (instruction.opcode == OpCodes.Stloc_S && (instruction.operand as LocalBuilder)!.LocalIndex == 16)
            {
                yield return new CodeInstruction(OpCodes.Ldloca_S, 16);
                yield return new CodeInstruction(OpCodes.Call, addAllMethod);
            }
            
            // before if (transform.TryGetComponent<Grenade>(out var component4))
            if (i < instructionArray.Length - 3 && instructionArray[i + 3].OperandIs(tryGetGrenadeMethod))
            {
                yield return instructionArray[i + 1]; // should be ldloc transform
                yield return new CodeInstruction(OpCodes.Ldarg_0);
                yield return new CodeInstruction(OpCodes.Call, hitMethod);
            }
        }
    }

    private void Awake()
    {
        RegisterTarget(this);
    }
}
