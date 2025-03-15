using UnityEngine;

public class Spin : MonoBehaviour
{
	public Vector3 spinDirection;

	[HideInInspector]
	public bool reversed;

	public float speed;

	public bool inLateUpdate;

	private Vector3 totalRotation;

	public bool notRelative;

	public bool gradual;

	public bool instantStart;

	public float gradualSpeed;

	private float currentSpeed;

	public bool off;

	[HideInInspector]
	public AudioSource aud;

	[HideInInspector]
	public float originalPitch;

	[HideInInspector]
	public float pitchMultiplier;

	[Header("Enemy")]
	public EnemyIdentifier eid;

	private int difficulty;

	public bool difficultyVariance;

	private float difficultySpeedMultiplier;

	private void Start()
	{
	}

	private void FixedUpdate()
	{
	}

	private void LateUpdate()
	{
	}

	public void ChangeState(bool on)
	{
	}

	public void ChangeSpeed(float newSpeed)
	{
	}

	public void ChangeGradualSpeed(float newGradualSpeed)
	{
	}

	public void ChangePitchMultiplier(float newPitch)
	{
	}

	public void ChangeSpinDirection(Vector3 newDirection)
	{
	}

	public void SetReverse(bool reverse)
	{
	}
}
