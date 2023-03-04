using UnityEditor;
using UnityEngine;

namespace Logic.Editor
{
    [CustomEditor(typeof(MapFloatSetter))]
    public class MapFloatSetterEditor : MapVarSetterEditorBase
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
            GUILayout.Label("Float Setter", EditorStyles.boldLabel);

            EditorGUILayout.PropertyField(inputType);

            switch ((FloatInputType) inputType.enumValueIndex)
            {
                case FloatInputType.CopyDifferentVariable:
                case FloatInputType.MultiplyByVariable:
                    EditorGUILayout.PropertyField(sourceVariableName);
                    break;
                case FloatInputType.RandomRange:
                    GUILayout.Space(2);
                    GUILayout.Label("Inclusive", EditorStyles.boldLabel);
                    EditorGUILayout.PropertyField(min);
                    
                    
                    GUILayout.Label("Exclusive", EditorStyles.boldLabel);
                    EditorGUILayout.PropertyField(max);
                    break;
                case FloatInputType.RandomFromList:
                    EditorGUILayout.PropertyField(list);
                    break;
                case FloatInputType.AddNumber:
                case FloatInputType.SetToNumber:
                case FloatInputType.MultiplyByNumber:
                    EditorGUILayout.PropertyField(number);
                    break;
            }
            
            serializedObject.ApplyModifiedProperties();
        }
    }
}