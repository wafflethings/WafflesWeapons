using System;
using System.Collections.Generic;
using GameConsole.CommandTree;

namespace GameConsole
{
	public abstract class CommandRoot : ICommand
	{
		private delegate bool ParseMyThing(string s, out object result);

		public class PrefReference
		{
			public string Key;

			public Type Type;

			public bool Local;

			public string Default;
		}

		private Branch root;

		private const string KeyColor = "#db872c";

		private const string TypeColor = "#879fff";

		private const string ValueColor = "#4ac246";

		public abstract string Name { get; }

		public abstract string Description { get; }

		public string Command => null;

		public Branch Root => null;

		protected abstract Branch BuildTree(Console con);

		public CommandRoot(Console con)
		{
		}

		public void Execute(Console con, string[] args)
		{
		}

		private bool TryFindCorrectLeaf(string soFar, Branch branch, Queue<string> args, Console con)
		{
			return false;
		}

		private void PrintUsage(Console con, string soFar, Branch branch)
		{
		}

		public (string soFar, Branch branch) FindLongestMatchingBranch(Branch root, Queue<string> args, Console con = null, Func<Branch, string, bool> matches = null)
		{
			return default((string, Branch));
		}

		public static Branch Branch(string name, params Node[] children)
		{
			return null;
		}

		public static Branch Branch(string name, bool requireCheats, params Node[] children)
		{
			return null;
		}

		public static Branch Leaf(string name, Action onExecute, bool requireCheats = false)
		{
			return null;
		}

		public static Leaf Leaf(Action onExecute, bool requireCheats = false)
		{
			return null;
		}

		public static Branch Leaf<T>(string name, Action<T> onExecute, bool requireCheats = false)
		{
			return null;
		}

		public static Leaf Leaf<T>(Action<T> onExecute, bool requireCheats = false)
		{
			return null;
		}

		public static Branch Leaf<T, U>(string name, Action<T, U> onExecute, bool requireCheats = false)
		{
			return null;
		}

		public static Leaf Leaf<T, U>(Action<T, U> onExecute, bool requireCheats = false)
		{
			return null;
		}

		public static Branch Leaf<T, U, V>(string name, Action<T, U, V> onExecute, bool requireCheats = false)
		{
			return null;
		}

		public static Leaf Leaf<T, U, V>(Action<T, U, V> onExecute, bool requireCheats = false)
		{
			return null;
		}

		public Branch BuildPrefsEditor(List<PrefReference> pref)
		{
			return null;
		}

		public Branch BoolMenu(string commandKey, Func<bool> valueGetter, Action<bool> valueSetter, bool inverted = false, bool requireCheats = false)
		{
			return null;
		}

		private string GetStateName(bool value, bool inverted)
		{
			return null;
		}
	}
}
