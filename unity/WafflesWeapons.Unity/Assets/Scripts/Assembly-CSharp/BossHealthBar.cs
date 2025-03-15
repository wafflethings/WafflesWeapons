using UnityEngine;
using UnityEngine.Serialization;
using plog;

public class BossHealthBar : MonoBehaviour
{
	private static readonly plog.Logger Log;

	[HideInInspector]
	public int bossBarId;

	[HideInInspector]
	public IEnemyHealthDetails source;

	public HealthLayer[] healthLayers;

	public string bossName;

	public bool secondaryBar;

	[FormerlySerializedAs("secondaryColor")]
	[SerializeField]
	public Color secondaryBarColor;

	public float secondaryBarValue;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void OnEnable()
	{
	}

	public void UpdateSecondaryBar(float value)
	{
	}

	public void SetSecondaryBarColor(Color clr)
	{
	}

	private void Update()
	{
	}

	private void OnDisable()
	{
	}

	public void DisappearBar()
	{
	}

	public void ChangeName(string newName)
	{
	}
}
