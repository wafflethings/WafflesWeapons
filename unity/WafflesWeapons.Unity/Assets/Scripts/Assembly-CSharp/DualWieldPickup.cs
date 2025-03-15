using Sandbox;
using UnityEngine;

public class DualWieldPickup : MonoBehaviour, IAlter, IAlterOptions<float>, IAlterOptions<bool>
{
	public bool infiniteUses;

	public float juiceAmount;

	public GameObject pickUpEffect;

	public string alterKey => null;

	public string alterCategoryName => null;

	AlterOption<float>[] IAlterOptions<float>.options => null;

	AlterOption<bool>[] IAlterOptions<bool>.options => null;

	private void OnTriggerEnter(Collider other)
	{
	}

	private void PickedUp()
	{
	}
}
