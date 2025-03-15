using UnityEngine;

namespace Logic
{
	public class MapFloatSetter : MapVarSetter
	{
		[SerializeField]
		private FloatInputType inputType;

		[SerializeField]
		private string sourceVariableName;

		[SerializeField]
		private float min;

		[SerializeField]
		private float max;

		[SerializeField]
		private float[] list;

		[SerializeField]
		private float number;

		public override void SetVar()
		{
		}
	}
}
