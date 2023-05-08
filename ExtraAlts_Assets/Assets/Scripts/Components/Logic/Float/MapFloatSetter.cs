using UnityEngine;

namespace Logic
{
    public partial class MapFloatSetter : MapVarSetter
    {
        [SerializeField] private FloatInputType inputType = FloatInputType.SetToNumber;

         
        [SerializeField] private string sourceVariableName;

         
        [SerializeField] private float min = 0f;
        [SerializeField] private float max = 1f;

         
        [SerializeField] private float[] list;

         
        [SerializeField] private float number;

        public override void SetVar() { }    }

    public enum FloatInputType { SetToNumber, AddNumber, RandomRange, RandomFromList, CopyDifferentVariable, MultiplyByNumber, MultiplyByVariable }
}