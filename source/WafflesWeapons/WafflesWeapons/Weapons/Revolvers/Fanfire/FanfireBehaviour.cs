using System.Collections;
using HarmonyLib;
using UnityEngine;
using WafflesWeapons.Weapons.Charging;

namespace WafflesWeapons.Weapons.Revolvers.Fanfire;

[HarmonyPatch]
public class FanfireBehaviour : BaseRevolver, IChargeable
{
    private static readonly int s_fan = Animator.StringToHash("Fan");
    private static readonly int s_shoot = Animator.StringToHash("Shoot");

    private static int s_globalCharge;

    [SerializeField] private AudioClip _spinSfx;
    [SerializeField] private Texture2D[] _chargeSprites;
    [SerializeField] private float _startDelay = 0.25f;
    [SerializeField] private float _shotInterval = 0.15f;
    private Coroutine? _fanCoroutine;
    private bool _fanning = false;
    private int _charge = 6;

    private void Update()
    {
        if (!_rev.gc.activated)
        {
            return;
        }
        
        _rev.screenMR.material.mainTexture = _chargeSprites[_charge];
        
        if (_fanning)
        {
            return;
        }
        
        if (_charge > 0 && InputManager.Instance.InputSource.Fire2.WasPerformedThisFrame)
        {
            _fanCoroutine = StartCoroutine(Fan());
        }
    }

    private IEnumerator Fan()
    {
        _rev.gunReady = false;
        _rev.gunAud.pitch = 1.2f;
        _rev.gunAud.clip = _spinSfx;
        _rev.gunAud.Play();
        _fanning = true;
        _rev.anim.SetBool(s_fan, true);
        yield return new WaitForSeconds(_startDelay);

        int shots = 0;

        while (_charge != 0 && shots < 6)
        {
            if (_charge == 1 || shots == 5)
            {
                _rev.anim.SetBool(s_fan, false);
            }

            float timer = _shotInterval;
            _rev.Shoot(2);
            _rev.anim.SetTrigger(s_shoot);
            _charge--;
            shots++;

            while (timer != 0)
            {
                _rev.gunReady = false;
                timer = Mathf.MoveTowards(timer, 0, Time.deltaTime);
                yield return null;

                if (_rev.altVersion && (InputManager.Instance.InputSource.Fire1.WasPerformedThisFrame) && _rev.gc.activated)
                {
                    timer = 0;
                }
            }
        }
        
        _fanning = false;
    }

    private void CancelFan()
    {
        if (!_fanning)
        {
            return;
        }
        
        StopCoroutine(_fanCoroutine);
        _fanning = false;
        _rev.gunReady = true;
        _charge = 0;
    }

    [HarmonyPatch(typeof(Coin), nameof(Coin.DelayedReflectRevolver)), HarmonyPostfix]
    private static void CoinHit(Coin __instance, GameObject beam)
    {
        if (beam == null || !beam.TryGetComponent(out RevolverBeam revolverBeam) || !(revolverBeam.sourceWeapon?.GetComponent<FanfireBehaviour>()?._fanning ?? false))
        {
            return;
        }

        Instantiate(revolverBeam.ricochetSound, __instance.transform.position, Quaternion.identity).GetComponent<AudioSource>().pitch = 1f + (__instance.power - 2f) / 5f;
        __instance.power += 8;
        __instance.CancelInvoke(nameof(Coin.GetDeleted));
        __instance.CancelInvoke(nameof(Coin.ReflectRevolver));
        __instance.Invoke(nameof(Coin.ReflectRevolver), 1f);
        Rigidbody rb = __instance.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.velocity = Vector3.zero;
        rb.AddForce(Vector3.up * 15, ForceMode.VelocityChange);
    }

    protected override void Awake()
    {
        base.Awake();
        WafflesWeaponsCharges.Chargeables.Add(this);
    }

    private void OnDestroy()
    {
        WafflesWeaponsCharges.Chargeables.Remove(this);
    }
    
    [HarmonyPatch(typeof(RevolverBeam), nameof(RevolverBeam.Start)), HarmonyPrefix]
    private static void AddBeamChargeCallback(RevolverBeam __instance)
    {
        if (__instance.sourceWeapon != null)
        {
            __instance.AddOnEnemyHit(OnBeamEnemyHit);
        }
    }
    
    private static void OnBeamEnemyHit(RevolverBeam beam, EnemyIdentifier enemy, float damage)
    {
        if (beam.beamType != BeamType.Revolver || enemy.dead)
        {
            return;
        }

        if (beam.sourceWeapon.TryGetComponent(out FanfireBehaviour fan))
        {
            fan._charge++;
            
            if (fan._charge > 6)
            {
                fan._charge = 6;
            }
        }
        else
        {
            s_globalCharge += 1;
            
            if (s_globalCharge > 6)
            {
                s_globalCharge = 6;
            }
        }
    }

    private void OnEnable()
    {
        _charge = s_globalCharge;
    }

    private void OnDisable()
    {
        CancelFan();
        s_globalCharge = _charge;
    }

    public void ResetCharge()
    {
        s_globalCharge = 0;
    }

    public void MaxCharges()
    {
        s_globalCharge = 6;
        _charge = 6;
    }
    
    public void ChargeOverTime(float amount)
    {
    }
}
