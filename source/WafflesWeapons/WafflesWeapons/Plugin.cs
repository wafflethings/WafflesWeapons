using System.Collections.Generic;
using BepInEx;
using HarmonyLib;
using UnityEngine;
using AtlasLib.Pages;
using AtlasLib.Weapons;
using BepInEx.Logging;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;
using WafflesWeapons.Assets;
using WafflesWeapons.Weapons.Revolvers.Fanfire;

namespace WafflesWeapons;

[BepInPlugin(Guid, Name, Version)]
[BepInDependency(AtlasLib.Plugin.Guid)]
[HarmonyPatch]
public class Plugin : BaseUnityPlugin
{
    public const string Guid = "waffle.ultrakill.extraalts";
    public const string Name = "Waffle's Weapons";
    private const string Version = "2.0.0";

    public static ManualLogSource Log;
    public static List<Weapon> Weapons = new();

    private void Awake()
    {
        Log = Logger;
        
        new Harmony(Guid).PatchAll();
        AssetManager.LoadCatalog();

        Weapons.AddRange([
            new BasicWeapon(Addressables.LoadAssetAsync<WeaponInfo>("Assets/WafflesWeapons/Weapons/Revolvers/Fanfire/Fanfire Weapon Info.asset").WaitForCompletion()),
            new BasicWeapon(Addressables.LoadAssetAsync<WeaponInfo>("Assets/WafflesWeapons/Weapons/Revolvers/Malevolent/Malevolent Weapon Info.asset").WaitForCompletion()),
            new BasicWeapon(Addressables.LoadAssetAsync<WeaponInfo>("Assets/WafflesWeapons/Weapons/Revolvers/Desperado/Desperado Weapon Info.asset").WaitForCompletion()),
            
            new BasicWeapon(Addressables.LoadAssetAsync<WeaponInfo>("Assets/WafflesWeapons/Weapons/Shotguns/Singularity/Singularity Weapon Info.asset").WaitForCompletion()),
            
            new BasicWeapon(Addressables.LoadAssetAsync<WeaponInfo>("Assets/WafflesWeapons/Weapons/Railcannons/Virtuous/Virtuous Weapon Info.asset").WaitForCompletion()),
        ]);
        
        if (!PatcherCheck())
        {
            SceneManager.sceneLoaded += ShowError;
            return;
        }
        
        WeaponRegistry.RegisterWeapons(Weapons);
        PageRegistry.RegisterPage(new BasicPage(Addressables.LoadAssetAsync<GameObject>("Assets/WafflesWeapons/Pages/WW Page.prefab").WaitForCompletion(), "Weapons Panel/Buttons"));
    }

    private void ShowError(Scene scene, LoadSceneMode mode)
    {
        if (SceneHelper.CurrentScene != "Main Menu")
        {
            return;
        }
        
        HudMessageReceiver.Instance.SendHudMessage($"{Name} will not load. Ensure all dependencies are installed correctly.");
        SceneManager.sceneLoaded -= ShowError;
    }
    
    private bool PatcherCheck() => Weapons[0].Info.WeaponObjects[0].GetComponent<FanfireBehaviour>().ChargeShotModule != null; // serialization will fail and itll be null if missing FPTS

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
