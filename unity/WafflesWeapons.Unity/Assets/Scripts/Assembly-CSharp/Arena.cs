using UnityEngine;

public class Arena : MonoBehaviour
{
	public Door[] doors;

	private void Awake()
	{
	}

	public ActivateNextWave[] GetWaves()
	{
		return null;
	}

	public static GameObject[] GetEnemies(Transform target)
	{
		return null;
	}

	public ActivateArena GetActivateArena()
	{
		return null;
	}

	private void ConfigureActivateArena(ActivateArena aa)
	{
	}

	private void ConfigureWaves(ActivateNextWave[] waves)
	{
	}

	public void AutoSetupWaves(ActivateNextWave[] waves)
	{
	}

	private void OnDrawGizmosSelected()
	{
	}
}
