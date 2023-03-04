using UnityEditor;
using UnityEngine;

namespace Logic.Editor
{
    [CustomEditor(typeof(MapIntSetter))]
    public class MapIntSetterEditor : MapVarSetterEditorBase
    {
        private SerializedProperty inputType;
        private SerializedProperty sourceVariableName;
        private SerializedProperty min;
        private SerializedProperty max;
        private SerializedProperty list;
        private SerializedProperty number;
        
        protected override void OnEnable()
        {
            base.OnEnable();
            inputType = serializedObject.FindProperty("inputType");
            sourceVariableName = serializedObject.FindProperty("sourceVariableName");
            min = serializedObject.FindProperty("min");
            max = serializedObject.FindProperty("max");
            list = serializedObject.FindProperty("list");
            number = serializedObject.FindProperty("number");
        }
        
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            
            GUILayout.Space(8);
            GUILayout.Label("Int Setter", EditorStyles.boldLabel);

            EditorGUILayout.PropertyField(inputType);

            switch ((IntInputType) inputType.enumValueIndex)
            {
                case IntInputType.CopyDifferentVariable:
                    EditorGUILayout.PropertyField(sourceVariableName);
                    break;
                case IntInputType.RandomRange:
                    GUILayout.Space(2);
                    GUILayout.Label("Inclusive", EditorStyles.boldLabel);
                    EditorGUILayout.PropertyField(min);
                    
                    
                    GUILayout.Label("Exclusive", EditorStyles.boldLabel);
                    EditorGUILayout.PropertyField(max);
                    break;
                case IntInputType.RandomFromList:
                    EditorGUILayout.PropertyField(list);
                    break;
                case IntInputType.AddNumber:
                case IntInputType.SetToNumber:
                    EditorGUILayout.PropertyField(number);
                    break;
            }
            
            serializedObject.ApplyModifiedProperties();
        }
    }
}