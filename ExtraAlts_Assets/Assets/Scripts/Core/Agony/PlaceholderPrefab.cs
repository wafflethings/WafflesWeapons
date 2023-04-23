using System;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEditor.Experimental.SceneManagement;
#endif

[DefaultExecutionOrder(-150)]
public class PlaceholderPrefab : MonoBehaviour
{
    public string uniqueId;
}

#if UNITY_EDITOR
[CustomEditor(typeof(PlaceholderPrefab))]
public class PlaceholderPrefabEditor : Editor
{
    private SerializedProperty uniqueId;

    private void OnEnable()
    {
        uniqueId = serializedObject.FindProperty("uniqueId");
    }

    public override void OnInspectorGUI()
    {
        var placeholderTarget = (PlaceholderPrefab) target;
        if (string.IsNullOrEmpty(placeholderTarget.uniqueId))
        {
            EditorGUILayout.PropertyField(uniqueId);
            serializedObject.ApplyModifiedProperties();
        }
        GUILayout.Label(placeholderTarget.uniqueId);
        if (GUILayout.Button("Copy ID")) GUIUtility.systemCopyBuffer = placeholderTarget.uniqueId;
    }
}
#endif