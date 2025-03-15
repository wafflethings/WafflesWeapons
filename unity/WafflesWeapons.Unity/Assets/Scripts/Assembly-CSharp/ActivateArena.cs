using UnityEngine;

[DefaultExecutionOrder(500)]
public class ActivateArena : MonoBehaviour
{
	public bool onlyWave;

	[HideInInspector]
	public bool activated;

	public Door[] doors;

	public GameObject[] enemies;

	private int currentEnemy;

	public bool forEnemy;

	public int waitForStatus;

	public bool activateOnEnable;

	private ArenaStatus astat;

	private bool playerIn;

	private void OnEnable()
	{
	}

	private void Update()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
	}

	private void OnTriggerExit(Collider other)
	{
	}

	public void Activate()
	{
	}

	private void SpawnEnemy()
	{
	}
}
