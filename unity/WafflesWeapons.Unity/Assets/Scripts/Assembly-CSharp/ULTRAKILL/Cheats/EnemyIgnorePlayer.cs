namespace ULTRAKILL.Cheats
{
	public class EnemyIgnorePlayer : ICheat
	{
		private static EnemyIgnorePlayer _lastInstance;

		private bool active;

		public static bool Active => false;

		public string LongName => null;

		public string Identifier => null;

		public string ButtonEnabledOverride { get; }

		public string ButtonDisabledOverride { get; }

		public string Icon => null;

		public bool IsActive => false;

		public bool DefaultState { get; }

		public StatePersistenceMode PersistenceMode => default(StatePersistenceMode);

		public void Enable(CheatsManager manager)
		{
		}

		public void Disable()
		{
		}
	}
}
