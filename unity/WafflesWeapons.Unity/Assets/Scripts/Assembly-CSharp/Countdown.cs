using TMPro;
using UnityEngine;

public class Countdown : MonoBehaviour
{
	public bool changePerDifficulty;

	public float countdownLength;

	public float[] countdownLengthPerDifficulty;

	private float time;

	public TextMeshProUGUI countdownText;

	public float decimalFontSize;

	public BossHealthBar bossbar;

	public bool invertBossBarAmount;

	public bool disableBossBarOnDisable;

	public bool paused;

	public bool resetOnEnable;

	public UltrakillEvent onZero;

	private bool done;

	private int difficulty;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void Update()
	{
	}

	public void PauseState(bool pause)
	{
	}

	public void ChangeTime(float newTime)
	{
	}

	public void ResetTime()
	{
	}

	private float GetCountdownLength()
	{
		return 0f;
	}
}
