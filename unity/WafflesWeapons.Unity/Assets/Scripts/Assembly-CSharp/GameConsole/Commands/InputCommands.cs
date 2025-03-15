using GameConsole.CommandTree;
using plog;

namespace GameConsole.Commands
{
	internal class InputCommands : CommandRoot, IConsoleLogger
	{
		public Logger Log { get; }

		public override string Name => null;

		public override string Description => null;

		public InputCommands(Console con)
			: base(null)
		{
		}

		protected override Branch BuildTree(Console con)
		{
			return null;
		}
	}
}
