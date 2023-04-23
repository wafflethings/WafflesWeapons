using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class PickClosestPoint : MonoBehaviour
{
    public Transform target;
    public Transform[] points;
    public Transform customComparisonPoint;
    [SerializeField] private bool pickOnEnable = true;
    [SerializeField] private bool parentTargetToClosestPoint = true;
    [SerializeField] private bool mimicRotation = true;
    [SerializeField] private bool mimicPosition = true;
    [SerializeField] private bool mimicScale = true;
    [SerializeField] private bool closestToPlayer = true;
    
    private void OnEnable() { }}

#if UNITY_EDITOR
[CustomEditor(typeof(PickClosestPoint))]
public class PickClosestPointEditor : Editor
{
    private SerializedProperty target;
    private SerializedProperty points;
    private SerializedProperty customComparisonPoint;
    private SerializedProperty pickOnEnable;
    private SerializedProperty parentTargetToClosestPoint;
    private SerializedProperty mimicPosition;
    private SerializedProperty mimicRotation;
    private SerializedProperty mimicScale;
    private SerializedProperty closestToPlayer;
    
    public override void OnInspectorGUI()
    {
        // base.OnInspectorGUI();
        serializedObject.Update();
        EditorGUILayout.PropertyField(target);
        EditorGUILayout.PropertyField(points);
        EditorGUILayout.PropertyField(pickOnEnable);
        GUILayout.Space(4);
        EditorGUILayout.PropertyField(closestToPlayer);
        if (!closestToPlayer.boolValue)
        {
            EditorGUILayout.PropertyField(customComparisonPoint);
        }
        GUILayout.Space(4);
        EditorGUILayout.PropertyField(parentTargetToClosestPoint);
        if (!parentTargetToClosestPoint.boolValue)
        {
            EditorGUILayout.PropertyField(mimicPosition);
            EditorGUILayout.PropertyField(mimicRotation);
            EditorGUILayout.PropertyField(mimicScale);
        }
        
        serializedObject.ApplyModifiedProperties();
    }
    
    private void OnEnable()
    {
        target = serializedObject.FindProperty("target");
        points = serializedObject.FindProperty("points");
        customComparisonPoint = serializedObject.FindProperty("customComparisonPoint");
        pickOnEnable = serializedObject.FindProperty("pickOnEnable");
        parentTargetToClosestPoint = serializedObject.FindProperty("parentTargetToClosestPoint");
        mimicPosition = serializedObject.FindProperty("mimicPosition");
        mimicRotation = serializedObject.FindProperty("mimicRotation");
        mimicScale = serializedObject.FindProperty("mimicScale");
        closestToPlayer = serializedObject.FindProperty("closestToPlayer");
    }
}
#endif