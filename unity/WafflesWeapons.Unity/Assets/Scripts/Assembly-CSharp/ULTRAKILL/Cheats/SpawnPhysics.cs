namespace ULTRAKILL.Cheats
{
	public class SpawnPhysics : ICheat
	{
		private static SpawnPhysics _lastInstance;

		public static bool PhysicsDynamic => false;

		public string LongName => null;

		public string Identifier => null;

		public string ButtonEnabledOverride => null;

		public string ButtonDisabledOverride => null;

		public string Icon => null;

		public bool IsActive { get; private set; }

		public bool DefaultState => false;

		public StatePersistenceMode PersistenceMode => default(StatePersistenceMode);

		public void Enable(CheatsManager manager)
		{
		}

		public void Disable()
		{
		}
	}
}
