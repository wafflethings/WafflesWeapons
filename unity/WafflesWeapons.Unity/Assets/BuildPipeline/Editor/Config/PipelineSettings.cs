using System.IO;
using UnityEditor;
using UnityEngine;

namespace BuildPipeline.Editor.Config
{
    public class PipelineSettings : ScriptableObject
    {
        public const string SettingsFileName = "Settings.asset";
        public static readonly string SettingsPath = Path.Combine("Assets", "BuildPipeline", SettingsFileName);

        public bool DoCopy;
        public string BuildCopyPath;

        public static PipelineSettings Instance
        {
            get
            {
                PipelineSettings? instance = AssetDatabase.LoadAssetAtPath<PipelineSettings>(SettingsPath);

                if (instance == null)
                {
                    instance = CreateInstance<PipelineSettings>();
                    AssetDatabase.CreateAsset(instance, SettingsPath);
                }

                return instance;
            }
        }

        public string AllSettings => string.Join(",", DoCopy, BuildCopyPath);
    }
}