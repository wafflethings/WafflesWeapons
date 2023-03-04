using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotgun : MonoBehaviour {

    public EnemyType safeEnemyType;
    public AudioClip shootSound;
    public AudioClip clickSound;
    public AudioClip smackSound;

    public int variation;
    public GameObject bullet;
    public GameObject grenade;
    public float spread;

    public bool gunReady = true;

    public Transform shootPoint;
    public GameObject muzzleFlash;

    public GameObject warningFlash;

    public void Fire()
{}
    public void AltFire()
{}
    public void PrepareFire()
{}
    public void PrepareAltFire()
{}
    public void ReleaseHeat()
{}
    public void ClickSound()
{}
    public void ReadyGun()
{}
    public void Smack()
{}
    
}
