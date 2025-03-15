using UnityEngine;

public class EnemyShotgun : MonoBehaviour, IEnemyWeapon
{
	private EnemyTarget target;

	public EnemyType safeEnemyType;

	private AudioSource gunAud;

	public AudioClip shootSound;

	public AudioClip clickSound;

	public AudioClip smackSound;

	private AudioSource heatSinkAud;

	public int variation;

	public GameObject bullet;

	public GameObject grenade;

	public float spread;

	private Animator anim;

	public bool gunReady;

	public Transform shootPoint;

	public GameObject muzzleFlash;

	private ParticleSystem[] parts;

	private bool charging;

	private AudioSource chargeSound;

	private float chargeAmount;

	public GameObject warningFlash;

	private int difficulty;

	private EnemyIdentifier eid;

	private float speedMultiplier;

	private float damageMultiplier;

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void UpdateTarget(EnemyTarget target)
	{
	}

	public void Fire()
	{
	}

	public void AltFire()
	{
	}

	public void PrepareFire()
	{
	}

	public void PrepareAltFire()
	{
	}

	public void CancelAltCharge()
	{
	}

	public void ReleaseHeat()
	{
	}

	public void ClickSound()
	{
	}

	public void ReadyGun()
	{
	}

	public void Smack()
	{
	}

	public void UpdateBuffs(EnemyIdentifier eid)
	{
	}
}
