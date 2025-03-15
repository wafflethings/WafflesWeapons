using System.Collections.Generic;
using UnityEngine;

public class Glass : MonoBehaviour
{
	public bool broken;

	public bool wall;

	private Transform[] glasses;

	public GameObject shatterParticle;

	private int kills;

	private Collider[] cols;

	private List<GameObject> enemies;

	public void Shatter()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
	}

	private void OnTriggerExit(Collider other)
	{
	}

	private void BecomeObstacle()
	{
	}
}
