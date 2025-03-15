using System.Collections.Generic;
using plog;

namespace GameConsole
{
	public class Binds
	{
		public Dictionary<string, InputActionState> registeredBinds;

		public Dictionary<string, string> defaultBinds;

		private Logger Log { get; }

		public bool OpenPressed => false;

		public bool SubmitPressed => false;

		public bool AutocompletePressed => false;

		public bool CommandHistoryUpPressed => false;

		public bool CommandHistoryDownPressed => false;

		public bool ScrollUpPressed => false;

		public bool ScrollDownPressed => false;

		public bool ScrollToBottomPressed => false;

		public bool ScrollToTopPressed => false;

		public bool ScrollUpHeld => false;

		public bool ScrollDownHeld => false;

		private bool SafeWasPerformed(string key)
		{
			return false;
		}

		private bool SafeIsHeld(string key)
		{
			return false;
		}

		public void Initialize()
		{
		}

		public void Rebind(string key, string bind)
		{
		}
	}
}
