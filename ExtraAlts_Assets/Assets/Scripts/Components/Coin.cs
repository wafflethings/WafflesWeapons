using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
	public GameObject sourceWeapon;
	public LayerMask lmask;
	public GameObject refBeam;
	public Vector3 hitPoint = Vector3.zero;
	public bool shot;
	public GameObject coinBreak;
	public float power;

	public bool quickDraw;

	public Material uselessMaterial;
	public GameObject coinHitSound;
	public bool doubled;

	public GameObject flash;
	public GameObject enemyFlash;
	public GameObject chargeEffect;

	public CoinChainCache ccc;

	 
	public int ricochets;

	public bool dontDestroyOnPlayerRespawn;
	  public bool ignoreBlessedEnemies;

	 
	void Start() { }
	 
	void Update() { }
	public void DelayedReflectRevolver(Vector3 hitp, GameObject beam = null) { }
	public void ReflectRevolver() { }
	public void DelayedPunchflection() { }
	public async void Punchflection() { }
	public void Bounce() { }
	public void DelayedEnemyReflect() { }
	public void EnemyReflect() { }
	void ShootAtPlayer() { }
	public void GetDeleted() { }
	void StartCheckingSpeed() { }
	public void RicoshotPointsCheck() { }}
