using System;
using SettingsMenu.Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SettingsMenu.Components
{
	public class SettingsItemBuilder : MonoBehaviour, ISettingsGroupUser
	{
		[NonSerialized]
		public SettingsItem asset;

		[SerializeField]
		private TMP_Text label;

		[SerializeField]
		private TMP_Text sideNote;

		[SerializeField]
		private GameObject blocker;

		private RectTransform rectTransform;

		private Image image;

		private CanvasGroup canvasGroup;

		private void Awake()
		{
		}

		public void ConfigureFrom(SettingsItem item, SettingsCategory category, SettingsPageBuilder pageBuilder)
		{
		}

		private void ApplyStyle(SettingsItemStyle style)
		{
		}

		private void ResizeBuilderToFitSideNote(RectTransform builderRectTransform)
		{
		}

		public void ValueChanged<T>(T value)
		{
		}

		public void UpdateGroupStatus(bool groupEnabled, SettingsGroupTogglingMode togglingMode)
		{
		}
	}
}
