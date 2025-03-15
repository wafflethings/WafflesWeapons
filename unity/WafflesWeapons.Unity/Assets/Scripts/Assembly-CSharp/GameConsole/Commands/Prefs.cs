using GameConsole.CommandTree;
using plog;

namespace GameConsole.Commands
{
	public class Prefs : CommandRoot, IConsoleLogger
	{
		public Logger Log { get; }

		public override string Name => null;

		public override string Description => null;

		public Prefs(Console con)
			: base(null)
		{
		}

		protected override Branch BuildTree(Console con)
		{
			return null;
		}
	}
}
