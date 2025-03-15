using UnityEngine;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class CrowdReactions : MonoSingleton<CrowdReactions>
{
	private AudioSource aud;

	public AudioClip cheer;

	public AudioClip cheerLong;

	public AudioClip aww;

	private void Start()
	{
	}

	public void React(AudioClip clip)
	{
	}
}
