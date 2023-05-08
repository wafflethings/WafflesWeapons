using System.Collections.Generic;
using UnityEngine.Events;

public enum UnlockableType { Florp, KITR }

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class UnlockablesData : MonoSingleton<UnlockablesData>
{
    public UnityAction unlockableFound = delegate { };

    void Start() { }
    public void SetUnlocked(UnlockableType unlockable, bool unlocked) { }
    public void CheckSave() { }}
