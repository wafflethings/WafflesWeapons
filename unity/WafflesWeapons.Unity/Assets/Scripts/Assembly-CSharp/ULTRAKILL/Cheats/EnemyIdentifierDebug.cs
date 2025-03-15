namespace ULTRAKILL.Cheats
{
	public class EnemyIdentifierDebug : ICheat
	{
		private static EnemyIdentifierDebug _lastInstance;

		public static bool Active => false;

		public string LongName => null;

		public string Identifier => null;

		public string ButtonEnabledOverride => null;

		public string ButtonDisabledOverride => null;

		public string Icon => null;

		public bool DefaultState => false;

		public StatePersistenceMode PersistenceMode => default(StatePersistenceMode);

		public bool IsActive { get; private set; }

		public void Enable(CheatsManager manager)
		{
		}

		public void Disable()
		{
		}
	}
}
