using UnityEngine;
using plog.Handlers;
using plog.Models;

namespace plog.unity.Handlers
{
	public class UnityProxy : plog.Handlers.ILogHandler
	{
		public static readonly Logger ProxyLogger;

		private bool _capturingStackTrace;

		private string? _lastStacktrace;

		public bool SuppressingUnityLogs { get; set; }

		[HideInCallstack]
		public Log HandleRecord(Logger source, Log log)
		{
			return null;
		}

		[HideInCallstack]
		public void LogMessageReceived(string message, string stacktrace, LogType type)
		{
		}
	}
}
