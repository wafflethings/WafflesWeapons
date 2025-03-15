using System;

namespace GameConsole.CommandTree
{
	public class Branch : Node
	{
		public readonly string name;

		public readonly Node[] children;

		public Branch(string name, bool requireCheats, params Node[] children)
		{
		}

		public Branch(string name, params Node[] children)
		{
		}

		public Branch(string name, bool requireCheats = false, params Delegate[] onLeafExecutes)
		{
		}

		public Branch(string name, params Delegate[] onLeafExecutes)
		{
		}
	}
}
