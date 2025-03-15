using System;
using UnityEngine;

[Serializable]
public class PlaceholderPrefabTarget
{
	public bool delayedSwap;

	public string uniqueId;

	[HideInInspector]
	public GameObject actualPrefab;

	public string assetPath;
}
