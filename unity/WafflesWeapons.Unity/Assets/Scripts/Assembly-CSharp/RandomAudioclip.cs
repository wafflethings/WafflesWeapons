using UnityEngine;

public class RandomAudioclip : MonoBehaviour
{
	public AudioClip[] clips;

	private AudioSource aud;

	public bool playOnChange;

	public bool activateOnEnable;

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	public void Activate()
	{
	}
}
