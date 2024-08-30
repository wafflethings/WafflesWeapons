using System;
using System.Collections.Generic;
using System.Diagnostics;
using BepInEx;
using HarmonyLib;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using UnityEngine;
using AtlasLib.Pages;
using AtlasLib.Utils;
using AtlasLib.Weapons;
using WafflesWeapons.Assets;
using WafflesWeapons.Components;
using WafflesWeapons.Pages;

namespace WafflesWeapons;

[BepInPlugin(GUID, Name, Version)]
[BepInDependency(AtlasLib.Plugin.GUID)]
[HarmonyPatch]
public class Plugin : BaseUnityPlugin
{
    public const string Name = "Waffle's Weapons";
    public const string GUID = "waffle.ultrakill.extraalts";
    public const string Version = "1.2.4";
        
    private static readonly Color[] _newColours =
    {
        new(0.25f, 0.5f, 1), // dblue
        new(1, 0.5f, 0.25f), // orange
        new(0.7f, 0.25f, 1)  // purp
    };

    public void Start()
    {
        new Harmony(GUID).PatchAll();
        AddressableManager.Setup();
        PageRegistry.Register(new CustomsPage());
        //PageRegistry.Register(typeof(ExtrasPage));
    }

    [HarmonyPatch(typeof(LeaderboardController), nameof(LeaderboardController.SubmitCyberGrindScore))]
    [HarmonyPatch(typeof(LeaderboardController), nameof(LeaderboardController.SubmitLevelScore))]
    [HarmonyPrefix]
    public static bool DisableCG()
    {
        foreach (Weapon weapon in WeaponRegistry.Weapons)
        {
            if (weapon.Selection != WeaponSelection.Disabled)
            {
                UnityEngine.Debug.Log("A weapon has been detected, disable CG ‼️");
                return false;
            }
        }

        return true;
    }
        
    [HarmonyPatch(typeof(ShopZone), nameof(ShopZone.Start)), HarmonyPrefix]
    public static void AddCredits(ShopZone __instance)
    {
        GameObject shopObject = __instance.gameObject;
            
        if (shopObject.GetChild("Canvas/Weapons") != null)
        {
            GameObject page = Instantiate(AddressableManager.Load<GameObject>("Assets/ExtraAlts/ExtraAlts Credits.prefab"), shopObject.GetChild("Canvas").transform);
            page.transform.SetSiblingIndex(10);
            page.GetComponent<CopyActiveState>().Target = shopObject.GetChild("Canvas/TipBox");
        }
    }

    [HarmonyPatch(typeof(GunSetter), nameof(GunSetter.ResetWeapons)), HarmonyPrefix]
    public static void AddCustomColours()
    {
        ColorBlindSettings.Instance.variationColors =
            ColorBlindSettings.Instance.variationColors.AddRangeToArray(_newColours);
    }

    [HarmonyPatch(typeof(GunSetter), nameof(GunSetter.Start)), HarmonyPrefix]
    public static void FixCharges()
    {
        WeaponCharges.Instance.revaltpickupcharges = new float[7];
    }

    [HarmonyPatch(typeof(Nailgun), nameof(Nailgun.Start)), HarmonyPostfix]
    public static void AddNailProjectileTypes(Nailgun __instance)
    {
        __instance.projectileVariationTypes = new[] 
        {
            "nailgun0",
            "nailgun1",
            "nailgun2",
            "nailgun3",
            "nailgun4",
            "nailgun5",
            "nailgun6",
            "nailgun8"
        };
    }

    [HarmonyPatch(typeof(WeaponIcon), nameof(WeaponIcon.variationColor), MethodType.Getter), HarmonyPrefix]
    public static bool ReplaceColour(WeaponIcon __instance, ref int __result)
    {
        if (__instance.TryGetComponent(out CustomColour colour))
        {
            __result = (int)colour.variationColorReal;
            return false;
        }
            
        return true;
    }
    
    [HarmonyPatch(typeof(Shotgun), nameof(Shotgun.Update)), HarmonyTranspiler]
    private static IEnumerable<CodeInstruction> FixShotgun(IEnumerable<CodeInstruction> instructions) //this sucks but rewrite is soon so i cba
    {
        FieldInfo variation = AccessTools.Field(typeof(Shotgun), nameof(Shotgun.variation));
        MethodInfo shouldBranch = AccessTools.Method(typeof(Plugin), nameof(ShouldBranch));
        CodeInstruction[] instructionArray = instructions.ToArray();
        int index = 0;
        
        foreach (CodeInstruction instruction in instructions)
        {
            yield return instruction;

            if (index > 3 && instruction.opcode == OpCodes.Beq && instructionArray[index - 1].opcode == OpCodes.Ldc_I4_1 && instructionArray[index - 2].opcode == OpCodes.Ldfld && instructionArray[index - 2].operand != null && instructionArray[index - 2].OperandIs(variation))
            {
                yield return new CodeInstruction(OpCodes.Ldarg_0);
                yield return new CodeInstruction(OpCodes.Ldfld, variation);
                yield return new CodeInstruction(OpCodes.Call, shouldBranch);
                yield return new CodeInstruction(OpCodes.Brtrue, instruction.operand);
            } 
            
            index++;
        }
    }

    [HarmonyPatch(typeof(Shotgun), nameof(Shotgun.UpdateMeter)), HarmonyPrefix]
    public static bool UpdateMeter(Shotgun __instance) => !ShouldBranch(__instance.variation);

    public static bool ShouldBranch(int variation) => variation >= 3;
}
