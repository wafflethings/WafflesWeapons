using UnityEngine;

namespace SettingsMenu.Models
{
	[CreateAssetMenu(fileName = "SettingsGroup", menuName = "ULTRAKILL/Settings/Group")]
	public class SettingsGroup : ScriptableObject
	{
		public SettingsGroupTogglingMode togglingMode;

		public PreferenceKey preferenceKey;

		public SettingsGroupValueType valueType;

		public bool invertValue;

		[HideInInspector]
		public int minValue;

		public bool GetEnabled()
		{
			return false;
		}

		public void SetEnabledBool(bool enabled)
		{
		}
	}
}
