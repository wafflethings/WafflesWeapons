using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{

	public GameObject sourceWeapon;

	public bool enemy;
	public bool harmless;
	public bool lowQuality;
	public float speed;
	public float maxSize;

	public int damage;
	public float enemyDamageMultiplier;
	public GameObject explosionChunk;
	public bool ignite;
	public bool friendlyFire;

	public string hitterWeapon;
	public bool halved;

	public AffectedSubjects canHit;

	public bool rocketExplosion;
	 
	public List<EnemyType> toIgnore;
	public bool unblockable;
	public bool electric;

	 
	void Start() { }
	 
	void FixedUpdate() { }
	void OnTriggerEnter(Collider other) { }}
