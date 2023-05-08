using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AffectedSubjects
{
    All,
    PlayerOnly,
    EnemiesOnly
}

public class DeathZone : MonoBehaviour {
    public GameObject sawSound;
    public string deathType;
    public bool dontExplode;
    public bool aliveOnly;

    public AffectedSubjects affected;
    public bool checkForPlayerOutsideTrigger;

    [Space(10)]
    public bool notInstakill;
    public Vector3 respawnTarget;
    public bool dontChangeRespawnTarget;
    public int damage = 50;
    public EnemyType[] unaffectedEnemyTypes;

    private void Start() { }}
