namespace ULTRAKILL.Cheats
{
	public class GunControlDebug : ICheat
	{
		private static GunControlDebug _lastInstance;

		public static bool GunControlActivated => false;

		public string LongName => null;

		public string Identifier => null;

		public string ButtonEnabledOverride { get; }

		public string ButtonDisabledOverride { get; }

		public string Icon => null;

		public bool IsActive { get; private set; }

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
