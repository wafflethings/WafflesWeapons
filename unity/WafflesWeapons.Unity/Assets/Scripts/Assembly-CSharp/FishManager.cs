using System;
using System.Collections.Generic;
using UnityEngine;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class FishManager : MonoSingleton<FishManager>
{
	[SerializeField]
	private FishDB[] fishDbs;

	public Dictionary<FishObject, bool> recognizedFishes;

	public Action<FishObject> onFishUnlocked;

	private int newFoundFishes;

	public int RemainingFishes => 0;

	protected override void Awake()
	{
	}

	public bool UnlockFish(FishObject fish)
	{
		return false;
	}

	public void UpdateFishCount()
	{
	}
}
