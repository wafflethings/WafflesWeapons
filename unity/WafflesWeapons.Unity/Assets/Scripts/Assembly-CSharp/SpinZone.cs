using UnityEngine;

public class SpinZone : MonoBehaviour
{
	public GameObject spinSound;

	public bool dontSpinEnemies;

	private bool interactedWithItem;

	private void OnDisable()
	{
	}

	private void OnEnable()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
	}

	private void SpinEnemy(EnemyIdentifier eid)
	{
	}
}
