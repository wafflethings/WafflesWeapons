using System.Collections.Generic;
using SettingsMenu.Models;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace SettingsMenu.Components
{
	[DefaultExecutionOrder(-100)]
	public class SettingsPageBuilder : MonoBehaviour
	{
		[SerializeField]
		public SettingsMenuAssets assets;

		[Space]
		[SerializeField]
		private SettingsPage page;

		[SerializeField]
		private Transform targetContainer;

		public Selectable navigationButtonSelectable;

		public Selectable[] customTopSelectables;

		public Selectable[] customBottomSelectables;

		[Space]
		[FormerlySerializedAs("buttonCallbacks")]
		public List<SettingsButtonEvent> buttonEvents;

		public List<SettingsGroupInterrupt> groupInterrupts;

		private bool pageBuilt;

		private bool selectAfterBuild;

		private GamepadObjectSelector gamepadObjectSelector;

		private Dictionary<SettingsItem, SettingsBuilderBase> createdInstances;

		private Dictionary<SettingsGroup, List<ISettingsGroupUser>> groups;

		private List<Selectable> selectableRows;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void OnDestroy()
		{
		}

		private void OnPrefChanged(string key, object value)
		{
		}

		private void OnValidate()
		{
		}

		private void BuildPage(SettingsPage settingsPage)
		{
		}

		public void SetSelected()
		{
		}

		public void RefreshSelectableNavigation()
		{
		}

		public void AddBuilderInstance(SettingsBuilderBase builder, SettingsItem item)
		{
		}

		public void AddToGroup(SettingsGroup group, ISettingsGroupUser builder)
		{
		}

		public void AddSelectableRow(Selectable selectable)
		{
		}

		public Selectable GetFirstSelectable()
		{
			return null;
		}

		public Selectable GetLastSelectable()
		{
			return null;
		}

		public void ConfirmGroupEnabled(SettingsGroup group)
		{
		}

		public void SetGroupEnabled(SettingsGroup group, bool groupEnabled, bool noInterrupts = false)
		{
		}

		private void UpdateGroupUsers(SettingsGroup group, bool groupEnabled)
		{
		}

		public bool TryGetItemBuilderInstance<T>(SettingsItem item, out T builder) where T : SettingsBuilderBase
		{
			builder = null;
			return false;
		}

		public void SetSelectedItem(SettingsItem item)
		{
		}
	}
}
