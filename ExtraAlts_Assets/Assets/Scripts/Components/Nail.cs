using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nail : MonoBehaviour
{
    public GameObject sourceWeapon;
    public float damage;
    public AudioClip environmentHitSound;
    public AudioClip enemyHitSound;
    public Material zapMaterial;
    public GameObject zapParticle;
    public bool fodderDamageBoost;

    public string weaponType;
    public bool heated;

    public bool enemy;
    public EnemyType safeEnemyType;

    [Header("Sawblades")]
    public bool sawblade;
    public float hitAmount = 3.9f;
    [SerializeField] GameObject sawBreakEffect;
    [SerializeField] GameObject sawBounceEffect;
    public bool bounceToSurfaceNormal;
    public int multiHitAmount = 1;
    public AudioSource stoppedAud;

     
    void Start() { }
    void SlowUpdate() { }
    private void Update() { }
    void FixedUpdate() { }
    void TouchEnemy(Transform other) { }
    void DamageEnemy(Transform other, EnemyIdentifier eid) { }
    public void MagnetCaught(Magnet mag) { }
    public void MagnetRelease(Magnet mag) { }
    public void Zap() { }
    void RemoveTime() { }
    void MasterRemoveTime() { }
    public void SawBreak() { }
    public void ForceCheckSawbladeRicochet() { }}
