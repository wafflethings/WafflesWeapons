using UnityEngine;

public class WeaponStateZone : MonoBehaviour
{
	public bool allowWeaponsOnEnter;

	public bool allowWeaponsOnExit;

	public bool allowArmOnEnter;

	public bool allowArmOnExit;

	private GunControl gc;

	private void OnTriggerEnter(Collider other)
	{
	}

	private void OnTriggerExit(Collider other)
	{
	}
}
