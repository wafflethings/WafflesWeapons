using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class FinalRank : MonoSingleton<FinalRank>
{
	public bool casual;

	public bool dontSavePos;

	public bool reachedSecondPit;

	public TMP_Text time;

	private float savedTime;

	public TMP_Text timeRank;

	private bool countTime;

	private int minutes;

	private float seconds;

	private float checkedSeconds;

	public TMP_Text kills;

	private int savedKills;

	public TMP_Text killsRank;

	private bool countKills;

	private float checkedKills;

	public TMP_Text style;

	private int savedStyle;

	public TMP_Text styleRank;

	private bool countStyle;

	private float checkedStyle;

	public TMP_Text extraInfo;

	public TMP_Text totalRank;

	public TMP_Text secrets;

	public Image[] secretsInfo;

	private int secretsFound;

	public GameObject[] levelSecrets;

	private int checkedSecrets;

	private int secretsCheckProgress;

	private int allSecrets;

	public List<int> prevSecrets;

	public Image[] challenges;

	public GameObject[] toAppear;

	private int i;

	private bool flashFade;

	private Image flashPanel;

	private Color flashColor;

	private float flashMultiplier;

	private Vector3 maxPos;

	private Vector3 startingPos;

	private Vector3 goalPos;

	public bool complete;

	public GameObject playerPosInfo;

	public Vector3 finalPitPos;

	private AsyncOperation asyncLoad;

	private string oldBundle;

	private bool rankless;

	public GameObject ppiObject;

	public string targetLevelName;

	public TMP_Text pointsText;

	public int totalPoints;

	private bool loadAndActivateScene;

	public bool dependenciesLoaded;

	private bool sceneBundleLoaded;

	private bool skipping;

	private float timeBetween;

	private bool noRestarts;

	private bool noDamage;

	private bool majorAssists;

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void SetTime(float seconds, string rank)
	{
	}

	public void SetKills(int killAmount, string rank)
	{
	}

	public void SetStyle(int styleAmount, string rank)
	{
	}

	public void SetInfo(int restarts, bool damage, bool majorUsed, bool cheatsUsed)
	{
	}

	public void SetRank(string rank)
	{
	}

	public void SetSecrets(int secretsAmount, int maxSecrets)
	{
	}

	public void Appear()
	{
	}

	public void FlashPanel(GameObject panel)
	{
	}

	private void CountSecrets()
	{
	}

	public void RanklessNextLevel(string lvlname)
	{
	}

	public void LevelChange(bool force = false)
	{
	}

	public void AddPoints(int points)
	{
	}

	private void PointsShow()
	{
	}
}
