using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;
using UnityEngine;

namespace WafflesWeapons.Weapons.Shotguns;

[HarmonyPatch]
public class BaseHammer : MonoBehaviour
{
    internal static Dictionary<ShotgunHammer, BaseHammer> VanillaToModded = new();
    
    protected ShotgunHammer _hammer;
    
    protected virtual void Awake()
    {
        if (!TryGetComponent(out _hammer) || _hammer == null)
        {
            Plugin.Log.LogError($"{gameObject.name} lacks ShotgunHammer script - this will not work!!");
            Destroy(this);
            return;
        }
        
        VanillaToModded.Add(_hammer, this);
    }
    
    private void OnDestroy()
    {
        if (_hammer != null)
        {
            VanillaToModded.Remove(_hammer);
        }
    }
    
    [HarmonyPatch(typeof(GunSetter), nameof(GunSetter.Start)), HarmonyPrefix]
    private static void FixCharges()
    {
        WeaponCharges.Instance.shoaltcooldowns = new float[8];
    }
    
    [HarmonyPatch(typeof(ShotgunHammer), nameof(ShotgunHammer.Update)), HarmonyTranspiler]
    private static IEnumerable<CodeInstruction> FixMeter(IEnumerable<CodeInstruction> instructions, ILGenerator transpiler)
    {
        CodeInstruction[] instructionArray = instructions.ToArray();
        FieldInfo variationField = AccessTools.Field(typeof(ShotgunHammer), nameof(ShotgunHammer.variation));
        MethodInfo pumpMethod = AccessTools.Method(typeof(ShotgunHammer), nameof(ShotgunHammer.Pump));

        for (int i = 0; i < instructionArray.Length; i++)
        {
            CodeInstruction instruction = instructionArray[i];
            
            if (instruction.opcode == OpCodes.Ldarg_0 && i < instructionArray.Length - 1 &&
                instructionArray[i + 1].OperandIs(pumpMethod))
            {
                Label afterPumpLabel = transpiler.DefineLabel();
                yield return new CodeInstruction(instruction); // ldarg0
                yield return new CodeInstruction(OpCodes.Ldfld, variationField);
                yield return new CodeInstruction(OpCodes.Ldc_I4_1); // load 1 onto the stack
                yield return new CodeInstruction(OpCodes.Bne_Un, afterPumpLabel); // if the variation is 2, jump over the ret, otherwise ret
                instructionArray[i + 2].WithLabels().labels.Add(afterPumpLabel); // after the pump method call
            }

            yield return instruction;
        }
    }
}
