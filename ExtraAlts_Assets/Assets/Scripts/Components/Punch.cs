using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FistType
{
    Standard,
    Heavy,
    Spear
}

public class Punch : MonoBehaviour
{

    public FistType type;

    public bool ready = true;
    public LayerMask deflectionLayerMask;
    public LayerMask ignoreEnemyTrigger;
    public LayerMask environmentMask;
    public GameObject dustParticle;
     

    public AudioSource normalHit;
    public AudioSource heavyHit;
    public AudioSource specialHit;

    public bool holding;
    public Transform holder;
    public ItemIdentifier heldItem;

    public GameObject parriedProjectileHitObject;

    public GameObject blastWave;
    public GameObject shell;
    public Transform shellEjector;

     
    void Start() { }
    private void OnEnable() { }
    public void ResetHeldState() { }
    public void ForceThrow() { }
    public void PlaceHeldObject(ItemPlaceZone[] placeZones, Transform target) { }
    public void ResetHeldItemPosition() { }
    public void ForceHold(ItemIdentifier itid) { }
    private void OnDisable() { }
    void Update() { }
    void PunchStart() { }
    void ActiveStart() { }
    public void CoinFlip() { }
    void ActiveEnd() { }
    public void ResetFistRotation() { }
    void PunchEnd() { }
    void ReadyToPunch() { }
    void PunchSuccess(Vector3 point, Transform target) { }
    public void Parry(bool hook = false, EnemyIdentifier eid = null) { }
    void ParryProjectile(Projectile proj) { }
    public void BlastCheck() { }
    public void Eject() { }
    public void Hide() { }
    public void ShopMode() { }
    public void StopShop() { }
    public void EquipAnimation() { }
    public void CancelAttack() { }}
