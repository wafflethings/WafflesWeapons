using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleProjectile : MonoBehaviour {
    public float speed;
    public LayerMask lmask;

    public GameObject lightningBolt;
    public GameObject lightningBolt2;
    public Material additive;

    public List<EnemyIdentifier> shootList = new List<EnemyIdentifier>();

    public bool enemy;
    public EnemyType safeType;

    public GameObject spawnEffect;
    public GameObject explosionEffect;

    public void Activate()
{}
    public void FadeIn()
{}
    public void Explode()
{}}
