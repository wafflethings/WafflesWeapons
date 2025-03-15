using UnityEngine;

public class StatueFake : MonoBehaviour
{
	private Animator anim;

	private AudioSource aud;

	private ParticleSystem part;

	public AudioSource step;

	public bool quickSpawn;

	[HideInInspector]
	public bool beingActivated;

	public UltrakillEvent onFirstCrack;

	private bool hasCracked;

	public UltrakillEvent onComplete;

	private void Start()
	{
	}

	public void Activate()
	{
	}

	public void Crack()
	{
	}

	public void Step()
	{
	}

	public void Done()
	{
	}

	private void SlowStart()
	{
	}
}
