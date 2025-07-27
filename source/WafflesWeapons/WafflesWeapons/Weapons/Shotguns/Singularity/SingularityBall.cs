using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using UnityEngine;

namespace WafflesWeapons.Weapons.Shotguns.Singularity;

[HarmonyPatch]
public class SingularityBall : MonoBehaviour
{
    [SerializeField] private bool _isAlt;
    [SerializeField] private float _altLaunchBoost = 25f;
    [SerializeField] private float _altParryBoost = 55f;
    [SerializeField] private float _altHammerBoost = 35f;
    [SerializeField] private float _lifetime = 20;
    [SerializeField] private GameObject _deathEffect;
    [SerializeField] private GameObject _hitEffect;
    [SerializeField] private GameObject _impulse;
    [SerializeField] private float _drillInterval = 0.75f; 
    [SerializeField] private SingularityTendril _tendril;
    [SerializeField] private float _tendrilDamage = 2f;
    [SerializeField] private float _enemyDamage = 2.5f;
    [SerializeField] private float _enemyDamageCooldown = 0.25f;
    [SerializeField] private float _speed;
    [SerializeField] private AudioSource _bounceSound;
    [SerializeField] private float _bounceSoundMinPitch = 0.35f;
    [SerializeField] private float _bounceSoundMaxPitch = 0.65f;
    [SerializeField] private SphereCollider _revolverCollider;    
    [SerializeField] private Rigidbody _rb;
    private float _time = 0;
    private int _drills = 0;
    private float _drillCooldown = 0;
    private List<EnemyIdentifier> _enemiesOnCooldown = new();
    private List<Rigidbody> _caughtObjects = new();
    private List<RevolverBeam> _ignoreBeams = new();
    private GameObject _sourceWeapon;

    [HarmonyPatch(typeof(HookArm), nameof(HookArm.FixedUpdate)), HarmonyPostfix]
    private static void GrabBall(HookArm __instance)
    {
        if (__instance.state == HookState.Throwing)
        {
            if (!InputManager.Instance.InputSource.Hook.IsPressed && (__instance.cooldown <= 0.1f || __instance.caughtObjects.Count > 0))
            {
                __instance.StopThrow(0f, false);
                return;
            }
            
            RaycastHit[] array = Physics.SphereCastAll(__instance.hookPoint, Mathf.Min(Vector3.Distance(__instance.transform.position, __instance.hookPoint) / 15f, 5f), __instance.throwDirection, 250f * Time.fixedDeltaTime, __instance.throwMask, QueryTriggerInteraction.Collide);
            Array.Sort(array, (RaycastHit x, RaycastHit y) => x.distance.CompareTo(y.distance));

            foreach (RaycastHit hit in array)
            {
                if (hit.transform.gameObject.layer == 14 && hit.transform.gameObject.TryGetComponent(out SingularityBall sbb))
                {
                    __instance.caughtTransform = sbb.transform;
                    __instance.caughtCollider = sbb.GetComponent<Collider>();
                    __instance.state = HookState.Caught;
                }
            }
        }
    }

    public void SetSourceWeapon(GameObject sourceWeapon) => _sourceWeapon = sourceWeapon;

    public void GetHammered()
    {
        if (_isAlt)
        {
            _rb.velocity = CameraController.Instance.transform.forward * _altHammerBoost;
        }
    }

    public void Parry()
    {
        Implode(25);
        
        if (!_isAlt)
        {
            transform.forward = CameraController.Instance.transform.forward;
            return;
        }
        
        _rb.velocity = CameraController.Instance.transform.forward * _altParryBoost;
    }

    public void RevolverHit(RevolverBeam beam)
    {
        if (_ignoreBeams.Contains(beam))
        {
            return;
        }
        
        _ignoreBeams.Add(beam);
        Implode(15 + (1.75f * beam.damage * beam.maxHitsPerTarget));
        TimeController.Instance.ParryFlash();
    }

    public void CoinHit(Coin coin)
    {
        // note: railcannon beams just reflect at it and dont call this, instead using revolverhit
        Implode(coin.power * 7.5f);
        TimeController.Instance.ParryFlash();
    }

    private void Awake()
    {
        Physics.IgnoreCollision(NewMovement.Instance.playerCollider, _revolverCollider);

        if (_isAlt)
        {
            _rb.velocity = CameraController.Instance.transform.forward * _altLaunchBoost;
        }
    }
    
    private void Update()
    {
        if (!_isAlt)
        {
            _rb.velocity = transform.forward * _speed;

            if (Physics.SphereCast(transform.position, _revolverCollider.radius + 0.5f, transform.forward, out RaycastHit hit, _revolverCollider.radius + 0.5f, LayerMaskDefaults.Get(LMD.Environment)))
            {
                DetectCollision(hit.normal);
            }
        }

        if (_drills > 0)
        {
            _drillCooldown += Time.deltaTime;
            if (_drillCooldown > _drillInterval / _drills)
            {
                _drillCooldown = 0;
                Implode(25);
            }
        }

        foreach (Rigidbody rb in _caughtObjects)
        {
            if (rb == null)
            {
                continue;
            }

            if (rb.isKinematic)
            {
                rb.transform.localPosition = Vector3.MoveTowards(rb.transform.localPosition, Vector3.zero, Time.deltaTime * 2);
            }
            else
            {
                rb.velocity = _rb.velocity + Vector3.ClampMagnitude(transform.position - rb.transform.position, 5);
            }
        }

        _time += Time.deltaTime;

        if (_time > _lifetime)
        {
            transform.localScale = Vector3.MoveTowards(transform.localScale, Vector3.zero, Time.deltaTime * 3);

            if (transform.localScale.sqrMagnitude < (0.1 * 0.1))
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnDestroy()
    {
        int i = 0;
        foreach (EnemyIdentifierIdentifier eidid in GetComponentsInChildren<EnemyIdentifierIdentifier>().Where(eidid => eidid.eid != null))
        {
            if (i % 2 == 0) //prob a better way to do this but its 2am and im eepy :3
            {
                eidid.eid.hitter = "enemy";
                eidid.eid.DeliverDamage(eidid.gameObject, Vector3.zero, eidid.gameObject.transform.position, 25f, false);
            }
            i++;
        }

        foreach (Breakable breakable in GetComponentsInChildren<Breakable>())
        {
            breakable.Break();
        }

        foreach (Projectile proj in GetComponentsInChildren<Projectile>())
        {
            proj.CreateExplosionEffect();
            Destroy(proj.gameObject);
        }
        
        foreach (EventOnDestroy e in GetComponentsInChildren<EventOnDestroy>())
        {
            e.OnDestroy();
        }

        Instantiate(_deathEffect, transform.position, Quaternion.identity);
    }

    private void CatchRb(Rigidbody rb)
    {
        rb.transform.parent = transform;
        rb.useGravity = false;
        //rb.isKinematic = true;
        _caughtObjects.Add(rb);
    }

    private void Implode(float distance)
    {
        Instantiate(_hitEffect, transform);
        Instantiate(_impulse, transform).GetComponent<SingularityImpulse>().SetSize(distance);
        
        foreach (EnemyIdentifier enemy in WeaponUtils.EnemiesInRange(transform.position, distance))
        {
            Instantiate(_tendril.gameObject, transform.position, Quaternion.identity).GetComponent<SingularityTendril>().SetPositions(transform, enemy.gameObject);
            enemy.SimpleDamage(_tendrilDamage);
            ApplyKnockback(enemy);
        }
        
        foreach (Projectile projectile in FindObjectsOfType<Projectile>())
        {
            if ((projectile.rb?.useGravity ?? true) || _caughtObjects.Contains(projectile.rb))
            {
                continue;
            }

            if ((transform.position - projectile.gameObject.transform.position).sqrMagnitude >= distance * distance)
            {
                continue;
            }

            projectile.transform.LookAt(gameObject.transform);
            Instantiate(_tendril.gameObject, transform.position, Quaternion.identity).GetComponent<SingularityTendril>().SetPositions(transform, projectile.gameObject);
        }
    }

    private void ApplyKnockback(EnemyIdentifier enemy)
    {
        if (!enemy.TryGetComponent(out Rigidbody enemyRb))
        {
            return;
        }
        
        Vector3 force = enemyRb.transform.up / 10;

        switch (enemy.enemyClass)
        {
            case EnemyClass.Husk:
                enemy.zombie?.KnockBack(force);
                break;
            case EnemyClass.Machine:
                enemy.machine?.KnockBack(force);
                break;
            case EnemyClass.Demon:
                enemy.statue?.KnockBack(force);
                break;
            default:
                enemyRb.AddForce(force, ForceMode.VelocityChange);
                break;
        }
        enemyRb.velocity = (transform.position - enemy.transform.position) * 5;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!LayerMaskDefaults.IsMatchingLayer(other.gameObject.layer, LMD.Environment))
        {
            return;
        }
        
        Vector3 hitDirection = other.contacts[0].point - transform.position;

        if (!Physics.SphereCast(transform.position, _revolverCollider.radius, hitDirection, out RaycastHit hit, 5))
        {
            return;
        }

        if (!_isAlt)
        {
            DetectCollision(hit.normal);
        }
    }

    private void DetectCollision(Vector3 normal)
    {
        _bounceSound.pitch = UnityEngine.Random.Range(_bounceSoundMinPitch, _bounceSoundMaxPitch);
        _bounceSound.Play();
        transform.forward = Vector3.Reflect(transform.forward, normal);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Harpoon harpoon) && !_caughtObjects.Contains(other.GetComponent<Rigidbody>()))
        {
            harpoon.GetComponent<Collider>().enabled = false;
            harpoon.rb.isKinematic = true;
            CatchRb(harpoon.rb);
            
            Magnet? magnet = harpoon.GetComponentInChildren<Magnet>();
            if (magnet != null)
            {
                magnet.maxWeight *= 0.75f;
            }

            if (harpoon.drill)
            {
                harpoon.currentDrillSound = Instantiate(harpoon.drillSound, harpoon.transform);
                harpoon.currentDrillSound.Play();
                Destroy(harpoon.GetComponent<DestroyAudio>());
                harpoon.StartCoroutine(DrillRiser(harpoon.currentDrillSound));
                _drills++;
            }

            harpoon.hit = true;
            
            Breakable? breakable = other.GetComponentInChildren<Breakable>();
            if (breakable != null)
            {
                breakable.unbreakable = true;
            }
        }
        
        if (other.TryGetComponent(out Projectile projectile))
        {
            CatchRb(projectile.rb);
            projectile.undeflectable = true;
            projectile.hittingPlayer = false;
            projectile.friendly = true;

            if (projectile.TryGetComponent(out RemoveOnTime rot))
            {
                Destroy(rot); 
            }
        }
        
        if (!LayerMaskDefaults.IsMatchingLayer(other.gameObject.layer, LMD.Enemies))
        {
            return;
        }

        EnemyIdentifier? enemy = other.GetComponent<EnemyIdentifier>() ?? other.GetComponent<EnemyIdentifierIdentifier>()?.eid;

        if (enemy == null || enemy.dead)
        {
            if (enemy?.enemyType == EnemyType.MaliciousFace)
            {
                enemy.GetComponent<SpiderBody>()?.BreakCorpse();
            }
            
            if (other.TryGetComponent(out Rigidbody rb))
            {
                other.GetComponent<Collider>().enabled = false;
                CatchRb(rb);
            }
            
            return;
        }

        if (_enemiesOnCooldown.Contains(enemy))
        {
            return;
        }
        
        StartCoroutine(HitEnemy(enemy));
    }

    private IEnumerator DrillRiser(AudioSource audioSource)
    {
        while (true)
        {
            Plugin.Log.LogMessage(audioSource.pitch);
            audioSource.pitch = Mathf.MoveTowards(audioSource.pitch, 4, Time.deltaTime / 20);
            yield return null;
        }
    }

    private IEnumerator HitEnemy(EnemyIdentifier enemy)
    {
        enemy.SimpleDamage(_enemyDamage);
        
        if (enemy.dead)
        {
            StyleCalculator.Instance.AddPoints(200, "<color=#b400ff>COMPRESSED</color>", enemy, _sourceWeapon);
        }
        
        _enemiesOnCooldown.Add(enemy);
        yield return new WaitForSeconds(_enemyDamageCooldown);
        _enemiesOnCooldown.Remove(enemy);
    }
}
