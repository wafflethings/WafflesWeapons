using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LayerSelect : MonoBehaviour
{
	public SecretMissionPanel secretMissionPanel;

	public int layerNumber;

	public int levelAmount;

	private float totalScore;

	private float scoresChecked;

	private int perfects;

	public int golds;

	private bool secretMission;

	[HideInInspector]
	public TMP_Text rankText;

	[HideInInspector]
	public Image rankImage;

	[HideInInspector]
	public Sprite rankSpriteOriginal;

	public Sprite rankSpriteOnP;

	public bool gold;

	public bool allPerfects;

	public int trueScore;

	public bool complete;

	public bool noSecretMission;

	[HideInInspector]
	public LevelSelectLeaderboard[] childLeaderboards;

	private Color defaultColor;

	private void Awake()
	{
	}

	private void Setup()
	{
	}

	private void OnDisable()
	{
	}

	public void CheckScore()
	{
	}

	public void AddScore(int score, bool perfect = false)
	{
	}

	public void Gold()
	{
	}

	public void SecretMissionDone()
	{
	}
}
