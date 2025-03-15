using UnityEngine;

public class MoveTowards : MonoBehaviour
{
	public Vector3 targetPosition;

	public float speed;

	public float easeAtEnd;

	public bool useRigidBody;

	private Rigidbody rb;

	public bool pitchAudioWithSpeed;

	private AudioSource aud;

	private float originalPitch;

	public UltrakillEvent onReachTarget;

	private void Start()
	{
	}

	private void FixedUpdate()
	{
	}

	public void SnapToTarget()
	{
	}

	public void ChangeTarget(Vector3 target)
	{
	}

	public void ChangeX(float number)
	{
	}

	public void ChangeY(float number)
	{
	}

	public void ChangeZ(float number)
	{
	}

	public void UseRigidbody(bool use)
	{
	}

	public void PitchAudioWithSpeed(bool use)
	{
	}

	public void UpdateAudioOriginalPitch()
	{
	}

	public void EaseAtEnd(float newEase)
	{
	}
}
