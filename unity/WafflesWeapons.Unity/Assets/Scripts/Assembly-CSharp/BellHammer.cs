using UnityEngine;

public class BellHammer : MonoBehaviour
{
	[HideInInspector]
	public HingeJoint joint;

	public AudioSource ringSound;

	[HideInInspector]
	public Rigidbody rb;

	[HideInInspector]
	public bool gotValues;

	[HideInInspector]
	public Quaternion originalRotation;

	private Vector3 previousFrameVelocity;

	private Vector3 currentFrameVelocity;

	[HideInInspector]
	public int hittingLimit;

	public float speedForMaxVolume;

	public bool oneTimeEvent;

	[HideInInspector]
	public bool rung;

	public UltrakillEvent onRing;

	private void Start()
	{
	}

	private void GetValues()
	{
	}

	private void FixedUpdate()
	{
	}

	private void Ring()
	{
	}
}
