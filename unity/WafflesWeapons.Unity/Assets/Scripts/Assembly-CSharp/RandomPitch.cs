using UnityEngine;

public class RandomPitch : MonoBehaviour
{
	public float defaultPitch;

	public float pitchVariation;

	public bool oneTime;

	public bool playOnEnable;

	public bool nailgunOverheatFix;

	[HideInInspector]
	public bool beenPlayed;

	public AudioSource aud;

	private void Start()
	{
	}

	private void OnEnable()
	{
	}

	public void Randomize()
	{
	}
}
