using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Statue : MonoBehaviour
{
	public float health;
	public bool limp;
	public GameObject chest;
	public AudioClip[] hurtSounds;
	public Material deadMaterial;
	public Material woundedMaterial;
	public Material woundedEnrageMaterial;
	public GameObject woundedParticle;
	public SkinnedMeshRenderer smr;
	public AudioClip deathSound;

	public List<GameObject> extraDamageZones = new List<GameObject>();
	public float extraDamageMultiplier;

	public bool grounded;
	public bool knockedBack;
	public float brakes;
	public float juggleWeight;
	public bool falling;
	public bool bigBlood;
	public bool massDeath;
	public bool specialDeath;

	public bool parryable;
	public bool partiallyParryable;

	 
	void Start() { }
	void OnDestroy() { }
	private void Update() { }
	private void FixedUpdate() { }
	public void KnockBack(Vector3 force) { }
	public void StopKnockBack() { }
	public void GetHurt(GameObject target, Vector3 force, float multiplier, float critMultiplier, Vector3 hurtPos, GameObject sourceWeapon = null) { }
	public void GoLimp() { }
	void StopHealing() { }
	void BloodExplosion() { }
	void DeathEnd() { }}
