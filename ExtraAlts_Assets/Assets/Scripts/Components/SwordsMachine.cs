using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SwordsMachine : MonoBehaviour
{
    public bool friendly;
    public Transform target;
    public Transform targetZone;
    public List<EnemyIdentifier> enemyTargets = new List<EnemyIdentifier>();
    public bool targetingEnemy;
    public GameObject player;
    public float phaseChangeHealth;
    public bool firstPhase;
    public bool active = true;
    public Transform rightArm;

    public bool inAction;
    public bool inSemiAction;

    public TrailRenderer swordTrail;
    public SkinnedMeshRenderer swordMR;
	public Material enragedSword;
    public Material heatMat;
    public GameObject swingSound;

    public GameObject head;
    public GameObject flash;
    public GameObject gunFlash;
    public float runningAttackCharge;

    public bool damaging;
    public int damage;

    public float runningAttackChance = 50;
    public GameObject shotgunPickUp;
    public GameObject activateOnPhaseChange;

    public Transform secondPhasePosTarget;
    public CheckPoint cpToReset;

    public float swordThrowCharge = 3;
    public int throwType;
    public GameObject[] thrownSword;
    public Transform handTransform;
    public LayerMask swordThrowMask;
    public float chaseThrowCharge = 0;

    public GameObject bigPainSound;

    public bool enraged;
    public EnemySimplifier ensim;
    public GameObject enrageEffect;
    public GameObject currentEnrageEffect;

    public Door[] doorsInPath;

    public bool eternalRage;
    public bool bothPhases;
    public bool downed;

    public float spawnAttackDelay = 0.5f;

     
    void Start() { }
    void UpdateBuff() { }
    void SetSpeed() { }
    private void OnDisable() { }
    private void OnEnable() { }
    void SlowUpdate() { }
     
    void Update() { }
    private void FixedUpdate() { }
    public void RunningSwing() { }
    void Combo() { }
    void SwordThrow() { }
    void SwordSpiral() { }
    public void StartMoving() { }
    public void StopMoving() { }
    public void LookAt() { }
    public void StopAction() { }
    public void SemiStopAction() { }
    public void HeatSword() { }
    public void HeatSwordThrow() { }
    public void CoolSword() { }
    public void DamageStart() { }
    public void DamageStop() { }
    public void PlayerBeenHit() { }
    public void ShootGun() { }
    public void StopShootAnimation() { }
    void ShootDelay() { }
    public void FlashGun() { }
    public void SwordSpawn() { }
    public void SwordCatch() { }
    void EndFirstPhase() { }
    public void Knockdown(bool light = false) { }
    public void Down() { }
    public void Disappear() { }
    public void Enrage() { }
    public void CheckLoop() { }}
