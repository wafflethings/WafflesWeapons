using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPlaceZone : MonoBehaviour
{
    public ItemType acceptedItemType;
    public GameObject[] activateOnSuccess;
    public GameObject[] deactivateOnSuccess;
    public GameObject[] activateOnFailure;

    public Door[] doors;
    public Door[] reverseDoors;
    public ArenaStatus[] arenaStatuses;
    public ArenaStatus[] reverseArenaStatuses;

    public GameObject boundsError;

    private void Start() { }
    void GetDoorBounds(Door[] doors, List<Bounds> boundies) { }
    public void CheckItem(bool prelim = false) { }}
