using Discord;
using UnityEngine;
using plog;

public class DiscordController : MonoBehaviour
{
	private static readonly plog.Logger Log;

	public static DiscordController Instance;

	[SerializeField]
	private long discordClientId;

	[Space]
	[SerializeField]
	private SerializedActivityAssets customLevelActivityAssets;

	[SerializeField]
	private SerializedActivityAssets missingActivityAssets;

	[SerializeField]
	private ActivityRankIcon[] rankIcons;

	private global::Discord.Discord discord;

	private ActivityManager activityManager;

	private int lastPoints;

	private bool disabled;

	private Activity cachedActivity;

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnPrefChanged(string id, object value)
	{
	}

	private void Update()
	{
	}

	private void OnApplicationQuit()
	{
	}

	public static void UpdateRank(int rank)
	{
	}

	public static void UpdateStyle(int points)
	{
	}

	public static void UpdateWave(int wave)
	{
	}

	public static void Disable()
	{
	}

	public static void Enable()
	{
	}

	private void ResetActivityCache()
	{
	}

	public void FetchSceneActivity(string scene)
	{
	}

	private void SendActivity()
	{
	}
}
