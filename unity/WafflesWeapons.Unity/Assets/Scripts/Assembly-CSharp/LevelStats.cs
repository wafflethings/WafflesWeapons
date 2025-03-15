using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelStats : MonoBehaviour
{
	public bool cyberGrind;

	public bool secretLevel;

	public TMP_Text levelName;

	private bool ready;

	public TMP_Text time;

	public TMP_Text timeRank;

	private float seconds;

	private float minutes;

	public TMP_Text kills;

	public TMP_Text killsRank;

	public TMP_Text style;

	public TMP_Text styleRank;

	public Image[] secrets;

	private bool checkSecrets;

	public Sprite filledSecret;

	public TMP_Text challenge;

	public TMP_Text majorAssists;

	[Header("Cyber Grind")]
	public TMP_Text wave;

	public TMP_Text enemiesLeft;

	private StatsManager sman => null;

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void CheckStats()
	{
	}
}
