using SettingsMenu.Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SettingsMenu.Components
{
	public class SettingsCategoryBuilder : MonoBehaviour, ISettingsGroupUser
	{
		[SerializeField]
		private TMP_Text title;

		[SerializeField]
		private Button button;

		[SerializeField]
		private Toggle toggle;

		[SerializeField]
		private SettingsRestoreDefaultButton restoreDefaultButton;

		private SettingsPageBuilder pageBuilder;

		private SettingsGroup group;

		public void ConfigureFrom(SettingsCategory category, SettingsPageBuilder pageBuilder)
		{
		}

		public void ToggleGroup()
		{
		}

		public void SetGroupEnabled(bool groupEnabled)
		{
		}

		public void UpdateGroupStatus(bool groupEnabled, SettingsGroupTogglingMode togglingMode)
		{
		}
	}
}
