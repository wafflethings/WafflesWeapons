using System;
using System.IO;
using System.Reflection;
using HarmonyLib;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace WafflesWeapons.Assets;

[HarmonyPatch]
public static class AssetManager
{
    private static bool s_dontSanitizeScenes;

    // ReSharper disable once MemberCanBePrivate.Global     DO NOT MAKE THIS PRIVATE this took me 6 hours to debug
    public static string AssetPath => Path.Combine(ModFolder, "Assets");
    private static string ModFolder => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? throw new Exception("Somehow the assembly doesn't have a location. I don't think this is possible.");
    private static string CatalogPath => Path.Combine(AssetPath, "catalog_wbp.json");

    public static void LoadCatalog()
    {
        Addressables.LoadContentCatalogAsync(CatalogPath, true).WaitForCompletion();
    }

    public static void LoadSceneUnsanitzed(string path)
    {
        s_dontSanitizeScenes = true;

        try
        {
            SceneHelper.LoadScene(path);
        }
        catch (Exception ex)
        {
            // i hate using try-catch but if this isn't set back to false, every un-modded scene load will fail
            Debug.LogError(ex.ToString());
        }

        s_dontSanitizeScenes = false;
    }
    
    [Obsolete("TODO delete")]
    public static T Load<T>(string path)
    {
        return Addressables.LoadAssetAsync<T>(path).WaitForCompletion();
    }

    [HarmonyPatch(typeof(SceneHelper), nameof(SceneHelper.SanitizeLevelPath)), HarmonyPrefix]
    private static bool PreventSanitization(string scene, ref string __result)
    {
        if (s_dontSanitizeScenes)
        {
            __result = scene;
            return false;
        }

        return true;
    }
}
