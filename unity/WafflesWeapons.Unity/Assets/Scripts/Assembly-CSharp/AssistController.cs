using UnityEngine;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class AssistController : MonoSingleton<AssistController>
{
	public bool majorEnabled;

	[HideInInspector]
	public bool cheatsEnabled;

	[HideInInspector]
	public bool hidePopup;

	[HideInInspector]
	public float gameSpeed;

	[HideInInspector]
	public float damageTaken;

	[HideInInspector]
	public bool infiniteStamina;

	[HideInInspector]
	public bool disableHardDamage;

	[HideInInspector]
	public bool disableWhiplashHardDamage;

	[HideInInspector]
	public bool disableWeaponFreshness;

	public int punchAssistFrames;

	[HideInInspector]
	public int difficultyOverride;

	private StatsManager sman;

	private void Start()
	{
	}

	protected override void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnPrefChanged(string key, object value)
	{
	}

	public void MajorEnabled()
	{
	}
}
