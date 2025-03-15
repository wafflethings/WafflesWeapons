using System;
using System.Reflection;
using plog;

namespace GameConsole
{
	public class PconAdapter
	{
		private static readonly Logger Log;

		private Assembly pconAssmebly;

		private Type pconClientType;

		private bool startCalled;

		public bool PConLibraryExists()
		{
			return false;
		}

		public void StartPConClient(Action<string> onExecute, Action onGameModified)
		{
		}
	}
}
