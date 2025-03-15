using UnityEngine;

namespace Logic
{
	[DefaultExecutionOrder(10)]
	public class MapBoolWatcher : MapVarWatcher<bool?>
	{
		[SerializeField]
		private BoolWatchMode watchMode;

		[SerializeField]
		private UnityEventBool onConditionMetWithValue;

		private bool? lastValue;

		private void OnEnable()
		{
		}

		private void Update()
		{
		}

		protected override void ProcessEvent(bool? value)
		{
		}

		protected override bool EvaluateState(bool? newValue)
		{
			return false;
		}

		protected override void CallEvents()
		{
		}
	}
}
