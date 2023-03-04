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

    public List<VirtueInsignia> childVi = new List<VirtueInsignia>();

    public void RandomDodge()
{}
    public void GetHurt(Vector3 force, float multiplier)
{}
    public void PlaySound(AudioClip clippe)
{}
    public void Explode()
{}
    public void Shoot()
{}
    public void SpawnInsignia()
{}}
