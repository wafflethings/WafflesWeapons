using UnityEngine;

public class SubDoor : MonoBehaviour
{
	public SubDoorType type;

	public Vector3 openPos;

	public Vector3 origPos;

	public Vector3 targetPos;

	public float speed;

	public bool playerSpeedMultiplier;

	[HideInInspector]
	public bool valuesSet;

	[HideInInspector]
	public bool isOpen;

	[HideInInspector]
	public AudioSource aud;

	private float origPitch;

	public Door dr;

	[HideInInspector]
	public Animator anim;

	public AudioClip[] sounds;

	public AudioClip openSound;

	public AudioClip stopSound;

	public UltrakillEvent[] animationEvents;

	private void Awake()
	{
	}

	private void Update()
	{
	}

	public void Open()
	{
	}

	public void Close()
	{
	}

	public void SetValues()
	{
	}

	public void AnimationEvent(int i)
	{
	}

	public void PlaySound(int targetSound)
	{
	}

	public void PlayStopSound()
	{
	}
}
