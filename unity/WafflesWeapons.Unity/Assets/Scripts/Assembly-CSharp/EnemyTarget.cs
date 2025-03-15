using UnityEngine;

public class EnemyTarget
{
	public bool isPlayer;

	public Transform targetTransform;

	public EnemyIdentifier enemyIdentifier;

	public Rigidbody rigidbody;

	public bool isEnemy => false;

	public Vector3 position => default(Vector3);

	public Vector3 headPosition => default(Vector3);

	public Transform headTransform => null;

	public Transform trackedTransform => null;

	public Vector3 forward => default(Vector3);

	public Vector3 right => default(Vector3);

	public bool isOnGround => false;

	public bool isValid => false;

	public bool IsTargetTransform(Transform other)
	{
		return false;
	}

	public EnemyTarget(Transform targetTransform)
	{
	}

	public EnemyTarget(EnemyIdentifier otherEnemy)
	{
	}

	public Vector3 GetVelocity()
	{
		return default(Vector3);
	}

	public Vector3 PredictTargetPosition(float time, bool includeGravity = false)
	{
		return default(Vector3);
	}

	private EnemyTarget()
	{
	}

	public static EnemyTarget TrackPlayer()
	{
		return null;
	}

	public static EnemyTarget TrackPlayerIfAllowed()
	{
		return null;
	}

	public override string ToString()
	{
		return null;
	}
}
