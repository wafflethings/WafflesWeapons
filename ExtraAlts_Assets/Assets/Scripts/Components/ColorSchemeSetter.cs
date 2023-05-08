using System;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class ColorSchemeSetter : MonoBehaviour
{
    public bool replaceDitherUserSetting;
    public float ditheringAmount;
    
    public bool enforceMapColorPalette;
    public Texture mapDefinedPalette;

    public bool applyOnPlayerTriggerEnter;
    public bool applyOnPlayerTriggerExit;
    public bool oneTime;

    public void Apply() { }}

#if UNITY_EDITOR
[CanEditMultipleObjects]
[CustomEditor(typeof(ColorSchemeSetter))]
public class ColorSchemeSetterEditor : Editor
{
    private SerializedProperty replaceDitherUserSetting;
    private SerializedProperty ditheringAmount;
    
    private SerializedProperty enforceMapColorPalette;
    private SerializedProperty mapDefinedPalette;
    
    private SerializedProperty applyOnPlayerTriggerEnter;
    private SerializedProperty applyOnPlayerTriggerExit;

    private void OnEnable()
    {
        replaceDitherUserSetting = serializedObject.FindProperty("replaceDitherUserSetting");
        ditheringAmount = serializedObject.FindProperty("ditheringAmount");
        
        enforceMapColorPalette = serializedObject.FindProperty("enforceMapColorPalette");
        mapDefinedPalette = serializedObject.FindProperty("mapDefinedPalette");
        
        applyOnPlayerTriggerEnter = serializedObject.FindProperty("applyOnPlayerTriggerEnter");
        applyOnPlayerTriggerExit = serializedObject.FindProperty("applyOnPlayerTriggerExit");
    }

    public override void OnInspectorGUI()
    {
        EditorGUILayout.PropertyField(replaceDitherUserSetting);
        if (replaceDitherUserSetting.boolValue)
        {
            EditorGUILayout.PropertyField(ditheringAmount);
        }

        EditorGUILayout.Space(8);
        
        EditorGUILayout.PropertyField(enforceMapColorPalette);
        if (enforceMapColorPalette.boolValue)
        {
            EditorGUILayout.PropertyField(mapDefinedPalette);
        }
        
        EditorGUILayout.Space(8);
        
        EditorGUILayout.LabelField("Note: the map defined palette will override the user defined palette.");
        EditorGUILayout.LabelField("It cannot be changed by the player.");
        
        EditorGUILayout.Space(12);
        
        EditorGUILayout.PropertyField(applyOnPlayerTriggerEnter);
        EditorGUILayout.PropertyField(applyOnPlayerTriggerExit);

        serializedObject.ApplyModifiedProperties();
    }
}
#endif
