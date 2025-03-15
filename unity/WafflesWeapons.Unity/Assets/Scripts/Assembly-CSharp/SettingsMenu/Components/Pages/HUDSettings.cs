using UnityEngine;
using UnityEngine.UI;

namespace SettingsMenu.Components.Pages
{
	public class HUDSettings : SettingsLogicBase
	{
		public static bool powerUpMeterEnabled;

		public static bool railcannonMeterEnabled;

		public static bool weaponIconEnabled;

		public Material hudMaterial;

		public Material hudTextMaterial;

		private HudController[] hudCons;

		private Mask[] masks;

		public override void Initialize(SettingsMenu settingsMenu)
		{
		}

		public override void OnPrefChanged(string key, object value)
		{
		}

		private void SetPowerUpMeter(bool value)
		{
		}

		private void AlwaysOnTop(bool stuff)
		{
		}
	}
}
