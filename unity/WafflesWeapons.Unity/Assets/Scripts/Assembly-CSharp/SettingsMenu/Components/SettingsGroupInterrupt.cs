using System;
using SettingsMenu.Models;
using UnityEngine.Events;

namespace SettingsMenu.Components
{
	[Serializable]
	public struct SettingsGroupInterrupt
	{
		public SettingsGroup group;

		public bool suppressDefaultEnable;

		public UnityEvent onEnableEvent;
	}
}
