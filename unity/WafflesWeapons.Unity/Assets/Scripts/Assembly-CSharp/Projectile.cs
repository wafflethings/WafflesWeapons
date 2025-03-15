using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	public GameObject sourceWeapon;

	private Rigidbody rb;

	public float speed;

	public float turnSpeed;

	public float speedRandomizer;

	private AudioSource aud;

	public GameObject explosionEffect;

	public float damage;

	public float enemyDamageMultiplier;

	public bool friendly;

	public bool playerBullet;

	public string bulletType;

	public string weaponType;

	public bool decorative;

	private Vector3 origScale;

	private bool active;

	public EnemyType safeEnemyType;

	public bool explosive;

	public bool bigExplosion;

	public List<EnemyIdentifier> alreadyHitEnemies;

	public HomingType homingType;

	public float turningSpeedMultiplier;

	public EnemyTarget target;

	private float maxSpeed;

	private Quaternion targetRotation;

	public float predictiveHomingMultiplier;

	public bool hittingPlayer;

	private NewMovement nmov;

	public bool boosted;

	[HideInInspector]
	public bool parried;

	private Collider col;

	private float radius;

	public bool undeflectable;

	public bool unparryable;

	public bool keepTrail;

	public bool strong;

	public bool spreaded;

	private int difficulty;

	public bool precheckForCollisions;

	public bool canHitCoin;

	public bool ignoreExplosions;

	public bool ignoreEnvironment;

	private List<Collider> alreadyDeflectedBy;

	public List<ContinuousBeam> connectedBeams;

	private void Start()
	{
	}

	private void Awake()
	{
	}

	public static float GetProjectileSpeedMulti(int difficulty)
	{
		return 0f;
	}

	private void Update()
	{
	}

	private void FixedUpdate()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
	}

	private void Collided(Collider other)
	{
	}

	private void CreateExplosionEffect()
	{
	}

	public void Explode()
	{
	}

	private void RecheckPlayerHit()
	{
	}

	private void TimeToDie()
	{
	}

	private void KeepTrail()
	{
	}
}
