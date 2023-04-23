using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class V2 : MonoBehaviour
{
    public Transform[] aimAtTarget;
    public SkinnedMeshRenderer smr;
    public Texture[] wingTextures;
    public GameObject wingChangeEffect;
    public Color[] wingColors;
    public GameObject[] weapons;
    public LayerMask environmentMask;
    public GroundCheckEnemy gc;
    public GroundCheckEnemy wc;

    public GameObject jumpSound;
    public GameObject dashJumpSound;

    public bool secondEncounter;
    public bool slowMode;
    public float movementSpeed;
    public float jumpPower;
    public float wallJumpPower;
    public float airAcceleration;

    public bool intro;
    public bool active;
    public GameObject dodgeEffect;

    public GameObject slideEffect;

    public GameObject gunFlash;
    public GameObject altFlash;

    public bool dontDie;
    public Transform escapeTarget;

    public bool longIntro;
    public GameObject shockwave;
    public GameObject KoScream;
    public GameObject enrageEffect;
    public GameObject spawnOnDeath;
    public GameObject coin;
    public float knockOutHealth;
    public bool slideOnly;
    public Vector3 forceSlideDirection;

    public UltrakillEvent onKnockout;

     
    void Start() { }
    void UpdateBuff() { }
    void SetSpeed() { }
     
    void Update() { }
    void SlowUpdate() { }
    void ThrowCoins() { }
    private void FixedUpdate() { }
    private void LateUpdate() { }
    public void Dodge(Transform projectile) { }
    public void ForceDodge(Vector3 direction) { }
    public void SwitchPattern(int pattern) { }
    public void Die() { }
    public void KnockedOut(string triggerName = "KnockedDown") { }
    public void Undie() { }
    public void IntroEnd() { }
    public void StareAtPlayer() { }
    public void BeginEscape() { }
    public void InstaEnrage() { }
    public void Enrage() { }
    public void Unenrage() { }
    public void SlideOnly(bool value) { }}
