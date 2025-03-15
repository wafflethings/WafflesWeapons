using UnityEditor;

namespace BuildPipeline.Editor.Building
{
    public class ReleaseBuildMode : BuildMode
    {
        private static BuildMode s_instance = new ReleaseBuildMode();
        
        [MenuItem("Addressable Build Pipeline/Release Build")]
        public static void BuildButton()
        {
            AddressableBuilder.Build(s_instance);
        }
    }
}