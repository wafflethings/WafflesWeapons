using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace SettingsMenu.Models
{
	public class SettingsItem : ScriptableObject
	{
		public string label;

		public SettingsItemType itemType;

		public SettingsItemStyle style;

		public SettingsGroup group;

		public PlatformRequirements platformRequirements;

		[HideInInspector]
		public bool noResetButton;

		[HideInInspector]
		public SettingsDropdownType dropdownType;

		[HideInInspector]
		public string dropdownEnumType;

		[HideInInspector]
		public string[] dropdownList;

		[HideInInspector]
		public SliderConfig sliderConfig;

		[HideInInspector]
		public string buttonLabel;

		[HideInInspector]
		public string sideNote;

		[HideInInspector]
		public PreferenceKey preferenceKey;

		[HideInInspector]
		[Tooltip("The multiplier applied to values before displaying them to the user, that is also reversed before saving.\n\nFor example a multiplier of 100, will cause the value of 0.5 to be displayed as 50 on a slider, while still being saved as 0.5")]
		public float valueDisplayMultiplayer;

		[HideInInspector]
		public ValueType valueType;

		[FormerlySerializedAs("dropdownCombinationOptions")]
		[HideInInspector]
		public List<DropdownCombinationRestoreDefaultButton.CombinationOption> combinationOptions;

		[HideInInspector]
		public int defaultCombination;

		public string GetLabel(bool capitalize = true)
		{
			return null;
		}

		public List<string> GetDropdownItems()
		{
			return null;
		}
	}
}
