using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum MPAttack
{
    Boxing,
    Combo,
    Dropkick,
    ProjectilePunch,
    Jump
}

public class MinosPrime : MonoBehaviour
{

    public GameObject explosion;
    public GameObject rubble;
    public GameObject bigRubble;
    public GameObject groundWave;
    public GameObject swoosh;

    public Transform aimingBone;
    public GameObject projectileCharge;
    public GameObject snakeProjectile;

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
    public UltrakillEvent onOutroEnd;

    [Header("Voice clips")]
    public AudioClip[] riderKickVoice;
    public AudioClip[] dropkickVoice;
    public AudioClip[] dropAttackVoice;
    public AudioClip[] boxingVoice;
    public AudioClip[] comboVoice;
    public AudioClip[] overheadVoice;
    public AudioClip[] projectileVoice;
    public AudioClip[] uppercutVoice;
    public AudioClip phaseChangeVoice;
    public AudioClip[] hurtVoice;

     
    void Start() { }
    void UpdateBuff() { }
    void SetSpeed() { }
    void OnDisable() { }
    void OnEnable() { }
     
    void Update() { }
    private void FixedUpdate() { }
    private void LateUpdate() { }
    void CustomPhysics() { }
    void PickAttack(int type) { }
    void Dropkick() { }
    void ProjectilePunch() { }
    void Jump() { }
    void Uppercut() { }
    void RiderKick() { }
    void DropAttack() { }
    void DownSwing() { }
    public void UppercutActivate() { }
    public void UppercutCancel(int parryable = 0) { }
    public void Combo() { }
    public void Boxing() { }
    void RiderKickActivate() { }
    void DropAttackActivate() { }
    public void SnakeSwingStart(int limb) { }
    public void DamageStart() { }
    public void DamageStop() { }
    public void Explosion() { }
    public void ProjectileCharge() { }
    public void ProjectileShoot() { }
    public void TeleportOnGround() { }
    public void TeleportAnywhere() { }
    public void TeleportSide(int side) { }
    public void Teleport(Vector3 teleportTarget, Vector3 startPos) { }
    public void Death() { }
    public void Ascend() { }
    public void OutroEnd() { }
    public void EnableGravity(int earlyCancel) { }
    public void Parryable() { }
    public void GotParried() { }
    public void Rubble() { }
    public void ResetRotation() { }
    public void DisableGravity() { }
    public void StopTracking() { }
    public void StopAction() { }
    public void PlayerBeenHit() { }
    public void OutOfBounds() { }
    public void Vibrate() { }
    public void PlayVoice(AudioClip[] voice) { }
    public void ResolveStuckness() { }}
