using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Streetcleaner : MonoBehaviour
{
    public bool dead;
    public LayerMask enviroMask;
    public bool dodging;

    public GameObject dodgeSound;
    public Transform hose;
    public Transform hoseTarget;

    public GameObject canister;
    public GameObject explosion;
    public bool canisterHit;

    public GameObject firePoint;
    public GameObject fireStopSound;
    public bool damaging;
    public GameObject warningFlash;

     
    void Start() { }
    void OnDisable() { }
     
    void Update() { }
    private void FixedUpdate() { }
    public void StartFire() { }
    public void StartDamaging() { }
    public void StopFire() { }
    public void Dodge() { }
    public void StopMoving() { }
    public void DodgeEnd() { }
    public void DeflectShot() { }
    public void SlapOver() { }
    public void OverrideOver() { }}
