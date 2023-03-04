using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class ProgressChecker : MonoSingleton<ProgressChecker>
{
    public bool continueWithoutSaving;

    public void SaveLoadError()
{}}
