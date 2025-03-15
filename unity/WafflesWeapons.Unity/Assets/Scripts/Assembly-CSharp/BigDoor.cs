using UnityEngine;

public class BigDoor : MonoBehaviour
{
	public bool open;

	[HideInInspector]
	public bool gotPos;

	public Vector3 openRotation;

	[HideInInspector]
	public Quaternion targetRotation;

	[HideInInspector]
	public Quaternion origRotation;

	public float speed;

	private float tempSpeed;

	public float gradualSpeedMultiplier;

	private CameraController cc;

	public bool screenShake;

	private AudioSource aud;

	public AudioClip openSound;

	public AudioClip closeSound;

	private float origPitch;

	public Light openLight;

	public bool reverseDirection;

	private Door controller;

	public bool playerSpeedMultiplier;

	private void Awake()
	{
	}

	private void Update()
	{
	}

	public void Open()
	{
	}

	public void Close()
	{
	}
}
