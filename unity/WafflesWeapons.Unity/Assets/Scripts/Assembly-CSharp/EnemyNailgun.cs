using UnityEngine;

public class EnemyNailgun : MonoBehaviour, IEnemyWeapon
{
	private EnemyTarget target;

	public GameObject nail;

	public GameObject altNail;

	public Transform shootPoint;

	public GameObject flash;

	public GameObject muzzleFlash;

	[SerializeField]
	private AudioSource chargeSound;

	private bool charging;

	private float chargeAmount;

	private int burstAmount;

	private float cooldown;

	private GameObject currentNail;

	private float currentSpread;

	private float fireRate;

	public Collider[] toIgnore;

	private int difficulty;

	private EnemyIdentifier eid;

	private float speedMultiplier;

	private float damageMultiplier;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void FixedUpdate()
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

	private void UpdateBuffs(EnemyIdentifier eid)
	{
	}
}
