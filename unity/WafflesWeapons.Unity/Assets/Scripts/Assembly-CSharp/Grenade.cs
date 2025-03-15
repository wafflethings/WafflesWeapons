using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
	public string hitterWeapon;

	public GameObject sourceWeapon;

	public GameObject explosion;

	public GameObject harmlessExplosion;

	public GameObject superExplosion;

	[SerializeField]
	private RevolverBeam grenadeBeam;

	private bool exploded;

	public bool enemy;

	[HideInInspector]
	public EnemyIdentifier originEnemy;

	public float totalDamageMultiplier;

	public bool rocket;

	[HideInInspector]
	public Rigidbody rb;

	[HideInInspector]
	public List<Magnet> magnets;

	[HideInInspector]
	public Magnet latestEnemyMagnet;

	public float rocketSpeed;

	[SerializeField]
	private GameObject freezeEffect;

	private CapsuleCollider col;

	public bool playerRiding;

	private bool playerInRidingRange;

	private float downpull;

	public GameObject playerRideSound;

	[HideInInspector]
	public bool rideable;

	[HideInInspector]
	public bool hooked;

	private bool hasBeenRidden;

	private LayerMask rocketRideMask;

	public EnemyTarget proximityTarget;

	public GameObject proximityWindup;

	private bool selfExploding;

	[HideInInspector]
	public bool levelledUp;

	[HideInInspector]
	public float timeFrozen;

	[SerializeField]
	private GameObject levelUpEffect;

	public List<EnemyType> ignoreEnemyType;

	public bool frozen => false;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}

	private void Update()
	{
	}

	private void FixedUpdate()
	{
	}

	private void LateUpdate()
	{
	}

	private void OnCollisionEnter(Collision collision)
	{
	}

	private void OnTriggerEnter(Collider other)
	{
	}

	public void Collision(Collider other)
	{
	}

	private void ProximityExplosion()
	{
	}

	public void Explode(bool big = false, bool harmless = false, bool super = false, float sizeMultiplier = 1f, bool ultrabooster = false, GameObject exploderWeapon = null, bool fup = false)
	{
	}

	public void PlayerRideStart()
	{
	}

	public void PlayerRideEnd()
	{
	}

	public void CanCollideWithPlayer(bool can = true)
	{
	}

	public void GrenadeBeam(Vector3 targetPoint, GameObject newSourceWeapon = null)
	{
	}
}
