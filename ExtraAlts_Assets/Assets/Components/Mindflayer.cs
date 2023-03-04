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
    
    void Update() { }
    
    public void Death() { }

    public void SwingStart() { }

    public void DamageStart() { }

    public void DamageEnd() { }

    public void LockTarget() {  }

    public void StartBeam() { }

    public void ShootProjectiles() { }

    public void HighDifficultyTeleport() { }

    public void MeleeTeleport() { }

    public void ResetAnimSpeed()
    { }

    public void StopAction()
    { }

    public void Enrage() { }
}
