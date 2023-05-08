using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Machine : MonoBehaviour
{
    public float health;
    public bool limp;
    public GameObject chest;
    public AudioClip[] hurtSounds;
    public Material deadMaterial;
    public SkinnedMeshRenderer smr;
    public AudioClip deathSound;
    public AudioClip scream;
    public bool bigKill;
    public bool parryable;
    public bool partiallyParryable;

    public GameObject[] destroyOnDeath;
    public Machine symbiote;

    public bool grounded;
    public bool knockedBack;
    public bool overrideFalling;
    public float brakes;
    public float juggleWeight;
    public bool falling;
    public bool noFallDamage;
    public bool dontDie;

    public bool dismemberment;

    public bool specialDeath;
    public UnityEvent onDeath;

     
    void Start() { }
    void OnEnable() { }
    private void Update() { }
    private void FixedUpdate() { }
    public void KnockBack(Vector3 force) { }
    public void StopKnockBack() { }
    public void GetHurt(GameObject target, Vector3 force, float multiplier, float critMultiplier, GameObject sourceWeapon = null) { }
    public void GoLimp() { }
    void StopHealing() { }
    public void CanisterExplosion() { }}
