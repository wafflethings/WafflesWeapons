using plog;

namespace GameConsole.Commands
{
	public class Scene : ICommand, IConsoleLogger
	{
		public Logger Log { get; }

		public string Name => null;

		public string Description => null;

		public string Command => null;

		public void Execute(Console con, string[] args)
		{
		}
	}
}
