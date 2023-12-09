using BepInEx;
using WafflesWeapons.Pages;
using WafflesWeapons.Weapons;
using HarmonyLib;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Atlas.Modules.Terminal;
using Atlas.Modules.Guns;
using WafflesWeapons.Components;
using WafflesWeapons.Utils;

namespace WafflesWeapons
{
    [BepInPlugin("waffle.ultrakill.extraalts", "Waffle's Weapons", "1.2.4")]
    public class Core : BaseUnityPlugin
    {
        public static readonly Harmony Harmony = new Harmony("waffle.ultrakill.extraalts");
        public static readonly AssetBundle Assets = AssetBundle.LoadFromFile(Path.Combine(PathUtils.ModPath(), "redrevolver.bundle"));

        private static readonly Color[] _newColours =
        {
            new Color(0.25f, 0.5f, 1), // dblue
            new Color(1, 0.5f, 0.25f), // orange
            new Color(0.7f, 0.25f, 1)  // purp
        };

        public void Start()
        {
            Harmony.PatchAll(typeof(Core));

            TerminalPageRegistry.RegisterPage(typeof(CustomsPage));
            //TerminalPageRegistry.RegisterPage(typeof(ExtrasPage));

            GunRegistry.Register(new FanFire());
            GunRegistry.Register(new Malevolent());
            GunRegistry.Register(new Desperado());

            GunRegistry.Register(new Sticky());
            GunRegistry.Register(new Singularity());

            GunRegistry.Register(new Conductor());
            GunRegistry.Register(new Mindrender());

            GunRegistry.Register(new Virtuous());

            GunRegistry.Register(new EepyCharger());

            GunRegistry.Register(new FerryOar());
            GunRegistry.Register(new LoaderGauntlet());

            Harmony.PatchAll(typeof(WaffleWeaponCharges));
        }

        [HarmonyPatch(typeof(LeaderboardController), nameof(LeaderboardController.SubmitCyberGrindScore))]
        [HarmonyPatch(typeof(LeaderboardController), nameof(LeaderboardController.SubmitLevelScore))]
        [HarmonyPrefix]
        public static bool DisableCG()
        {
            foreach (Weapon weapon in GunRegistry.WeaponList)
            {
                if (weapon.Enabled() > 0)
                {
                    Debug.Log("A weapon has been detected, disable CG ‼️");
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
                GameObject page = Instantiate(Assets.LoadAsset<GameObject>("ExtraAlts Credits.prefab"), shopObject.GetChild("Canvas").transform);
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
    }
}
