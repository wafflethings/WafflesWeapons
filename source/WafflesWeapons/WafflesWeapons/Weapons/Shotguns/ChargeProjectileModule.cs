using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;
using UnityEngine;

namespace WafflesWeapons.Weapons.Shotguns;

[Serializable]
[HarmonyPatch]
public class ChargeProjectileModule
{
    /// <summary>
    /// Whether this revolver retains the core eject / chainsaw charge behaviour
    /// </summary>
    [Header("Whether this revolver retains the core eject / chainsaw charge behaviour")]
    public bool Enabled = false;
    
    private static bool ShouldCharge(Shotgun shotgun) => BaseShotgun.VanillaToModded.TryGetValue(shotgun, out BaseShotgun moddedShotgun) ? moddedShotgun.ChargeProjectileModule?.Enabled ?? false : shotgun.variation != 1;
    
    [HarmonyPatch(typeof(Shotgun), nameof(Shotgun.Update)), HarmonyTranspiler]
    private static IEnumerable<CodeInstruction> FixUpdate(IEnumerable<CodeInstruction> instructions)
    {
        CodeInstruction[] instructionArray = instructions.ToArray();
        FieldInfo variationField = AccessTools.Field(typeof(Shotgun), nameof(Shotgun.variation));
        MethodInfo pumpMethod = AccessTools.Method(typeof(Shotgun), nameof(Shotgun.Pump));
        MethodInfo shouldChargeMethod = AccessTools.Method(typeof(ChargeProjectileModule), nameof(ShouldCharge));
        
        for (int i = 0; i < instructionArray.Length; i++)
        {
            CodeInstruction instruction = instructionArray[i];
            
            // [variation != 1] part of [if (MonoSingleton<InputManager>.Instance.InputSource.Fire2.IsPressed && variation != 1 && gunReady && gc.activated && !GameStateManager.Instance.PlayerInputLocked && (variation != 2 || MonoSingleton<WeaponCharges>.Instance.shoSawCharge >= 1f))]
            if (instruction.opcode == OpCodes.Beq && i < instructionArray.Length - 2 && instructionArray[i - 2].OperandIs(variationField) && i > 16 && instructionArray[i - 16].OperandIs(pumpMethod))
            {
                yield return new CodeInstruction(OpCodes.Pop); // pop 1
                yield return new CodeInstruction(OpCodes.Pop); // pop variation
                yield return new CodeInstruction(OpCodes.Ldarg_0);
                yield return new CodeInstruction(OpCodes.Call, shouldChargeMethod);
                instruction.opcode = OpCodes.Brfalse;
            }

            yield return instruction;
        }
    }
    
    [HarmonyPatch(typeof(Shotgun), nameof(Shotgun.UpdateMeter)), HarmonyTranspiler]
    private static IEnumerable<CodeInstruction> FixMeter(IEnumerable<CodeInstruction> instructions, ILGenerator transpiler)
    {
        CodeInstruction[] instructionArray = instructions.ToArray();
        FieldInfo chargeSliderField = AccessTools.Field(typeof(Shotgun), nameof(Shotgun.chargeSlider));
        FieldInfo shoSawChargeField = AccessTools.Field(typeof(WeaponCharges), nameof(WeaponCharges.shoSawCharge));
        FieldInfo variationField = AccessTools.Field(typeof(Shotgun), nameof(Shotgun.variation));
        FieldInfo grenadeForceField = AccessTools.Field(typeof(Shotgun), nameof(Shotgun.grenadeForce));
        MethodInfo shouldChargeMethod = AccessTools.Method(typeof(ChargeProjectileModule), nameof(ShouldCharge));

        for (int i = 0; i < instructionArray.Length; i++)
        {
            CodeInstruction instruction = instructionArray[i];
            
            // occurs after else if (variation == 0), no c# equiv, label 01b2
            if (instruction.opcode == OpCodes.Ldarg_0 && i < instructionArray.Length - 2 &&
                instructionArray[i + 1].OperandIs(chargeSliderField) &&
                instructionArray[i + 3].OperandIs(shoSawChargeField))
            {
                Label retLabel = transpiler.DefineLabel();
                yield return new CodeInstruction(instruction); // ldarg0 which gets jumped to 
                yield return new CodeInstruction(OpCodes.Ldfld, variationField);
                yield return new CodeInstruction(OpCodes.Ldc_I4_2);
                yield return new CodeInstruction(OpCodes.Beq, retLabel); // if the variation is 2, jump over the ret, otherwise ret
                yield return new CodeInstruction(OpCodes.Ret);
                CodeInstruction ldargJumpToAvoidRet = new(OpCodes.Ldarg_0);
                ldargJumpToAvoidRet.WithLabels().labels.Add(retLabel);
                yield return ldargJumpToAvoidRet;
                continue;
            }

            yield return instruction;
            
            // if (grenadeForce > 0f)       branch out if not charge
            if (instruction.opcode == OpCodes.Ble_Un && 
                i > 2 && instructionArray[i - 2].OperandIs(grenadeForceField))
            {
                yield return new CodeInstruction(OpCodes.Ldarg_0);
                yield return new CodeInstruction(OpCodes.Call, shouldChargeMethod);
                yield return new CodeInstruction(OpCodes.Brfalse, instruction.operand); 
            }
        }
    }
}
