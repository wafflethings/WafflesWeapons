using System.Collections.Generic;
using System;
using Sandbox;
using UnityEngine;
using UnityEngine.AddressableAssets;

public enum BeamType
{
	Revolver,
	Railgun,
	MaliciousFace,
	Enemy
}

public class RevolverBeam : MonoBehaviour
{

	public BeamType beamType;
	public HitterAttribute[] attributes;
	public Vector3 alternateStartPoint;

	public GameObject sourceWeapon;
	public CameraController cc;
	public GameObject hitParticle;
	public int bulletForce;
	public bool quickDraw;
	public int gunVariation;
	public float damage;
	public float critDamageOverride;
	public float screenshakeMultiplier = 1;
	 
	 
	public int hitAmount;
	public int maxHitsPerTarget;
	public bool noMuzzleflash;

	public int ricochetAmount = 0;
	public GameObject ricochetSound;
	public GameObject enemyHitSound;
	public bool fake;

	public EnemyType ignoreEnemyType;
	public bool deflected;
	public bool strongAlt;
	public bool ultraRicocheter = true;
	public bool canHitProjectiles;

	 
	void Start() { }
	 
	void Update() { }
	public void FakeShoot(Vector3 target) { }
	void Shoot() { }
	void HitSomething(RaycastHit hit) { }
	void PiercingShotOrder() { }
	void PiercingShotCheck() { }
	public void ExecuteHits(RaycastHit currentHit) { }
	void RicochetAimAssist(GameObject beam, bool aimAtHead = false) { }}
