using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using plog;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class PlayerMovementParenting : MonoSingleton<PlayerMovementParenting>
{
	private static readonly plog.Logger Log;

	public Transform deltaReceiver;

	private Vector3 lastTrackedPos;

	private float lastAngle;

	private Transform playerTracker;

	[HideInInspector]
	public bool lockParent;

	private Vector3 teleportLockDelta;

	private Rigidbody rb;

	private List<Transform> trackedObjects;

	public Vector3 currentDelta { get; private set; }

	public List<Transform> TrackedObjects => null;

	private new void Awake()
	{
	}

	private void FixedUpdate()
	{
	}

	public bool IsPlayerTracking()
	{
		return false;
	}

	public bool IsObjectTracked(Transform other)
	{
		return false;
	}

	public void AttachPlayer(Transform other)
	{
	}

	public void DetachPlayer([CanBeNull] Transform other = null)
	{
	}

	private void ClearTrackedNulls()
	{
	}

	public void LockMovementParent(bool fuck)
	{
	}

	public void LockMovementParentTeleport(bool fuck)
	{
	}
}
