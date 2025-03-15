using System.Collections.Generic;
using UnityEngine;

public class Washer : MonoBehaviour
{
	private bool isSpraying;

	public ParticleSystem part;

	public List<ParticleCollisionEvent> collisionEvents;

	private InputManager inputManager;

	private AudioSource aud;

	[SerializeField]
	private AudioClip click;

	[SerializeField]
	private AudioClip triggerOn;

	[SerializeField]
	private AudioClip triggerOff;

	private ParticleSystem.ShapeModule shapeModule;

	private ParticleSystem.MainModule mainModule;

	[SerializeField]
	private GameObject[] nozzles;

	private bool musicStarted;

	[SerializeField]
	private GameObject music;

	private Vector3 defaultSprayPos;

	private Quaternion defaultSprayRot;

	private int nozzleMode;

	public CorrectCameraView correctCameraView;

	private void Start()
	{
	}

	private void OnEnable()
	{
	}

	private void Update()
	{
	}

	private void SwitchNozzle()
	{
	}

	private void StartWashing()
	{
	}

	private void StopWashing()
	{
	}

	private void OnParticleCollision(GameObject other)
	{
	}
}
