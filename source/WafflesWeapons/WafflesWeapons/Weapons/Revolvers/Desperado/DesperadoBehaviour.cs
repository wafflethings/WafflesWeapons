using HarmonyLib;
using UnityEngine;
using UnityEngine.UI;
using WafflesWeapons.Weapons.Charging;

namespace WafflesWeapons.Weapons.Revolvers.Desperado;

[HarmonyPatch]
public class DesperadoBehaviour : BaseRevolver, IChargeable
{
    private static float s_globalSize;

    [SerializeField] private Slider _barSlider;
    [SerializeField] private RectTransform _perfectZone;
    [SerializeField] private float _maxSize;
    [SerializeField] private float _minSize;
    [SerializeField] private float _sizeDecreaseForShot;
    [SerializeField] private float _sizeRegenRate;
    [SerializeField] private AudioSource _pingSound;
    [SerializeField] private AudioSource _humSound;
    private float _size;
    private bool _moving = false;
    private BarState _state = BarState.GoingRight;
    private float _barPosition = 0;
    private float _currentSpeed = 1f;
    private float _perfectStart = 0;
    private float _perfectEnd = 1;
    private bool _superShotUsed = false;
    private bool _donePing = false;
    
    protected override void Awake()
    {
        base.Awake();
        WafflesWeaponsCharges.Chargeables.Add(this);
        s_globalSize = _maxSize;
    }

    private void Update()
    {
        if (!_rev.gc.activated)
        {
            return;
        }

        _barSlider.value = _barPosition;

        if (!_moving)
        {
            UpdatePerfectZone();
            _size = Mathf.MoveTowards(_size, _maxSize, _sizeRegenRate * Time.deltaTime);

            if (InputManager.Instance.InputSource.Fire2.IsPressed)
            {
                _humSound.Play();
                _moving = true;
            }
            
            return;
        }

        _rev.gunReady = false;
        _barPosition = Mathf.MoveTowards(_barPosition, _state == BarState.GoingLeft ? 0 : 1, _currentSpeed * Time.deltaTime);

        bool perfect = (_barPosition >= _perfectStart && _barPosition <= _perfectEnd);
        
        if (perfect)
        {
            if (!_donePing)
            {
                _pingSound.Play();
                _donePing = true;
            }

            _humSound.pitch = 1.25f;
        }
        else
        {
            _humSound.pitch = 1 - (GetProximityToBar());
        }
        
        if (InputManager.Instance.InputSource.Fire1.WasPerformedThisFrame && !_superShotUsed)
        {
            if (perfect)
            {
                TimeController.Instance.SlowDown(0.25f);
            }
         
            _humSound.Stop();
            _superShotUsed = true;
            _size = Mathf.Clamp(_size - _sizeDecreaseForShot, _minSize, _maxSize);
            _rev.Shoot(perfect ? 2 : 1);
        }

        if (_barPosition is 0 or 1)
        {
            ResetBar();
        }
    }

    private float GetProximityToBar()
    {
        if (_barPosition >= _perfectStart && _barPosition <= _perfectEnd)
        {
            return 0;
        }

        float leftProximity = Mathf.Abs(_perfectStart - _barPosition);
        float rightProximity = Mathf.Abs(_perfectEnd - _barPosition);
        Plugin.Log.LogMessage($"{leftProximity} {rightProximity} -> {Mathf.Min(leftProximity, rightProximity)}");
        return Mathf.Min(leftProximity, rightProximity);
    }

    private void ResetBar()
    {
        _state = (_state == BarState.GoingLeft ? BarState.GoingRight : BarState.GoingLeft);
        UpdatePerfectZone();
        _humSound.Stop();
        _moving = false;
        _rev.gunReady = true;
        _superShotUsed = false;
        _barPosition = (_state == BarState.GoingLeft) ? 1 : 0;
        _donePing = false;
    }
    
    private void UpdatePerfectZone()
    {
        float start = (_state == BarState.GoingLeft) ? 0.2f : 0.8f - _size;
        SetPerfectZone(start, start + _size);
    }

    private void SetPerfectZone(float start, float end)
    {
        float sliderWidth = (_perfectZone.transform.parent as RectTransform).rect.width;

        float startProportional = start * sliderWidth;
        float endProportional = end * sliderWidth;
        _perfectZone.anchoredPosition = new Vector2(startProportional, _perfectZone.anchoredPosition.y);
        _perfectZone.sizeDelta = new Vector2(endProportional - startProportional, _perfectZone.sizeDelta.y);
        
        _perfectStart = start;
        _perfectEnd = end;
    }
    
    [HarmonyPatch(typeof(WalkingBob), nameof(WalkingBob.Update)), HarmonyPostfix]
    public static void DecreaseBob(WalkingBob __instance)
    {
        if ((GunControl.Instance?.currentWeapon?.TryGetComponent(out DesperadoBehaviour db) ?? false) && db._moving)
        {
            __instance.transform.localPosition = Vector3.MoveTowards(__instance.transform.localPosition, __instance.originalPos, Time.deltaTime);
        }
    }

    private void OnEnable()
    {
        _size = s_globalSize;
    }

    private void OnDisable()
    {
        ResetBar();
        s_globalSize = _size;
    }

    public void ResetCharge()
    {
        s_globalSize = _maxSize;
    }

    public void ChargeOverTime(float amount)
    {
        s_globalSize = Mathf.MoveTowards(s_globalSize, _maxSize, _sizeRegenRate * Time.deltaTime);
    }

    public void MaxCharges()
    {
        s_globalSize = _maxSize;
    }
}
