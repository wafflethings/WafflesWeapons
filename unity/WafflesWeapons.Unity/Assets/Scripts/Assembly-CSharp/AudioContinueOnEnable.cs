using UnityEngine;

public class AudioContinueOnEnable : MonoBehaviour
{
	public bool autoStartIfNotPlaying;

	private bool wasPlaying;

	private float currentTime;

	private AudioSource aud;

	private void OnEnable()
	{
	}

	private void Update()
	{
	}
}
