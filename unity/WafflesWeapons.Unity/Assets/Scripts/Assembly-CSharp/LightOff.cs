using UnityEngine;

public class LightOff : MonoBehaviour
{
	private Light light;

	private AudioSource[] aud;

	public GameObject otherLamp;

	private Light otherLight;

	public float oLIntensity;

	private void Awake()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
	}
}
