using UnityEngine;

namespace Logic
{
	[DefaultExecutionOrder(10)]
	public class MapIntWatcher : MapVarWatcher<int?>
	{
		[SerializeField]
		private IntWatchMode watchMode;

		[SerializeField]
		private UnityEventInt onConditionMetWithValue;

		[SerializeField]
		private int targetValue;

		private int? lastValue;

		private void OnEnable()
		{
		}

		private void Update()
		{
		}

		protected override void ProcessEvent(int? value)
		{
		}

		protected override bool EvaluateState(int? newValue)
		{
			return false;
		}

		protected override void CallEvents()
		{
		}
	}
}
