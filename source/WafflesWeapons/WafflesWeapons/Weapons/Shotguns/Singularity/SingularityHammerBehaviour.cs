using UnityEngine;
using WafflesWeapons.Weapons.Charging;

namespace WafflesWeapons.Weapons.Shotguns.Singularity;

public class SingularityHammerBehaviour : BaseHammer, IChargeable
{
    private static float s_globalCharge = 0;
    
    [SerializeField] private AudioSource _fullChargeSound;
    [SerializeField] private GameObject _ball;
    private float _charge = 0;
    
    protected override void Awake()
    {
        base.Awake();
        WafflesWeaponsCharges.Chargeables.Add(this);
    }

    private void Start()
    {
        _hammer.secondaryMeter.color = ColorBlindSettings.Instance.variationColors[_hammer.variation];
    }
    
    private void Update()
    {
        _hammer.secondaryMeterFill = _charge;
        _hammer.secondaryMeter.color = ColorBlindSettings.Instance.variationColors[_hammer.variation];
        
        if (_charge < 1)
        {
            return;
        }
        
        transform.localPosition = new Vector3(
            _hammer.wpos.currentDefault.x + Random.Range(-0.01f, 0.01f),
            _hammer.wpos.currentDefault.y + Random.Range(-0.01f, 0.01f),
            _hammer.wpos.currentDefault.z + Random.Range(-0.01f, 0.01f));

        if (!_fullChargeSound.isPlaying)
        {
            _fullChargeSound.Play();
        }

        if (InputManager.Instance.InputSource.Fire2.WasPerformedThisFrame)
        {
            ShootBall();
            transform.localPosition = _hammer.wpos.currentDefault;
            _fullChargeSound.Stop();
        }
    }
    
    private void ShootBall()
    {
        _charge = 0;
        _hammer.anim.Play("NadeSpawn", -1, 0f);
        Instantiate(_ball, CameraController.Instance.transform.position + CameraController.Instance.transform.forward, CameraController.Instance.transform.rotation).GetComponent<SingularityBall>().SetSourceWeapon(gameObject);
    }

    private void OnEnable()
    {
        _charge = s_globalCharge;
    }

    private void OnDisable()
    {
        s_globalCharge = _charge;
    }

    public void ResetCharge()
    {
        _charge = 0;
        s_globalCharge = 0;
    }

    public void ChargeOverTime(float amount)
    {
        _charge = Mathf.MoveTowards(_charge, 1, Time.deltaTime / 30f);
        s_globalCharge = Mathf.MoveTowards(_charge, 1, Time.deltaTime / 30f);
    }

    public void MaxCharges()
    {
        _charge = 1;
        s_globalCharge = 1;
    }
}
