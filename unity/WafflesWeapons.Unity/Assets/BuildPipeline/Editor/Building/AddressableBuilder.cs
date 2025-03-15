using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEditor.AddressableAssets;
using UnityEditor.AddressableAssets.Build;
using UnityEditor.AddressableAssets.Settings;
using UnityEditor.AddressableAssets.Settings.GroupSchemas;
using UnityEngine;

namespace BuildPipeline.Editor.Building
{
	public static class AddressableBuilder
	{
		//AssetPathLocation needs to lead to a getter that returns the path where you store all your bundles in the mod.
		public const string AssetPathLocation = "{TemplateMod.Assets.AssetManager.AssetPath}";
		private const string MonoscriptBundleNaming = "templatemod";
		private const string WbpTemplateName = "WBP Assets";
		private const string CatalogPostfix = "wbp";
		private const string EmptyGroupName = "Empty Dont Delete";
		private const string EmptyAssetPath = "Assets/BuildPipeline/Assets/Empty.png";
		
		private static AddressableAssetSettings Settings => AddressableAssetSettingsDefaultObject.Settings;
		
		//TODO make configurable
		private static string s_buildPath = "Built Bundles";
		public static readonly string[] CommonGroupNames = { "Assets", "Game Prefabs", "Music", "Other" };

		public static void Build(BuildMode buildMode)
		{
			ValidateAddressables();
			SetCorrectValuesForSettings();
			CreateEmptyGroup();
			SetDefaultValuesForSchemas();

			if (!Directory.Exists(s_buildPath))
			{
				Directory.CreateDirectory(s_buildPath);
			}

			buildMode.PreBuild(s_buildPath, Settings);
			AddressableAssetSettings.BuildPlayerContent(out AddressablesPlayerBuildResult result);
			buildMode.PostBuild(s_buildPath, Settings);
			
			if (!string.IsNullOrEmpty(result.Error))
			{
				throw new System.Exception(result.Error);
			}
			
			ReplaceBuiltInWithEmpty();
		}
		
		public static void RefreshGroups()
		{
			EditorUtility.SetDirty(Settings);
			AssetDatabase.SaveAssets();
			AssetDatabase.Refresh();
			string assetPath = "Assets/AddressableAssetsData/AddressableAssetSettings.asset";
			AssetDatabase.ImportAsset(assetPath, ImportAssetOptions.ForceUpdate);
			AddressableAssetSettingsDefaultObject.Settings = AssetDatabase.LoadAssetAtPath<AddressableAssetSettings>(assetPath);
		}

		[InitializeOnLoadMethod]
        private static void CreateCustomTemplateOnLoad()
        {
            EditorApplication.delayCall += EnsureCustomTemplateExists;
        }

		private static void EnsureCustomTemplateExists()
		{
			foreach (ScriptableObject so in Settings.GroupTemplateObjects)
			{
				if ((bool)so && so.name == WbpTemplateName)
				{
					return;
				}
			}

			if (!Settings.CreateAndAddGroupTemplate(WbpTemplateName, "Assets for Waffle's Build Pipeline.", typeof(BundledAssetGroupSchema)))
			{
				Debug.LogError($"Failed to create the '{WbpTemplateName}' template, whar?");
				return;
			}

			AddressableAssetGroupTemplate wbpAssetsTemplate = Settings.GroupTemplateObjects[Settings.GroupTemplateObjects.Count - 1] as AddressableAssetGroupTemplate;

			if ((bool)wbpAssetsTemplate && wbpAssetsTemplate.Name != WbpTemplateName)
			{
				Debug.LogError($"Somehow got wrong template, this shouldn't be possible? [got {wbpAssetsTemplate.name}]");
				return;
			}

			BundledAssetGroupSchema groupSchema = wbpAssetsTemplate.GetSchemaByType(typeof(BundledAssetGroupSchema)) as BundledAssetGroupSchema;

			if (!(bool)groupSchema)
			{
				Debug.LogError("Getting the schema from the template is null?");
				return;
			}

			SetDefaultWbpValuesForSchema(groupSchema);
		}
		
		// TundraEditor: Core/Editor/TundraInit.cs
        // thanks pitr i stole this completely ;3
        private static void ValidateAddressables(bool forceRewrite = false)
        {
            const string templatePostfix = ".template";
            const string metaPostfix = ".meta";
            const string assetPath = "Assets/AddressableAssetsData/AddressableAssetSettings.asset";
            const string assetTemplatePath = assetPath + templatePostfix;
            const string metaPath = assetPath + metaPostfix;
            const string metaTemplatePath = assetPath + metaPostfix + templatePostfix;

            bool valid = File.Exists(assetPath);

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
        
        private static void SetCorrectValuesForSettings()
        {
            Settings.profileSettings.CreateValue("ModBuildPath", s_buildPath);
            Settings.profileSettings.CreateValue("ModLoadPath", AssetPathLocation);
            Settings.profileSettings.SetValue(Settings.activeProfileId, "ModBuildPath", s_buildPath);
            Settings.profileSettings.SetValue(Settings.activeProfileId, "ModLoadPath", AssetPathLocation);

            Settings.IgnoreUnsupportedFilesInBuild = true;
            Settings.OverridePlayerVersion = CatalogPostfix;
            Settings.BuildRemoteCatalog = true;
            Settings.RemoteCatalogBuildPath.SetVariableByName(Settings, "ModBuildPath");
            Settings.RemoteCatalogLoadPath.SetVariableByName(Settings, "ModLoadPath");
            Settings.MonoScriptBundleNaming = MonoScriptBundleNaming.Custom;
            Settings.MonoScriptBundleCustomNaming = MonoscriptBundleNaming;
            Settings.ShaderBundleNaming = ShaderBundleNaming.Custom;
            Settings.ShaderBundleCustomNaming = "shader";
        }
        
        private static void ReplaceBuiltInWithEmpty()
        {
            string emptyPath = Path.Combine(s_buildPath, $"{EmptyGroupName.Replace(" ", "").ToLower()}_assets_all.bundle");
            string shaderPath = Path.Combine(s_buildPath, $"{Settings.ShaderBundleCustomNaming}_unitybuiltinshaders.bundle");
            File.Delete(shaderPath);
            File.Move(emptyPath, shaderPath);
        }

        private static void SetDefaultValuesForSchemas()
        {
	        foreach (AddressableAssetGroup group in Settings.groups)
	        {
		        BundledAssetGroupSchema schema = group.GetSchema<BundledAssetGroupSchema>();

		        if (schema == null)
		        {
			        continue;
		        }
				
		        if (CommonGroupNames.Contains(group.name))
		        {
			        SetDefaultCommonValuesForSchema(schema);
			        continue;
		        }
		        SetDefaultWbpValuesForSchema(schema);
	        }
        }

		private static void SetDefaultWbpValuesForSchema(BundledAssetGroupSchema groupSchema)
		{
			SetCorrectValuesForSettings(); //if this isnt done then modbuildpath/loadpath may not exist and it will be empty

			groupSchema.IncludeInBuild = true;
			groupSchema.IncludeAddressInCatalog = true;
			groupSchema.BuildPath.SetVariableByName(Settings, "ModBuildPath");
			groupSchema.LoadPath.SetVariableByName(Settings, "ModLoadPath");
			groupSchema.BundleNaming = BundledAssetGroupSchema.BundleNamingStyle.NoHash;
			groupSchema.UseAssetBundleCrcForCachedBundles = false;
			groupSchema.UseAssetBundleCrc = false;
			EditorUtility.SetDirty(groupSchema.Group);
		}
		
		// taken from tundra core MapExport.ExportMap()
		private static void SetDefaultCommonValuesForSchema(BundledAssetGroupSchema groupSchema)
		{
			groupSchema.BuildPath.SetVariableByName(Settings, "LocalBuildPath");
			groupSchema.LoadPath.SetVariableByName(Settings, "LocalLoadPath");
			groupSchema.IncludeInBuild = true;
			groupSchema.IncludeAddressInCatalog = true;
			groupSchema.IncludeLabelsInCatalog = true;
			groupSchema.IncludeGUIDInCatalog = true;
			EditorUtility.SetDirty(groupSchema.Group);
		}

		private static void CreateEmptyGroup()
		{
			if (Settings.groups.Any(x => x.name == EmptyGroupName))
			{
				return;
			}

			AddressableAssetGroup group = Settings.CreateGroup(EmptyGroupName, false, false, false, null, typeof(BundledAssetGroupSchema));
			SetDefaultWbpValuesForSchema(group.GetSchema<BundledAssetGroupSchema>());
			List<AddressableAssetEntry> entries = new List<AddressableAssetEntry>
			{
				Settings.CreateOrMoveEntry(AssetDatabase.AssetPathToGUID(EmptyAssetPath), group, false, false)
			};

			group.SetDirty(AddressableAssetSettings.ModificationEvent.EntryAdded, entries, false, true);
			Settings.SetDirty(AddressableAssetSettings.ModificationEvent.EntryAdded, entries, true, false);
		}
	}
}