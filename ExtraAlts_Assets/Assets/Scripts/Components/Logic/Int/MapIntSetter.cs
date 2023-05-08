using UnityEngine;

namespace Logic
{
    public partial class MapIntSetter : MapVarSetter
    {
        [SerializeField] private IntInputType inputType = IntInputType.SetToNumber;

         
        [SerializeField] private string sourceVariableName;

         
        [SerializeField] private int min = 0;
        [SerializeField] private int max = 1;

         
        [SerializeField] private int[] list;

         
        [SerializeField] private int number;

        public override void SetVar() { }    }

    public enum IntInputType { SetToNumber, AddNumber, RandomRange, RandomFromList, CopyDifferentVariable }
}