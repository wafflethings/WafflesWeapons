using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpiderBody : MonoBehaviour
{
	public bool limp;
	 
	public GameObject proj;
	public LayerMask aimlm;

	public float health;
	public bool dead;
	public bool stationary;

	public GameObject impactParticle;
	public GameObject impactSprite;

	public Transform mouth;
	public GameObject chargeEffect;
	public GameObject spiderBeam;
	public GameObject beamExplosion;

	public GameObject dripBlood;
	public GameObject spark;

	public GameObject enrageEffect;
	public Material woundedMaterial;
	public Material woundedEnrageMaterial;
	public GameObject woundedParticle;

	[SerializeField] Transform headModel;
	public GameObject breakParticle;

	public GameObject shockwave;

	public Renderer mainMesh;

	public float targetHeight = 1;

	[SerializeField] private Collider headCollider;

	 
	void Start() { }
	private void OnDisable() { }
	private void Update() { }
	public void GetHurt(GameObject target, Vector3 force, Vector3 hitPoint, float multiplier, GameObject sourceWeapon = null) { }
	public void Die() { }
	public void TriggerHit(Collider other) { }
	void FallKillEnemy(EnemyIdentifier targetEid) { }
	public void Enrage() { }
	public void BreakCorpse() { }
	void ResolveStuckness() { }}
