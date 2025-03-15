using UnityEngine;

public class ObjectActivatorStay : MonoBehaviour
{
	public bool oneTime;

	public bool skippable;

	public bool disableOnExit;

	private bool activated;

	public float delay;

	public GameObject[] toActivate;

	public GameObject[] toDisActivate;

	public bool forEnemies;

	private void OnTriggerEnter(Collider other)
	{
	}

	private void OnTriggerStay(Collider other)
	{
	}

	private void OnTriggerExit(Collider other)
	{
	}

	private void Activate()
	{
	}

	private void OnDisable()
	{
	}
}
