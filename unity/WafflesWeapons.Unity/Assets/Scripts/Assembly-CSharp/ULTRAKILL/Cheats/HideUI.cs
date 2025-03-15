using plog;

namespace ULTRAKILL.Cheats
{
	public class HideUI : ICheat
	{
		private static readonly Logger Log;

		private HudController[] hudControllers;

		public static bool Active => false;

		private static HideUI Instance { get; set; }

		public string LongName => null;

		public string Identifier => null;

		public string ButtonEnabledOverride { get; }

		public string ButtonDisabledOverride { get; }

		public string Icon { get; }

		public bool IsActive { get; private set; }

		public bool DefaultState => false;

		public StatePersistenceMode PersistenceMode => default(StatePersistenceMode);

		public void Enable(CheatsManager manager)
		{
		}

		public void Disable()
		{
		}

		public void Update()
		{
		}
	}
}
