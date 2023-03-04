#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class RemoveOnTime : MonoBehaviour
{
    public bool useAudioLength;
    public float time;
}

#if UNITY_EDITOR
[CanEditMultipleObjects]
[CustomEditor(typeof(RemoveOnTime))]
class RemoveOnTimeEditor : Editor
{
    private SerializedProperty time;
    private SerializedProperty useAudioLength;

    private void OnEnable()
    {
        time = serializedObject.FindProperty("time");
        useAudioLength = serializedObject.FindProperty("useAudioLength");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(useAudioLength);
        if (!useAudioLength.boolValue)
        {
            EditorGUILayout.PropertyField(time);
        }

        serializedObject.ApplyModifiedProperties();
    }
}
#endif