using System;

namespace SettingsMenu.Models
{
	[Serializable]
	public class PlatformRequirements
	{
		public bool requiresSteam;

		public bool requiresDiscord;

		public bool requiresFileSystemAccess;

		public bool hideInCloudManaged;

		public bool Check()
		{
			return false;
		}

		public static bool IsCloudManagedRelease()
		{
			return false;
		}
	}
}
