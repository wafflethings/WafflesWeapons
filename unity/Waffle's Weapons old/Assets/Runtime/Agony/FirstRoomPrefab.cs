using System.Collections.Generic;
using UnityEngine;

public class FirstRoomPrefab : MonoBehaviour, IPlaceholdableComponent
{
    public GameObject[] activateOnFirstRoomDoorOpen;
    public bool levelNameOnOpen = true;
    
    public void WillReplace(GameObject oldObject, GameObject newObject, bool isSelfBeingReplaced)
    {
        // Dummy Tundra Code
    }

    private void SwapData(FirstRoomPrefab source)
    {
        // Dummy Tundra Code
    }
}
