using UnityEngine;

public class AlwaysLookAtCamera : MonoBehaviour
{
	public Transform overrideTarget;

	public EnemyTarget target;

	[Space]
	[Tooltip("If the target is player (null), use the camera instead of the player head position. Helpful in third-person mode.")]
	public bool preferCameraOverHead;

	[Tooltip("Copies camera's rotation instead of looking at the camera, this will mean the object always appears flat like a sprite.")]
	public bool faceScreenInsteadOfCamera;

	public bool dontRotateIfBlind;

	public float speed;

	public bool easeIn;

	public float maxAngle;

	[Space]
	public bool useXAxis;

	public bool useYAxis;

	public bool useZAxis;

	[Space]
	public Vector3 rotationOffset;

	[Space]
	public float maxXAxisFromParent;

	public float maxYAxisFromParent;

	public float maxZAxisFromParent;

	[Header("Enemy")]
	public EnemyIdentifier eid;

	private int difficulty;

	public bool difficultyVariance;

	private float difficultySpeedMultiplier;

	private void Start()
	{
	}

	private void EnsureTargetExists()
	{
	}

	private void SlowUpdate()
	{
	}

	private void LateUpdate()
	{
	}

	public void ChangeOverrideTarget(EnemyTarget target)
	{
	}

	public void ChangeOverrideTarget(Transform target)
	{
	}

	public void SnapToTarget()
	{
	}

	public void ChangeSpeed(float newSpeed)
	{
	}

	public void ChangeDifficulty(int newDiff)
	{
	}

	public void UpdateDifficulty()
	{
	}
}
