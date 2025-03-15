using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SettingsMenu.Components
{
	public class SettingsActionButton : SettingsBuilderBase
	{
		[SerializeField]
		private Button button;

		[SerializeField]
		private TMP_Text label;

		public override void ConfigureFrom(SettingsItemBuilder itemBuilder, SettingsPageBuilder pageBuilder)
		{
		}

		public override void SetSelected()
		{
		}
	}
}
