using SettingsMenu.Models;

namespace SettingsMenu.Components
{
	public interface ISettingsGroupUser
	{
		void UpdateGroupStatus(bool enabled, SettingsGroupTogglingMode togglingMode);
	}
}
