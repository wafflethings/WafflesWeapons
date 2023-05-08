using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mass : MonoBehaviour
{

    public bool inAction;

    public Transform[] shootPoints;
    public GameObject homingProjectile;
    public float attackCooldown = 2;
    public GameObject explosiveProjectile;

    public GameObject slamExplosion;

    public Transform tailEnd;
    public GameObject spear;
    public bool spearShot;
    public GameObject spearFlash;
    public GameObject tempSpear;
    public List<GameObject> tailHitboxes = new List<GameObject>();

    public GameObject regurgitateSound;
    public GameObject bigPainSound;
    public GameObject windupSound;

    public bool dead;
    public bool crazyMode;
    public float crazyModeHealth;
    public GameObject enrageEffect;
    public GameObject currentEnrageEffect;
    public Material enrageMaterial;

    public Material highVisShockwave;
    public GameObject[] activateOnEnrage;
    
     
    void Start() { }
    void UpdateBuff() { }
    void SetSpeed() { }
    void OnDisable() { }
    void OnEnable() { }
     
    void Update() { }
    private void LateUpdate() { }
    public void HomingAttack() { }
    public void ExplosiveAttack() { }
    public void SwingAttack() { }
    public void ToScout() { }
    public void ToBattle() { }
    public void SlamImpact() { }
    public void ShootHoming(int arm) { }
    public void ShootExplosive(int arm) { }
    public void ShootSpear() { }
    public void SpearParried() { }
    public void SpearReturned() { }
    public void StopAction() { }
    public void BattleSlam() { }
    public void SwingStart() { }
    public void SwingEnd() { }
    public void Enrage() { }
    public void CrazyReady() { }
    public void CrazyShoot() { }}
