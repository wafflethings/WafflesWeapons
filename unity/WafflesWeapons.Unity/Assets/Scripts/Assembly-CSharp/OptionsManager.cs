using SettingsMenu.Components;
using UnityEngine;
using UnityEngine.UI;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class OptionsManager : MonoSingleton<OptionsManager>
{
	public bool mainMenu;

	[HideInInspector]
	public bool paused;

	public bool inIntro;

	public bool frozen;

	[HideInInspector]
	public GameObject pauseMenu;

	[HideInInspector]
	public SettingsMenu.Components.SettingsMenu optionsMenu;

	public GameObject progressChecker;

	private NewMovement nm;

	private GunControl gc;

	private FistControl fc;

	[HideInInspector]
	public float mouseSensitivity;

	[HideInInspector]
	public float simplifiedDistance;

	[HideInInspector]
	public bool simplifyEnemies;

	[HideInInspector]
	public bool outlinesOnly;

	private int screenWidth;

	private int screenHeight;

	[HideInInspector]
	public Toggle fullScreen;

	[HideInInspector]
	public float bloodstainChance;

	[HideInInspector]
	public float maxGore;

	[HideInInspector]
	public float maxStains;

	[HideInInspector]
	public GameObject playerPosInfo;

	[HideInInspector]
	public bool dontUnpause;

	public bool previousWeaponState;

	public static bool forceRadiance;

	public static bool forceSand;

	public static bool forcePuppet;

	public static bool forceBossBars;

	public static float radianceTier;

	protected override void Awake()
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

	public void SetSimplifyEnemies(int value)
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void Pause()
	{
	}

	public void UnPause()
	{
	}

	public void Freeze()
	{
	}

	public void UnFreeze()
	{
	}

	public void RestartCheckpoint()
	{
	}

	public void RestartMission()
	{
	}

	public void OpenOptions()
	{
	}

	public void CloseOptions()
	{
	}

	public void QuitMission()
	{
	}

	public void QuitGame()
	{
	}

	public void ChangeLevel(string levelname)
	{
	}

	public void ChangeLevelAbrupt(string scene)
	{
	}

	public void ChangeLevelWithPosition(string levelname)
	{
	}

	public void SetChangeLevelPosition(bool noPosition)
	{
	}
}
