using ScriptableObjects;
using UnityEngine;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class PlayerAnimations : MonoSingleton<PlayerAnimations>
{
	[SerializeField]
	private FootstepSet footstepSet;

	public bool onGround;

	public AudioClip[] footsteps;

	private AudioSource aud;

	private float footstepTimer;

	private int lastFootstep;

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void Footstep(float volume = 0.25f, bool force = false, float delay = 0f)
	{
	}

	public void WallJump(Vector3 position)
	{
	}

	public void WallJump(CustomGroundProperties cgp)
	{
	}

	private void PlayRandomFootstepClip(AudioClip[] clips, float delay = 0f)
	{
	}

	private void PlayFootstepClip(AudioClip clip, float delay = 0f)
	{
	}
}
