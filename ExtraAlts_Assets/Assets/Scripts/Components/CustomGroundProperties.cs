using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class CustomGroundProperties : MonoBehaviour
{
    public float friction = 1;
    public float speedMultiplier = 1;
    public bool push;
    public Vector3 pushForce;
    public bool pushDirectionRelative;

    public bool canJump = true;
    public bool silentJumpFail = false;
    public float jumpForceMultiplier = 1;

    public bool canSlide = true;
    public bool silentSlideFail = false;

    public bool canDash = true;
    public bool silentDashFail = false;

    public bool launchable = true;
    public bool forceCrouch = false;

    public bool overrideFootsteps = false;
    public AudioClip newFootstepSound;
    
    public bool dontRotateCamera = false;
}

#if UNITY_EDITOR
[CustomEditor(typeof(CustomGroundProperties))]
[CanEditMultipleObjects]
public class CustomGroundPropertiesEditor : Editor
{
    private SerializedProperty friction;
    private SerializedProperty speedMultiplier;
    private SerializedProperty push;
    private SerializedProperty pushForce;
    private SerializedProperty pushDirectionRelative;

    private SerializedProperty canJump;
    private SerializedProperty silentJumpFail;
    private SerializedProperty jumpForceMultiplier;

    private SerializedProperty canSlide;
    private SerializedProperty silentSlideFail;

    private SerializedProperty canDash;
    private SerializedProperty silentDashFail;

    private SerializedProperty launchable;
    private SerializedProperty forceCrouch;

    private SerializedProperty overrideFootsteps;
    private SerializedProperty newFootstepSound;
    
    private SerializedProperty dontRotateCamera;

    private void OnEnable()
    {
        friction = serializedObject.FindProperty(nameof(friction));
        speedMultiplier = serializedObject.FindProperty(nameof(speedMultiplier));
        push = serializedObject.FindProperty(nameof(push));
        pushForce = serializedObject.FindProperty(nameof(pushForce));
        pushDirectionRelative = serializedObject.FindProperty(nameof(pushDirectionRelative));

        canJump = serializedObject.FindProperty(nameof(canJump));
        silentJumpFail = serializedObject.FindProperty(nameof(silentJumpFail));
        jumpForceMultiplier = serializedObject.FindProperty(nameof(jumpForceMultiplier));

        canSlide = serializedObject.FindProperty(nameof(canSlide));
        silentSlideFail = serializedObject.FindProperty(nameof(silentSlideFail));

        canDash = serializedObject.FindProperty(nameof(canDash));
        silentDashFail = serializedObject.FindProperty(nameof(silentDashFail));

        launchable = serializedObject.FindProperty(nameof(launchable));

        forceCrouch = serializedObject.FindProperty(nameof(forceCrouch));

        overrideFootsteps = serializedObject.FindProperty(nameof(overrideFootsteps));
        newFootstepSound = serializedObject.FindProperty(nameof(newFootstepSound));
        
        dontRotateCamera = serializedObject.FindProperty(nameof(dontRotateCamera));
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        //General
        EditorGUILayout.PropertyField(friction);
        EditorGUILayout.PropertyField(speedMultiplier);

        GUILayout.Space(14);

        //Push
        EditorGUILayout.LabelField("Push", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(push);
        if (push.boolValue)
        {
            EditorGUILayout.PropertyField(pushDirectionRelative, new GUIContent("Direction Relative To Rotation"));
            EditorGUILayout.PropertyField(pushForce, new GUIContent("Force"));
        }

        GUILayout.Space(14);

        //Jumping
        EditorGUILayout.LabelField("Movement", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(canJump);
        if (canJump.boolValue)
            EditorGUILayout.PropertyField(jumpForceMultiplier);
        else
            EditorGUILayout.PropertyField(silentJumpFail);

        //Sliding
        EditorGUILayout.PropertyField(canSlide);
        if (!canSlide.boolValue)
            EditorGUILayout.PropertyField(silentSlideFail);

        //Dashing
        EditorGUILayout.PropertyField(canDash);
        if (!canDash.boolValue)
            EditorGUILayout.PropertyField(silentDashFail);
        GUILayout.Space(14);

        //Footsteps
        EditorGUILayout.LabelField("Footsteps", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(overrideFootsteps);
        if (overrideFootsteps.boolValue)
            EditorGUILayout.PropertyField(newFootstepSound);
        GUILayout.Space(14);

        //Other
        EditorGUILayout.LabelField("Other", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(launchable);
        EditorGUILayout.PropertyField(forceCrouch);

        var other = ((CustomGroundProperties)target).gameObject;
        if (other.CompareTag("Moving") || other.layer == 11 ||
            other.layer == 26)
        {
            GUILayout.Space(14);
            EditorGUILayout.LabelField("Moving", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(dontRotateCamera);
        }

        serializedObject.ApplyModifiedProperties();
    }
}
#endif
