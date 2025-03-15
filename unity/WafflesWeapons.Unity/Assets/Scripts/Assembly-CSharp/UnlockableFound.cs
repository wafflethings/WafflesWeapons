using UnityEngine;

public class UnlockableFound : MonoBehaviour
{
	[SerializeField]
	private UnlockableType unlockableType;

	[SerializeField]
	private bool unlockOnEnable;

	[SerializeField]
	private bool unlockOnTriggerEnter;

	private void OnEnable()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
	}

	public void Unlock()
	{
	}
}
