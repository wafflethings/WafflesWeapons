using GameConsole.CommandTree;

namespace GameConsole.Commands
{
	public class Pcon : CommandRoot
	{
		public override string Name => null;

		public override string Description => null;

		public Pcon(Console con)
			: base(null)
		{
		}

		protected override Branch BuildTree(Console con)
		{
			return null;
		}
	}
}
