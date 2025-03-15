using UnityEngine;

public class SetFishZone : MonoBehaviour
{
	[SerializeField]
	private bool onEnter;

	[SerializeField]
	private bool restorePreviousOnExit;

	public float suggestedFishingDistance;

	private float previousFishingDistance;

	private float previousMinDistance;

	[SerializeField]
	private bool customMinDistance;

	[SerializeField]
	private float minDistance;

	private void OnTriggerEnter(Collider other)
	{
	}

	private void OnTriggerExit(Collider other)
	{
	}

	public void Set()
	{
	}

	public void Restore()
	{
	}
}
