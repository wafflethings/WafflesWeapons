using System.Collections.Generic;
using UnityEngine;

public class PhysicalShockwave : MonoBehaviour
{
	public EnemyTarget target;

	public int damage;

	public float speed;

	public float maxSize;

	public float force;

	public bool hasHurtPlayer;

	public bool enemy;

	public bool noDamageToEnemy;

	private List<Collider> hitColliders;

	public EnemyType enemyType;

	public GameObject soundEffect;

	[HideInInspector]
	public bool fading;

	private ScaleNFade[] faders;

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void OnCollisionEnter(Collision collision)
	{
	}

	private void OnTriggerEnter(Collider collision)
	{
	}

	private void CheckCollision(Collider col)
	{
	}

	private void GetDestroyed()
	{
	}
}
