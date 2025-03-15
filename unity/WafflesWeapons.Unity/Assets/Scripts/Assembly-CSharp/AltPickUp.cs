using UnityEngine;
using UnityEngine.Events;

public class AltPickUp : MonoBehaviour
{
	public string pPref;

	public UnityEvent onPickUp;

	private void OnCollisionEnter(Collision other)
	{
	}

	private void OnTriggerEnter(Collider other)
	{
	}

	private void GotActivated()
	{
	}
}
