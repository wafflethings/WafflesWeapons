using System;
using System.Collections;
using UnityEngine;
using WafflesWeapons.Weapons.Charging;

namespace WafflesWeapons.Weapons.Revolvers.Malevolent;

public class MalevolentBehaviour : BaseRevolver, IChargeable
{
    private static float s_globalCharge = 0;
    
    [SerializeField] private float _shotDelay = 0.2f;
    private int _shotCounter;
    
    protected override void Awake()
    {
        base.Awake();
        Shot += OnShot;
        WafflesWeaponsCharges.Chargeables.Add(this);
    }

    private void OnEnable()
    {
        _shotCounter = 0;
        _rev.pierceCharge = s_globalCharge;
    }

    private void OnDisable()
    {
        s_globalCharge = _rev.pierceCharge;
    }

    private void OnShot(RevolverBeam beam)
    {
        if (beam.hitParticle == _rev.revolverBeamSuper.GetComponent<RevolverBeam>().hitParticle)
        {
            return;
        }
        
        _shotCounter++;

        if (_shotCounter == 3)
        {
            _shotCounter = 0;
            return;
        }

        StartCoroutine(DelayedShot());
    }

    private IEnumerator DelayedShot()
    {
        yield return new WaitForSeconds(_shotDelay);
        _rev.Shoot();
    }

    public void ResetCharge()
    {
        s_globalCharge = 0;
    }

    public void ChargeOverTime(float amount)
    {
        s_globalCharge = Mathf.MoveTowards(s_globalCharge, 100, ChargeModule.RechargeRate * 100 * 0.5f * amount);
    }

    public void MaxCharges()
    {
        s_globalCharge = 100;
    }
}
