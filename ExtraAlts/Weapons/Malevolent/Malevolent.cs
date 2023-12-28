using System.Collections.Generic;
using AtlasLib.Utils;
using AtlasLib.Weapons;
using HarmonyLib;
using UnityEngine;
using WafflesWeapons.Assets;

namespace WafflesWeapons.Weapons.Malevolent
{
    [PatchThis($"{Plugin.GUID}.Malevolent")]
    public class Malevolent : Weapon
    {
        public static WeaponAssets Assets;
        
        static Malevolent()
        {
            Assets = Plugin.Assets.LoadAsset<WeaponAssets>("Malevolent Assets.asset");
        }

        public override WeaponInfo Info => Assets.GetAsset<WeaponInfo>("Info");

        [HarmonyPatch(typeof(StyleHUD), nameof(StyleHUD.DecayFreshness))]
        [HarmonyPostfix]
        public static void StyleMult(StyleHUD __instance, GameObject sourceWeapon, string pointID, bool boss)
        {
            if (sourceWeapon.GetComponent<MalevolentBehaviour>() != null)
            {
                var dict = __instance.weaponFreshness;
                if (!dict.ContainsKey(sourceWeapon))
                {
                    return;
                }
                float num = __instance.freshnessDecayPerMove;
                if (__instance.freshnessDecayMultiplierDict.ContainsKey(pointID))
                {
                    num *= __instance.freshnessDecayMultiplierDict[pointID];
                }
                if (boss)
                {
                    num *= __instance.bossFreshnessDecayMultiplier;
                }

                if(pointID == "ultrakill.explosionhit")
                {
                    num *= 0.33f;
                } else
                {
                    num *= 0.5f;
                }

                __instance.AddFreshness(sourceWeapon, num);
            }
        }

        public static List<MalevolentBehaviour> Guns = new List<MalevolentBehaviour>();

        [HarmonyPatch(typeof(Revolver), nameof(Revolver.Update))]
        [HarmonyPrefix] // i blame hakita
        public static bool AAAAAAAAAAAAAAAA(Revolver __instance)
        {
            return __instance.gunVariation != 5;
        }
    }
}
