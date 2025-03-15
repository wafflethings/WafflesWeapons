using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpread : MonoBehaviour
{
	private GameObject projectile;

	public float spreadAmount;

	public int projectileAmount;

	public float timeUntilDestroy;

	public bool parried;

	public bool dontSpawn;

	public EnemyTarget target;

	[HideInInspector]
	public List<EnemyIdentifier> hitEnemies;

	private void Start()
	{
	}

	public void ParriedProjectile()
	{
	}

	private void NoLongerParried()
	{
	}

	private void Remove()
	{
	}
}
