using System;
using System.Collections;
using UnityEngine;

namespace WafflesWeapons.Weapons.Revolvers.Malevolent;

public class MalevolentBehaviour : BaseRevolver
{
    [SerializeField] private float _shotDelay = 0.2f;
    private int _shotCounter;
    
    protected override void Awake()
    {
        base.Awake();
        
        Shot += OnShot;
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
}
