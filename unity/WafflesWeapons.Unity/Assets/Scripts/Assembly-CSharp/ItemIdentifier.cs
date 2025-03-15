using UnityEngine;

public class ItemIdentifier : MonoBehaviour
{
	public bool infiniteSource;

	public bool dropOnHit;

	public bool pickedUp;

	[HideInInspector]
	public bool beenPickedUp;

	public bool reverseTransformSettings;

	public Vector3 putDownPosition;

	public Vector3 putDownRotation;

	public Vector3 putDownScale;

	public GameObject pickUpSound;

	public ItemType itemType;

	public bool noHoldingAnimation;

	[HideInInspector]
	public bool hooked;

	[HideInInspector]
	public ItemPlaceZone ipz;

	public UltrakillEvent onPickUp;

	public UltrakillEvent onPutDown;

	public ItemIdentifier CreateCopy()
	{
		return null;
	}

	private void PickUp()
	{
	}

	private void PutDown()
	{
	}

	public void ForcePutDown(ItemPlaceZone target)
	{
	}
}
