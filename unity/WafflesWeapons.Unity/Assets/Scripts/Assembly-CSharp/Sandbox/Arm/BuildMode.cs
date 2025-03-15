using UnityEngine;

namespace Sandbox.Arm
{
	public class BuildMode : ArmModeWithHeldPreview
	{
		private float tickDelay;

		private bool firstBrushPositionSet;

		private Vector3 firstBlockPos;

		private Vector3 secondBlockPos;

		private Vector3 previousSecondBlockPos;

		private Vector3 brushOffset;

		private GameObject worldPreviewObject;

		private GameObject pointAIndicatorObject;

		private GameObject pointBIndicatorObject;

		private new static readonly int Punch;

		public override string Name => null;

		public override void SetPreview(SpawnableObject obj)
		{
		}

		private void SetupBlockCreator(SpawnableObject template)
		{
		}

		public override void Update()
		{
		}

		private Vector3 CalculatePropPosition(RaycastHit hit)
		{
			return default(Vector3);
		}

		public override void OnPrimaryDown()
		{
		}

		private void CreateWorldPreview()
		{
		}

		public override void OnDisable()
		{
		}

		public override void OnDestroy()
		{
		}
	}
}
