namespace ULTRAKILL.Cheats
{
	public class SandboxArmDebug : ICheat
	{
		private bool active;

		private static SandboxArmDebug _lastInstance;

		public static bool DebugActive => false;

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
