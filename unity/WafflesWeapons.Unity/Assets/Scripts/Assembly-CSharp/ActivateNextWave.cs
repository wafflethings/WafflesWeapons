using UnityEngine;

public class ActivateNextWave : MonoBehaviour
{
	public bool lastWave;

	[HideInInspector]
	public bool activated;

	public int deadEnemies;

	public int enemyCount;

	private ActivateNextWave[] linkedAnws;

	public GameObject[] nextEnemies;

	private int currentEnemy;

	public Door[] doors;

	private int currentDoor;

	public GameObject[] toActivate;

	private bool objectsActivated;

	public Door doorForward;

	private float slowDown;

	public bool forEnemies;

	public bool killChallenge;

	public bool noActivationDelay;

	public void CountEnemies()
	{
	}

	private void Awake()
	{
	}

	private void FixedUpdate()
	{
	}

	private void SpawnEnemy()
	{
	}

	private void EndWaves()
	{
	}

	public void AddDeadEnemy()
	{
	}
}
