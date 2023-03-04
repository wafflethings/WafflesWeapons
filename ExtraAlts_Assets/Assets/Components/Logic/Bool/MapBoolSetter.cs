using UnityEngine;

namespace Logic
{
    public partial class MapBoolSetter : MapVarSetter
    {
        public BoolInputType inputType;
        public bool value;

        public override void SetVar() { }
    }
    
    public enum BoolInputType { Set, Toggle }
}