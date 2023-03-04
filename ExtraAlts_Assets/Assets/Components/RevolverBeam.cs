using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public enum BeamType
{
    Revolver,
    Railgun,
    MaliciousFace,
    Enemy
}

public class RevolverBeam : MonoBehaviour {

    public BeamType beamType;
    public HitterAttribute[] attributes;
    public Vector3 alternateStartPoint;

    public GameObject hitParticle;
    public int bulletForce;
    public bool quickDraw;
    public int gunVariation;
    public float damage;
    public float critDamageOverride;
    public int hitAmount;
    public int maxHitsPerTarget;
    public bool noMuzzleflash;

    public GameObject ricochetSound;
    public GameObject enemyHitSound;
    public bool fake;

    public EnemyType ignoreEnemyType;
    public bool deflected;
    public bool strongAlt;
}
