using UnityEngine;

namespace Logic
{
    public partial class MapFloatSetter : MapVarSetter
    {
        [SerializeField] private FloatInputType inputType = FloatInputType.SetToNumber;

        // copy different variable
        [SerializeField] private string sourceVariableName;

        // random range
        [SerializeField] private float min = 0f;
        [SerializeField] private float max = 1f;

        // random from list
        [SerializeField] private float[] list;

        // just number
        [SerializeField] private float number;

        public override void SetVar() { }
    }

    public enum FloatInputType { SetToNumber, AddNumber, RandomRange, RandomFromList, CopyDifferentVariable, MultiplyByNumber, MultiplyByVariable }
}