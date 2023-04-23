using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(-300)]
[DisallowMultipleComponent]
public class MapInfo : MapInfoBase
{
    [Header("Generate once, keep forever")]
    public string uniqueId;
    [Header("Details")]
    public string mapName;
    [TextArea] public string description;
    public string author;
    [Header("Should be 640x480")]
    public Texture2D thumbnail;
    [Header("Map Configuration")]
    public bool renderSkybox;
    public bool sandboxTools;
}

#if UNITY_EDITOR
[CustomEditor(typeof(MapInfo))]
public class MapInfoEditor : Editor
{
    MapInfo Target
    {
        get { return target as MapInfo; }
    }
    
    public override void OnInspectorGUI()
    {
        if (string.IsNullOrEmpty(Target.uniqueId))
        {
            if (GUILayout.Button("Generate an Id")) {
                Undo.RecordObject(Target, "Generate an unique identifier for the map");
                Target.uniqueId = GUID.Generate().ToString();
            }
        }
        base.OnInspectorGUI();
    }
}
#endif


public class MapHeader
{
    public string name;
    public string description;
    public int bundleSize;
    public string bundleName;
    public int thumbSize;
    public string uniqueIdentifier;
    public string author;
    public int version;
    public string[] placeholderPrefabs;
    public string catalog;
}