using UnityEngine;

public class Footsteps : MonoBehaviour
{
	public bool dontInstantiate;

	public GameObject footstep;

	private AudioSource aud;

	public AudioClip[] steps;

	private int previousStep;

	private void Awake()
	{
	}

	public void Footstep()
	{
	}
}
