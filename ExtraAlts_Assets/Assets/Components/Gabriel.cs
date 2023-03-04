using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GabrielWeaponType
{
    Sword,
    Zweihander,
    Axe,
    Spear,
    Glaive
}

public class Gabriel : MonoBehaviour
{
    public GameObject particles;    
    public Material enrageBody;
    public Material enrageWing;

    public bool enraged;
    public GameObject enrageEffect;
    public bool secondPhase;
    public float phaseChangeHealth;
    public GameObject teleportSound;
    public GameObject decoy;

    public Transform rightHand;
    public Transform leftHand;

    public GameObject sword;
    public GameObject zweiHander;
    public GameObject axe;
    public GameObject spear;
    public GameObject glaive;
    public GameObject dashEffect;
    public GameObject juggleEffect;

    public GameObject summonedSwords;

    public Transform head;
    public GameObject attackFlash;

    public void EnrageNow()
{}
    public void EnableWeapon()
{}
    public void DisableWeapon()
{}
    public void DamageStartLeft(int damage)
{}
    public void DamageStopLeft(int keepMoving)
{}
    public void DamageStartRight(int damage)
{}
    public void DamageStopRight(int keepMoving)
{}
    public void SetForwardSpeed(int newSpeed)
{}
    public void EnrageTeleport(int teleportType = 0)
{}
    public void LookAtTarget(int instant = 0)
{}
    public void FollowTarget()
{}
    public void StopAction()
{}
    public void ResetWingMat()
{}}
