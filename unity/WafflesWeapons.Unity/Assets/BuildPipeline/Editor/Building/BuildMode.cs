using UnityEditor.AddressableAssets.Settings;

namespace BuildPipeline.Editor.Building
{
    public abstract class BuildMode
    {
        public virtual void PreBuild(string buildPath, AddressableAssetSettings settings)
        {

        }

        public virtual void PostBuild(string buildPath, AddressableAssetSettings settings)
        {

        }
    }
}