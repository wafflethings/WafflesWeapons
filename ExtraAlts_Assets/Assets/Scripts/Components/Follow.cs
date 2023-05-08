using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class Follow : MonoBehaviour {
    public float speed = 0;
    public Transform target;
    public bool mimicPosition = true;
    public bool applyPositionLocally = false;
    public bool followX = true;
    public bool followY = true;
    public bool followZ = true;
    public bool mimicRotation = false;
    public bool applyRotationLocally = false;
    public bool rotX = true;
    public bool rotY = true;
    public bool rotZ = true;

    public Collider[] restrictToColliderBounds;
    public bool destroyIfNoTarget;

    void Awake() { }
	void Update ()  { }}

#if UNITY_EDITOR
[CustomEditor(typeof(Follow))]
[CanEditMultipleObjects]
public class FollowEditor : Editor
{
    private SerializedProperty speed;
    private SerializedProperty target;
    private SerializedProperty mimicPosition;
    private SerializedProperty applyPositionLocally;
    private SerializedProperty followX;
    private SerializedProperty followY;
    private SerializedProperty followZ;
    private SerializedProperty mimicRotation;
    private SerializedProperty applyRotationLocally;
    private SerializedProperty rotX;
    private SerializedProperty rotY;
    private SerializedProperty rotZ;
    private SerializedProperty restrictToColliderBounds;

    private void OnEnable()
    {
        speed = serializedObject.FindProperty("speed");
        target = serializedObject.FindProperty("target");
        mimicPosition = serializedObject.FindProperty("mimicPosition");
        applyPositionLocally = serializedObject.FindProperty("applyPositionLocally");
        followX = serializedObject.FindProperty("followX");
        followY = serializedObject.FindProperty("followY");
        followZ = serializedObject.FindProperty("followZ");
        mimicRotation = serializedObject.FindProperty("mimicRotation");
        applyRotationLocally = serializedObject.FindProperty("applyRotationLocally");
        rotX = serializedObject.FindProperty("rotX");
        rotY = serializedObject.FindProperty("rotY");
        rotZ = serializedObject.FindProperty("rotZ");
        restrictToColliderBounds = serializedObject.FindProperty("restrictToColliderBounds");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        
        // Position
        EditorGUILayout.LabelField("General", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(target);
        EditorGUILayout.LabelField("Leave empty for player", EditorStyles.miniLabel);
        GUILayout.Space(7);
        EditorGUILayout.LabelField("Movement", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(mimicPosition);
        if (mimicPosition.boolValue)
        {
            EditorGUILayout.PropertyField(applyPositionLocally);
            EditorGUILayout.PropertyField(speed);
            EditorGUILayout.LabelField("0 for instant", EditorStyles.miniLabel);
            GUILayout.Space(4);
            EditorGUILayout.PropertyField(followX);
            EditorGUILayout.PropertyField(followY);
            EditorGUILayout.PropertyField(followZ);
        }
        GUILayout.Space(7);
        EditorGUILayout.LabelField("Rotation", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(mimicRotation);
        if (mimicRotation.boolValue)
        {
            EditorGUILayout.PropertyField(applyRotationLocally);
            if (target.objectReferenceValue == null)
            {
                EditorGUILayout.PropertyField(rotX);
                EditorGUILayout.PropertyField(rotY);
            }
            else
            {
                EditorGUILayout.PropertyField(rotX);
                EditorGUILayout.PropertyField(rotY);
                EditorGUILayout.PropertyField(rotZ);
            }
        }
        
        GUILayout.Space(12);
        EditorGUILayout.PropertyField(restrictToColliderBounds);
        
        serializedObject.ApplyModifiedProperties();
    }
}
#endif