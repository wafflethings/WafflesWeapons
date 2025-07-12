using System;
using System.Collections;
using HarmonyLib;
using UnityEngine;
using UnityEngine.UI;
using WafflesWeapons.Weapons.Charging;

namespace WafflesWeapons.Weapons.Revolvers.Desperado;

[HarmonyPatch]
public class DesperadoBehaviour : BaseRevolver
{
    private static readonly int s_fan = Animator.StringToHash("Fan");
    private static readonly int s_shoot = Animator.StringToHash("Shoot");

    private static int s_globalCharge;

    [SerializeField] private Slider _barSlider;
    [SerializeField] private RectTransform _perfectZone;
    private bool _moving = false;
    private BarState _state = BarState.Left;
    private float _barPosition = 0;
    private float _currentSpeed = 1f;

    private void Update()
    {
        if (!_rev.gc.activated)
        {
            return;
        }
	
	_barSlider.value = _barPosition;
        
        if (!_moving)
        {
            if (!InputManager.Instance.InputSource.Fire2.WasPerformedThisFrame)
            {
                return;
            }
            
            _moving = true;
        }
        
        _rev.gunReady = false;
        _barPosition = Mathf.MoveTowards(_barPosition, _state == BarState.Left ? 0 : 1, _currentSpeed * Time.deltaTime);

        if (_barPosition is 0 or 1)
        {
            _state = (_state == BarState.Left ? BarState.Right : BarState.Left);
            _moving = false;
	    _rev.gunReady = true;
        }
    }
}
