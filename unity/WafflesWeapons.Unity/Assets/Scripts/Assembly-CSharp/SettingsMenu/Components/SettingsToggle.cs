using UnityEngine;
using UnityEngine.UI;

namespace SettingsMenu.Components
{
	public class SettingsToggle : SettingsBuilderBase
	{
		[SerializeField]
		private Toggle toggle;

		public override void ConfigureFrom(SettingsItemBuilder itemBuilder, SettingsPageBuilder pageBuilder)
		{
		}

		public override void SetSelected()
		{
		}

		public override void AttachRestoreDefaultButton(SettingsRestoreDefaultButton restoreDefaultButton)
		{
		}
	}
}
