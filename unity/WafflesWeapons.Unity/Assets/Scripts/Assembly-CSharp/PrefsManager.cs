using System;
using System.Collections.Generic;
using System.IO;
using plog;

[ConfigureSingleton(SingletonFlags.PersistAutoInstance | SingletonFlags.DestroyDuplicates)]
public class PrefsManager : MonoSingleton<PrefsManager>
{
	private enum PrefsCommitMode
	{
		Immediate = 0,
		OnQuit = 1,
		DirtySlowTick = 2
	}

	private static readonly Logger Log;

	private FileStream prefsStream;

	private FileStream localPrefsStream;

	private static PrefsCommitMode CommitMode;

	private TimeSince timeSinceLastTick;

	private const float SlowTickCommitInterval = 3f;

	private const bool DebugLogging = false;

	private bool isDirty;

	private bool isLocalDirty;

	public static int monthsSinceLastPlayed;

	public static Action<string, object> onPrefChanged;

	public Dictionary<string, object> prefMap;

	public Dictionary<string, object> localPrefMap;

	private readonly Dictionary<string, Func<object, object>> propertyValidators;

	public readonly Dictionary<string, object> defaultValues;

	private static string prefsNote;

	public static string PrefsPath => null;

	public bool HasKey(string key)
	{
		return false;
	}

	public void DeleteKey(string key)
	{
	}

	public bool GetBoolLocal(string key, bool fallback = false)
	{
		return false;
	}

	public bool GetBool(string key, bool fallback = false)
	{
		return false;
	}

	public void SetBoolLocal(string key, bool content)
	{
	}

	public void SetBool(string key, bool content)
	{
	}

	public int GetIntLocal(string key, int fallback = 0)
	{
		return 0;
	}

	public int GetInt(string key, int fallback = 0)
	{
		return 0;
	}

	public void SetIntLocal(string key, int content)
	{
	}

	public void SetInt(string key, int content)
	{
	}

	public float GetFloatLocal(string key, float fallback = 0f)
	{
		return 0f;
	}

	public float GetFloat(string key, float fallback = 0f)
	{
		return 0f;
	}

	public void SetFloatLocal(string key, float content)
	{
	}

	public void SetFloat(string key, float content)
	{
	}

	public string GetStringLocal(string key, string fallback = null)
	{
		return null;
	}

	public string GetString(string key, string fallback = null)
	{
		return null;
	}

	public void SetStringLocal(string key, string content)
	{
	}

	public void SetString(string key, string content)
	{
	}

	private void CommitPrefs(bool local)
	{
	}

	private void UpdateTimestamp()
	{
	}

	private void EnsureInitialized()
	{
	}

	private void Initialize()
	{
	}

	private object EnsureValid(string key, object value)
	{
		return null;
	}

	private Dictionary<string, object> LoadPrefs(FileStream stream)
	{
		return null;
	}

	protected override void Awake()
	{
	}

	private void Start()
	{
	}

	private void FixedUpdate()
	{
	}

	private void OnApplicationQuit()
	{
	}
}
