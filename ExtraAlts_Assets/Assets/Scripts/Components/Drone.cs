using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Drone : MonoBehaviour
{
	public bool friendly;
	public bool dontStartAware;
	public bool stationary;

	public float health;
	public bool crashing;

	public bool playerSpotted;
	public bool toLastKnownPos;
	public float checkCooldown;
	public float blockCooldown;

	public float preferredDistanceToTarget = 15;
	public GameObject explosion;
	public GameObject gib;
	public AudioClip hurtSound;
	public AudioClip deathSound;
	public AudioClip windUpSound;
	public AudioClip spotSound;
	public AudioClip loseSound;
	public GameObject projectile;
	public Material shootMaterial;

	public ParticleSystem chargeParticle;
	public bool enraged;
	public GameObject enrageEffect;
	public Material[] originalMaterials;
	public Material[] enrageMaterials;
	public bool cantInstaExplode;

	 
	void Start() { }
	void UpdateBuff() { }
	private void OnDisable() { }
	private void OnEnable() { }
	void Update() { }
	private void FixedUpdate() { }
	public void RandomDodge() { }
	public void GetHurt(Vector3 force, float multiplier, GameObject sourceWeapon = null) { }
	public void PlaySound(AudioClip clippe) { }
	public void Explode() { }
	void Death() { }
	public void Shoot() { }
	void SetProjectileSettings(Projectile proj) { }
	public void SpawnInsignia() { }
	public void Hooked() { }
	public void Unhooked() { }
	void NoMoreHomeRun() { }}
