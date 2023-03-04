using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuousBeam : MonoBehaviour
{

    public bool hitPlayer;
    public bool hitEnemy;
    
    public bool enemy;
    public EnemyType safeEnemyType;

    public float damage;

    public GameObject impactEffect;
}
