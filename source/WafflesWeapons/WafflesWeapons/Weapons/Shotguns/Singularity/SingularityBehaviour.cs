using UnityEngine;
using WafflesWeapons.Weapons.Charging;

namespace WafflesWeapons.Weapons.Shotguns.Singularity;

public class SingularityBehaviour : BaseShotgun, IChargeable
{
    private static float s_globalCharge = 0;

    [SerializeField] private AudioSource _fullChargeSound;
    [SerializeField] private GameObject _ball;
    private float _charge = 0;
    private static readonly int s_pumpFire = Animator.StringToHash("PumpFire");

    protected override void Awake()
    {
        base.Awake();
        WafflesWeaponsCharges.Chargeables.Add(this);
    }

    private void Start()
    {
        _shotgun.sliderFill.color = ColorBlindSettings.Instance.variationColors[_shotgun.variation];
    }
    
    private void Update()
    {
        _shotgun.chargeSlider.value = _charge;
        _shotgun.sliderFill.color = ColorBlindSettings.Instance.variationColors[_shotgun.variation];
        
        if (_charge < 1)
        {
            return;
        }
        
        transform.localPosition = new Vector3(
            _shotgun.wpos.currentDefault.x + UnityEngine.Random.Range(-0.01f, 0.01f),
            _shotgun.wpos.currentDefault.y + UnityEngine.Random.Range(-0.01f, 0.01f),
            _shotgun.wpos.currentDefault.z + UnityEngine.Random.Range(-0.01f, 0.01f));

        if (!_fullChargeSound.isPlaying)
        {
            _fullChargeSound.Play();
        }

        if (InputManager.Instance.InputSource.Fire2.WasPerformedThisFrame)
        {
            ShootBall();
            transform.localPosition = _shotgun.wpos.currentDefault;
            _fullChargeSound.Stop();
        }
    }

    private void ShootBall()
    {
        _charge = 0;
        _shotgun.anim.SetTrigger(s_pumpFire);
        Instantiate(_ball, _shotgun.cc.transform.position + _shotgun.cc.transform.forward, _shotgun.cc.transform.rotation).GetComponent<SingularityBall>().SetSourceWeapon(gameObject);
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
