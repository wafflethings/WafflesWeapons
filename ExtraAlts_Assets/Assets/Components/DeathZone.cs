using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum affectedSubjects
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

    public affectedSubjects affected;

    public bool notInstakill;
    public Vector3 respawnTarget;
    public bool checkForPlayerOutsideTrigger;
}
