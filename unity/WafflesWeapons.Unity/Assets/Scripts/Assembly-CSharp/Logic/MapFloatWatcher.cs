using UnityEngine;

namespace Logic
{
	[DefaultExecutionOrder(10)]
	public class MapFloatWatcher : MapVarWatcher<float?>
	{
		[SerializeField]
		private FloatWatchMode watchMode;

		[SerializeField]
		private UnityEventFloat onConditionMetWithValue;

		[SerializeField]
		private float targetValue;

		private float? lastValue;

		private void OnEnable()
		{
		}

		private void Update()
		{
		}

		protected override void ProcessEvent(float? value)
		{
		}

		protected override bool EvaluateState(float? newValue)
		{
			return false;
		}

		protected override void CallEvents()
		{
		}
	}
}
