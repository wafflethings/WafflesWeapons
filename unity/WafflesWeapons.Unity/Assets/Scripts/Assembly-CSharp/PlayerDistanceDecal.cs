using UnityEngine;

public class PlayerDistanceDecal : MonoBehaviour
{
	public GameObject decal;

	private GameObject currentDecal;

	private Collider col;

	private GameObject camObj;

	private void OnDisable()
	{
	}

	private void OnCollisionStay(Collision collision)
	{
	}

	private void OnCollisionExit(Collision collision)
	{
	}

	private void OnTriggerStay(Collider other)
	{
	}

	private void OnTriggerExit(Collider other)
	{
	}
}
