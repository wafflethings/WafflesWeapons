using System;

namespace GameConsole.CommandTree
{
	public class Leaf : Node
	{
		public readonly Delegate onExecute;

		public Leaf(Delegate onExecute, bool requireCheats)
		{
		}

		public Leaf(Delegate onExecute)
		{
		}
	}
}
