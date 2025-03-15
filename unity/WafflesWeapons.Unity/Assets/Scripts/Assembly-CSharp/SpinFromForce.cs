using System.Collections.Generic;
using UnityEngine;

public class SpinFromForce : MonoBehaviour
{
	public Vector3 rotationAxis;

	public float angularDrag;

	public float mass;

	private Vector3 angularVelocity;

	private void Update()
	{
	}

	public void AddSpin(ref List<ParticleCollisionEvent> pEvents)
	{
	}
}
