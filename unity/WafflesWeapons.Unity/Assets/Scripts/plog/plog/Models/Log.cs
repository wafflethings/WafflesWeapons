using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace plog.Models
{
	public record Log
	{
		[CompilerGenerated]
		protected virtual Type EqualityContract
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
		}

		public readonly string Message;

		public DateTime Timestamp;

		public readonly Level Level;

		public IEnumerable<Tag>? ExtraTags;

		public string? StackTrace;

		public object? Context;

		public Log(string Message, Level Level, IEnumerable<Tag>? ExtraTags = null, string? StackTrace = null, object? Context = null)
		{
		}

		[CompilerGenerated]
		public override string ToString()
		{
			return null;
		}

		[CompilerGenerated]
		protected virtual bool PrintMembers(StringBuilder builder)
		{
			return false;
		}

		[CompilerGenerated]
		public virtual bool Equals(Log? other)
		{
			return false;
		}

		[CompilerGenerated]
		protected Log(Log original)
		{
		}

		[CompilerGenerated]
		public void Deconstruct(out string Message, out Level Level, out IEnumerable<Tag>? ExtraTags, out string? StackTrace, out object? Context)
		{
			Message = null;
			Level = default(Level);
			ExtraTags = null;
			StackTrace = null;
			Context = null;
		}
	}
}
