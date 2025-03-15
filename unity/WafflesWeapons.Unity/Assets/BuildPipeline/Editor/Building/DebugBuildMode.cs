using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.AddressableAssets.Settings;
using UnityEngine;

namespace BuildPipeline.Editor.Building
{
    public class DebugBuildMode : BuildMode
    {
        private static BuildMode s_instance = new DebugBuildMode();
        private Dictionary<AddressableAssetGroup, List<AddressableAssetEntry>> _removedEntries = new Dictionary<AddressableAssetGroup, List<AddressableAssetEntry>>();
        
        [MenuItem("Addressable Build Pipeline/Debug Build")]
        public static void BuildButton()
        {
            AddressableBuilder.Build(s_instance);
        }

        public override void PreBuild(string buildPath, AddressableAssetSettings settings)
        {
            foreach (AddressableAssetGroup group in settings.groups)
            {
                if (!AddressableBuilder.CommonGroupNames.Contains(group.name))
                {
                    continue;
                }

                List<AddressableAssetEntry> entries = new List<AddressableAssetEntry>();
                entries.AddRange(group.entries);
                _removedEntries.Add(group, entries);
                
                foreach (AddressableAssetEntry entry in entries)
                {
                    settings.RemoveAssetEntry(entry.guid);
                }
            }
            
            AddressableBuilder.RefreshGroups();
        }

        public override void PostBuild(string buildPath, AddressableAssetSettings settings)
        {
            foreach (AddressableAssetGroup group in _removedEntries.Keys)
            {
                settings.MoveEntries(_removedEntries[group], group);
            }
            
            AddressableBuilder.RefreshGroups();
        }
    }
}