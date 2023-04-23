using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HomingType
{
	None,
	Gradual,
	Loose,
	HorizontalOnly,
	Instant
}

public class Projectile : MonoBehaviour
{
	public GameObject sourceWeapon;
	public float speed;
	public float turnSpeed;
	public float speedRandomizer;
	public GameObject explosionEffect;

	public float damage;
	public float enemyDamageMultiplier = 1;
	public bool friendly;
	public bool playerBullet;
	public string bulletType;
	public string weaponType;

	public bool decorative;

	public EnemyType safeEnemyType;
	public bool explosive;
	public bool bigExplosion;

	public HomingType homingType;
	public float turningSpeedMultiplier = 1;
	public Transform target;
	public float predictiveHomingMultiplier;

	public bool hittingPlayer;

	public bool boosted;
	public bool undeflectable;

	 
	public bool keepTrail;
	public bool strong;

	public bool spreaded;

	public bool precheckForCollisions;
	public bool canHitCoin;
	public bool ignoreExplosions;

	 
	void Start() { }
	void Awake() { }
	private void Update() { }
	 
	void FixedUpdate() { }
	void Collided(Collider other) { }
	void CreateExplosionEffect() { }
	public void Explode() { }
	void KeepTrail() { }}
