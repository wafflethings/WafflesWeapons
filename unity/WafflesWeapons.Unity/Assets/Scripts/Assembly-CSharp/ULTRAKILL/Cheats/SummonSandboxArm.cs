using System.Collections.Generic;
using Sandbox.Arm;
using UnityEngine;

namespace ULTRAKILL.Cheats
{
	public class SummonSandboxArm : ICheat
	{
		private bool active;

		private readonly List<SandboxArm> createdArms;

		private readonly Dictionary<SpawnableType, SandboxArm> spawnedArmMap;

		private readonly SpawnableType[][] mainArmTypes;

		public static List<GameObject> armSlot => null;

		public string LongName => null;

		public string Identifier => null;

		public string ButtonEnabledOverride => null;

		public string ButtonDisabledOverride => null;

		public string Icon => null;

		public bool IsActive => false;

		public bool DefaultState { get; }

		public StatePersistenceMode PersistenceMode => default(StatePersistenceMode);

		public static bool AnyArmActive => false;

		public void Enable(CheatsManager manager)
		{
		}

		public void TryCreateArmType(SpawnableType type)
		{
		}

		private SandboxArm CreateArm(SpawnableType type)
		{
			return null;
		}

		public void SelectArm(SpawnableObject obj)
		{
		}

		public void Disable()
		{
		}

		private void DeleteAllArms()
		{
		}
	}
}
