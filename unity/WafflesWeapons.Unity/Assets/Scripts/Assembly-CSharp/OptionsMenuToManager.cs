using System.Collections.Generic;
using SettingsMenu.Components;
using UnityEngine;
using UnityEngine.UI;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class OptionsMenuToManager : MonoSingleton<OptionsMenuToManager>
{
	public GameObject pauseMenu;

	public SettingsMenu.Components.SettingsMenu optionsMenu;

	private OptionsManager opm;

	private Camera mainCam;

	private List<string> options;

	[Space]
	public BasicConfirmationDialog quitDialog;

	public BasicConfirmationDialog resetDialog;

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

	private void SetPauseMenu()
	{
	}

	public void EnableGamepadLookAndMove()
	{
	}

	public void DisableGamepadLookAndMove()
	{
	}

	public void EnableGamepadMove()
	{
	}

	public void EnableGamepadLook()
	{
	}

	public void DisableGamepadMove()
	{
	}

	public void DisableGamepadLook()
	{
	}

	public void SetSelected(Selectable selectable)
	{
	}

	public void Pause()
	{
	}

	public void UnPause()
	{
	}

	public void RestartCheckpoint()
	{
	}

	public void RestartMission()
	{
	}

	public void RestartMissionNoConfirm()
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

	public void QuitMissionNoConfirm()
	{
	}

	public void QuitGame()
	{
	}

	public void CheckIfTutorialBeaten()
	{
	}

	public void ChangeLevel(string levelname)
	{
	}

	public void MasterVolume(float stuff)
	{
	}

	public void SFXVolume(float stuff)
	{
	}

	public void MusicVolume(float stuff)
	{
	}
}
