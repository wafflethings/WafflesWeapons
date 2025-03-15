using UnityEngine;

public class FishBaitCollisionProxy : MonoBehaviour
{
	[SerializeField]
	private FishBait fishBait;

	private Vector3 lastPosition;

	private void OnTriggerExit(Collider other)
	{
	}

	private void OnCollisionEnter(Collision collision)
	{
	}

	private void Update()
	{
	}
}
