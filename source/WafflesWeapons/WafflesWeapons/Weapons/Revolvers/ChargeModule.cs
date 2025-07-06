using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;
using ULTRAKILL.Cheats;
using UnityEngine;

namespace WafflesWeapons.Weapons.Revolvers;

[HarmonyPatch]
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
    public float PierceChargeRate = 1.75f;
    
    /// <summary>
    ///  How much charge is gained per second, out of 1
    /// </summary>
    [Header("How much charge is gained per second, out of 1")]
    public float RechargeRate = 0.4f;

    /// <summary>
    /// Colours for the battery - needs 2 options
    /// </summary>
    [Header("Colours for the battery - needs 2 options")]
    public Color[] RechargeColours = [Color.red, Color.yellow, ];

    /// <summary>
    /// Whether the screen uses a texture or a canvas
    /// </summary>
    [Header("Whether the screen uses a texture or a canvas")]
    public bool UseTextureScreen = true;

    private const float DefaultRechargeRate = 40f;          // default is 40*dt (0.5x for alt) out of 100
    
    private const int DefaultPierceChargeRate = 175;     // default is 175*dt out of 100 for piercer only, not ss
    
    private static float GetRechargeRate(Revolver revolver) => BaseRevolver.VanillaToModded.TryGetValue(revolver, out BaseRevolver moddedRevolver) ? moddedRevolver.ChargeModule?.RechargeRate * 100 ?? throw new Exception() : DefaultRechargeRate;
    
    private static int GetPierceChargeRate(Revolver revolver) => BaseRevolver.VanillaToModded.TryGetValue(revolver, out BaseRevolver moddedRevolver) ? (int)(moddedRevolver.ChargeModule?.PierceChargeRate * 100 ?? throw new Exception()) : DefaultPierceChargeRate;

    private static bool ShouldCharge(Revolver revolver) => BaseRevolver.VanillaToModded.TryGetValue(revolver, out BaseRevolver moddedRevolver) ? moddedRevolver.ChargeModule?.Enabled ?? false : revolver.gunVariation == 0;
    
    private static bool ChargeDisabled(Revolver revolver) =>  BaseRevolver.VanillaToModded.TryGetValue(revolver, out BaseRevolver moddedRevolver) ? !moddedRevolver.ChargeModule?.Enabled ?? true : revolver.gunVariation == 1;

    [HarmonyPatch(typeof(Revolver), nameof(Revolver.Update)), HarmonyTranspiler]
    private static IEnumerable<CodeInstruction> ChangeRechargeRate(IEnumerable<CodeInstruction> instructions)
    {
        CodeInstruction? previous = null;
        FieldInfo pierceChargeField = AccessTools.Field(typeof(Revolver), nameof(Revolver.pierceCharge));
        MethodInfo rateMethod = AccessTools.Method(typeof(ChargeModule), nameof(GetRechargeRate));
        
        foreach (CodeInstruction instruction in instructions)
        {
            if (previous != null && previous.opcode == OpCodes.Ldfld && previous.OperandIs(pierceChargeField) && instruction.opcode == OpCodes.Ldc_R4 && instruction.OperandIs(DefaultRechargeRate))
            {
                yield return new CodeInstruction(OpCodes.Ldarg_0);
                instruction.opcode = OpCodes.Call;
                instruction.operand = rateMethod;
            }
            
            previous = instruction;
            yield return instruction;
        }
    }
    
    [HarmonyPatch(typeof(Revolver), nameof(Revolver.Update)), HarmonyTranspiler]
    private static IEnumerable<CodeInstruction> ChangePierceChargeRate(IEnumerable<CodeInstruction> instructions)
    {
        MethodInfo rateMethod = AccessTools.Method(typeof(ChargeModule), nameof(GetPierceChargeRate));
        
        foreach (CodeInstruction instruction in instructions)
        {
            if (instruction.opcode == OpCodes.Ldc_I4 && instruction.OperandIs(DefaultPierceChargeRate)) // normally would jump over 175, this is fixed in FixUpdate
            {
                instruction.opcode = OpCodes.Ldarg_0;
                instruction.operand = null;
                yield return instruction;
                yield return new CodeInstruction(OpCodes.Call, rateMethod);
                continue;
            }
            
            yield return instruction;
        }
    }

    private static bool ShouldSkipWeaponChargesSet(Revolver revolver) => revolver.gunVariation is not 0 and not 1 and not 2;
    
    [HarmonyPatch(typeof(Revolver), nameof(Revolver.OnEnable)), HarmonyTranspiler]
    private static IEnumerable<CodeInstruction> SkipWeaponChargesSet(IEnumerable<CodeInstruction> instructions)
    {
        CodeInstruction[] instructionArray = instructions.ToArray();
        FieldInfo rev0ChargeField = AccessTools.Field(typeof(WeaponCharges), nameof(WeaponCharges.rev0charge));
        MethodInfo shouldSkipMethod = AccessTools.Method(typeof(ChargeModule), nameof(ShouldSkipWeaponChargesSet));
        
        for (int i = 0; i < instructionArray.Length; i++)
        {
            CodeInstruction instruction = instructionArray[i];
            
            if (instruction.opcode == OpCodes.Ldarg_0 && i > 3 && instructionArray[i - 3].OperandIs(rev0ChargeField)) //target of the jump when gunvariation is not 0
            {
                yield return instruction; // another ldarg0 but with the label that it jumps to if gunvariation not 0
                yield return new CodeInstruction(OpCodes.Call, shouldSkipMethod);
                yield return new CodeInstruction(OpCodes.Brtrue, instructionArray[i - 1].operand); //should be a label to jump to if (gunvariation == 2)
                yield return new CodeInstruction(OpCodes.Ldarg_0); // create another ldarg0 for the one thats been stolen
                continue;
            }
            
            yield return instruction;
        }
    }
    
    [HarmonyPatch(typeof(Revolver), nameof(Revolver.Shoot)), HarmonyTranspiler]
    private static IEnumerable<CodeInstruction> SkipRev2Set(IEnumerable<CodeInstruction> instructions)
    {
        CodeInstruction[] instructionArray = instructions.ToArray();
        FieldInfo rev2ChargeField = AccessTools.Field(typeof(WeaponCharges), nameof(WeaponCharges.rev2charge));
        MethodInfo shouldSkipMethod = AccessTools.Method(typeof(ChargeModule), nameof(ShouldSkipWeaponChargesSet));
        
        for (int i = 0; i < instructionArray.Length; i++)
        {
            CodeInstruction instruction = instructionArray[i];
            
            if (instruction.opcode == OpCodes.Ldarg_0 && i < instructionArray.Length - 3 && instructionArray[i + 3].OperandIs(rev2ChargeField))
            {
                yield return instruction; // another ldarg0 but with the label that it jumps to if gunvariation not 0
                yield return new CodeInstruction(OpCodes.Call, shouldSkipMethod);
                yield return new CodeInstruction(OpCodes.Brtrue, instructionArray[i - 1].operand); //should be a label to jump to if wid.delay is not 0f, if((bool)supergunsound)
                yield return new CodeInstruction(OpCodes.Ldarg_0); // create another ldarg0 for the one thats been stolen
                continue;
            }
            
            yield return instruction;
        }
    }

    private static bool ShouldUseTextureScreen(Revolver revolver) => BaseRevolver.VanillaToModded.TryGetValue(revolver, out BaseRevolver moddedRevolver) ? ((moddedRevolver.ChargeModule?.Enabled ?? false) && (moddedRevolver.ChargeModule.UseTextureScreen)) : revolver.gunVariation == 0;

    [HarmonyPatch(typeof(Revolver), nameof(Revolver.Start)), HarmonyTranspiler]
    private static IEnumerable<CodeInstruction> FixStart(IEnumerable<CodeInstruction> instructions)
    {
        CodeInstruction[] instructionArray = instructions.ToArray();
        FieldInfo gunVariationField = AccessTools.Field(typeof(Revolver), nameof(Revolver.gunVariation));
        FieldInfo screenMrField = AccessTools.Field(typeof(Revolver), nameof(Revolver.screenMR));
        FieldInfo screenAudField = AccessTools.Field(typeof(Revolver), nameof(Revolver.screenAud));
        
        MethodInfo shouldTexMethod = AccessTools.Method(typeof(ChargeModule), nameof(ShouldUseTextureScreen));
        MethodInfo shouldChargeMethod = AccessTools.Method(typeof(ChargeModule), nameof(ShouldCharge));
        
        for (int i = 0; i < instructionArray.Length; i++)
        {
            CodeInstruction instruction = instructionArray[i];
            CodeInstruction? previous = i > 0 ? instructionArray[i - 1] : null;

            bool enableScreenAudSetter = i < instructionArray.Length - 3 && instructionArray[i + 3].OperandIs(screenMrField);
            bool enableChargeSoundSetter = i < instructionArray.Length - 2 && instructionArray[i + 2].OperandIs(screenAudField);
            bool shouldAdd = previous?.opcode == OpCodes.Ldfld && previous.OperandIs(gunVariationField) &&
                instruction.opcode == OpCodes.Brtrue &&
                (enableChargeSoundSetter || enableScreenAudSetter);
            
            if (shouldAdd)
            {
                yield return new CodeInstruction(OpCodes.Pop);                  // pop gunVariation
                yield return new CodeInstruction(OpCodes.Ldarg_0);              // load revolver instance

                if (enableScreenAudSetter) // set screenaud if using a texture
                {
                    yield return new CodeInstruction(OpCodes.Call, shouldTexMethod); // load bool using revolver instance on stack already
                    instruction.opcode = OpCodes.Brfalse_S;
                }
                
                if (enableChargeSoundSetter) // set charging sound if charge module enabled
                {
                    yield return new CodeInstruction(OpCodes.Call, shouldChargeMethod); // load bool using revolver instance on stack already
                    instruction.opcode = OpCodes.Brfalse_S;
                }
            }

            yield return instruction;
        }
    }

    [HarmonyPatch(typeof(Revolver), nameof(Revolver.Update)), HarmonyTranspiler]
    private static IEnumerable<CodeInstruction> FixUpdate(IEnumerable<CodeInstruction> instructions, ILGenerator transpiler)

    {
        CodeInstruction[] instructionArray = instructions.ToArray();
        FieldInfo gunVariationField = AccessTools.Field(typeof(Revolver), nameof(Revolver.gunVariation));
        FieldInfo pierceShotChargeField = AccessTools.Field(typeof(Revolver), nameof(Revolver.pierceShotCharge));
        FieldInfo coinChargeField = AccessTools.Field(typeof(Revolver), nameof(Revolver.coinCharge));
        FieldInfo chargeEffectField = AccessTools.Field(typeof(Revolver), nameof(Revolver.chargeEffect));
        FieldInfo screenPropsField = AccessTools.Field(typeof(Revolver), nameof(Revolver.screenProps));
        FieldInfo gunReadyField = AccessTools.Field(typeof(Revolver), nameof(Revolver.gunReady));
        FieldInfo fire1Field = AccessTools.Field(typeof(PlayerInput), nameof(PlayerInput.Fire1));
        MethodInfo noCooldownGetter = AccessTools.PropertyGetter(typeof(NoWeaponCooldown), nameof(NoWeaponCooldown.NoCooldown));
        MethodInfo checkCoinChargesMethod = AccessTools.Method(typeof(Revolver), nameof(Revolver.CheckCoinCharges));

        MethodInfo shouldTexMethod = AccessTools.Method(typeof(ChargeModule), nameof(ShouldUseTextureScreen));
        MethodInfo shouldChargeMethod = AccessTools.Method(typeof(ChargeModule), nameof(ShouldCharge));
        MethodInfo chargeDisabledMethod = AccessTools.Method(typeof(ChargeModule), nameof(ChargeDisabled));

        CodeInstruction? disableChargeJumpInstruction = null;

        for (int i = 0; i < instructionArray.Length; i++)
        {
            CodeInstruction instruction = instructionArray[i];
            CodeInstruction? previous = i > 0 ? instructionArray[i - 1] : null;

            bool enablePierceSound = i < instructionArray.Length - 1 && instructionArray[i + 1].OperandIs(noCooldownGetter); // first variation == 0 check
            bool enablePierceChargeAndShake = i < instructionArray.Length - 2 && instructionArray[i + 2].OperandIs(pierceShotChargeField); // second check, else if (gunvariation == 0)
            bool enableChargeEffect = i < instructionArray.Length - 2 && instructionArray[i + 2].OperandIs(chargeEffectField); // if variation == 0 ... chargeEffect.transform.scale
            bool enableTexScreen = i < instructionArray.Length - 4 && instructionArray[i + 4].OperandIs(screenPropsField); // if variation == 0 ... chargeEffect.transform.scale
            bool shouldAddTrue = previous?.opcode == OpCodes.Ldfld && previous.OperandIs(gunVariationField) &&
                                 instruction.opcode == OpCodes.Brtrue &&
                                 (enablePierceSound || enablePierceChargeAndShake || enableChargeEffect || enableTexScreen);

            bool setChargeAmount = i < instructionArray.Length - 4 && instructionArray[i + 4].OperandIs(75); // make the charge out of 175 like the piercer, not 750/75 like the sharpshooters
            bool setMinimumCharge = i < instructionArray.Length - 4 && instructionArray[i + 2].OperandIs(pierceShotChargeField) && instructionArray[i + 3].OperandIs(25); // ternary operator for minimum charge - (gunVariation == 0) ? (pierceShotCharge == 100f) : (pierceShotCharge >= 25f))
            bool setPierceReady = i < instructionArray.Length - 2 && instructionArray[i + 2].OperandIs(coinChargeField); // else if (inman.InputSource.Fire2.IsPressed && (gunVariation == 2 || shootReady) && ((gunVariation == 0) ? pierceReady : (coinCharge >= (float)(altVersion ? 300 : 100))))
            bool disableCheckCoin = i < instructionArray.Length - 2 && instructionArray[i + 2].OperandIs(checkCoinChargesMethod); // if (gunVariation != 0) CheckCoinCharges()
            bool shouldAddFalse = previous?.opcode == OpCodes.Ldfld && previous.OperandIs(gunVariationField) &&
                                  instruction.opcode == OpCodes.Brfalse &&
                                  (setChargeAmount || setMinimumCharge || setPierceReady || disableCheckCoin);

            if (shouldAddTrue || shouldAddFalse)
            {
                yield return new CodeInstruction(OpCodes.Pop); // pop gunVariation
                yield return new CodeInstruction(OpCodes.Ldarg_0); // load revolver instance

                if (shouldAddTrue)
                {
                    yield return new CodeInstruction(OpCodes.Call, !enableTexScreen ? shouldChargeMethod : shouldTexMethod); // load bool using revolver instance on stack already
                    instruction.opcode = OpCodes.Brfalse_S;
                }

                if (shouldAddFalse)
                {
                    yield return new CodeInstruction(OpCodes.Call, shouldChargeMethod); // load bool using revolver instance on stack already
                    instruction.opcode = OpCodes.Brtrue_S;
                }
            }

            yield return instruction;

            // the part where it checks [else if (gunReady && !inman.PerformingCheatMenuCombo() && inman.InputSource.Fire1.IsPressed && shootReady)] for the coin revolver
            bool disableChargeIfDisabled = instruction.opcode == OpCodes.Brfalse && previous?.opcode == OpCodes.Ldfld && previous.OperandIs(gunReadyField) && i < instructionArray.Length - 2 && instructionArray[i + 2].OperandIs(gunVariationField);

            if (disableChargeIfDisabled)
            {
                yield return new CodeInstruction(OpCodes.Ldarg_0);
                yield return new CodeInstruction(OpCodes.Call, chargeDisabledMethod);
                disableChargeJumpInstruction = new CodeInstruction(OpCodes.Brtrue, null);
                yield return disableChargeJumpInstruction;
            }

            // if (!wid || wid.delay == 0f) in variation 1 logic, after coin shoot on rclick logic
            bool isDisableChargeTargetToJumpTo = instruction.opcode == OpCodes.Ldarg_0 && i < instructionArray.Length - 4 && instructionArray[i + 1].OperandIs(gunReadyField) && instructionArray[i + 10].OperandIs(fire1Field) && i > 12 && instructionArray[i - 12].OperandIs("ThrowCoin"); 

            if (isDisableChargeTargetToJumpTo && disableChargeJumpInstruction != null)
            {
                Label jumpLabel = transpiler.DefineLabel();
                instruction.WithLabels().labels.Add(jumpLabel);
                disableChargeJumpInstruction.operand = jumpLabel;
            }
        }
    }
}
