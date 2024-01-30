using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AtlasLib.Utils;
using AtlasLib.Weapons;
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
        public static string WeaponsPath => Path.Combine(AssetPath, "weapons.json");
        public static string CatalogPath => Path.Combine(AssetPath, "catalog.json");
        
        public static void Setup()
        {
            Addressables.LoadContentCatalogAsync(CatalogPath, true).WaitForCompletion();
            LoadDataFile();
        }

        public static T Load<T>(string path)
        {
            return Addressables.LoadAssetAsync<T>(path).WaitForCompletion();
        }
        
        private static void LoadDataFile()
        {
            Dictionary<string, List<string>> data = null;
            using (StreamReader reader = new(File.OpenRead(WeaponsPath)))
            {
                JsonSerializer serializer = new();
                data = serializer.Deserialize<Dictionary<string, List<string>>>(new JsonTextReader(reader));
            }

            RegisterWeapons(GetDataOfType<WeaponInfo>(data));
        }
        
        private static IEnumerable<T> GetDataOfType<T>(Dictionary<string, List<string>> data) where T : UnityEngine.Object
        {
            if (!data.ContainsKey(typeof(T).FullName))
                return Array.Empty<T>(); //Prevent index out of range tbh

            return data[typeof(T).FullName].Select(Load<T>);
        }
        
        private static void RegisterWeapons(IEnumerable<WeaponInfo> weapons)
        {
            foreach (WeaponInfo weapon in weapons)
            {
                WeaponRegistry.Register(new BasicWeapon(weapon));
            }
        }
    }
}
