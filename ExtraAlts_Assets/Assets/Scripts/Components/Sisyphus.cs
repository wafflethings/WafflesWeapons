using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NewBlood.IK;
using UnityEngine.AI;

[RequireComponent(typeof(Solver3D))]
public class Sisyphus : MonoBehaviour
{

    [SerializeField]
    Transform target;

    [SerializeField]
    Solver3D m_Solver;

    [SerializeField]
    Animator anim;

    [SerializeField]
    Transform m_Boulder;

    [SerializeField] 
    private Collider boulderCol;

    [SerializeField]
    PhysicalShockwave m_ShockwavePrefab;
    [SerializeField] GameObject explosion;
    [SerializeField] private GameObject rubble;
    [SerializeField] private TrailRenderer trail;
    [SerializeField] private ParticleSystem swingParticle;
    [SerializeField] private AudioSource swingAudio;

    public bool stationary;
    [SerializeField] private AudioClip[] attackVoices;
    [SerializeField] private AudioClip stompVoice;
    [SerializeField] private AudioClip deathVoice;
    [SerializeField] private GameObject[] hurtSounds;

    [SerializeField] private Transform[] legs;
    [SerializeField] private Transform armature;
    [SerializeField] private GameObject attackFlash;
    [SerializeField] private Cannonball boulderCb;
    [SerializeField] private Transform originalBoulder;

    [SerializeField] private GameObject fallSound;

    [Header("Animations")] [SerializeField]
    private SisyAttackAnimationDetails overheadSlamAnim;

    [SerializeField] private SisyAttackAnimationDetails horizontalSwingAnim;
    [SerializeField]
    private SisyAttackAnimationDetails groundStabAnim;
    [SerializeField]
    private SisyAttackAnimationDetails airStabAnim;
    public bool jumpOnSpawn;

    enum AttackType
    {
        OverheadSlam,
        HorizontalSwing,
        Stab,
        AirStab,
    }

    void Start() { }
    void UpdateBuff() { }
    void SetSpeed() { }
    void OnDisable() { }
    void OnEnable() { }
    void LateUpdate() { }
    void ChangeArmLength(float targetLength) { }
    void FixedUpdate() { }
    private void Update() { }
    public void ExtendArm(float time) { }
    public void RetractArm(float time) { }
    void SetupExplosion(GameObject temp) { }
    public void TryToRetractArm(float time) { }
    public void SwingStop() { }
    void Jump(bool noEnd = false) { }
    void Jump(Vector3 target, bool noEnd = false) { }
    void FlyToArm() { }
    void CancelAirStab() { }
    public void Death() { }
    void StopAction() { }
    void ResetBoulderPose() { }
    void RotateTowardsTarget() { }
    public void StompExplosion() { }
    public void PlayHurtSound(int type = 0) { }
    public void GotParried() { }
    public void Knockdown(Vector3 boulderPos) { }
    public void FallSound() { }
    void FallKillEnemy(EnemyIdentifier eid) { }
    public void CheckLoop() { }
    void Undown() { }}
