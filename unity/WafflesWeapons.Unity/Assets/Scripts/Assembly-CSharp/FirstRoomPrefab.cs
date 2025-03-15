using UnityEngine;

public class FirstRoomPrefab : MonoBehaviour, IPlaceholdableComponent
{
	[HideInInspector]
	public GameObject[] activateOnFirstRoomDoorOpen;

	[HideInInspector]
	public bool levelNameOnOpen;

	public Door mainDoor;

	public FinalDoor finalDoor;

	public void WillReplace(GameObject oldObject, GameObject newObject, bool isSelfBeingReplaced)
	{
	}

	private void SwapData(FirstRoomPrefab source)
	{
	}
}
