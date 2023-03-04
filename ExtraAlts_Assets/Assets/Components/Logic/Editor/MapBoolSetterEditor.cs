using UnityEditor;
using UnityEngine;

namespace Logic.Editor
{
    [CustomEditor(typeof(MapBoolSetter))]
    public class MapBoolSetterEditor : MapVarSetterEditorBase
    {
        private SerializedProperty inputType;
        private SerializedProperty value;

        protected override void OnEnable()
        {
            base.OnEnable();
            inputType = serializedObject.FindProperty("inputType");
            value = serializedObject.FindProperty("value");
        }
        
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            
            GUILayout.Space(8);
            GUILayout.Label("Bool Setter", EditorStyles.boldLabel);

            EditorGUILayout.PropertyField(inputType);

            switch ((BoolInputType) inputType.enumValueIndex)
            {
                case BoolInputType.Set:
                    EditorGUILayout.PropertyField(value);
                    break;
                case BoolInputType.Toggle:
                    break;
            }
            
            serializedObject.ApplyModifiedProperties();
        }
    }
}