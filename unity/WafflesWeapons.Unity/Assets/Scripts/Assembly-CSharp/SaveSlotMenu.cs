using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class SaveSlotMenu : MonoBehaviour
{
	public class SlotData
	{
		public bool exists;

		public int highestLvlNumber;

		public int highestDifficulty;

		public override string ToString()
		{
			return null;
		}
	}

	public const int Slots = 5;

	private static readonly Color ActiveColor;

	[SerializeField]
	private SlotRowPanel templateRow;

	[SerializeField]
	private Button closeButton;

	[FormerlySerializedAs("consentWrapper")]
	[SerializeField]
	private GameObject reloadConsentWrapper;

	[SerializeField]
	private TMP_Text wipeConsentContent;

	[SerializeField]
	private GameObject wipeConsentWrapper;

	private int queuedSlot;

	private SlotRowPanel[] slots;

	private void OnEnable()
	{
	}

	public void ReloadMenu()
	{
	}

	private void UpdateSlotState(SlotRowPanel targetPanel, SlotData data)
	{
	}

	public void ConfirmReload()
	{
	}

	public void ConfirmWipe()
	{
	}

	public void CancelConsent()
	{
	}

	private void SelectSlot(int slot)
	{
	}

	private void ClearSlot(int slot)
	{
	}
}
