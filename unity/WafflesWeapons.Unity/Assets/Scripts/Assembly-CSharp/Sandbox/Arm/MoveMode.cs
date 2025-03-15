using UnityEngine;
using plog;

namespace Sandbox.Arm
{
	public class MoveMode : ISandboxArmMode, ISandboxArmDebugGUI
	{
		public class ManipulatedObject
		{
			public Transform target;

			public SandboxSpawnableInstance spawnable;

			public GameObject particles;

			public Rigidbody rigidbody;

			public Collider collider;

			public Vector3 positionOffset;

			public float distance;

			public Vector3 originalRotation;

			public float simpleRotationOffset;

			public Quaternion rotationOffset;

			public ManipulatedObject(RaycastHit hit, SandboxSpawnableInstance propOverwrite = null)
			{
			}
		}

		private static readonly plog.Logger Log;

		private static readonly int Manipulating;

		private static readonly int Pinched;

		private static readonly int PushZ;

		private static readonly int Crush;

		private SandboxArm hostArm;

		private ManipulatedObject manipulatedObject;

		private Vector3 targetPos;

		private Vector3 objectVelocity;

		public string Name => null;

		public bool CanOpenMenu => false;

		public virtual string Icon => null;

		public virtual bool Raycast => false;

		public virtual void OnEnable(SandboxArm arm)
		{
		}

		public void OnDisable()
		{
		}

		public void OnDestroy()
		{
		}

		public void Update()
		{
		}

		public void FixedUpdate()
		{
		}

		public void OnPrimaryDown()
		{
		}

		public void OnPrimaryUp()
		{
		}

		public bool OnGUI()
		{
			return false;
		}

		public void OnSecondaryDown()
		{
		}

		public void OnSecondaryUp()
		{
		}

		private void IntegrityCheck()
		{
		}

		private void ReleaseManipulatedObject(Vector3 velocity, Quaternion? deltaRot = null)
		{
		}
	}
}
