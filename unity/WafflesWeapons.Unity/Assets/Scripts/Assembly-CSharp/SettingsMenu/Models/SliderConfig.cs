using System;

namespace SettingsMenu.Models
{
	[Serializable]
	public class SliderConfig
	{
		public float minValue;

		public float maxValue;

		public bool wholeNumbers;

		public SliderValueToTextConfig textConfig;
	}
}
