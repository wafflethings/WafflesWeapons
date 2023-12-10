using Atlas.Modules.Guns;
using UnityEngine;
using UnityEngine.UI;
using WafflesWeapons.Components;

namespace WafflesWeapons.Weapons.Sticky
{
    public class StickyBehaviour : GunBehaviour<StickyBehaviour>
    {
        private GameObject og;
        private Shotgun sho;
        [HideInInspector] public bool fromGreed;
        private float cooldown = 0;
        private float detonateTime = 0;
        [HideInInspector] public static int Charges = 0;
        private const float DETONATE_AT = 0.35f;
        public GameObject StickyBomb;
        public Slider slider;
        public Slider detonateSlider;

        public void Start()
        {
            sho = GetComponent<Shotgun>();
            fromGreed = GetComponent<WeaponIdentifier>().delay != 0;

            if (GetComponent<WeaponIdentifier>().delay == 0)
            {
                og = gameObject;
            }

            detonateSlider.maxValue = DETONATE_AT;
        }

        public void OnEnable()
        {
            cooldown = WaffleWeaponCharges.Instance.DemoShoCooldown;
        }

        public void OnDisable()
        {
            WaffleWeaponCharges.Instance.DemoShoCooldown = cooldown;
        }

        public void FireSticky()
        {
            GameObject silly = Instantiate(StickyBomb, sho.cc.transform.position + (sho.cc.transform.forward * 0.5f), Quaternion.identity);
            Physics.IgnoreCollision(silly.GetComponent<Collider>(), NewMovement.Instance.GetComponent<Collider>());
            StickyBombBehaviour sbb = silly.GetComponent<StickyBombBehaviour>();
            sbb.myBehaviour = this;
            sho.anim.SetTrigger("PumpFire");

            silly.GetComponent<Projectile>().explosionEffect.GetComponentInChildren<Explosion>().sourceWeapon = og;
            silly.GetComponent<Projectile>().sourceWeapon = gameObject;
        }

        public void Update()
        {
            if (sho.gc.activated)
            {
                if (ULTRAKILL.Cheats.NoWeaponCooldown.NoCooldown)
                {
                    Charges = 0;
                }

                cooldown = Mathf.MoveTowards(cooldown, 0, Time.deltaTime);

                if (Gun.OnAltFireReleased() && detonateTime >= DETONATE_AT)
                {
                    detonateTime = 0;

                    if (GetComponent<WeaponIdentifier>().delay == 0)
                    {
                        sho.anim.SetTrigger("Fire");
                        cooldown = 1.35f;
                        foreach (StickyBombBehaviour sbb in FindObjectsOfType<StickyBombBehaviour>())
                        {
                            sbb.GetComponent<Projectile>().CreateExplosionEffect();
                            GameObject.Destroy(sbb.gameObject);
                        }
                    }
                }

                if (Gun.OnAltFireHeld() && Charges != 0)
                {
                    detonateTime += Time.deltaTime * (Charges == 4 ? 2 : 1);
                } 
                else
                {
                    detonateTime -= Time.deltaTime * 2;
                }

                detonateSlider.value = detonateTime;
                detonateTime = Mathf.Clamp(detonateTime, 0, DETONATE_AT);

                if (Gun.OnAltFire())
                {
                    if (Charges < 4)
                    {
                        if (cooldown == 0)
                        {
                            float Delay = GetComponent<WeaponIdentifier>().delay;
                            cooldown = 0.25f;
                            Invoke("FireSticky", Delay);

                            if (Delay == 0)
                            {
                                Charges++;
                            }
                        }
                    }
                }

                slider.value = (4 - (Charges));
            }
        }
    }
}
