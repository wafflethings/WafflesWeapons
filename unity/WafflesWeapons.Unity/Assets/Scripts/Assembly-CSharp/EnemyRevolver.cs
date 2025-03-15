using UnityEngine;

public class EnemyRevolver : MonoBehaviour, IEnemyWeapon
{
	private EnemyTarget target;

	public EnemyType safeEnemyType;

	public int variation;

	public GameObject bullet;

	public GameObject altBullet;

	public GameObject primaryPrepare;

	private GameObject currentpp;

	private GameObject altCharge;

	private AudioSource altChargeAud;

	private float chargeAmount;

	private bool charging;

	public Transform shootPoint;

	public GameObject muzzleFlash;

	public GameObject muzzleFlashAlt;

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

	private void OnDisable()
	{
	}

	private void UpdateBuffs(EnemyIdentifier eid)
	{
	}
}
