using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnRadius : MonoBehaviour
{
	public GameObject[] spawnables;

	private List<GameObject> spawnedObjects;

	private List<EnemyIdentifier> currentEnemies;

	public float minimumDistance;

	public float maximumDistance;

	public float spawnCooldown;

	private float cooldown;

	public int maximumEnemyCount;

	public bool spawnAsPuppets;

	private GoreZone gz;

	private void Start()
	{
	}

	private void SlowUpdate()
	{
	}

	private void Update()
	{
	}

	public void SpawnEnemy()
	{
	}

	public void KillAllEnemies()
	{
	}
}
