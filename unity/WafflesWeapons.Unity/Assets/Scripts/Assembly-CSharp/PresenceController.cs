using UnityEngine.SceneManagement;
using plog;

[ConfigureSingleton(SingletonFlags.NoAutoInstance | SingletonFlags.DestroyDuplicates)]
public class PresenceController : MonoSingleton<PresenceController>
{
	private static readonly Logger Log;

	public string[] diffNames;

	private bool trackingTimeInSandbox;

	private TimeSince timeInSandbox;

	private void Start()
	{
	}

	private void OnDisable()
	{
	}

	public static void UpdateCyberGrindWave(int wave)
	{
	}

	private void SceneManagerOnsceneLoaded(Scene _, LoadSceneMode mode)
	{
	}

	public void AddToStatInt(string statKey, int amount)
	{
	}

	private void OnApplicationQuit()
	{
	}
}
