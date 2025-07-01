using UnityEditor;

namespace BuildPipeline.Editor.Config
{
    public class ConfigWindow : EditorWindow
    {
        [MenuItem("Addressable Build Pipeline/Config")]
        public static void ShowWindow() => GetWindow<ConfigWindow>("WBP Config");
        
        private void OnGUI()
        {
            PipelineSettings instance = PipelineSettings.Instance;
            string oldSettings = instance.AllSettings;
            
            instance.DoCopy = EditorGUILayout.Toggle("Copy files after build", instance.DoCopy);
            instance.BuildCopyPath = EditorGUILayout.TextField("Copy to path: ", instance.BuildCopyPath);
            
            if (oldSettings != instance.AllSettings) 
            {
                EditorUtility.SetDirty(instance);
            }
        }
    }
}