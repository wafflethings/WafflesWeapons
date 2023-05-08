using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnviroDamageType
{
    Normal,
    Burn,
    Acid,
    WeakBurn
}

public class HurtZone : MonoBehaviour
{
    public EnviroDamageType damageType;
    public bool trigger;
    public float damage;
    public float enemyDamageOverride;

    public GameObject hurtParticle;

    private void Start() { }
    private void OnDisable() { }
     
    void FixedUpdate() { }
    void Enter(Collider other) { }
    void Exit(Collider other) { }}
