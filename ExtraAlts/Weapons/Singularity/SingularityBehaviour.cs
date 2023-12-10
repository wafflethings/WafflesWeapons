using Atlas.Modules.Guns;
using UnityEngine;
using UnityEngine.UI;
using WafflesWeapons.Components;

namespace WafflesWeapons.Weapons.Singularity
{
    public class SingularityBehaviour : GunBehaviour<SingularityBehaviour>
    {
        public const float HEALTH_NEEDED = 400;
        public Slider Slider;
        public GameObject Ball;
        public AudioSource FullCharge;
        private Shotgun sho;
        private CameraController cc;
        private WeaponPos wpos;
        [HideInInspector] public float charge;

        public void Start()
        {
            sho = GetComponent<Shotgun>();
            cc = CameraController.Instance;
            wpos = GetComponent<WeaponPos>();
            Slider.maxValue = HEALTH_NEEDED;
        }

        public void Update()
        {
            if (ULTRAKILL.Cheats.NoWeaponCooldown.NoCooldown)
            {
                charge = HEALTH_NEEDED;
            }

            if (sho.gc.enabled)
            {
                if (charge >= HEALTH_NEEDED)
                {
                    transform.localPosition = new Vector3(
                        wpos.currentDefault.x + UnityEngine.Random.Range(-0.01f, 0.01f),
                        wpos.currentDefault.y + UnityEngine.Random.Range(-0.01f, 0.01f),
                        wpos.currentDefault.z + UnityEngine.Random.Range(-0.01f, 0.01f));

                    if (!FullCharge.isPlaying)
                    {
                        FullCharge.Play();
                    }

                    if (Gun.OnAltFire())
                    {
                        Invoke("ShootBall", sho.wid.delay);
                    }
                }
                else
                {
                    transform.localPosition = wpos.currentDefault;

                    if (FullCharge.isPlaying)
                    {
                        FullCharge.Stop();
                    }
                }

                Slider.value = Mathf.MoveTowards(Slider.value, charge, Time.deltaTime * 2500);
                charge = Mathf.Clamp(charge, 0, HEALTH_NEEDED);
            }
        }

        public void OnEnable()
        {
            charge = WaffleWeaponCharges.Instance.SingularityShoCharge;
        }

        public void OnDisable()
        {
            WaffleWeaponCharges.Instance.SingularityShoCharge = charge;
        }

        public void ShootBall()
        {
            Instantiate(Ball, cc.transform.position + cc.transform.forward, cc.transform.rotation);
            sho.anim.SetTrigger("PumpFire");
            charge -= HEALTH_NEEDED;
        }
    }
}
