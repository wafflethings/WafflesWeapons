using UnityEngine;

namespace Logic
{
	public class MapIntSetter : MapVarSetter
	{
		[SerializeField]
		private IntInputType inputType;

		[SerializeField]
		private string sourceVariableName;

		[SerializeField]
		private int min;

		[SerializeField]
		private int max;

		[SerializeField]
		private int[] list;

		[SerializeField]
		private int number;

		public override void SetVar()
		{
		}
	}
}
