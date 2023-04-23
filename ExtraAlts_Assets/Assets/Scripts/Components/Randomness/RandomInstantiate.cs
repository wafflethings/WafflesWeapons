using System.Collections.Generic;
using System.Linq;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class RandomInstantiate : RandomBase<RandomGameObjectEntry>
{
    public bool removePreviousOnRandomize = true;
    [SerializeField] private InstantiateObjectMode mode = InstantiateObjectMode.Normal;
    public bool reParent = true;
    public bool useOwnPosition = true;
    public bool useOwnRotation = true;

    public override void PerformTheAction(RandomEntry entry) { }
    public override void RandomizeWithCount(int count) { }    
    
}

#if UNITY_EDITOR
[CustomEditor(typeof(RandomInstantiate))]
public class RandomInstantiateEditor : Editor
{
    private RandomInstantiate realTarget;
    private void OnEnable()
    {
        realTarget = (RandomInstantiate) target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (realTarget.entries == null || realTarget.entries.Length == 0) return;
        var poolEntries = realTarget.entries.Sum(entry => entry.weight);
        GUILayout.Space(8);
        GUILayout.Label("The bigger the weight, the bigger the chance.", EditorStyles.boldLabel);
        GUILayout.Space(8);
        GUILayout.Label($"There are {poolEntries} entries in the virtual pool.");
        GUILayout.Label($"There are {realTarget.entries.Length} objects total.");
    }
}
#endif