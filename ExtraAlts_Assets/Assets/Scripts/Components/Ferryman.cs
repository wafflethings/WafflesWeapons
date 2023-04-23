using UnityEngine;
using UnityEngine.AI;

public class Ferryman : MonoBehaviour
{

    [SerializeField] GameObject parryableFlash;
    [SerializeField] GameObject unparryableFlash;
    [SerializeField] Transform head;
    [SerializeField] GameObject slamExplosion;

    [SerializeField] GameObject lightningBoltWindup;
    [SerializeField] LightningStrikeExplosive lightningBolt;
    [SerializeField] AudioSource lightningBoltChimes;

    [Header("SwingChecks")]
    [SerializeField] SwingCheck2 mainSwingCheck;
    [SerializeField] SwingCheck2 oarSwingCheck;
    [SerializeField] SwingCheck2 kickSwingCheck;
    [SerializeField] AudioSource swingAudioSource;
    [SerializeField] AudioClip[] swingSounds;

    [Header("Trails")]
    [SerializeField] TrailRenderer frontTrail;
    [SerializeField] TrailRenderer backTrail;
    [SerializeField] TrailRenderer bodyTrail;

    [Header("Footsteps")]
    [SerializeField] ParticleSystem[] footstepParticles;
    [SerializeField] AudioSource footstepAudio;

    [Header("Boss Version")]
    [SerializeField] bool bossVersion;
    [SerializeField] float phaseChangeHealth;
    [SerializeField] Transform[] phaseChangePositions;
    [SerializeField] UltrakillEvent onPhaseChange;

     
    void Start() { }
    void UpdateBuff() { }
    void SetSpeed() { }
    void OnDisable() { }
    void OnEnable() { }
    void SlowUpdate() { }
    void Update() { }
    void FixedUpdate() { }
    void Downslam() { }
    void BackstepAttack() { }
    void Stinger() { }
    void Vault() { }
    void VaultSwing() { }
    void KickCombo() { }
    void OarCombo() { }
    void Uppercut() { }
    public void Roll(bool toPlayerSide = false) { }
    public void LightningBolt() { }
    public void LightningBoltWindup() { }
    public void LightningBoltWindupOver() { }
    public void SpawnLightningBolt(Vector3 position, bool safeForPlayer = false) { }
    public void CancelLightningBolt() { }
    public void OnDeath() { }
    void StartTracking() { }
    void StopTracking() { }
    void StartMoving(float speed) { }
    void StopMoving() { }
    public void SlamHit() { }
    void Footstep(float volume = 0.5f) { }
    void StartUppercut() { }
    void StopUppercut() { }
    void StartDamage(int damage = 25) { }
    void StopDamage() { }
    void PlayerBeenHit() { }
    void StopAction() { }
    public void ParryableFlash() { }
    public void UnparryableFlash() { }
    public void GotParried() { }
    void PlayerStatus() { }
    void SnapToGround() { }
    public void PhaseChange() { }
    public void EndPhaseChange() { }}
