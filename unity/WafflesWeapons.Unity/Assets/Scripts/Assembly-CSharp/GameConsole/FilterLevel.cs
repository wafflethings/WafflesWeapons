using System;

namespace GameConsole
{
	[Flags]
	public enum FilterLevel
	{
		None = 0,
		Info = 1,
		Warning = 2,
		Error = 4,
		All = 7
	}
}
