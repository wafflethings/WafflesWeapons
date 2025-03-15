using System.Collections.Generic;
using UnityEngine;

public class DelayedActivationManager : MonoSingleton<DelayedActivationManager>
{
	private List<GameObject> toActivate;

	private List<float> activateCountdowns;

	private void Update()
	{
	}

	public void Add(GameObject target, float time)
	{
	}

	public void Remove(GameObject target)
	{
	}
}
