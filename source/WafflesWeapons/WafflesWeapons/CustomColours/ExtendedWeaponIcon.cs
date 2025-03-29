using HarmonyLib;
using UnityEngine;

namespace WafflesWeapons.CustomColours;

[HarmonyPatch]
public class ExtendedWeaponIcon : MonoBehaviour
{
    private static readonly Color[] s_newColours =
    {
        new(0.25f, 0.5f, 1), // dblue
        new(1, 0.5f, 0.25f), // orange
        new(0.7f, 0.25f, 1)  // purp
    };
    
    public ExtendedWeaponVariant ExtendedColour;
    
    [HarmonyPatch(typeof(WeaponIcon), nameof(WeaponIcon.variationColor), MethodType.Getter), HarmonyPrefix]
    private static bool ReplaceColour(WeaponIcon __instance, ref int __result)
    {
        if (__instance.TryGetComponent(out ExtendedWeaponIcon extIcon))
        {
            __result = (int)extIcon.ExtendedColour;
            return false;
        }
            
        return true;
    }
    
    [HarmonyPatch(typeof(GunSetter), nameof(GunSetter.ResetWeapons)), HarmonyPrefix]
    private static void AddCustomColours()
    {
        ColorBlindSettings.Instance.variationColors = ColorBlindSettings.Instance.variationColors.AddRangeToArray(s_newColours);
    }
}
