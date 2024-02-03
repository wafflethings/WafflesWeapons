using AtlasLib.Utils;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using WafflesWeapons.Components;
using WafflesWeapons.Weapons.Conductor.StunProjectiles;

namespace WafflesWeapons.Weapons.Conductor;

public class ConductorBehaviour : GunBehaviour<ConductorBehaviour>
{
    public Nailgun Nailgun;
    public GameObject ChargeProjectile;
    public Slider ChargeSlider;
    public Slider HoldLengthSlider;
    public AudioSource ChargeSound;
    public AudioSource ShootSound;
    public AudioSource FinishChargeSound;
    public MeshRenderer[] Barrels;
    public Material NormalBarrelHeat;
    public Material BlueBarrelHeat;
    public ParticleSystem ElecParticles;
    public Color ShootColour;
    public Color ElecColour;
    private float _charge;
    private float _chargeLength;
    private float _cooldown;

    public void MaxCharge()
    {
        _charge = 1;
    }

    public void Start()
    {
        Nailgun = GetComponent<Nailgun>();
        SetBarrelsOrange();
    }

    public void Update()
    {
        if (ULTRAKILL.Cheats.NoWeaponCooldown.NoCooldown)
        {
            _charge = 1;
        }

        if (Nailgun.gc.activated)
        {
            Nailgun.currentFireRate = Nailgun.fireRate;
            _cooldown = Mathf.MoveTowards(_cooldown, 0, Time.deltaTime);
            _charge = Mathf.MoveTowards(_charge, 1, Time.deltaTime * 0.1f);

            Nailgun.heatSlider = null;
            ChargeSlider.value = _charge;
            HoldLengthSlider.value = _chargeLength == 0 ? 0 : _chargeLength + (1 - _charge);

            if (_cooldown == 0)
            {
                if (_charge >= 0.1f && Inputs.AltFireHeld)
                {
                    Held();
                }
                else
                {
                    Nailgun.canShoot = true;
                }

                if (Inputs.AltFireReleased && _charge >= 0.1f)
                {
                    Shoot();
                }
            }
        }
    }

    private void Shoot()
    {
        if (_chargeLength <= 0.1f)
        {
            _chargeLength = 0.1f;
        }

        ChargeSound.Stop();
        ShootSound.Play();

        if (_chargeLength < 0.1f)
        {
            _chargeLength = 0.1f;
        }

        IStunProjectile projectile = Instantiate(ChargeProjectile, Nailgun.cc.transform.position + Nailgun.cc.transform.forward, Nailgun.cc.transform.rotation)
            .GetComponent<IStunProjectile>();
        projectile.Initialize(this, _chargeLength);
            
        Nailgun.anim.SetTrigger("Shoot");
        CameraController.Instance.CameraShake(2 * _chargeLength);

        _charge -= _chargeLength;
        _chargeLength = 0;
        _cooldown = 0.25f;

        SetBarrelsOrange();
    }
        
    private void Held()
    {
        Nailgun.heatUp = _chargeLength;
        Nailgun.spinSpeed = 250f + Nailgun.heatUp * 2250f;
        Nailgun.canShoot = false;
            
        if (_chargeLength < 1)
        {
            _chargeLength = Mathf.MoveTowards(_chargeLength, _charge, Time.deltaTime / 1.5f);
            if (_chargeLength == 1)
            {
                FinishChargeSound.Play();
            }
        }
            
        if (!ChargeSound.isPlaying)
        {
            ChargeSound.Play();
        }
            
        SetBarrelsBlue();
        ChargeSound.pitch = 0.5f + _chargeLength;
        CameraController.Instance.CameraShake(_chargeLength * 0.25f);
    }

    public void SetBarrelsOrange()
    {
        foreach (MeshRenderer mr in Barrels)
        {
            mr.material = NormalBarrelHeat;
            Light light = mr.TryGetComponent(out Light l) ? l : mr.transform.parent.GetComponentInChildren<Light>();
            light.color = ShootColour;
        }

        ParticleSystem.EmissionModule em = ElecParticles.emission;
        em.rateOverTime = 0;
    }

    public void SetBarrelsBlue()
    {
        foreach (MeshRenderer mr in Barrels)
        {
            mr.material = BlueBarrelHeat;
            Light light = mr.TryGetComponent(out Light l) ? l : mr.transform.parent.GetComponentInChildren<Light>();
            light.color = ElecColour;
        }

        ParticleSystem.EmissionModule em = ElecParticles.emission;
        em.rateOverTime = _chargeLength * 100;
    }

    public void OnEnable()
    {
        _chargeLength = 0;
        _charge = WaffleWeaponCharges.Instance.ConductorCharge;
    }

    public void OnDisable()
    {
        WaffleWeaponCharges.Instance.ConductorCharge = _charge;
    }
}
