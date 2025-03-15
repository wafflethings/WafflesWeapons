using UnityEngine;

namespace Logic
{
	public class MapStringSetter : MapVarSetter
	{
		[SerializeField]
		private StringInputType inputType;

		[SerializeField]
		private string sourceVariableName;

		[SerializeField]
		private VariableType sourceVariableType;

		[SerializeField]
		private string textValue;

		public override void SetVar()
		{
		}
	}
}
