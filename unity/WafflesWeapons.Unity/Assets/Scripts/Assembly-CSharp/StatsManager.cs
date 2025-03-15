using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class StatsManager : MonoSingleton<StatsManager>
{
	[HideInInspector]
	public GameObject[] checkPoints;

	private GameObject player;

	private NewMovement nm;

	[HideInInspector]
	public Vector3 spawnPos;

	[HideInInspector]
	public CheckPoint currentCheckPoint;

	public int levelNumber;

	[HideInInspector]
	public int kills;

	[HideInInspector]
	public int stylePoints;

	[HideInInspector]
	public int restarts;

	[HideInInspector]
	public int secrets;

	[HideInInspector]
	public float seconds;

	public bool timer;

	public bool firstPlayThrough;

	private bool timerOnOnce;

	[HideInInspector]
	public bool levelStarted;

	[HideInInspector]
	public FinalRank fr;

	private StyleHUD shud;

	private GunControl gunc;

	[HideInInspector]
	public bool infoSent;

	private bool casualFR;

	public int[] timeRanks;

	public int[] killRanks;

	public int[] styleRanks;

	[HideInInspector]
	public int rankScore;

	public GameObject[] secretObjects;

	[HideInInspector]
	public List<int> prevSecrets;

	[HideInInspector]
	public List<int> newSecrets;

	[HideInInspector]
	public bool challengeComplete;

	public AudioClip[] rankSounds;

	[HideInInspector]
	public int maxGlassKills;

	[HideInInspector]
	public GameObject crosshair;

	[HideInInspector]
	public bool tookDamage;

	public GameObject bonusGhost;

	public GameObject bonusGhostSupercharge;

	[HideInInspector]
	public bool majorUsed;

	[HideInInspector]
	public bool endlessMode;

	private AssistController asscon;

	public static event Action checkpointRestart
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	protected override void Awake()
	{
	}

	protected override void OnDestroy()
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void GetCheckPoint(Vector3 position)
	{
	}

	public void Restart()
	{
	}

	public void StartTimer()
	{
	}

	public void StopTimer()
	{
	}

	public void HideShit()
	{
	}

	public void SendInfo()
	{
	}

	public string GetRanks(int[] ranksToCheck, float value, bool reverse, bool addToRankScore = false)
	{
		return null;
	}

	private void GetFinalRank()
	{
	}

	private void SetRankSound(string rank, GameObject target)
	{
	}

	public void MajorUsed()
	{
	}

	public void SecretFound(int i)
	{
	}

	public static string DivideMoney(int money)
	{
		return null;
	}
}
