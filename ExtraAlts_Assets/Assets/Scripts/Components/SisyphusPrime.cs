using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum SPAttack
{
    UppercutCombo,
    StompCombo,
    Chop,
    Clap,
    AirStomp,
    AirKick,
    Explosion
}

public class SisyphusPrime : MonoBehaviour
{

    public GameObject explosion;
    public GameObject explosionChargeEffect;
    public GameObject rubble;
    public GameObject bigRubble;
    public GameObject groundWave;
    public GameObject swoosh;

    public Transform aimingBone;
    public GameObject projectileCharge;
    public GameObject sparkleExplosion;

    public GameObject warningFlash;
    public GameObject parryableFlash;
    public GameObject attackTrail;
    public GameObject swingSnake;

    public Transform[] swingLimbs;
    public GameObject passiveEffect;
    public GameObject flameEffect;
    public GameObject phaseChangeEffect;
    public GameObject lightShaft;
    public GameObject outroExplosion;
    public UltrakillEvent onPhaseChange;
    public UltrakillEvent onOutroEnd;

    [Header("Voice clips")]
    public AudioClip[] uppercutComboVoice;
    public AudioClip[] stompComboVoice;
    public AudioClip phaseChangeVoice;
    public AudioClip[] hurtVoice;
    public AudioClip[] explosionVoice;
    public AudioClip[] tauntVoice;
    public AudioClip[] clapVoice;

     
    void Start() { }
    void UpdateBuff() { }
    void SetSpeed() { }
    void OnDisable() { }
    void OnEnable() { }
     
    void Update() { }
    private void FixedUpdate() { }
    private void LateUpdate() { }
    void CustomPhysics() { }
    void PickAnyAttack() { }
    void PickPrimaryAttack(int type = -1) { }
    void PickSecondaryAttack(int type = -1) { }
    public void CancelIntoSecondary() { }
    public void Taunt() { }
    public void UppercutCombo() { }
    public void StompCombo() { }
    void Chop() { }
    void Clap() { }
    void AirStomp() { }
    void AirKick() { }
    void ExplodeAttack() { }
    public void ClapStart() { }
    public void ClapShockwave() { }
    public void StompShockwave() { }
     

    void RiderKickActivate() { }
    void DropAttackActivate() { }
    public void SnakeSwingStart(int limb) { }
    public void DamageStart() { }
    public void DamageStop() { }
    public void Explosion() { }
    public void ProjectileCharge() { }
    public void ProjectileShoot() { }
    public void TeleportOnGround(int forceNoPrediction = 0) { }
    public void TeleportAnywhere() { }
    public void TeleportAnywhere(bool predictive = false) { }
    public void TeleportAbove() { }
    public void TeleportAbove(bool predictive = true) { }
    public void TeleportSideRandom(int predictive) { }
    public void TeleportSideRandomAir(int predictive) { }
    public void TeleportSide(int side, bool inAir = false, bool predictive = false) { }
    public void Teleport(Vector3 teleportTarget, Vector3 startPos) { }
    public void LookAtTarget() { }
    public void Death() { }
    public void Ascend() { }
    public void OutroEnd() { }
    public void EnableGravity(int earlyCancel) { }
    public void Parryable() { }
    public void Unparryable() { }
    public void GotParried() { }
    public void Rubble() { }
    public void ResetRotation() { }
    public void DisableGravity() { }
    public void StartTracking() { }
    public void StopTracking() { }
    public void StopAction() { }
    public void PlayerBeenHit() { }
    public void OutOfBounds() { }
    public void Vibrate() { }
    public void PlayVoice(AudioClip[] voice) { }
    public void ForceKnockbackDown() { }
    public void SwingIgnoreSliding() { }
    public void ResolveStuckness() { }}
