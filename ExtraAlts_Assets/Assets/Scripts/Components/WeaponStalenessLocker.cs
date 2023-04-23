using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public enum LockerType
{
    State,
    Value,
    Unlocker
}

public class WeaponStalenessLocker : MonoBehaviour
{
    public LockerType type;
    public int slot;
    public float minValue;
    public float maxValue;
    public StyleFreshnessState minState;
    public StyleFreshnessState maxState;
    public bool oneTime;

    void Start() { }
    void OnTriggerEnter(Collider other) { }
    public void Activate() { }}

#if UNITY_EDITOR
[CustomEditor(typeof(WeaponStalenessLocker))]
[CanEditMultipleObjects]
public class WeaponStalenessLockerEditor : Editor
{
    private SerializedProperty type;
    private SerializedProperty slot;
    private SerializedProperty minValue;
    private SerializedProperty maxValue;
    private SerializedProperty minState;
    private SerializedProperty maxState;
    private SerializedProperty oneTime;

    private void OnEnable()
    {
        type = serializedObject.FindProperty(nameof(type));
        slot = serializedObject.FindProperty(nameof(slot));
        minValue = serializedObject.FindProperty(nameof(minValue));
        maxValue = serializedObject.FindProperty(nameof(maxValue));
        minState = serializedObject.FindProperty(nameof(minState));
        maxState = serializedObject.FindProperty(nameof(maxState));
        oneTime = serializedObject.FindProperty(nameof(oneTime));
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(slot, new GUIContent("Weapon Slot"));
        GUILayout.Space(14);
        EditorGUILayout.PropertyField(type, new GUIContent("Lock Type"));

        switch (type.intValue)
        {
            case 0:
                EditorGUILayout.PropertyField(minState, new GUIContent("Minimum"));
                EditorGUILayout.PropertyField(maxState, new GUIContent("Maximum"));
                break;

            case 1:
                EditorGUILayout.PropertyField(minValue, new GUIContent("Minimum"));
                EditorGUILayout.PropertyField(maxValue, new GUIContent("Maximum"));
                break;
        }
        GUILayout.Space(14);
        EditorGUILayout.PropertyField(oneTime);

        serializedObject.ApplyModifiedProperties();
    }
}
#endif
