using UnityEngine;

namespace Sandbox.Arm
{
	public class PlaceMode : ArmModeWithHeldPreview
	{
		private GameObject worldPreviewObject;

		public override string Name => null;

		public override bool Raycast => false;

		public override void SetPreview(SpawnableObject obj)
		{
		}

		private void CreateWorldPreview(SpawnableObject obj)
		{
		}

		private void CreateWorldPreview()
		{
		}

		public override void Update()
		{
		}

		private Quaternion CalculatePropRotation(Vector3 normal, Quaternion baseRotation)
		{
			return default(Quaternion);
		}

		private Vector3 CalculatePropPosition(RaycastHit hit)
		{
			return default(Vector3);
		}

		public override void OnPrimaryDown()
		{
		}

		public override void OnEnable(SandboxArm arm)
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
