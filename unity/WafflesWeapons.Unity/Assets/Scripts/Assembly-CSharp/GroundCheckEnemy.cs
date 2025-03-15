using System.Collections.Generic;
using UnityEngine;

public class GroundCheckEnemy : MonoBehaviour
{
	public bool onGround;

	public bool fallSuppressed;

	public bool touchingGround;

	public List<Collider> cols;

	private List<Collider> toRemove;

	public bool dontCheckTags;

	[HideInInspector]
	public int forcedOff;

	public List<Collider> toIgnore;

	private Collider col;

	private bool waitForPhysicsTick;

	private void Start()
	{
	}

	private void OnEnable()
	{
	}

	public static bool TaggedAsStandable(GameObject obj)
	{
		return false;
	}

	private void UpdateGrounds()
	{
	}

	private void FixedUpdate()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
	}

	private void OnTriggerExit(Collider other)
	{
	}

	private void CheckCols()
	{
	}

	private void CheckColsOnce()
	{
	}

	public void ForceOff()
	{
	}

	public void StopForceOff()
	{
	}

	public Vector3 ClosestPoint()
	{
		return default(Vector3);
	}

	public float DistanceToGround()
	{
		return 0f;
	}
}
