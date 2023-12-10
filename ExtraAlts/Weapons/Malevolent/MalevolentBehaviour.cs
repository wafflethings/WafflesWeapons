using Atlas.Modules.Guns;
using UnityEngine;
using WafflesWeapons.Components;

namespace WafflesWeapons.Weapons.Malevolent
{
    public class MalevolentBehaviour : GunBehaviour<MalevolentBehaviour>
    {
        public Revolver rev;

        public void Start()
        {
            rev = GetComponent<Revolver>();
            rev.screenAud = rev.screenMR.gameObject.GetComponent<AudioSource>();
            rev.screenMR.material.color = ColorBlindSettings.Instance.variationColors[5];
            Weapons.Malevolent.Guns.Add(this);
        }

        public void Update()
        {
            if (rev.gc.activated)
            {
                if (ULTRAKILL.Cheats.NoWeaponCooldown.NoCooldown)
                {
                    MaxCharge();
                }

                Charge();

                if (Gun.OnFireHeld() && rev.shootReady && rev.gunReady)
                {
                    if ((rev.altVersion && WeaponCharges.Instance.revaltpickupcharges[rev.gunVariation] == 0) ||
                        !rev.altVersion)
                    {
                        float delay = GetComponent<WeaponIdentifier>().delay;
                        if (!rev.altVersion)
                        {
                            Invoke("Shoot", 0 + delay);
                            Invoke("Shoot", 0.1f + delay);
                            Invoke("Shoot", 0.2f + delay);

                            if (rev.wid.delay != 0)
                            {
                                rev.shootCharge = 0;
                                rev.shootReady = false;
                            }
                        }
                        else
                        {
                            Invoke("Shoot", 0 + delay);
                            Invoke("Shoot", 0.25f + delay);
                            Invoke("Shoot", 0.5f + delay);
                        }
                    }
                }

                rev.chargeEffect.transform.localScale = Vector3.one * rev.pierceShotCharge * 0.02f;
                rev.ceaud.volume = 0.25f + rev.pierceShotCharge * 0.005f;
                rev.ceaud.pitch = rev.pierceShotCharge * 0.005f;
                rev.celight.range = rev.pierceShotCharge * 0.01f;

                if (Gun.OnAltFireReleased() && rev.pierceReady && rev.shootReady && rev.pierceShotCharge == 100f &&
                    rev.gunReady)
                {
                    Invoke("Shoot2", rev.wid.delay);
                }

                if (rev.pierceCharge < 50f)
                {
                    rev.screenMR.material.SetTexture("_MainTex", rev.batteryLow);
                    //rev.screenMR.material.color = Color.red;
                }
                else
                {
                    if (rev.pierceCharge < 100f)
                    {
                        rev.screenMR.material.SetTexture("_MainTex", rev.batteryMid);
                        //rev.screenMR.material.color = Color.yellow;
                    }
                    else
                    {
                        rev.screenMR.material.SetTexture("_MainTex", rev.batteryFull);
                    }
                }

                if (Gun.OnAltFireHeld() && rev.shootReady && rev.pierceReady)
                {
                    rev.chargingPierce = true;
                    if (rev.pierceShotCharge + 175f * Time.deltaTime < 100f)
                    {
                        rev.pierceShotCharge += 175f * Time.deltaTime;
                    }
                    else
                    {
                        rev.pierceShotCharge = 100f;
                    }
                }
                else
                {
                    rev.chargingPierce = false;
                    if (rev.pierceShotCharge - 175f * Time.deltaTime > 0f)
                    {
                        rev.pierceShotCharge -= 175f * Time.deltaTime;
                    }
                    else
                    {
                        rev.pierceShotCharge = 0f;
                    }
                }
            }

            if (rev.pierceShotCharge != 0f)
            {
                if (rev.pierceShotCharge < 50f)
                {
                    rev.screenMR.material.SetTexture("_MainTex", rev.batteryCharges[0]);
                }
                else
                {
                    if (rev.pierceShotCharge < 100f)
                    {
                        rev.screenMR.material.SetTexture("_MainTex", rev.batteryCharges[1]);
                    }
                    else
                    {
                        rev.screenMR.material.SetTexture("_MainTex", rev.batteryCharges[2]);
                    }
                }

                transform.localPosition = new Vector3(rev.wpos.currentDefault.x + rev.pierceShotCharge / 250f *
                    Random.Range(-0.05f, 0.05f), rev.wpos.currentDefault.y + rev.pierceShotCharge / 250f *
                    Random.Range(-0.05f, 0.05f), rev.wpos.currentDefault.z + rev.pierceShotCharge / 250f *
                    Random.Range(-0.05f, 0.05f));
            }

            rev.cylinder.spinSpeed = rev.pierceShotCharge;
        }

        public void OnEnable()
        {
            if (rev != null)
                rev.pierceCharge = WaffleWeaponCharges.Instance.MalRevCharge;
        }

        public void OnDisable()
        {
            if (rev != null)
                WaffleWeaponCharges.Instance.MalRevCharge = rev.pierceCharge;
            CancelInvoke("Shoot");
        }

        public void Shoot()
        {
            rev.Shoot();
        }

        public void Shoot2()
        {
            rev.Shoot(2);
            rev.wc.rev2charge += (rev.altVersion ? 300 : 100); // hakita's code is pretty bad.
            // instead of checking if it is the sharpshooter revolver, it checks if it isnt the piercer.
            // there's no way not to make it subtract, so i just add it back. this code hurts me.
        }

        public void MaxCharge()
        {
            if (rev != null)
            {
                rev.pierceCharge = 100;
                rev.pierceReady = true;
            }
        }

        public void Charge()
        {
            if (!rev.shootReady)
            {
                if (rev.shootCharge + 200f * Time.deltaTime < 100f)
                {
                    rev.shootCharge += 200f * Time.deltaTime;
                }
                else
                {
                    rev.shootCharge = 100f;
                    rev.shootReady = true;
                }
            }

            float num = 1f;

            if (rev.altVersion)
            {
                num = 0.5f;
            }

            if (rev.pierceCharge + 30f * Time.deltaTime < 100f)
            {
                rev.pierceCharge += 30f * Time.deltaTime * num;
            }
            else
            {
                if (!rev.pierceReady)
                {
                    rev.screenAud.clip = rev.chargedSound;
                    rev.screenAud.loop = false;
                    rev.screenAud.volume = 0.35f;
                    rev.screenAud.pitch = Random.Range(1f, 1.1f);
                    rev.screenAud.Play();
                }

                rev.pierceCharge = 100f;
                rev.pierceReady = true;
            }
        }
    }
}
