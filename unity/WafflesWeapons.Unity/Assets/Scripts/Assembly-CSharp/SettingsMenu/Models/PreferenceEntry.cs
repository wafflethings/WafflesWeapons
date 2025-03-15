using System;

namespace SettingsMenu.Models
{
	[Serializable]
	public class PreferenceEntry
	{
		public PreferenceKey key;

		public PreferenceType type;

		public bool boolValue;

		public int intValue;

		public float floatValue;

		public bool IsBool()
		{
			return false;
		}

		public bool IsInt()
		{
			return false;
		}

		public bool IsFloat()
		{
			return false;
		}

		public void Apply()
		{
		}
	}
}
