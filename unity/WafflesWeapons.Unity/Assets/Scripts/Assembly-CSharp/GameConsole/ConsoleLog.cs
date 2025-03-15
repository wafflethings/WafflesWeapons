using System;
using plog;
using plog.Models;

namespace GameConsole
{
	[Serializable]
	public class ConsoleLog
	{
		public Log log;

		public Logger source;

		public UnscaledTimeSince timeSinceLogged;

		public bool expanded;

		public ConsoleLog(Log log, Logger source)
		{
		}
	}
}
