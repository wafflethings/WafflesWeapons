using UnityEngine;

namespace SettingsMenu.Models
{
	[CreateAssetMenu(fileName = "SettingsPreset", menuName = "ULTRAKILL/Settings/Preset")]
	public class SettingsPreset : ScriptableObject
	{
		public PreferenceEntry[] preferences;

		public void Apply()
		{
		}
	}
}
