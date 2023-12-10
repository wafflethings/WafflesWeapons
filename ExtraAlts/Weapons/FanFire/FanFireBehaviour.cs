using System.Collections;
using System.Collections.Generic;
using Atlas.Modules.Guns;
using UnityEngine;
using WafflesWeapons.Components;

namespace WafflesWeapons.Weapons.FanFire
{
    public class FanFireBehaviour : GunBehaviour<FanFireBehaviour>
    {
        private Revolver rev;
        [HideInInspector] public float Charge = 0;
        [HideInInspector] public float Damage = 0;
        private bool fanning = false;
        public Texture2D[] NumberToTexture;
        public static List<RevolverBeam> BeamsUsed = new List<RevolverBeam>();

        public void Start()
        {
            rev = GetComponent<Revolver>();
            rev.screenMR.material.color = ColorBlindSettings.Instance.variationColors[4];
        }

        public void Update()
        {
            if (ULTRAKILL.Cheats.NoWeaponCooldown.NoCooldown)
            {
                Charge = 6;
            }
            Charge = Mathf.Clamp(Charge, 0, 6);

            rev.pierceShotCharge = 0;
            rev.screenMR.material.SetTexture("_MainTex", NumberToTexture[(int)Charge]);

            if (Gun.OnFireHeld() && rev.shootReady && rev.gc.activated && rev.gunReady && !fanning)
            {
                if ((rev.altVersion && !fanning && WeaponCharges.Instance.revaltpickupcharges[rev.gunVariation] == 0) || !rev.altVersion)
                {
                    rev.Shoot();
                }
            }

            if (Gun.OnAltFire() && !fanning)
            {
                StartCoroutine(DoFanning());
            }
        }

        public IEnumerator DoFanning()
        {
            yield return rev.wid.delay;
            Damage = 0;
            fanning = true;
            int startCharge = (int)Charge;

            float timer = 0.25f;

            for (int i = 0; i < startCharge; i++)
            {
                while ((rev.altVersion ? timer < 0.25f && !Gun.OnFire() : timer < 0.15f) || !GunControl.Instance.activated)
                {
                    timer += Time.deltaTime;
                    yield return null;
                }
                timer = 0;
                yield return null;

                Damage = ((i + 1) * 0.25f) + 0.25f;
                ShootFan();
            }

            fanning = false;
        }

        public void OnEnable()
        {
            Charge = WaffleWeaponCharges.Instance.FanRevCharge;
        }

        public void OnDisable()
        {
            WaffleWeaponCharges.Instance.FanRevCharge = Charge;
            fanning = false;
            CancelInvoke("ShootFan");
        }

        public void ShootFan()
        {
            Charge--;
            GameObject original = rev.revolverBeam;
            rev.revolverBeam = rev.revolverBeamSuper;
            rev.revolverBeam.GetComponent<RevolverBeam>().damage = Damage;
            rev.Shoot(1);
            rev.revolverBeam = original;
        }
    }
}
