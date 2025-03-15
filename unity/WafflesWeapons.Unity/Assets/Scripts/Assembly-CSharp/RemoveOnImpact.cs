using UnityEngine;

public class RemoveOnImpact : MonoBehaviour
{
	public string otherTag;

	public float timeUntilRemove;

	private void OnTriggerEnter(Collider other)
	{
	}

	private void RemoveSelf()
	{
	}
}
