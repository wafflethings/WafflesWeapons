using UnityEngine;

public class MusicChanger : MonoBehaviour
{
	public bool match;

	public bool oneTime;

	public bool onEnable;

	public bool dontStart;

	public bool forceOn;

	public float pitch;

	public AudioClip clean;

	public AudioClip battle;

	public AudioClip boss;

	private MusicManager muman;

	private void OnEnable()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
	}

	public void ChangeTo(AudioClip clip)
	{
	}

	public void Change()
	{
	}

	public void ChangePitch(float newPitch)
	{
	}
}
