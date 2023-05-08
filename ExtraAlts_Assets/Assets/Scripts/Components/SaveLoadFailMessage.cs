using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class SaveLoadFailMessage : MonoSingleton<SaveLoadFailMessage>
{
    [SerializeField] private GameObject saveMergeConsentPanel;
    [SerializeField] private Text rootMergeOptionBtnText;
    [SerializeField] private Text slotOneMergeOptionBtnText;

    [SerializeField] private GameObject errorGeneric;
    [SerializeField] private GameObject errorTempValidation;
    [SerializeField] private Text tempErrorCode;

    private void OnEnable() { }
    public void ConfirmMergeRoot() { }
    public void ConfirmMergeFirstSlot() { }
    public void QuitGame() { }    
    public void ShowError(SaveLoadError error, string errorCode, Action saveRedo) { }
    private void Update() { }    
    public enum SaveLoadError { Generic, TempValidation }
}
