using BepInEx;
using HarmonyLib;
using UnityEngine;
using AtlasLib.Pages;
using AtlasLib.Weapons;
using BepInEx.Logging;
using UnityEngine.AddressableAssets;
using WafflesWeapons.Assets;

namespace WafflesWeapons;

[BepInPlugin(Guid, Name, Version)]
[BepInDependency(AtlasLib.Plugin.Guid)]
[HarmonyPatch]
public class Plugin : BaseUnityPlugin
{
    public const string Guid = "waffle.ultrakill.extraalts";
    private const string Name = "Waffle's Weapons";
    private const string Version = "2.0.0";

    public static ManualLogSource Log;

    private void Awake()
    {
        Log = Logger;
        new Harmony(Guid).PatchAll();
        AssetManager.LoadCatalog();
        PageRegistry.RegisterPage(new BasicPage(Addressables.LoadAssetAsync<GameObject>("Assets/WafflesWeapons/Pages/WW Page.prefab").WaitForCompletion(), "Weapons Panel/Buttons"));
        WeaponRegistry.RegisterWeapons([
            new BasicWeapon(Addressables.LoadAssetAsync<WeaponInfo>("Assets/WafflesWeapons/Weapons/Revolvers/Fanfire/Fanfire Weapon Info.asset").WaitForCompletion())
        ]);
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
                Debug.Log("A weapon has been detected, disable CG ‼️");
                return false;
            }
        }

        return true;
    }
}
