using UnityEngine;

namespace Logic
{
    public partial class MapStringSetter : MapVarSetter
    {
        [SerializeField] private StringInputType inputType = StringInputType.JustText;

        // copy different variable
        [SerializeField] private string sourceVariableName;
        [SerializeField] private VariableType sourceVariableType;

        // random range
        [SerializeField] private string textValue;

        public override void SetVar() { }
    }
    
    public enum StringInputType { JustText, CopyDifferentVariable }
}