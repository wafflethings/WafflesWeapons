using UnityEngine;

public class SoundLoopWithIntro : MonoBehaviour
{
	private AudioSource aud;

	[SerializeField]
	private AudioClip intro;

	[SerializeField]
	private AudioClip loop;

	private bool introOver;

	private void Awake()
	{
	}

	private void Update()
	{
	}
}
