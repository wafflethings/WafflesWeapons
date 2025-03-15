using UnityEngine;

namespace Sandbox
{
	public class SandboxProp : SandboxSpawnableInstance
	{
		[SerializeField]
		private PhysicsSounds.PhysMaterial physicsMaterial;

		[SerializeField]
		private bool enableImpactDamage;

		public bool forceFullWorldPreview;

		private TimeSince timeSinceLastImpact;

		private void Start()
		{
		}

		private void OnCollisionEnter(Collision other)
		{
		}

		public SavedProp SaveProp()
		{
			return null;
		}

		private void OnCollisionStay(Collision other)
		{
		}

		public override void Pause(bool freeze = true)
		{
		}

		public override void Resume()
		{
		}
	}
}
