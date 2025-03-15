using System.Collections.Generic;
using UnityEngine;

public class ProjectileParryZone : MonoBehaviour
{
	private List<GameObject> projs;

	public Material origMat;

	public Material newMat;

	private void OnTriggerEnter(Collider other)
	{
	}

	private void OnTriggerExit(Collider other)
	{
	}

	public Projectile CheckParryZone()
	{
		return null;
	}
}
