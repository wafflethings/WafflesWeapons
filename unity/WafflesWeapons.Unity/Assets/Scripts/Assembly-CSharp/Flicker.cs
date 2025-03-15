using UnityEngine;

public class Flicker : MonoBehaviour
{
	private Light light;

	public float delay;

	private AudioSource aud;

	private float intensity;

	public bool onlyOnce;

	public bool quickFlicker;

	public float intensityRandomizer;

	public float timeRandomizer;

	public bool stopAudio;

	public bool forceOnAfterDisable;

	public GameObject[] flickerDisableObjects;

	private void Start()
	{
	}

	private void OnDisable()
	{
	}

	private void OnEnable()
	{
	}

	private void Flickering()
	{
	}

	private void On()
	{
	}

	private void Off()
	{
	}
}
