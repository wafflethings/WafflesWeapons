using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace plog.unity.Models
{
	public record UnityConfiguration
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

		public static UnityConfiguration Default => null;

		public static UnityConfiguration RuntimeDefault => null;

		public bool ColorizeMessages;

		public bool ColorizeLoggerTags;

		public bool ShowLoggerTags;

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
		public virtual bool Equals(UnityConfiguration? other)
		{
			return false;
		}

		[CompilerGenerated]
		protected UnityConfiguration(UnityConfiguration original)
		{
		}

		public UnityConfiguration()
		{
		}
	}
}
