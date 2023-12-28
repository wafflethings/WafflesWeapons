using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using WafflesWeapons.Assets;

[CustomEditor(typeof(WeaponAssets))]
public class WeaponAssetsEditor : Editor
{
    private bool _unrolled = true;
    private SerializedProperty _keys;
    private SerializedProperty _values;
    private int _targetSize;

    private void OnEnable()
    {
        _keys = serializedObject.FindProperty(nameof(WeaponAssets.Keys));
        _values = serializedObject.FindProperty(nameof(WeaponAssets.Values));
        _targetSize = _keys.arraySize;
    }
    
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        
        GUILayout.BeginHorizontal();
        GUILayout.Space(EditorGUI.indentLevel * 10); GUILayout.Label("Amount of assets", GUILayout.Width(50));
        GUILayout.FlexibleSpace();
        GUILayout.Space(EditorGUI.indentLevel * 10); _targetSize = EditorGUILayout.IntField(_targetSize, GUILayout.MinWidth(300));
        GUILayout.EndHorizontal();
        
        EditorGUI.BeginChangeCheck();
        
        while (_keys.arraySize > _targetSize)
        {
            _keys.DeleteArrayElementAtIndex(_keys.arraySize - 1);
        }
        
        while (_values.arraySize > _targetSize)
        {
            _values.DeleteArrayElementAtIndex(_values.arraySize - 1);
        }
        
        while (_keys.arraySize < _targetSize)
        {
            _keys.InsertArrayElementAtIndex(_keys.arraySize);
        }

        while (_targetSize > _values.arraySize)
        {
            _values.InsertArrayElementAtIndex(_values.arraySize);
        }

        _unrolled = EditorGUILayout.Foldout(_unrolled, "Assets");
        if (_unrolled)
        {
            for (int i = 0; i < _keys.arraySize; i++)
            {
                EditorGUI.indentLevel++;
                GUILayout.Space(EditorGUI.indentLevel * 10); GUILayout.Label($"Asset {i}", GUILayout.Width(100));
                EditorGUI.indentLevel++;

                GUILayout.BeginHorizontal();
                GUILayout.Space(EditorGUI.indentLevel * 10); GUILayout.Label("Key", GUILayout.Width(50));
                GUILayout.FlexibleSpace();
                GUILayout.Space(EditorGUI.indentLevel * 10); EditorGUILayout.PropertyField(_keys.GetArrayElementAtIndex(i), GUIContent.none, false, GUILayout.MinWidth(300));
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Space(EditorGUI.indentLevel * 10); GUILayout.Label("Value", GUILayout.Width(50));
                GUILayout.FlexibleSpace();
                GUILayout.Space(EditorGUI.indentLevel * 10); EditorGUILayout.PropertyField(_values.GetArrayElementAtIndex(i), GUIContent.none, false, GUILayout.MinWidth(300));
                GUILayout.EndHorizontal();
                EditorGUI.indentLevel--;
                EditorGUI.indentLevel--;
            }
        }

        bool somethingChanged = EditorGUI.EndChangeCheck();
        if(somethingChanged)
        {
            EditorUtility.SetDirty((WeaponAssets)target);
        }
        serializedObject.ApplyModifiedProperties();
        
        //base.OnInspectorGUI();
    }
}
