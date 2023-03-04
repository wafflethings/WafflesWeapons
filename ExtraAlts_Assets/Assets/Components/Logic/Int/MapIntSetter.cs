using UnityEngine;

namespace Logic
{
    public partial class MapIntSetter : MapVarSetter
    {
        [SerializeField] private IntInputType inputType = IntInputType.SetToNumber;

        // copy different variable
        [SerializeField] private string sourceVariableName;

        // random range
        [SerializeField] private int min = 0;
        [SerializeField] private int max = 1;

        // random from list
        [SerializeField] private int[] list;

        // just number
        [SerializeField] private int number;

        public override void SetVar() { }
    }

    public enum IntInputType { SetToNumber, AddNumber, RandomRange, RandomFromList, CopyDifferentVariable }
}