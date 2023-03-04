using UnityEditor;
using UnityEngine;

namespace Logic.Editor
{
    [CustomEditor(typeof(MapIntSetter))]
    public class MapVarSetterEditorBase : UnityEditor.Editor
    {
        private SerializedProperty variableName;
        private SerializedProperty persistence;
        private SerializedProperty setOnEnable;
        private SerializedProperty setEveryFrame;
        
        protected virtual void OnEnable()
        {
            variableName = serializedObject.FindProperty("variableName");
            persistence = serializedObject.FindProperty("persistence");
            setOnEnable = serializedObject.FindProperty("setOnEnable");
            setEveryFrame = serializedObject.FindProperty("setEveryFrame");
        }
        
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            
            GUILayout.Label("Variable", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(variableName);
            EditorGUILayout.PropertyField(persistence);

            GUILayout.Space(8);
            
            GUILayout.Label("Execution", EditorStyles.boldLabel);

            EditorGUILayout.PropertyField(setOnEnable);
            EditorGUILayout.PropertyField(setEveryFrame);
        }
    }
}