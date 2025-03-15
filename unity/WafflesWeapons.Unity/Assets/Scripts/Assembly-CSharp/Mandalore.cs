using UnityEngine;

public class Mandalore : MonoBehaviour
{
	private AudioSource aud;

	private EnemyIdentifier eid;

	public AudioClip voiceFull;

	public AudioClip voiceFuller;

	private float cooldown;

	private float fullerChance;

	private int shotsLeft;

	private float maxHp;

	private int phase;

	public GameObject fullAutoProjectile;

	public GameObject fullerAutoProjectile;

	public MandaloreVoice[] voices;

	private bool taunt;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void FullBurst()
	{
	}

	public void FullerBurst()
	{
	}

	public void Sandify()
	{
	}

	public void DontTaunt()
	{
	}
}
