using System.Collections.Generic;
using UnityEngine;

public class MovementParticleTrigger : MonoBehaviour
{
	public GameObject particle;

	public float distancePerParticle;

	private Collider[] colliders;

	[HideInInspector]
	public List<EntererTracker> enterers;

	private void Awake()
	{
	}

	private void OnCollisionEnter(Collision collision)
	{
	}

	private void OnTriggerEnter(Collider other)
	{
	}

	private void Enter(Collider other)
	{
	}

	private void OnCollisionExit(Collision collision)
	{
	}

	private void OnTriggerExit(Collider other)
	{
	}

	private void Exit(Collider other)
	{
	}

	private void OnDisable()
	{
	}

	private void Update()
	{
	}

	private EntererTracker IsTracked(GameObject gob)
	{
		return null;
	}

	private Vector3 GetClosestPointOnTrigger(Vector3 position)
	{
		return default(Vector3);
	}
}
