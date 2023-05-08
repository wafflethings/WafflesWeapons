using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeviathanController : MonoBehaviour
{

    public LeviathanHead head;
    [SerializeField] Transform headWeakPoint;
    public LeviathanTail tail;
    [SerializeField] Transform tailWeakPoint;
    public float phaseChangeHealth;

    [HideInInspector] public int difficulty
{get;set;}
    public UltrakillEvent onEnterSecondPhase;

    [SerializeField] Transform tailPartsParent;
    [SerializeField] Transform headPartsParent;

    public UltrakillEvent onDeathEnd;

    public GameObject bigSplash;

    void Awake() { }
    void UpdateBuff() { }
    void OnDestroy() { }
    void Update() { }
    void BeginMainPhase() { }
    public void MainPhaseOver() { }
    public void BeginSubPhase() { }
    void SubAttack() { }
    public void SubAttackOver() { }
    void SpecialDeath() { }
    void ExplodeTail() { }
    void ExplodeHead() { }
    void FinalExplosion() { }
    public void DeathEnd() { }}
