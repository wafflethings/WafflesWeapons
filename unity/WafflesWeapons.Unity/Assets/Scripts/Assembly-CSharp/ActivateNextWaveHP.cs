using UnityEngine;

public class ActivateNextWaveHP : MonoBehaviour
{
	public bool lastWave;

	private bool activated;

	public EnemyIdentifier target;

	public float health;

	public GameObject[] nextEnemies;

	private int currentEnemy;

	public Door[] doors;

	private int currentDoor;

	public GameObject[] toActivate;

	private bool objectsActivated;

	public Door doorForward;

	public bool forEnemies;

	private void Update()
	{
	}

	private void SpawnEnemy()
	{
	}

	private void EndWaves()
	{
	}
}
