using UnityEngine;

namespace SettingsMenu.Models
{
	[CreateAssetMenu(fileName = "SettingsPage", menuName = "ULTRAKILL/Settings/Page")]
	public class SettingsPage : ScriptableObject
	{
		public SettingsCategory[] categories;
	}
}
