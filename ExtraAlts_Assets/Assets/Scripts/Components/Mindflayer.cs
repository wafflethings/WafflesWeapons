using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mindflayer : MonoBehaviour
{

    public GameObject homingProjectile;
    public GameObject decorativeProjectile;
    public GameObject warningFlash;
    public GameObject warningFlashUnparriable;
    public GameObject decoy;
    public Transform[] tentacles;
    public float cooldown;

    public GameObject bigHurt;
    public GameObject windUp;
    public GameObject windUpSmall;
    public GameObject teleportSound;
    public GameObject beam;
    public Transform rightHand;
    public GameObject deathExplosion;
    public ParticleSystem chargeParticle;
    public GameObject enrageEffect;
    public GameObject originalGlow;
    public GameObject enrageGlow;

     
    void Start() { }
    void UpdateBuff() { }
    void SetSpeed() { }

    void OnDisable() { }
     
    void Update() { }
    private void FixedUpdate() { }
    void RandomizeDirection() { }
    public void Teleport(bool closeRange = false) { }
    public void Death() { }
    void DeathExplosion() { }
    void HomingAttack() { }
    void BeamAttack() { }    
    void MeleeAttack() { }
    public void SwingStart() { }
    public void DamageStart() { }
    public void DamageEnd() { }
    public void LockTarget() { }
    public void StartBeam() { }
    void StopBeam() { }
    public void ShootProjectiles() { }
    public void HighDifficultyTeleport() { }
    public void MeleeTeleport() { }
    public void ResetAnimSpeed() { }
    public void StopAction() { }
    public void Enrage() { }}
