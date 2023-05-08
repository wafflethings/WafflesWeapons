using System.Collections.Generic;
using System.Linq;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class WaterDryTracker
{
    public Transform transform;
    public Vector3 closestPosition;

    public WaterDryTracker(Transform tf, Vector3 clopo) { }}

public class ScrollingTexture : MonoBehaviour
{

    public float scrollSpeedX;
    public float scrollSpeedY;

    public bool scrollAttachedObjects;
    public Vector3 force;
    public bool relativeDirection;
    public List<Transform> attachedObjects = new List<Transform>();

     
    void Start() { }
    void SlowUpdate() { }
     
    void Update() { }}

#if UNITY_EDITOR
[CustomEditor(typeof(ScrollingTexture))]
[CanEditMultipleObjects]
public class ScrollingTextureEditor : Editor
{
    private SerializedProperty scrollSpeedX;
    private SerializedProperty scrollSpeedY;

    private SerializedProperty scrollAttachedObjects;
    private SerializedProperty force;
    private SerializedProperty relativeDirection;
    private SerializedProperty attachedObjects;

    private void OnEnable()
    {
        scrollSpeedX = serializedObject.FindProperty(nameof(scrollSpeedX));
        scrollSpeedY = serializedObject.FindProperty(nameof(scrollSpeedY));

        scrollAttachedObjects = serializedObject.FindProperty(nameof(scrollAttachedObjects));
        force = serializedObject.FindProperty(nameof(force));
        relativeDirection = serializedObject.FindProperty(nameof(relativeDirection));
        attachedObjects = serializedObject.FindProperty(nameof(attachedObjects));
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        //General
        EditorGUILayout.PropertyField(scrollSpeedX);
        EditorGUILayout.PropertyField(scrollSpeedY);

        GUILayout.Space(14);

        //Push
        EditorGUILayout.PropertyField(scrollAttachedObjects);
        if (scrollAttachedObjects.boolValue)
        {
            EditorGUILayout.PropertyField(force);
            EditorGUILayout.PropertyField(relativeDirection);
            EditorGUILayout.PropertyField(attachedObjects);
        }

        serializedObject.ApplyModifiedProperties();
    }
}
#endif
