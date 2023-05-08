using System;
using System.Linq;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class RandomSetActive : RandomBase<RandomGameObjectEntry>
{
    
    public bool resetStatesOnRandomize = true;

    public override void PerformTheAction(RandomEntry entry) { }
    public override void RandomizeWithCount(int count) { }}

#if UNITY_EDITOR
[CustomEditor(typeof(RandomSetActive))]
public class RandomSetActiveEditor : Editor
{
    private RandomSetActive realTarget;
    private void OnEnable()
    {
        realTarget = (RandomSetActive) target;
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

class SimulatedRandomEntry
{
    public int firstIndex;
    public int lastIndex;
    public RandomEntry target;
}