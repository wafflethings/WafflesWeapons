using UnityEngine;

public class PlayerSoftPuller : MonoBehaviour
{
	public float pullAmount;

	public bool useX;

	public bool useY;

	public bool useZ;

	private int playerIsIn;

	private void OnDisable()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
	}

	private void OnTriggerExit(Collider other)
	{
	}

	private void FixedUpdate()
	{
	}
}
