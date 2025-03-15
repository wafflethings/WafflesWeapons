using UnityEngine;

namespace SettingsMenu.Components
{
	public abstract class SettingsBuilderBase : MonoBehaviour
	{
		public abstract void ConfigureFrom(SettingsItemBuilder itemBuilder, SettingsPageBuilder pageBuilder);

		public abstract void SetSelected();

		public virtual void AttachRestoreDefaultButton(SettingsRestoreDefaultButton restoreDefaultButton)
		{
		}
	}
}
