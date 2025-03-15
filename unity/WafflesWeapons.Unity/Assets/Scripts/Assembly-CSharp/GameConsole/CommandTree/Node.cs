namespace GameConsole.CommandTree
{
	public abstract class Node
	{
		public readonly bool requireCheats;

		protected Node(bool requireCheats = false)
		{
		}
	}
}
