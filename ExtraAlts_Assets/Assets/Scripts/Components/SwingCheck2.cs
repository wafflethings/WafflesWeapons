using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingCheck2 : MonoBehaviour {
    public EnemyType type;

    public bool playerOnly;

    public bool playerBeenHit;

    public int damage;
    public int enemyDamage;
    public float knockBackForce;
    public bool knockBackDirectionOverride;
    public Vector3 knockBackDirection;

    public bool strong;
    public Collider[] additionalColliders;

    public bool useRaycastCheck;

    public bool ignoreSlidingPlayer;
    public bool startActive;
    public bool interpolateBetweenFrames;

    private void Start() { }
    private void Update() { }
    void CheckCollision(Collider other) { }
    public void DamageStart() { }
    public void DamageStop() { }
    public void OverrideEnemyIdentifier(EnemyIdentifier newEid) { }}
