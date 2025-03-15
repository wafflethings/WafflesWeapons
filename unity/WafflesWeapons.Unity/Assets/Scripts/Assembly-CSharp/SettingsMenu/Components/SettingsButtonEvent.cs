using System;
using SettingsMenu.Models;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace SettingsMenu.Components
{
	[Serializable]
	public struct SettingsButtonEvent
	{
		public SettingsItem buttonItem;

		[FormerlySerializedAs("callback")]
		public UnityEvent onClickEvent;
	}
}
