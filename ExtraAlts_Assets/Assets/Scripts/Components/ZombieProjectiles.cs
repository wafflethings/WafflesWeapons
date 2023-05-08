using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieProjectiles : MonoBehaviour {

    public bool stationary;
    public bool smallRay;
    public bool wanderer;
    public bool afraid;
    public bool chaser;
    public bool hasMelee;

    public Vector3 targetPosition;
    public TrailRenderer tr;

    public GameObject projectile;
    public Transform shootPos;

    public GameObject head;
    public bool playerSpotted;
    public LayerMask lookForPlayerMask;
    public bool seekingPlayer = true;
    public GameObject decProjectileSpawner;
    public GameObject decProjectile;

    public bool swinging;

    public Transform aimer;
    
    void SetValues() { }
	 
	void Start ()  { }
    private void OnEnable() { }
    private void OnDisable() { }
     
    void Update () {}
    private void LateUpdate() { }
    void SetDestination(Vector3 position) { }
    public void Melee() { }
    public void MeleePrep() { }
    public void MeleeDamageStart() { }
    public void MeleeDamageEnd() { }
    public void Swing() { }
    public void SwingEnd() { }
    public void SpawnProjectile() { }
    public void DamageStart() { }
    public void ThrowProjectile() { }
    public void ShootProjectile(int skipOnEasy) { }
    public void StopTracking() { }
    public void DamageEnd() { }
    public void CancelAttack() { }
    void Wander() { }
    public void Block(Vector3 attackPosition) { }}
