using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtlasLib.Weapons;
using WafflesWeapons.Assets;
using Newtonsoft.Json;
using UnityEditor;
using UnityEditor.AddressableAssets;
using UnityEditor.AddressableAssets.Settings;
using UnityEditor.AddressableAssets.Settings.GroupSchemas;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

namespace Assets.Editor 
{
	public static class BuildAssetBundles 
	{
		public const string RESULT_PATH = "Built Bundles";

		private static void LoadAndReplaceDefaultAssets()
        {
			string scenePath = "Assets" + "\\" + "Scenes";
			string active = scenePath + "\\" + SceneManager.GetActiveScene().name + ".unity";

			foreach (string scene in Directory.GetFiles(scenePath).Where(path => path.EndsWith(".unity")))
			{
				Debug.Log(SceneManager.GetActiveScene().name);
				EditorSceneManager.OpenScene(scene);

				ReplaceDefaultAssets(false);
				EditorSceneManager.SaveOpenScenes();
				EditorSceneManager.CloseScene(SceneManager.GetActiveScene(), false);
			}
			ReplaceDefaultAssets(true);

			EditorSceneManager.OpenScene(active);
		}

		private static void ReplaceDefaultAssets(bool doPrefabsInsteadOfScene)
		{
			Debug.Log("Looking for default assets to replace...");

			var unityBuiltInPath = "Resources/unity_builtin_extra";
			var tundraResourcesPath = "Assets/Core/BuiltInResources";

			var knownBaseTypes = new List<Type> { typeof(Renderer) };

			var sw = new System.Diagnostics.Stopwatch();
			sw.Start();

			// Collect all relevant components in scene
			var relevantComponents = new List<Component>();

			if (doPrefabsInsteadOfScene)
			{
				// Load all non-scene assets
				Resources.LoadAll("Crypt_Assets");
				Resources.LoadAll("ULTRAKILL Prefabs");
				var rootObjects = Resources.FindObjectsOfTypeAll<GameObject>().Where(go => !EditorUtility.IsPersistent(go.transform.root.gameObject) && go.hideFlags != HideFlags.HideAndDontSave && go.hideFlags != HideFlags.NotEditable).ToArray();

				foreach (var rootObject in rootObjects)
				{
					var components = rootObject.GetComponentsInChildren<Component>(true);
					foreach (var component in components)
					{
						if (component == null) continue;

						var componentType = component.GetType();

						if (knownBaseTypes.Any(baseType => baseType.IsAssignableFrom(componentType)))
						{
							relevantComponents.Add(component);
						}
					}
				}
			}
			else
			{
				var rootObjects = Resources.FindObjectsOfTypeAll<GameObject>().Where(go => EditorUtility.IsPersistent(go.transform.root.gameObject) && go.hideFlags != HideFlags.HideAndDontSave && go.hideFlags != HideFlags.NotEditable).ToArray();

				foreach (var rootObject in rootObjects)
				{
					var components = rootObject.GetComponentsInChildren<Component>(true);
					foreach (var component in components)
					{
						if (component == null) continue;

						var componentType = component.GetType();

						if (knownBaseTypes.Any(baseType => baseType.IsAssignableFrom(componentType)))
						{
							relevantComponents.Add(component);
						}
					}
				}
			}

			Debug.Log($"Found {relevantComponents.Count} relevant components");

			var replaced = 0;
			foreach (var component in relevantComponents)
			{
				if (component is Renderer renderer)
				{
					var materials = renderer.sharedMaterials;
					for (var i = 0; i < materials.Length; i++)
					{
						var material = materials[i];
						if (material == null) continue;
						// Check if material is a built-in resource
						var ownPath = AssetDatabase.GetAssetPath(material);
						if (!ownPath.StartsWith(unityBuiltInPath)) continue;

						Debug.Log($"Found built-in material: {ownPath}/{material.name}");

						// Create duplicate or reuse duplicate
						var duplicatePath = $"{tundraResourcesPath}/{material.name}.asset";
						var duplicate = AssetDatabase.LoadAssetAtPath<Material>(duplicatePath);
						if (duplicate == null)
						{
							Debug.Log($"Creating duplicate: {duplicatePath}");
							duplicate = new Material(material);
							AssetDatabase.CreateAsset(duplicate, duplicatePath);
						}
						else
						{
							Debug.Log($"Reusing duplicate: {duplicatePath}");
						}

						// Replace material
						materials[i] = duplicate;
						renderer.sharedMaterials = materials;
						replaced++;

						EditorUtility.SetDirty(renderer);

					}
				}
			}

			sw.Stop();
			Debug.Log($"Replaced {replaced} default assets in {sw.Elapsed.TotalSeconds:0.00} seconds");

			// Ensure changes submitted before build
			AssetDatabase.SaveAssets();
			Resources.UnloadUnusedAssets();
		}

		[MenuItem("Ultracrypt Extensions/Build AssetBundles")]
		public static void Build()
		{
			if (!Directory.Exists(RESULT_PATH))
			{
				Directory.CreateDirectory(RESULT_PATH);
			}

			// Save Data Info
			Dictionary<string, List<string>> dataInfo = new Dictionary<string, List<string>>();
			AddData<WeaponInfo>(dataInfo);
			
			ValidateAddressables();
			AddBundles();

			using (StreamWriter writer = new StreamWriter(File.Create($"{RESULT_PATH}/weapons.json")))
			{
				JsonSerializer serializer = new JsonSerializer();
				serializer.Serialize(new JsonTextWriter(writer) { Formatting = Formatting.Indented }, dataInfo);
			}

			Debug.LogWarning($"BUNDLE DATA: {AddressableManager.MonoScriptBundleName} {AddressableManager.AssetPathLocation}");
			AddressableAssetSettings.BuildPlayerContent();
			
			// afaik you cant change the monoscript bundle load path, so you have to edit the catalog :3
			// fucking kill me, but we ball
			string libAddressables = Application.dataPath + "/../Library/com.unity.addressables/aa/Windows";
			string defaultPath = "{UnityEngine.AddressableAssets.Addressables.RuntimePath}";
			string monoscriptPath = $@"{defaultPath}\\{EditorUserBuildSettings.activeBuildTarget}\\{AddressableManager.MonoScriptBundleName}";
			string newMonoscript = $@"{AddressableManager.AssetPathLocation}\\{AddressableManager.MonoScriptBundleName}";
			string catalog = File.ReadAllText(Path.Combine(libAddressables, "catalog.json"));
			catalog = catalog.Replace(monoscriptPath, newMonoscript);
			File.WriteAllText(Path.Combine(RESULT_PATH, "catalog.json"), catalog);

			if (Directory.Exists(Path.Combine(libAddressables, "StandaloneWindows")))
			{
				EditorUtility.DisplayDialog("Switch version", "You need to be on _x86_64 in build settings or addressables won't work.", "ok","also ok");
			}

			File.Copy(Path.Combine(libAddressables, "StandaloneWindows64", AddressableManager.MonoScriptBundleName), Path.Combine(RESULT_PATH, AddressableManager.MonoScriptBundleName), true);
		}

		private static void AddData<T>(Dictionary<string, List<string>> dataInfo) where T : UnityEngine.Object
		{
			List<string> value =
							FindAllPathsForFilesOfType<T>()
							.Select((path) => path.Replace('\\', '/'))
							.ToList();
			dataInfo.Add(typeof(T).FullName, value);
		}
		
		private static IEnumerable<string> FindAllPathsForFilesOfType<T>() where T : UnityEngine.Object
		{
			foreach (string path in Directory.GetFiles(Application.dataPath, "*.asset", SearchOption.AllDirectories))
			{
				string unityVersionWorkingDirectory = Directory.GetCurrentDirectory().Replace("\\", "/");
				string realPath = Path.Combine(path.Replace("\\", "/").Replace(unityVersionWorkingDirectory + "/", ""));
				Type type = AssetDatabase.LoadAssetAtPath<ScriptableObject>(realPath)?.GetType();

				if (type == typeof(T))
				{
					yield return realPath;
				}
			}
		}
		
		private static void AddBundles()
		{
			var settings = AddressableAssetSettingsDefaultObject.Settings;
			settings.IgnoreUnsupportedFilesInBuild = true;
			settings.OverridePlayerVersion = string.Empty;
			settings.BuildRemoteCatalog = false;
			settings.MonoScriptBundleCustomNaming = AddressableManager.MonoScriptBundleName.Replace("_monoscripts.bundle", string.Empty);

			AssetDatabase.RemoveUnusedAssetBundleNames();
			foreach (string bundle in AssetDatabase.GetAllAssetBundleNames())
			{
				settings.RemoveGroup(settings.FindGroup(bundle));
				var group = settings.CreateGroup(bundle, false, false, false, null, typeof(BundledAssetGroupSchema));

				var groupSchema = group.GetSchema<BundledAssetGroupSchema>();
				groupSchema.IncludeInBuild = true;
				groupSchema.IncludeAddressInCatalog = true;
				groupSchema.BuildPath.SetVariableByName(settings, "RemoteBuildPath");
				groupSchema.LoadPath.SetVariableByName(settings, "RemoteLoadPath");
				groupSchema.BundleNaming = BundledAssetGroupSchema.BundleNamingStyle.NoHash;
				groupSchema.UseAssetBundleCrcForCachedBundles = false;
				groupSchema.UseAssetBundleCrc = false;

				group.Settings.profileSettings.SetValue(group.Settings.activeProfileId, "RemoteBuildPath", "Built Bundles");
				group.Settings.profileSettings.SetValue(group.Settings.activeProfileId, "RemoteLoadPath", AddressableManager.AssetPathLocation);

				foreach (string path in AssetDatabase.GetAssetPathsFromAssetBundle(bundle))
				{
					settings.CreateOrMoveEntry(AssetDatabase.AssetPathToGUID(path), group, false, true);
				}
			}
		}
		
		//Core/blob/master/Editor/TundraInit.cs
		public static void ValidateAddressables(bool forceRewrite = false)
		{
			// TODO check the content
			var templatePostfix = ".template";
			var metaPostfix = ".meta";
        
			var assetPath = "Assets/AddressableAssetsData/AddressableAssetSettings.asset";
			var assetTemplatePath = assetPath + templatePostfix;
        
			var metaPath = assetPath + metaPostfix;
			var metaTemplatePath = assetPath + metaPostfix + templatePostfix;
        
			var valid = File.Exists(assetPath);

			if (!valid || forceRewrite)
			{
				Debug.Log($"Rewriting Addressables: {assetPath}");
				File.Copy(assetTemplatePath, assetPath, true);
				File.Copy(metaTemplatePath, metaPath, true);
				// Mark the asset database as dirty to force a refresh
				AssetDatabase.ImportAsset(assetPath, ImportAssetOptions.ForceUpdate);
				AddressableAssetSettingsDefaultObject.Settings = AssetDatabase.LoadAssetAtPath<AddressableAssetSettings>(assetPath);
			}
		}
	}
}