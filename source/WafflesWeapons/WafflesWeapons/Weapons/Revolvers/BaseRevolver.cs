using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;
using UnityEngine;

namespace WafflesWeapons.Weapons.Revolvers;

[HarmonyPatch]
public class BaseRevolver : MonoBehaviour
{
    internal static Dictionary<Revolver, BaseRevolver> VanillaToModded = new();

    public delegate void Shoot(RevolverBeam beam);
    public event Shoot? Shot;
    
    public ChargeModule? ChargeModule;
    
    protected Revolver _rev;

    protected virtual void Awake()
    {
        if (!TryGetComponent(out _rev) || _rev == null)
        {
            Plugin.Log.LogError($"{gameObject.name} lacks Revolver script - this will not work!!");
            Destroy(this);
            return;
        }
        
        VanillaToModded.Add(_rev, this);
    }

    private void OnDestroy()
    {
        if (_rev != null)
        {
            VanillaToModded.Remove(_rev);
        }
    }

    private static void BeamCallbackCaller(Revolver revolver, RevolverBeam beam1, RevolverBeam beam2)
    {
        if (!VanillaToModded.TryGetValue(revolver, out BaseRevolver baseRevolver))
        {
            return;
        }
        
        baseRevolver.Shot?.Invoke(beam1 != null ? beam1 : beam2);
    }

    [HarmonyPatch(typeof(GunSetter), nameof(GunSetter.Start)), HarmonyPrefix]
    private static void FixCharges()
    {
        WeaponCharges.Instance.revaltpickupcharges = new float[7];
    }

    [HarmonyPatch(typeof(Revolver), nameof(Revolver.Shoot)), HarmonyTranspiler]
    private static IEnumerable<CodeInstruction> AddShootCallback(IEnumerable<CodeInstruction> instructions)
    {
        MethodInfo callbackMethod = AccessTools.Method(typeof(BaseRevolver), nameof(BeamCallbackCaller));
        foreach (CodeInstruction instruction in instructions)
        {
            if (instruction.opcode == OpCodes.Ret)
            {
                yield return new CodeInstruction(OpCodes.Ldarg_0);
                yield return new CodeInstruction(OpCodes.Ldloc_S, 1); // normal shot rb
                yield return new CodeInstruction(OpCodes.Ldloc_S, 5); // charge shot rb
                yield return new CodeInstruction(OpCodes.Call, callbackMethod);
            }
            
            yield return instruction;
        }
    }

    [HarmonyPatch(typeof(Revolver), nameof(Revolver.Start)), HarmonyTranspiler]
    private static IEnumerable<CodeInstruction> SkipScreenAud(IEnumerable<CodeInstruction> instructions, ILGenerator transpiler)    // if canvas is null, don't bother getting audiosource
    {
        CodeInstruction[] instructionArray = instructions.ToArray();
        MethodInfo getChildCanvasMethod = AccessTools.Method(typeof(Component), nameof(GetComponentInChildren)).MakeGenericMethod(typeof(Canvas));
        CodeInstruction? branchInstruction = null;

        for (int i = 0; i < instructionArray.Length; i++)
        {
            CodeInstruction instruction = instructionArray[i];

            if (i > 3 && instructionArray[i - 3].OperandIs(getChildCanvasMethod)) // if it's the place it should branch to (3 after get child canvas). should be ldarg.0 then chargeeffect
            { 
                Label jumpOverPopLabel = transpiler.DefineLabel();
                instruction.WithLabels().labels.Add(jumpOverPopLabel);
                yield return new CodeInstruction(OpCodes.Br_S, jumpOverPopLabel); // if not coming from the jump in the nullcheck, we want to jump over the pop
                
                CodeInstruction target = new(OpCodes.Pop);    // pop the canvas that was duplicated by Dup
                Label jumpToPopLabel = transpiler.DefineLabel();
                target.WithLabels().labels.Add(jumpToPopLabel);
                branchInstruction.operand = jumpToPopLabel;
                yield return target;

                yield return new CodeInstruction(OpCodes.Pop); // pop the leftover Revolver instance created because ldarg.0 is called twice
            }
            
            yield return instruction;

            if (instruction.OperandIs(getChildCanvasMethod))
            {
                yield return new CodeInstruction(OpCodes.Dup);
                branchInstruction = new CodeInstruction(OpCodes.Brfalse_S);
                yield return branchInstruction;
            }
        }
    }
}
