using UnityEngine;

public class BloodDestroyer : MonoBehaviour, IBloodstainReceiver
{
	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	public bool HandleBloodstainHit(ref RaycastHit hit)
	{
		return false;
	}
}
