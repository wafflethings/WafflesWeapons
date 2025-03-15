using System.Collections.Generic;
using UnityEngine;

public class BloodAbsorberChild : MonoBehaviour, IBloodstainReceiver
{
	[HideInInspector]
	public BloodAbsorber bloodGroup;

	private void Start()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	public bool HandleBloodstainHit(ref RaycastHit hit)
	{
		return false;
	}

	public void ProcessWasherSpray(ref List<ParticleCollisionEvent> pEvents, Vector3 position)
	{
	}
}
