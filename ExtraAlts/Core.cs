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

namespace WafflesWeapons
{
    [BepInPlugin("waffle.ultrakill.extraalts", "Waffle's Weapons", "1.0.1")]
    public class Core : BaseUnityPlugin
    {
        public static Harmony Harmony = new Harmony("waffle.ultrakill.extraalts");
        public static AssetBundle Assets;

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

            TerminalPageRegistry.RegisterPage(typeof(CustomsPage));
            //TerminalPageRegistry.RegisterPage(typeof(ExtrasPage));

            FanFire.LoadAssets();
            GunRegistry.Register(new FanFire());

            Malevolent.LoadAssets();
            GunRegistry.Register(new Malevolent());

            Airblast.LoadAssets();
            GunRegistry.Register(new Airblast());

            LoaderGauntlet.LoadAssets();
            GunRegistry.Register(new LoaderGauntlet());

            Virtuous.LoadAssets();
            GunRegistry.Register(new Virtuous());

            Sticky.LoadAssets();
            GunRegistry.Register(new Sticky());

            TacticalNuke.LoadAssets();
            GunRegistry.Register(new TacticalNuke());

            Mindrender.LoadAssets();
            GunRegistry.Register(new Mindrender());

            Desperado.LoadAssets();
            GunRegistry.Register(new Desperado());

            Singularity.LoadAssets();
            GunRegistry.Register(new Singularity());

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

        public static GameObject page;
        public static GameObject tip;

        [HarmonyPatch(typeof(ShopZone), nameof(ShopZone.Start))]
        [HarmonyPrefix]
        public static void AddCredits(ShopZone __instance)
        {
            if (__instance.gameObject.ChildByName("Canvas").ChildByName("Weapons") != null)
            {
                tip = __instance.gameObject.ChildByName("Canvas").ChildByName("TipBox");
                page = GameObject.Instantiate(Assets.LoadAsset<GameObject>("ExtraAlts Credits.prefab"));
                page.transform.SetParent(__instance.gameObject.ChildByName("Canvas").transform, false);
                page.transform.SetSiblingIndex(10);
            }
        }

        [HarmonyPatch(typeof(ShopZone), nameof(ShopZone.Update))]
        [HarmonyPrefix]
        public static void ToggleCredits(ShopZone __instance)
        {
            if (page != null)
            {
                page.SetActive(tip.activeSelf);
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

        [HarmonyPatch(typeof(GunSetter), nameof(GunSetter.Start))]
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

        [HarmonyPatch(typeof(WeaponIcon), nameof(WeaponIcon.variationColor), MethodType.Getter)]
        [HarmonyPrefix]
        public static bool ReplaceColour(WeaponIcon __instance, ref int __result)
        {
            if (__instance.GetComponent<CustomColour>() != null)
            {
                __result = (int)__instance.GetComponent<CustomColour>().variationColorReal;
                return false;
            }
            return true;
        }

        [HarmonyPatch(typeof(WeaponOrderController), nameof(WeaponOrderController.ChangeOrderNumber))]
        [HarmonyPrefix]
        public static bool ExtendOrderNumbers(WeaponOrderController __instance, int additive)
        {
            string[] legalVariations = { "rev", "sho", "nai", "rai", "rock" };

            if (legalVariations.Contains(__instance.variationName))
            {
                int newCount = __instance.currentOrderNumber + additive;
                if (newCount > 0 && newCount < 8)
                {
                    for (int i = 0; i < __instance.variationOrder.Length; i++)
                    {
                        if ((__instance.variationOrder[i] - '0') == newCount)
                        {
                            __instance.variationOrder = __instance.variationOrder.Replace(__instance.variationOrder[i], __instance.variationOrder[__instance.variationNumber]);
                        }
                    }
                    __instance.variationOrder = __instance.variationOrder.Remove(__instance.variationNumber, 1);
                    __instance.variationOrder = __instance.variationOrder.Insert(__instance.variationNumber, newCount.ToString());
                    PrefsManager.Instance.SetString($"weapon.{__instance.variationName}.order", __instance.variationOrder.Substring(0, 4));
                    PrefsManager.Instance.SetString($"weapon.{__instance.variationName}.order_secondhalf", __instance.variationOrder.Substring(4, 3));
                    WeaponOrderController[] componentsInChildren = __instance.transform.parent.parent.parent.GetComponentsInChildren<WeaponOrderController>();
                    for (int j = 0; j < componentsInChildren.Length; j++)
                    {
                        componentsInChildren[j].ResetValues();
                    }
                    GunSetter gunSetter = Object.FindObjectOfType<GunSetter>();
                    gunSetter.ResetWeapons(false);
                }

                return false;
            }

            return true;
        }

        [HarmonyPatch(typeof(WeaponOrderController), nameof(WeaponOrderController.ResetValues))]
        [HarmonyPrefix]
        public static bool ResetSecondHalf(WeaponOrderController __instance)
        {
            string[] legalVariations = { "rev", "sho", "nai", "rai", "rock" };

            if (legalVariations.Contains(__instance.variationName))
            {
                if (!__instance.text)
                {
                    __instance.text = __instance.GetComponentInChildren<Text>();
                }

                if (__instance.revolver)
                {
                    __instance.variationOrder = PrefsManager.Instance.GetString($"weapon.{__instance.variationName}.order", "1324");
                }
                else
                {
                    __instance.variationOrder = PrefsManager.Instance.GetString($"weapon.{__instance.variationName}.order", "1234");
                }
                __instance.variationOrder += PrefsManager.Instance.GetString($"weapon.{__instance.variationName}.order_secondhalf", "567");

                __instance.currentOrderNumber = (__instance.variationOrder[__instance.variationNumber] - '0');
                __instance.text.text = (__instance.variationOrder[__instance.variationNumber].ToString() ?? "");
                Debug.Log("Order in WeaponOrderController: " + __instance.variationOrder);

                return false;
            }

            return true;
        }

        [HarmonyPatch(typeof(GunSetter), nameof(GunSetter.CheckWeaponOrder))]
        [HarmonyPrefix]
        public static bool CheckOrderFixer(string weaponType, ref List<int> __result)
        {
            string[] legalVariations = { "rev", "sho", "nai", "rai", "rock" };

            if (legalVariations.Contains(weaponType))
            {
                string defaultSlots = "1234567";
                if (weaponType == "rev")
                {
                    defaultSlots = "1324567";
                }

                string slots = PrefsManager.Instance.GetString($"weapon.{weaponType}.order", defaultSlots.Substring(0, 4));
                slots += PrefsManager.Instance.GetString($"weapon.{weaponType}.order_secondhalf", defaultSlots.Substring(4, 3));

                if (slots.Length != 7)
                {
                    Debug.LogError("Faulty WeaponOrder: " + weaponType);
                    slots = defaultSlots;
                    PrefsManager.Instance.SetString($"weapon.{weaponType}.order", defaultSlots.Substring(0, 4));
                    PrefsManager.Instance.SetString($"weapon.{weaponType}.order_secondhalf", defaultSlots.Substring(4, 3));
                }

                List<int> list = new List<int>();
                for (int i = 0; i < slots.Length; i++)
                {
                    list.Add((slots[i] - '0'));
                }
                __result = list;

                return false;
            }

            return true;
        }
    }
}
