using System.Collections.Generic;
using UnityEngine;

public class ParticleCollisionSpawn : MonoBehaviour
{
	private ParticleSystem part;

	private List<ParticleCollisionEvent> collisionEvents;

	public GameObject toSpawn;

	private void OnParticleCollision(GameObject other)
	{
	}
}
