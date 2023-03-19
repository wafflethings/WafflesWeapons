using Atlas.Modules.Guns;
using Atlas.Modules.Terminal;
using BepInEx;
using WafflesWeapons.Pages;
using WafflesWeapons.Weapons;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace WafflesWeapons
{
    [BepInPlugin("waffle.ultrakill.extraalts", "Waffle's Weapons", "1.0.0")]
    public class Core : BaseUnityPlugin
    {
        public static Harmony Harmony = new Harmony("waffle.ultrakill.extraalts");
        public static AssetBundle Assets;
        public static Core Instance;

        public static Color[] NewColours =
        {
            new Color(0.25f, 0.5f, 1), // dblue
            new Color(1, 0.5f, 0.25f), // orange
            new Color(0.7f, 0.25f, 1)  // purp
        };

        public void Start()
        {
            Assets = AssetBundle.LoadFromFile(Path.Combine(PathUtils.ModPath(), "redrevolver.bundle"));
            Harmony.PatchAll(typeof(Core));

            Instance = this;

            TerminalPageRegistry.RegisterPage(typeof(CustomsPage));

            FanFire.LoadAssets();
            GunRegistry.Register(typeof(FanFire));

            Malevolent.LoadAssets();
            GunRegistry.Register(typeof(Malevolent));

            Airblast.LoadAssets();
            GunRegistry.Register(typeof(Airblast));

            LoaderGauntlet.LoadAssets();
            GunRegistry.Register(typeof(LoaderGauntlet));

            Virtuous.LoadAssets();
            GunRegistry.Register(typeof(Virtuous));

            Sticky.LoadAssets();
            GunRegistry.Register(typeof(Sticky));

            TacticalNuke.LoadAssets();
            GunRegistry.Register(typeof(TacticalNuke));
        }

        [HarmonyPatch(typeof(ShopZone), nameof(ShopZone.Start))]
        [HarmonyPrefix]
        public static void AddCredits(ShopZone __instance)
        {
            if (__instance.gameObject.ChildByName("Canvas").ChildByName("Weapons") != null)
            {
                GameObject page = GameObject.Instantiate(Assets.LoadAsset<GameObject>("ExtraAlts Credits.prefab"));
                page.transform.SetParent(__instance.gameObject.ChildByName("Canvas").transform, false);
                page.transform.SetSiblingIndex(10);
            }
        }

        [HarmonyPatch(typeof(GunSetter), nameof(GunSetter.ResetWeapons))]
        [HarmonyPrefix]
        public static void AddCustomColours()
        {
            var col = ColorBlindSettings.Instance;
            var SillyList = col.variationColors.ToList(); // :3
            SillyList.AddRange(NewColours);

            col.variationColors = SillyList.ToArray();
        }

        [HarmonyPatch(typeof(NewMovement), nameof(NewMovement.Start))]
        [HarmonyPrefix]
        public static void FixCharges()
        {
            WeaponCharges.Instance.revaltpickupcharges = new float[7];
        }

        [HarmonyPatch(typeof(Nailgun), nameof(Nailgun.Start))]
        [HarmonyPostfix]
        public static void AddNailProj(Nailgun __instance)
        {
            __instance.projectileVariationTypes = new string[] {
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
    }
}
