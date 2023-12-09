using Atlas.Modules.Guns;
using UnityEngine;
using UnityEngine.UI;
using WafflesWeapons.Components;

namespace WafflesWeapons.Weapons.Conductor
{
public class ConductorBehaviour : GunBehaviour<ConductorBehaviour>
    {
        private Nailgun nail;
        [HideInInspector] public float Charge;
        [HideInInspector] public float ChargeLength;
        [HideInInspector] public float LastCharge;
        public GameObject Beam;
        public GameObject Saw;
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
        private float fireRate = 0;
        private float cooldown = 0;

        public void MaxCharge()
        {
            Charge = 1;
        }

        public void Start()
        {
            nail = GetComponent<Nailgun>();
            fireRate = nail.fireRate;
            SetBarrelsOrange();
        }

        public void Update()
        {
            if (ULTRAKILL.Cheats.NoWeaponCooldown.NoCooldown)
            {
                Charge = 1;
            }

            if (nail.gc.activated)
            {
                nail.fireRate = fireRate;
                cooldown = Mathf.MoveTowards(cooldown, 0, Time.deltaTime);
                Charge = Mathf.MoveTowards(Charge, 1, Time.deltaTime * 0.1f);

                nail.heatSlider = null;
                ChargeSlider.value = Charge;
                HoldLengthSlider.value = ChargeLength == 0 ? 0 : ChargeLength + (1 - Charge);

                if (cooldown == 0)
                {
                    if (Charge >= 0.1f && Gun.OnAltFireHeld())
                    {
                        nail.heatUp = ChargeLength;
                        nail.spinSpeed = 250f + nail.heatUp * 2250f;
                        SetBarrelsBlue();

                        nail.canShoot = false;
                        if (ChargeLength < 1)
                        {
                            ChargeLength = Mathf.MoveTowards(ChargeLength, Charge, Time.deltaTime / 1.5f);
                            if (ChargeLength == 1)
                            {
                                FinishChargeSound.Play();
                            }
                        }
                        if (!ChargeSound.isPlaying)
                        {
                            ChargeSound.Play();
                        }
                        ChargeSound.pitch = 0.5f + ChargeLength;
                        CameraController.Instance.CameraShake(ChargeLength * 0.25f);
                    }
                    else
                    {
                        nail.canShoot = true;
                    }

                    if (Gun.OnAltFireReleased() && Charge >= 0.1f)
                    {
                        LastCharge = ChargeLength;
                        if (ChargeLength <= 0.1f)
                        {
                            ChargeLength = 0.1f;
                        }

                        ChargeSound.Stop();
                        ShootSound.Play();

                        if (ChargeLength < 0.1f)
                        {
                            ChargeLength = 0.1f;
                        }

                        nail.anim.SetTrigger("Shoot");
                        CameraController.Instance.CameraShake(2 * ChargeLength);

                        if (!nail.altVersion)
                        {
                            RevolverBeam beam = GameObject.Instantiate(Beam, nail.cc.transform.position + nail.cc.transform.forward, nail.cc.transform.rotation).GetComponent<RevolverBeam>();
                            if (ChargeLength == 1)
                            {
                                beam.hitParticle = Conductor.FullExplosion;
                                foreach (Explosion e in beam.hitParticle.GetComponentsInChildren<Explosion>(true))
                                {
                                    e.sourceWeapon = gameObject;
                                }
                            }
                            beam.alternateStartPoint = nail.shootPoints[0].transform.position;
                            beam.damage *= ChargeLength;
                            beam.sourceWeapon = gameObject;
                            beam.enemyLayerMask |= (1 << 14); // have to add the Projectile layer, but can't use rb.canHitProjectiles as it will cause the sharpshooter behaviour
                            foreach (LineRenderer lr in beam.GetComponentsInChildren<LineRenderer>())
                            {
                                lr.startWidth *= 2 * ChargeLength;
                            }
                        } 
                        else
                        {
                            Nail saw = GameObject.Instantiate(Saw, nail.cc.transform.position, nail.cc.transform.rotation).GetComponent<Nail>();
                            if (ChargeLength == 1)
                            {
                                saw.sawBounceEffect = Conductor.SawExplosion;
                            }
                            saw.damage *= ChargeLength;
                            saw.weaponType = nail.projectileVariationTypes[nail.variation];
                            saw.sourceWeapon = gameObject;
                            saw.ForceCheckSawbladeRicochet();
                            saw.sourceWeapon = gameObject;
                            saw.rb.velocity = saw.transform.forward * 200;
                            saw.transform.forward = CameraController.Instance.transform.forward;

                            Vector3 newScale = Vector3.one * 0.1f * ChargeLength * 2;
                            newScale.y = 0.1f;
                            saw.transform.localScale = newScale;
                            saw.transform.position -= transform.forward * ChargeLength * 2;
                        }

                        Charge -= ChargeLength;
                        ChargeLength = 0;
                        cooldown = 0.25f;

                        SetBarrelsOrange();
                    }
                }
            }
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
            em.rateOverTime = ChargeLength * 100;
        }

        public void OnEnable()
        {
            ChargeLength = 0;
            Charge = WaffleWeaponCharges.Instance.ConductorCharge;
        }

        public void OnDisable()
        {
            WaffleWeaponCharges.Instance.ConductorCharge = Charge;
        }
    }
}
