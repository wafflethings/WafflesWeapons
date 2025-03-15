using UnityEngine;

public class WeaponPickUp : MonoBehaviour
{
	public GameObject weapon;

	public int inventorySlot;

	private int tempSlot;

	public GunSetter gs;

	public string pPref;

	public bool arm;

	public GameObject activateOnPickup;

	private bool activated;

	private void Awake()
	{
	}

	private void OnCollisionEnter(Collision collision)
	{
	}

	private void OnTriggerEnter(Collider other)
	{
	}

	private void GotActivated()
	{
	}
}
