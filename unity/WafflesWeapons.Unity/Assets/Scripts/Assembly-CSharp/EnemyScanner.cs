using System.Collections.Generic;
using UnityEngine;
using plog;

public class EnemyScanner
{
	private static readonly plog.Logger Log;

	private const bool DebugMode = false;

	private readonly EnemyIdentifier owner;

	private readonly Transform ownerRaycastOrigin;

	private readonly float tickInterval;

	private TimeSince? timeSinceLastTick;

	private Queue<EnemyIdentifier> pendingLineOfSightChecks;

	public EnemyScanner(EnemyIdentifier owner)
	{
	}

	public void Update()
	{
	}

	public void Reset()
	{
	}

	private void Tick()
	{
	}

	private bool CanBeTargeted(EnemyIdentifier enemy)
	{
		return false;
	}

	private void SetTarget(EnemyIdentifier enemy)
	{
	}
}
