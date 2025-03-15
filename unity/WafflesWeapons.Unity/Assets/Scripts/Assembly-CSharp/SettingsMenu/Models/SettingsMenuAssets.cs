using SettingsMenu.Components;
using UnityEngine;

namespace SettingsMenu.Models
{
	[CreateAssetMenu(fileName = "SettingsMenuAssets", menuName = "ULTRAKILL/Settings/MenuAssets")]
	public class SettingsMenuAssets : ScriptableObject
	{
		public SettingsItemBuilder itemPrefab;

		public SettingsCategoryBuilder categoryTitlePrefab;

		public SettingsBuilderBase togglePrefab;

		public SettingsBuilderBase dropdownPrefab;

		public SettingsBuilderBase sliderPrefab;

		public SettingsBuilderBase actionButtonPrefab;

		public SettingsRestoreDefaultButton resetButtonPrefab;

		public SettingsRestoreDefaultButton smallResetButtonPrefab;

		public SettingsBuilderBase GetBuilderFor(SettingsItemType itemType)
		{
			return null;
		}
	}
}
