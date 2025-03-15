using System.Collections.Generic;
using UnityEngine;

public class ItemPlaceZone : MonoBehaviour
{
	private bool acceptedItemPlaced;

	public ItemType acceptedItemType;

	public GameObject[] activateOnSuccess;

	public GameObject[] deactivateOnSuccess;

	public GameObject[] activateOnFailure;

	public Door[] doors;

	public Door[] reverseDoors;

	public ArenaStatus[] arenaStatuses;

	public ArenaStatus[] reverseArenaStatuses;

	private Collider col;

	private List<Bounds> doorsBounds;

	private List<Bounds> reverseDoorsBounds;

	public GameObject boundsError;

	public bool hideEffects;

	public InstantiateObject[] altarElements;

	public ParticleSystem elementChangeEffect;

	public AudioSource soundOnActivated;

	public AudioSource soundOnDeactivated;

	private void Start()
	{
	}

	private void Awake()
	{
	}

	private void GetDoorBounds(Door[] doors, List<Bounds> boundies)
	{
	}

	public bool CheckDoorBounds(Vector3 origin, Vector3 end, bool reverseBounds)
	{
		return false;
	}

	private void ColorDoors(Door[] drs)
	{
	}

	public void CheckItem(bool prelim = false)
	{
	}
}
