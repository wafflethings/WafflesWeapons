using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void Dodge(Transform projectile)
{}
    public void SwitchPattern(int pattern)
{}
    public void Die()
{}
    public void IntroEnd()
{}
    public void StareAtPlayer()
{}
    public void BeginEscape()
{}
    public void Enrage()
{}}
