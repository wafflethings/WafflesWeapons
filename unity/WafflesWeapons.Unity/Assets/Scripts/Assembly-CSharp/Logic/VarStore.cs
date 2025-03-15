using System.Collections.Generic;
using plog;

namespace Logic
{
	public class VarStore
	{
		private static readonly Logger Log;

		public HashSet<string> persistentKeys;

		public Dictionary<string, int> intStore;

		public Dictionary<string, bool> boolStore;

		public Dictionary<string, float> floatStore;

		public Dictionary<string, string> stringStore;

		public void Clear()
		{
		}

		public VarStore DuplicateStore()
		{
			return null;
		}

		public static VarStore LoadPersistentStore()
		{
			return null;
		}

		public static void LoadVariable(SavedVariable variable, VarStore store)
		{
		}
	}
}
