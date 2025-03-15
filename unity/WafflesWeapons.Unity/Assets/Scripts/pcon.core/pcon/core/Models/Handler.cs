using System;

namespace pcon.core.Models
{
	public class Handler
	{
		public Action<string> onExecute;

		public Action onGameModified;
	}
}
