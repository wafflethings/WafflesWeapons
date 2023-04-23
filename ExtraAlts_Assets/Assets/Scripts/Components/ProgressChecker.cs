using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class ProgressChecker : MonoSingleton<ProgressChecker>
{
    public bool continueWithoutSaving;

     
    protected override void Awake() { }
    public void DisableSaving() { }
    public void SaveLoadError(SaveLoadFailMessage.SaveLoadError error = SaveLoadFailMessage.SaveLoadError.Generic, string tempValidationError = "", Action saveRedo = null) { }}
