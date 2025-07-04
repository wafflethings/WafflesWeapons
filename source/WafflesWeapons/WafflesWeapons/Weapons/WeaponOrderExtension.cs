using System.Collections.Generic;
using System.IO;
using System.Reflection.Emit;
using AtlasLib.Saving;
using AtlasLib.Weapons;
using HarmonyLib;

namespace WafflesWeapons.Weapons;

[HarmonyPatch]
public class WeaponOrderExtension
{
    public static SaveFile<Dictionary<string, string>> PrefToExtendedOrder = SaveFile.RegisterFile(new SaveFile<Dictionary<string, string>>("order.json", Path.Combine("wafflethings", Plugin.Name), new()));

    private static bool s_disablePatches = false;
    
    [HarmonyPatch(typeof(PrefsManager), nameof(PrefsManager.GetString)), HarmonyPrefix]
    private static bool ReplaceGetName(ref string __result, string key)
    {
        if (s_disablePatches || !key.StartsWith("weapon.") || !key.EndsWith(".order"))
        {
            return true;
        }

        if (!PrefToExtendedOrder.Data.ContainsKey(key) || PrefToExtendedOrder.Data[key] == null || PrefToExtendedOrder.Data[key].Length != 8)
        {
            s_disablePatches = true;
            PrefToExtendedOrder.Data[key] = (PrefsManager.Instance.GetString(key) ?? "1234") + "5678";
            s_disablePatches = false;
        }

        __result = PrefToExtendedOrder.Data[key];
        return false;
    }
    
    [HarmonyPatch(typeof(PrefsManager), nameof(PrefsManager.SetString)), HarmonyPrefix]
    private static bool ReplaceSetName(string key, string content)
    {
        if (!key.StartsWith("weapon.") || !key.EndsWith(".order"))
        {
            return true;
        }

        PrefToExtendedOrder.Data[key] = content;
        PrefsManager.onPrefChanged?.Invoke(key, content);
        return false;
    }

    [HarmonyPatch(typeof(GunSetter), nameof(GunSetter.CheckWeaponOrder)), HarmonyTranspiler]
    private static IEnumerable<CodeInstruction> SkipLengthCheck(IEnumerable<CodeInstruction> instructions)
    {
        foreach (CodeInstruction instruction in instructions)
        {
            if (instruction.opcode == OpCodes.Beq)
            {
                yield return new CodeInstruction(OpCodes.Pop); // pops 4
                yield return new CodeInstruction(OpCodes.Pop); // pops length
                instruction.opcode = OpCodes.Br;
            }

            yield return instruction;
        }
    }
    
    [HarmonyPatch(typeof(WeaponOrderController), nameof(WeaponOrderController.ChangeOrderNumber)), HarmonyTranspiler]
    private static IEnumerable<CodeInstruction> SkipLengthCheck2(IEnumerable<CodeInstruction> instructions)
    {
        foreach (CodeInstruction instruction in instructions)
        {
            if (instruction.opcode == OpCodes.Bge)
            {
                yield return new CodeInstruction(OpCodes.Pop); // pops 4
                yield return new CodeInstruction(OpCodes.Pop); // pops num
                continue;                                            // dont push bge
            }

            yield return instruction;
        }
    }

    [HarmonyPatch(typeof(GunSetter), nameof(GunSetter.ResetWeapons)), HarmonyPostfix, HarmonyBefore(AtlasLib.Plugin.Guid)]
    private static void SetWeaponIndexes()
    {
        foreach (Weapon weapon in Plugin.Weapons)
        {
            string prefString = $"weapon.{weapon.Info.Id.Substring(0, weapon.Info.Id.Length - 1)}.order";
            weapon.Info.IndexInSlot = PrefsManager.Instance.GetString(prefString).IndexOf((char)(weapon.Info.Id[weapon.Info.Id.Length - 1]));
        }
    }
}
