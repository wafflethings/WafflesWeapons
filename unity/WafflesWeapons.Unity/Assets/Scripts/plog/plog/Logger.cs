using System.Collections.Generic;
using System.Diagnostics;
using plog.Handlers;
using plog.Models;

namespace plog
{
	public class Logger
	{
		public readonly Tag? Tag;

		public bool NotifyParent;

		private Logger? _parent;

		private readonly List<ILogHandler> _handlers;

		public static Logger Root { get; }

		public Logger? Parent
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public void Info(string message, IEnumerable<Tag>? extraTags = null, string? stackTrace = null, object? context = null)
		{
		}

		public void Fine(string message, IEnumerable<Tag>? extraTags = null, string? stackTrace = null, object? context = null)
		{
		}

		public void Warning(string message, IEnumerable<Tag>? extraTags = null, string? stackTrace = null, object? context = null)
		{
		}

		public void Error(string message, IEnumerable<Tag>? extraTags = null, string? stackTrace = null, object? context = null)
		{
		}

		public void Exception(string message, IEnumerable<Tag>? extraTags = null, string? stackTrace = null, object? context = null)
		{
		}

		public void CommandLine(string message, IEnumerable<Tag>? extraTags = null, string? stackTrace = null, object? context = null)
		{
		}

		public void Config(string message, IEnumerable<Tag>? extraTags = null, string? stackTrace = null, object? context = null)
		{
		}

		[Conditional("DEBUG")]
		public void Debug(string message, IEnumerable<Tag>? extraTags = null, string? stackTrace = null, object? context = null)
		{
		}

		public Logger()
		{
		}

		public Logger(string name)
		{
		}

		public Logger(object self)
		{
		}

		public void AddHandler(ILogHandler handler)
		{
		}

		public void Record(string message, Level level, IEnumerable<Tag>? extraTags = null, string? stackTrace = null, object? context = null)
		{
		}

		public void Record(Log log)
		{
		}

		protected void Record(Log log, Logger source)
		{
		}
	}
}
