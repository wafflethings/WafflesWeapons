using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GabrielSecond : MonoBehaviour
{
    public GameObject particles;
    public GameObject particlesEnraged;
    public Material enrageBody;
    public Material enrageWing;

    public bool enraged;
    public bool secondPhase;
    public float phaseChangeHealth;
    public GameObject teleportSound;
    public GameObject decoy;

    [Header("Swords")]
    public Transform rightHand;
    public Transform leftHand;
    [SerializeField] SwingCheck2 generalSwingCheck;
    [SerializeField] AudioSource swingSound;
    [SerializeField] AudioSource kickSwingSound;
    [SerializeField] Renderer[] swordRenderers;
    [SerializeField] GameObject fakeCombinedSwords;
    [SerializeField] Projectile combinedSwordsThrown;

    [Space(20)]
    public TrailRenderer kickTrail;
    public GameObject dashEffect;
    public GameObject juggleEffect;

    public GameObject summonedSwords;

    public Transform head;
    [SerializeField] GameObject genericOutro;
    public bool ceilingHitChallenge;
    [SerializeField] GameObject ceilingHitEffect;

    [Header("Events")]
    public UltrakillEvent onFirstPhaseEnd;
    public UltrakillEvent onSecondPhaseStart;

     
    void Start() { }
    void SetValues() { }
    void UpdateBuff() { }
    void UpdateSpeed() { }
    private void OnDisable() { }
    void OnEnable() { }
     
    void Update() { }
    private void FixedUpdate() { }
    void BasicCombo() { }
    void FastComboDash() { }
    void FastCombo() { }
    void ThrowCombo() { }
    void CombineSwords() { }    
    void Gattai() { }
    void CombinedSwordAttack() { }
    public void UnGattai(bool destroySwords = true) { }
    void CheckIfSwordsCombined() { }
    void CreateLightSwords() { }
    void ThrowSwords() { }
    public void Teleport(bool closeRange = false, bool longrange = false, bool firstTime = true, bool horizontal = false, bool vertical = false) { }
    void StartDash() { }
    void Parryable() { }
    void AttackFlash(int unparryable = 0) { }
    void JuggleStart() { }
    void JuggleStop(bool enrage = false) { }
    void EnrageAnimation() { }
    public void EnrageNow() { }
    void ForceUnEnrage() { }
    public void UnEnrage() { }
    void RandomizeDirection() { }
    public void DamageStartLeft(int damage) { }
    public void DamageStopLeft(int keepMoving) { }
    public void DamageStartRight(int damage) { }
    public void DamageStopRight(int keepMoving) { }
    public void DamageStartKick(int damage) { }
    public void DamageStopKick(int keepMoving) { }
    public void DamageStartBoth(int damage) { }
    public void DamageStopBoth(int keepMoving) { }
    public void SetForwardSpeed(int newSpeed) { }
    public void EnrageTeleport(int teleportType = 0) { }
    void ResetAnimSpeed() { }
    public void LookAtTarget(int instant = 0) { }
    public void FollowTarget() { }
    public void StopAction() { }
    public void ResetWingMat() { }
    public void Death() { }
    void SetDamage(int damage) { }
    void PlayerBeenHit() { }
    void DecideMovementSpeed(float normal, float longDistance) { }
    void SpawnSummonedSwords() { }}
