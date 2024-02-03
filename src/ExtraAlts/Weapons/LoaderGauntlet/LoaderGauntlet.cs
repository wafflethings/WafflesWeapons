using AtlasLib.Utils;
using AtlasLib.Weapons;
using HarmonyLib;
using UnityEngine;
using WafflesWeapons.Assets;

namespace WafflesWeapons.Weapons.LoaderGauntlet;

[PatchThis($"{Plugin.GUID}.LoaderGauntlet")]
public class LoaderGauntlet : Weapon
{
    public static WeaponAssets Assets;
    public static LoaderBehaviour curOne;

    static LoaderGauntlet()
    {
        Assets = AddressableManager.Load<WeaponAssets>("Assets/ExtraAlts/Loader/Earthshatter Assets.asset");
    }

    public override WeaponInfo Info => Assets.GetAsset<WeaponInfo>("Info");

    [HarmonyPatch(typeof(NewMovement), nameof(NewMovement.Start))]
    [HarmonyPostfix]
    public static void AddLoaderCheck(NewMovement __instance)
    {
        __instance.gameObject.AddComponent<LoaderArmCollisionHandler>();
    }

    [HarmonyPatch(typeof(Punch), nameof(Punch.CoinFlip))]
    [HarmonyPrefix]
    public static bool CancelIfCharging(Punch __instance)
    {
        if (__instance.GetComponent<LoaderBehaviour>() != null && !__instance.holdingInput)
        {
            __instance.anim.SetTrigger("CoinFlip");
            return false;
        }

        return true;
    }

    [HarmonyPatch(typeof(Punch), nameof(Punch.PunchStart))]
    [HarmonyPrefix]
    public static bool LoaderPunch(Punch __instance)
    {
        LoaderBehaviour lb = __instance.GetComponent<LoaderBehaviour>();

        if (lb != null)
        {
            if (LoaderArmCollisionHandler.Instance.MidCharge)
            {
                return false;
            }

            if (__instance.ready)
            {
                // lb.anim.Play("Armature|ES_HookPunch", 0, 0);
                lb.Punch();
            }
        }

        return true;
    }

    [HarmonyPatch(typeof(Punch), nameof(Punch.BlastCheck))]
    [HarmonyPrefix]
    public static bool CancelBlast(Punch __instance)
    {
        LoaderBehaviour lb = __instance.GetComponent<LoaderBehaviour>();

        if (lb != null)
        {
            return false;
        }

        return true;
    }

    [HarmonyPatch(typeof(FistControl), nameof(FistControl.UpdateFistIcon))]
    [HarmonyPostfix]
    public static void FixColour(FistControl __instance)
    {
        try
        {
            if (__instance.currentArmObject.GetComponent<LoaderBehaviour>() != null)
            {
                __instance.fistIcon.color = ColorBlindSettings.Instance.variationColors[5];
            }
        }
        catch
        {
            Debug.LogError($"whar? {ColorBlindSettings.Instance.variationColors.Length}");
        }
    }

    [HarmonyPatch(typeof(Coin), nameof(Coin.Start))]
    [HarmonyPostfix]
    public static void CheckIfMadeWhenLaunching(Coin __instance)
    {
        if(LoaderArmCollisionHandler.Instance.MidCharge)
        {
            LoaderArmCollisionHandler.Instance.BadCoins.Add(__instance);
        }
    }

    [HarmonyPatch(typeof(NewMovement), nameof(NewMovement.Dodge))]
    [HarmonyPostfix]
    public static void StopOnDodge()
    {
        if (curOne != null && LoaderArmCollisionHandler.Instance != null)
        {
            LoaderArmCollisionHandler.Instance.MidCharge = false;
            curOne.anim.SetBool("Midflight", false);
        }
    }


    [HarmonyPatch(typeof(NewMovement), nameof(NewMovement.Slamdown))]
    [HarmonyPostfix]
    public static void StopOnSlam()
    {
        if (curOne != null && LoaderArmCollisionHandler.Instance != null)
        {
            LoaderArmCollisionHandler.Instance.MidCharge = false;
            curOne.anim.SetBool("Midflight", false);
        }
    }

    [HarmonyPatch(typeof(NewMovement), nameof(NewMovement.WallJump))]
    [HarmonyPostfix]
    public static void StopOnWallJump()
    {
        if (curOne != null && LoaderArmCollisionHandler.Instance != null)
        {
            LoaderArmCollisionHandler.Instance.MidCharge = false;
            curOne.anim.SetBool("Midflight", false);
        }
    }

    [HarmonyPatch(typeof(HookArm), nameof(HookArm.Update))]
    [HarmonyPostfix]
    public static void StopOnHook(HookArm __instance)
    {
        if (curOne != null && LoaderArmCollisionHandler.Instance != null && __instance.state == HookState.Caught)
        {
            LoaderArmCollisionHandler.Instance.MidCharge = false;
            curOne.anim.SetBool("Midflight", false);
        }

    }
}
