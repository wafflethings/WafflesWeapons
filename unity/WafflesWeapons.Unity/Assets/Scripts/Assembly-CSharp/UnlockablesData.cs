using System.Collections.Generic;
using UnityEngine.Events;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class UnlockablesData : MonoSingleton<UnlockablesData>
{
	public UnityAction unlockableFound;

	private bool checkedSave;

	private readonly HashSet<UnlockableType> unlocked;

	private void InitDictionary()
	{
	}

	private void Start()
	{
	}

	public bool IsUnlocked(UnlockableType unlockable)
	{
		return false;
	}

	public void SetUnlocked(UnlockableType unlockable, bool unlocked)
	{
	}

	public void CheckSave()
	{
	}
}
