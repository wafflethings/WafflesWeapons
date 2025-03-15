using SettingsMenu.Models;
using UnityEngine;
using UnityEngine.UI;

namespace SettingsMenu.Components
{
	[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
	public class SettingsMenu : MonoSingleton<SettingsMenu>
	{
		public static bool selectedSomethingThisFrame;

		[SerializeField]
		private Transform navigationRail;

		[SerializeField]
		private Transform pageContainer;

		private GameObject[] pageGameObjects;

		private SettingsPageBuilder[] pageBuilders;

		private SettingsLogicBase[] settingsLogic;

		private bool initialized;

		private void Start()
		{
		}

		public void Initialize()
		{
		}

		public void OnPrefChanged(string key, object value)
		{
		}

		public void SetActivePage(GameObject targetPage)
		{
		}

		public static void SetSelected(Selectable selectable)
		{
		}

		private void LateUpdate()
		{
		}

		public bool TryGetItemBuilderInstance<T>(SettingsItem item, out T builder) where T : SettingsBuilderBase
		{
			builder = null;
			return false;
		}
	}
}
