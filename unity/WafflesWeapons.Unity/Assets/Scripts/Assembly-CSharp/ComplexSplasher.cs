using System.Collections.Generic;
using UnityEngine;

public class ComplexSplasher : MonoBehaviour
{
	[SerializeField]
	private ParticleCluster splashParticles;

	[SerializeField]
	private float maxSplashDistance;

	[SerializeField]
	private float keepAliveFor;

	private List<SplashingElement> children;

	private Dictionary<ParticleCluster, TimeSince> currentSplashes;

	private int splashElementIndex;

	private void Awake()
	{
	}

	private void OnDrawGizmosSelected()
	{
	}

	private void OnDisable()
	{
	}

	private void FixedUpdate()
	{
	}
}
