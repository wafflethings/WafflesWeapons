using System.Collections.Generic;
using SettingsMenu.Models;
using TMPro;
using UnityEngine;

namespace SettingsMenu.Components
{
	public class SettingsDropdown : SettingsBuilderBase
	{
		[SerializeField]
		private TMP_Dropdown dropdown;

		private SettingsItem item;

		public TMP_Dropdown.DropdownEvent onValueChanged
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public override void ConfigureFrom(SettingsItemBuilder itemBuilder, SettingsPageBuilder pageBuilder)
		{
		}

		public override void SetSelected()
		{
		}

		public override void AttachRestoreDefaultButton(SettingsRestoreDefaultButton restoreDefaultButton)
		{
		}

		public void SetDropdownItems(List<string> items, bool reloadValue = true)
		{
		}

		public void SetDropdownValue(int value, bool notify = false)
		{
		}

		private void LoadCurrentValue()
		{
		}
	}
}
