using System;

namespace SettingsMenu.Models
{
	[Serializable]
	public struct PreferenceKey
	{
		public string key;

		public bool isLocal;

		public readonly bool IsValid()
		{
			return false;
		}

		public readonly bool GetBoolValue(bool fallbackValue = false)
		{
			return false;
		}

		public readonly int GetIntValue(int fallbackValue = 0)
		{
			return 0;
		}

		public readonly float GetFloatValue(float fallbackValue = 0f)
		{
			return 0f;
		}

		public readonly string GetStringValue(string fallbackValue = "")
		{
			return null;
		}

		public readonly void SetBoolValue(bool value)
		{
		}

		public readonly void SetIntValue(int value)
		{
		}

		public readonly void SetFloatValue(float value)
		{
		}

		public readonly void SetStringValue(string value)
		{
		}

		public readonly void SetValue<T>(T value)
		{
		}
	}
}
