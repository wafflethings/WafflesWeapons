using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class TeleportPlayer : MonoBehaviour
{

    public bool affectPosition = true;
    public Vector3 relativePosition;
    public bool notRelative;
    public bool relativeToCollider;
    public Vector3 objectivePosition;
    
    public bool affectRotation;
    public bool notRelativeRotation;
    public Vector2 rotationDelta;
    public Vector2 objectiveRotation;

    public bool resetPlayerSpeed;

    public GameObject teleportEffect;
    public UltrakillEvent onTeleportPlayer;

    public void PerformTheTeleport() { }}

#if UNITY_EDITOR
[CustomEditor(typeof(TeleportPlayer))]
[CanEditMultipleObjects]
public class TeleportPlayerEditor : Editor
{
    private SerializedProperty affectPosition;
    private SerializedProperty relativePosition;
    private SerializedProperty objectivePosition;
    private SerializedProperty notRelative;
    private SerializedProperty relativeToCollider;

    private SerializedProperty affectRotation;
    private SerializedProperty notRelativeRotation;
    private SerializedProperty rotationDelta;
    private SerializedProperty objectiveRotation;

    private SerializedProperty resetPlayerSpeed;

    private SerializedProperty teleportEffect;
    private SerializedProperty onTeleportPlayer;

    private void OnEnable()
    {
        affectPosition = serializedObject.FindProperty("affectPosition");
        relativePosition = serializedObject.FindProperty("relativePosition");
        objectivePosition = serializedObject.FindProperty("objectivePosition");
        notRelative = serializedObject.FindProperty("notRelative");
        relativeToCollider = serializedObject.FindProperty("relativeToCollider");
        
        affectRotation = serializedObject.FindProperty("affectRotation");
        notRelativeRotation = serializedObject.FindProperty("notRelativeRotation");
        rotationDelta = serializedObject.FindProperty("rotationDelta");
        objectiveRotation = serializedObject.FindProperty("objectiveRotation");

        resetPlayerSpeed = serializedObject.FindProperty("resetPlayerSpeed");

        teleportEffect = serializedObject.FindProperty("teleportEffect");
        onTeleportPlayer = serializedObject.FindProperty("onTeleportPlayer");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        
        // Position
        EditorGUILayout.LabelField("Position", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(affectPosition);
        if (affectPosition.boolValue)
        {
            EditorGUILayout.PropertyField(notRelative);
            if (notRelative.boolValue)
            {
                // Objective
                EditorGUILayout.PropertyField(objectivePosition);
            }
            else
            {
                // Relative
                EditorGUILayout.PropertyField(relativeToCollider);
                EditorGUILayout.PropertyField(relativePosition);
            }
            
        }
        
        GUILayout.Space(14);
        
        // Rotation
        EditorGUILayout.LabelField("Rotation", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(affectRotation);
        if (affectRotation.boolValue)
        {
            EditorGUILayout.PropertyField(notRelativeRotation);
            if (notRelativeRotation.boolValue)
            {
                // Objective
                EditorGUILayout.PropertyField(objectiveRotation);
            }
            else
            {
                // Relative
                EditorGUILayout.PropertyField(rotationDelta);
            }
        }
        
        GUILayout.Space(14);

        EditorGUILayout.PropertyField(resetPlayerSpeed);
        EditorGUILayout.PropertyField(teleportEffect);

        GUILayout.Space(14);

        EditorGUILayout.LabelField("Events", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(onTeleportPlayer);
        
        serializedObject.ApplyModifiedProperties();
    }
}
#endif