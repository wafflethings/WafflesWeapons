using UnityEngine;

public class SpatialMusic : MonoBehaviour
{
	public float minDistance;

	public float maxDistance;

	private AudioHighPassFilter hiPass;

	private float hiPassDefaultFrequency;

	private AudioSource aud;

	private Transform target;

	private void Start()
	{
	}

	private void Update()
	{
	}
}
