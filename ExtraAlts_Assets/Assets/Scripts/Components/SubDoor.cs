using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public enum SubDoorType
{
    Standard,
    Animation
}

public class SubDoor : MonoBehaviour
{
    public SubDoorType type;
    public Vector3 openPos;
    public Vector3 origPos;
    public Vector3 targetPos;
    public float speed = 1;

    public Door dr;

    public AudioClip[] sounds;
    public AudioClip stopSound;
    public UltrakillEvent[] animationEvents;

    private void Update() { }
    public void Open() { }
    public void Close() { }
    public void SetValues() { }
    public void AnimationEvent(int i) { }
    public void PlaySound(int targetSound) { }
    public void PlayStopSound() { }}

#if UNITY_EDITOR
[CustomEditor(typeof(SubDoor))]
[CanEditMultipleObjects]
public class SubDoorEditor : Editor
{
    private SerializedProperty type;
    private SerializedProperty speed;

    private SerializedProperty openPos;

    private SerializedProperty animationEvents;
    private SerializedProperty sounds;
    private SerializedProperty stopSound;

    private void OnEnable()
    {
        type = serializedObject.FindProperty(nameof(type));
        speed = serializedObject.FindProperty(nameof(speed));
        openPos = serializedObject.FindProperty(nameof(openPos));
        animationEvents = serializedObject.FindProperty(nameof(animationEvents));
        sounds = serializedObject.FindProperty(nameof(sounds));
        stopSound = serializedObject.FindProperty(nameof(stopSound));
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        //General
        EditorGUILayout.PropertyField(type);
        EditorGUILayout.PropertyField(speed);

        if (type.enumValueIndex == 0)
            EditorGUILayout.PropertyField(openPos);
        else if (type.enumValueIndex == 1)
        {
            EditorGUILayout.PropertyField(animationEvents);
            EditorGUILayout.PropertyField(sounds);
            EditorGUILayout.PropertyField(stopSound);
        }

        serializedObject.ApplyModifiedProperties();
    }
}
#endif
