using System;
using System.Collections;
using AtlasLib.Utils;
using HarmonyLib;
using UnityEngine;

namespace WafflesWeapons.Weapons.DrillRocket.Behaviours;

[PatchThis($"{Plugin.GUID}.DrillPrimary")]
public class DrillPrimary : MonoBehaviour
{
    public float Speed;
    [Header("Explosion")] 
    public GameObject HarmlessExplosion;
    public GameObject StandardExplosion;
    public GameObject BigExplosion;
    [Header("Effects")] 
    public AudioSource ChainsawSound;
    public ParticleSystem Smoke;
    public GameObject Rubble;

    [HideInInspector] public GameObject SourceWeapon;
    [HideInInspector] public bool Frozen;

    private Rigidbody _rigidbody;
    private Collider _collider;
    private Vector3 _frozenOffset;
    private float _currentSpeed;
    private float _timeOutOfEnemy;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
        _currentSpeed = Speed;
    }
        
    private void FixedUpdate()
    {
        if (!Frozen)
        {
            _timeOutOfEnemy += Time.deltaTime;

            if (_timeOutOfEnemy > 30)
            {
                Destroy(gameObject);
            }
                
            _rigidbody.velocity = transform.forward * _currentSpeed;
        }
        else
        {
            transform.localPosition = _frozenOffset;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (Frozen)
        {
            return;
        }
            
        if (LayerMaskDefaults.Get(LMD.Enemies).Contains(other.gameObject.layer))
        {
            HitEnemy(other.gameObject.GetComponent<EnemyIdentifierIdentifier>());
            return;
        }
            
        if (LayerMaskDefaults.Get(LMD.Environment).Contains(other.gameObject.layer))
        {
            HitEnvironment();
        }
    }

    private void HitEnemy(EnemyIdentifierIdentifier eidid)
    {
        EnemyIdentifier eid = eidid.eid;
        //StartCoroutine(SlowForTime());
        StickHarpoon(eidid);
        eid.hitter = "rocket";
        eid.DeliverDamage(eidid.gameObject, _rigidbody.velocity.normalized, eidid.transform.position, 1, false, 0, SourceWeapon);
        TimeController.Instance.HitStop(0.05f); 
    }

    private IEnumerator IgnoreEnemy(EnemyIdentifier eid)
    {
        EnemyIdentifierIdentifier[] eidids = eid.GetComponentsInChildren<EnemyIdentifierIdentifier>();

        foreach (EnemyIdentifierIdentifier eidid in eidids)
        {
            Physics.IgnoreCollision(eidid.GetComponent<Collider>(), _collider, true);
        }

        yield return new WaitForSeconds(0.25f);
            
        foreach (EnemyIdentifierIdentifier eidid in eidids)
        {
            Physics.IgnoreCollision(eidid.GetComponent<Collider>(), _collider, false);
        }
    }

    private void StickHarpoon(EnemyIdentifierIdentifier eidid)
    {
        gameObject.layer = 2; //non raycast
        ChainsawSound.Play();
        transform.parent = eidid.transform;
        _rigidbody.isKinematic = true;
        _frozenOffset = transform.localPosition;
        GetComponent<Collider>().enabled = false;
        _timeOutOfEnemy = 0;
        Frozen = true;
    }

    private void UnstickHarpoon()
    {
        gameObject.layer = 14; //projectile
        EnemyIdentifier eid = transform.GetComponentInParent<EnemyIdentifier>();
        Explode(true, !eid.flying && (!eid.gce?.onGround ?? false), SourceWeapon);
        StartCoroutine(IgnoreEnemy(eid));
        ChainsawSound.Play();
        transform.parent = null;
        _rigidbody.isKinematic = false;
        GetComponent<Collider>().enabled = true;
        Frozen = false;
    }

    private void HitEnvironment()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 10, LayerMaskDefaults.Get(LMD.Environment)))
        {
            GameObject rubble = Instantiate(Rubble, hit.point, Quaternion.identity);
            rubble.transform.LookAt(hit.normal);
        }
            
        StartCoroutine(SlowForTime());
        // Explode(false, false, SourceWeapon);
    }
        
    public void Explode(bool hitEnemy, bool aerialHit, GameObject sourceWeapon = null)
    {
        GameObject selectedExplosion = HarmlessExplosion;

        if (hitEnemy)
        {
            if (aerialHit)
            {
                selectedExplosion = BigExplosion;
            }
            else
            {
                selectedExplosion = StandardExplosion;
            }
        }

        GameObject createdExplosion = Instantiate(selectedExplosion, transform.position, transform.rotation);
            
        foreach (Explosion explosion in createdExplosion.GetComponentsInChildren<Explosion>())
        {
            explosion.sourceWeapon = sourceWeapon;
                
            if (explosion.damage != 0)
            {
                explosion.rocketExplosion = true;
            }
        }
    }

    //can only have 0 or 1 param in editor
    public void ExplosionWithFlash()
    {
        TimeController.Instance.ParryFlash();
        Explode(true, false);
        Destroy(gameObject);
    }

    public void Parry()
    {
        UnstickHarpoon();
        transform.position = CameraController.Instance.GetDefaultPos() + CameraController.Instance.transform.forward;
        transform.forward = CameraController.Instance.transform.forward;
    }

    private IEnumerator SlowForTime()
    {
        ChainsawSound.Play();
        Smoke.Play();
        _currentSpeed = Speed / 3;
        _rigidbody.detectCollisions = false;
        yield return new WaitForSeconds(0.3f);
        Smoke.Stop();
        _currentSpeed = Speed;
        _rigidbody.detectCollisions = true;
    }

    [HarmonyPatch(typeof(EnemyIdentifier), nameof(EnemyIdentifier.DeliverDamage)), HarmonyPostfix]
    private static void ParryDrillsOnPunch(EnemyIdentifier __instance)
    {
        if (__instance.hitter != "punch")
        {
            return;
        }

        DrillPrimary[] drills = __instance.GetComponentsInChildren<DrillPrimary>();

        if (drills.Length == 0)
        {
            return;
        }
            
        TimeController.Instance.ParryFlash();
        foreach (DrillPrimary drill in drills)
        {
            drill.Parry();
        }
    }
}
