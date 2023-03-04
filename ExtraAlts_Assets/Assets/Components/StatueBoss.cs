using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StatueBoss : MonoBehaviour
{
    public GameObject player;

    public bool inAction;
    public bool friendly;

    public Transform stompPos;
    public GameObject stompWave;

    public bool damaging;
    public bool launching;
    public int damage;

    public GameObject orbProjectile;

    public GameObject stepSound;
    public GameObject backUp;

    public GameObject statueChargeSound;
    public GameObject statueChargeSound2;
    public GameObject statueChargeSound3;

    public bool enraged;
    public GameObject enrageEffect;
    public GameObject currentEnrageEffect;

    public LayerMask lmask;

    public void StompHit()
{}
    public void OrbSpawn()
{}
    public void OrbRespawn()
{}
    public void StopAction()
{}
    public void StopTracking()
{}
    public void Dash()
{}
    public void StopDash()
{}
    public void ForceStopDashSound()
{}
    public void StartDamage()
{}
    public void StopDamage()
{}
    public void Step()
{}
    public void Enrage()
{}
    public void EnrageNow()
{}}
