using System.Collections.Generic;
using SettingsMenu.Models;
using UnityEngine;

namespace SettingsMenu.Components.Pages
{
	public class GraphicsSettings : SettingsLogicBase
	{
		[SerializeField]
		private SettingsItem resolutionItem;

		public static bool simpleNailPhysics;

		public static bool bloodEnabled;

		private SettingsMenu settingsMenu;

		private int currentResolutionIndex;

		private readonly List<(Resolution, string)> availableResolutions;

		public static bool disabledComputeShaders;

		public override void Initialize(SettingsMenu settingsMenu)
		{
		}

		private void Start()
		{
		}

		private void SetColorPalette(bool value)
		{
		}

		private void InitializeResolutionDropdown()
		{
		}

		public override void OnPrefChanged(string key, object value)
		{
		}

		private void SetGamma(float value)
		{
		}

		private void SetColorCompression(int value)
		{
		}

		public static float GetPixelizationValue(int option)
		{
			return 0f;
		}

		public static int GetColorCompressionValue(int option)
		{
			return 0;
		}

		public static float GetVertexWarpingValue(int option)
		{
			return 0f;
		}

		private void SetTextureWarping(float value)
		{
		}

		private void SetVertexWarping(int value)
		{
		}

		private void SetDithering(float value)
		{
		}

		private void GetAvailableResolutions()
		{
		}

		public void SetResolution(int stuff)
		{
		}

		private void SetFrameRateLimit(int stepValue)
		{
		}

		private void SetVSync(bool value)
		{
		}

		private void SetSimpleExplosions(bool value)
		{
		}

		private void SetSimplifyEnemies(int value)
		{
		}
	}
}
