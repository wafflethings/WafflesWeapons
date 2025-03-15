using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
	public int type;

	private Door dc;

	private bool open;

	private bool playerIn;

	public bool enemyIn;

	public bool reverseDirection;

	public bool dontDeactivateOnAltarControl;

	public List<EnemyIdentifier> doorUsers;

	private List<EnemyIdentifier> doorUsersToDelete;

	private void Start()
	{
	}

	private void OnDrawGizmos()
	{
	}

	private void OnDisable()
	{
	}

	private void Update()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
	}

	private void OnTriggerExit(Collider other)
	{
	}

	public void Close()
	{
	}

	public void ForcePlayerOut()
	{
	}
}
