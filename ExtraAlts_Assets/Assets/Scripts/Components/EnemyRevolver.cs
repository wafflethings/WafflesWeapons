using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRevolver : MonoBehaviour
{
    public EnemyType safeEnemyType;
    public int variation;
    public GameObject bullet;
    public GameObject altBullet;

    public GameObject primaryPrepare;

    public Transform shootPoint;
    public GameObject muzzleFlash;
    public GameObject muzzleFlashAlt;

    private void Start() { }
    private void Update() { }
    public void Fire() { }
    public void AltFire() { }
    public void PrepareFire() { }
    public void PrepareAltFire() { }
    public void CancelAltCharge() { }
    private void OnDisable() { }
    void UpdateBuffs(EnemyIdentifier eid) { }}
