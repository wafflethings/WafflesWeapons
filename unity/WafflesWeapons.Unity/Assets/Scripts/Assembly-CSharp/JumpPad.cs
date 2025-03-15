using Sandbox;
using UnityEngine;

public class JumpPad : MonoBehaviour, IAlter, IAlterOptions<float>
{
	public float force;

	private float origPitch;

	private AudioSource aud;

	public AudioClip launchSound;

	public AudioClip lightLaunchSound;

	public bool forceDirection;

	public bool ignoreSlam;

	public string alterKey => null;

	public string alterCategoryName => null;

	public AlterOption<float>[] options => null;

	private void Start()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
	}
}
