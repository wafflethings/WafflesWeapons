using System.Collections;
using UnityEngine;

namespace WafflesWeapons.Weapons.Revolvers.Fanfire;

public class FanfireBehaviour : BaseRevolver
{
    private static readonly int s_fan = Animator.StringToHash("Fan");
    private static readonly int s_shoot = Animator.StringToHash("Shoot");

    [SerializeField] private AudioClip _spinSfx;
    [SerializeField] private Texture2D[] _chargeSprites;
    [SerializeField] private float _startDelay = 0.25f;
    [SerializeField] private float _shotInterval = 0.15f;
    private bool _fanning = false;
    private int _charge = 6;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Update()
    {
        _rev.screenMR.material.mainTexture = _chargeSprites[_charge];
        
        if (_fanning)
        {
            return;
        }
        
        if (_charge > 1 && InputManager.Instance.InputSource.Fire2.WasPerformedThisFrame)
        {
            StartCoroutine(StandardFan());
        }
    }

    private IEnumerator StandardFan()
    {
        _rev.gunAud.pitch = 1.2f;
        _rev.gunAud.clip = _spinSfx;
        _rev.gunAud.Play();
        _fanning = true;
        _rev.anim.SetBool(s_fan, true);
        yield return new WaitForSeconds(_startDelay);

        while (_charge > 0)
        {
            _rev.anim.SetTrigger(s_shoot);
            _rev.Shoot(2);
            _charge--;
            yield return new WaitForSeconds(_shotInterval);
        }
        
        _rev.anim.SetBool(s_fan, false);
        _fanning = false;
    }
}
