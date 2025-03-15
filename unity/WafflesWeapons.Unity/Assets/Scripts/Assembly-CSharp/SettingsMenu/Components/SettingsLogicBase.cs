using UnityEngine;

namespace SettingsMenu.Components
{
	public abstract class SettingsLogicBase : MonoBehaviour
	{
		public abstract void Initialize(SettingsMenu settingsMenu);

		public abstract void OnPrefChanged(string key, object value);
	}
}
