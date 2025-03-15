using System;
using UnityEngine;
using UnityEngine.UI;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class SaveLoadFailMessage : MonoSingleton<SaveLoadFailMessage>
{
	public enum SaveLoadError
	{
		Generic = 0,
		TempValidation = 1
	}

	[SerializeField]
	private GameObject saveMergeConsentPanel;

	[SerializeField]
	private Text rootMergeOptionBtnText;

	[SerializeField]
	private Text slotOneMergeOptionBtnText;

	[SerializeField]
	private GameObject errorGeneric;

	[SerializeField]
	private GameObject errorTempValidation;

	[SerializeField]
	private Text tempErrorCode;

	private SaveLoadError currentError;

	private bool beenActivated;

	private Action potentialSaveRedo;

	private static bool consentQueued;

	private static SaveSlotMenu.SlotData queuedRootSlot;

	private static SaveSlotMenu.SlotData queuedSlotOneData;

	public static void DisplayMergeConsent(SaveSlotMenu.SlotData rootSlot, SaveSlotMenu.SlotData slotOneData)
	{
	}

	private void DisplayMergeConsentInstance(SaveSlotMenu.SlotData rootSlot, SaveSlotMenu.SlotData slotOneData)
	{
	}

	private new void OnEnable()
	{
	}

	public void ConfirmMergeRoot()
	{
	}

	public void ConfirmMergeFirstSlot()
	{
	}

	public void QuitGame()
	{
	}

	public void ShowError(SaveLoadError error, string errorCode, Action saveRedo)
	{
	}

	private void HideAll()
	{
	}

	private void Update()
	{
	}
}
