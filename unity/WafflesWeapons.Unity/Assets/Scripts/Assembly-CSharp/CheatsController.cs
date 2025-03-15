using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using plog;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class CheatsController : MonoSingleton<CheatsController>
{
	private static readonly plog.Logger Log;

	public GameObject spawnerArm;

	public GameObject fullBrightLight;

	private static readonly KeyCode[] Sequence;

	[Space]
	[SerializeField]
	private GameObject consentScreen;

	[SerializeField]
	private GameObject cheatsEnabledPanel;

	[SerializeField]
	private GameObject cheatsInfoPanel;

	[SerializeField]
	public GameObject cheatsTeleportPanel;

	public TMP_Text cheatsInfo;

	[Space]
	[SerializeField]
	private AudioSource cheatEnabledSound;

	[SerializeField]
	private AudioSource cheatDisabledSound;

	private int sequenceIndex;

	public bool cheatsEnabled;

	private bool noclip;

	private bool flight;

	private bool infiniteJumps;

	private bool stayEnabled;

	private static bool TryGetKeyboardButton(int sequenceIndex, out ButtonControl button)
	{
		button = null;
		return false;
	}

	private static bool TryGetGamepadButton(int sequenceIndex, out ButtonControl button)
	{
		button = null;
		return false;
	}

	public void ShowTeleportPanel()
	{
	}

	private void Start()
	{
	}

	public void PlayToggleSound(bool newState)
	{
	}

	private void ProcessInput()
	{
	}

	private bool AnyGamepadButtonPressed()
	{
		return false;
	}

	private bool GamepadCombo()
	{
		return false;
	}

	public void Update()
	{
	}

	public void ActivateCheats()
	{
	}

	public void Cancel()
	{
	}
}
