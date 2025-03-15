using UnityEngine;
using UnityEngine.UI;

namespace SettingsMenu.Components
{
	public class SettingsSlider : SettingsBuilderBase
	{
		[SerializeField]
		private Button containerButton;

		[SerializeField]
		private Slider slider;

		[SerializeField]
		private SliderValueToText sliderValueToText;

		private void Awake()
		{
		}

		private void OnContainerButtonClicked()
		{
		}

		public override void ConfigureFrom(SettingsItemBuilder itemBuilder, SettingsPageBuilder pageBuilder)
		{
		}

		public void SelectInnerSlider()
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
