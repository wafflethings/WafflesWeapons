using UnityEngine;

namespace Logic
{
    public partial class MapStringSetter : MapVarSetter
    {
        [SerializeField] private StringInputType inputType = StringInputType.JustText;

         
        [SerializeField] private string sourceVariableName;
        [SerializeField] private VariableType sourceVariableType;

         
        [SerializeField] private string textValue;

        public override void SetVar() { }    }
    
    public enum StringInputType { JustText, CopyDifferentVariable }
}