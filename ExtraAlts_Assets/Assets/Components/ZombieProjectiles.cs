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
    public float coolDown;
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

    public void Melee()
{}
    public void MeleePrep()
{}
    public void MeleeDamageStart()
{}
    public void MeleeDamageEnd()
{}
    public void Swing()
{}
    public void SwingEnd()
{}
    public void SpawnProjectile()
{}
    public void DamageStart()
{}
    public void ThrowProjectile()
{}
    public void ShootProjectile(int skipOnEasy)
{}
    public void StopTracking()
{}
    public void DamageEnd()
{}
    public void CancelAttack()
{}}
