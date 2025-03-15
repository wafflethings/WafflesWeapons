using plog;

namespace Sandbox.Arm
{
	public class AlterMode : ISandboxArmMode
	{
		private static readonly Logger Log;

		private SandboxArm hostArm;

		private static readonly int Tap;

		private static readonly int Point;

		private SandboxSpawnableInstance selected;

		public string Name => null;

		public bool CanOpenMenu => false;

		public bool Raycast => false;

		public virtual string Icon => null;

		public void EndSession()
		{
		}

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

		public void OpenProp(SandboxSpawnableInstance prop)
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
