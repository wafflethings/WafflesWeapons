namespace Sandbox.Arm
{
	public class DestroyMode : ISandboxArmMode
	{
		private SandboxArm hostArm;

		private static readonly int Tap;

		private static readonly int Point;

		public string Name => null;

		public bool CanOpenMenu => false;

		public bool Raycast => false;

		public virtual string Icon => null;

		public void OnEnable(SandboxArm arm)
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

		public void OnSecondaryDown()
		{
		}

		public void OnSecondaryUp()
		{
		}
	}
}
