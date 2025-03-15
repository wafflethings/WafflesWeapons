using System.Collections.Generic;
using UnityEngine.Events;
using plog;

namespace Logic
{
	[ConfigureSingleton(SingletonFlags.PersistAutoInstance)]
	public class MapVarManager : MonoSingleton<MapVarManager>
	{
		private static readonly Logger Log;

		private VarStore currentStore;

		private VarStore stashedStore;

		private MapVarSaver saver;

		private readonly Dictionary<string, List<UnityAction<int>>> intSubscribers;

		private readonly Dictionary<string, List<UnityAction<bool>>> boolSubscribers;

		private readonly Dictionary<string, List<UnityAction<float>>> floatSubscribers;

		private readonly Dictionary<string, List<UnityAction<string>>> stringSubscribers;

		private readonly List<UnityAction<string, object>> globalSubscribers;

		public static bool LoggingEnabled;

		public VarStore Store => null;

		public bool HasStashedStore => false;

		private void Start()
		{
		}

		public void ReloadMapVars()
		{
		}

		public void ResetStores()
		{
		}

		private void RestorePersistent()
		{
		}

		public void StashStore()
		{
		}

		public void RestoreStashedStore()
		{
		}

		public void RegisterIntWatcher(string key, UnityAction<int> callback)
		{
		}

		public void RegisterBoolWatcher(string key, UnityAction<bool> callback)
		{
		}

		public void RegisterFloatWatcher(string key, UnityAction<float> callback)
		{
		}

		public void RegisterStringWatcher(string key, UnityAction<string> callback)
		{
		}

		public void RegisterGlobalWatcher(UnityAction<string, object> callback)
		{
		}

		public void SetInt(string key, int value, bool persistent = false)
		{
		}

		public void AddInt(string key, int value, bool persistent = false)
		{
		}

		public void SetBool(string key, bool value, bool persistent = false)
		{
		}

		public void SetFloat(string key, float value, bool persistent = false)
		{
		}

		public void SetString(string key, string value, bool persistent = false)
		{
		}

		public int? GetInt(string key)
		{
			return null;
		}

		public bool? GetBool(string key)
		{
			return null;
		}

		public float? GetFloat(string key)
		{
			return null;
		}

		public string GetString(string key)
		{
			return null;
		}

		public List<VariableSnapshot> GetAllVariables()
		{
			return null;
		}
	}
}
