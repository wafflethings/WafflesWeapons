using UnityEngine;
using plog.Models;

namespace plog.unity.Extensions
{
	public static class UnityPLogExtensions
	{
		public static Level ToPLogLevel(this LogType type)
		{
			return default(Level);
		}

		public static LogType ToUnityLogType(this Level level)
		{
			return default(LogType);
		}
	}
}
