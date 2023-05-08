using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNailgun : MonoBehaviour
{
    public GameObject nail;
    public GameObject altNail;
    public Transform shootPoint;
    public GameObject flash;
    public GameObject muzzleFlash;

    [SerializeField] private AudioSource chargeSound;

    public Collider[] toIgnore;

    private void Start() { }
     
    void FixedUpdate() { }
    public void Fire() { }
    public void AltFire() { }
    public void PrepareFire() { }
    public void PrepareAltFire() { }
    public void CancelAltCharge() { }
    void UpdateBuffs(EnemyIdentifier eid) { }}
