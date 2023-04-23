using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class SaveSlotMenu : MonoBehaviour
{
    public const int Slots = 5;

    [SerializeField] private SlotRowPanel templateRow;
    [SerializeField] private Button closeButton;
    [FormerlySerializedAs("consentWrapper")] [SerializeField] private GameObject reloadConsentWrapper;

    [SerializeField] private Text wipeConsentContent;
    [SerializeField] private GameObject wipeConsentWrapper;

    private void OnEnable() { }
    public void ConfirmReload() { }
    public void ConfirmWipe() { }
    public void CancelConsent() { }
    public class SlotData
    {
        public bool exists;
        public int highestLvlNumber;
        public int highestDifficulty;
    }
}
