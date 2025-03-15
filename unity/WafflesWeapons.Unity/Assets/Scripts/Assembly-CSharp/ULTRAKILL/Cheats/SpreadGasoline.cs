using UnityEngine;

namespace ULTRAKILL.Cheats
{
	public class SpreadGasoline : ICheat
	{
		private bool active;

		private GameObject asset;

		public string LongName => null;

		public string Identifier => null;

		public string ButtonEnabledOverride { get; }

		public string ButtonDisabledOverride => null;

		public string Icon => null;

		public bool IsActive => false;

		public bool DefaultState { get; }

		public StatePersistenceMode PersistenceMode => default(StatePersistenceMode);

		public void Enable(CheatsManager manager)
		{
		}

		private void SpawnProjectiles(GameObject projectilePrefab)
		{
		}

		public void Disable()
		{
		}
	}
}
