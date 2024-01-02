using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AtlasLib.Utils;
using HarmonyLib;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

namespace WafflesWeapons.Assets
{
    [PatchThis($"{Plugin.GUID}.AddressableManager")]
    public static class AddressableManager
    {
        public static string AssetPathLocation => "{" + $"{typeof(AddressableManager).FullName}.{nameof(AssetPath)}" + "}"; //should eval to "{EndlessDelivery.Assets.AddressableManager.AssetPath}"
        public static string MonoScriptBundleName => "monoscript_wafflesweapons_monoscripts.bundle";
        
        public static string AssetPath => Path.Combine(PathUtils.ModPath(), "Assets");
        public static string CatalogPath => Path.Combine(AssetPath, "catalog.json");
        
        public static void Setup()
        {
            Addressables.LoadContentCatalogAsync(CatalogPath, true).WaitForCompletion();
        }

        public static T Load<T>(string path)
        {
            return Addressables.LoadAssetAsync<T>(path).WaitForCompletion();
        }
    }
}
