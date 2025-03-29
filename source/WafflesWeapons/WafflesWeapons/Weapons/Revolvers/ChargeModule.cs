using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;
using UnityEngine;

namespace WafflesWeapons.Weapons.Revolvers;

[Serializable]
public class ChargeModule
{
    /// <summary>
    /// Whether this revolver retains the Piercer charge behaviour
    /// </summary>
    [Header("Whether this revolver retains the Piercer charge behaviour")]
    public bool Enabled = false;
    
    /// <summary>
    ///  How much charge is gained per second, out of 1
    /// </summary>
    [Header("How much charge is gained per second, out of 1")]
    public float Rate = 0.4f;

    /// <summary>
    /// Whether it shakes while charging
    /// </summary>
    [Header("Whether it shakes while charging")]
    public bool Shake;

    /// <summary>
    /// Colours for the battery - needs 3 options
    /// </summary>
    [Header("Colours for the battery - needs 2 options")]
    public Color[] RechargeColours = [Color.red, Color.yellow, ];

    private const float DefaultChargeRate = 40f;
    private static float GetRate(Revolver revolver) => BaseRevolver.VanillaToModded.TryGetValue(revolver, out BaseRevolver moddedRevolver) ? moddedRevolver.ChargeModule?.Rate ?? throw new Exception() : DefaultChargeRate;
    
    private static bool ShouldCharge(Revolver revolver) => BaseRevolver.VanillaToModded.TryGetValue(revolver, out BaseRevolver moddedRevolver) ? moddedRevolver.ChargeModule?.Enabled ?? false : revolver.gunVariation == 0;

    // [HarmonyPatch(typeof(Revolver), nameof(Revolver.Update)), HarmonyTranspiler]
    private static IEnumerable<CodeInstruction> ChangeChargeRate(IEnumerable<CodeInstruction> instructions)
    {
        CodeInstruction? previous = null;
        FieldInfo pierceChargeField = AccessTools.Field(typeof(Revolver), nameof(Revolver.pierceCharge));
        MethodInfo rateMethod = AccessTools.Method(typeof(ChargeModule), nameof(GetRate));
        
        foreach (CodeInstruction instruction in instructions)
        {
            if (previous != null && previous.opcode == OpCodes.Ldfld && previous.OperandIs(pierceChargeField) && instruction.opcode == OpCodes.Ldc_R4 && instruction.OperandIs(DefaultChargeRate))
            {
                instruction.opcode = OpCodes.Call;
                instruction.operand = rateMethod;
            }
            
            previous = instruction;
            yield return instruction;
        }
    }
}
