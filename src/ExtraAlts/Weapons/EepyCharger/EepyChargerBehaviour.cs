using System.Collections;
using AtlasLib.Utils;
using UnityEngine;
using WafflesWeapons.Components;

namespace WafflesWeapons.Weapons.EepyCharger;

public class EepyChargerBehaviour : GunBehaviour<EepyChargerBehaviour>
{
    public static float PreviousHeldTime;
    public static float ChargeDivide = 4;
    [HideInInspector] public float WindUp = 0;
    public GameObject HugeRocket;
    public AudioSource ChargeUp;
    public GameObject Click;
    private GunControl gc;
    private RocketLauncher rock;
    private float HeldTime;
    private WeaponPos wpos;

    public void Start()
    {
        gc = GunControl.Instance;
        rock = GetComponent<RocketLauncher>();
        wpos = GetComponent<WeaponPos>();
    }

    public void Update()
    {
        if (ULTRAKILL.Cheats.NoWeaponCooldown.NoCooldown)
        {
            WindUp = 1;
        }

        WindUp = Mathf.Clamp(WindUp, 0, 1);

        rock.timerMeter.fillAmount = WindUp - HeldTime;
        rock.timerArm.localRotation = Quaternion.Euler(0f, 0f, 360 * (WindUp - HeldTime));

        if (gc.activated)
        {
            transform.localPosition = new Vector3(
                wpos.currentDefault.x + HeldTime * UnityEngine.Random.Range(-0.01f, 0.01f),
                wpos.currentDefault.y + HeldTime * UnityEngine.Random.Range(-0.01f, 0.01f),
                wpos.currentDefault.z + HeldTime * UnityEngine.Random.Range(-0.01f, 0.01f));

            if (Inputs.AltFireReleased && HeldTime > 0.125f)
            {
                StartCoroutine(Shoot(HeldTime, rock.wid.delay));
                CameraController.Instance.CameraShake(2f);
                WindUp -= HeldTime;
            }

            if (Inputs.AltFireHeld && WindUp > 0.125f)
            {
                float oldValue = HeldTime;
                HeldTime = Mathf.MoveTowards(HeldTime, WindUp, Time.deltaTime);
                ChargeUp.pitch = 1 + HeldTime;

                if (!ChargeUp.isPlaying)
                {
                    ChargeUp.Play();
                }

                if (oldValue < 1 && HeldTime == 1)
                {
                    Instantiate(Click, NewMovement.Instance.transform.position, Quaternion.identity);
                }
            }
            else
            {
                HeldTime = Mathf.MoveTowards(HeldTime, 0, Time.deltaTime * 2);

                if (ChargeUp.isPlaying)
                {
                    ChargeUp.Stop();
                }
            }
        }
    }

    public void OnEnable()
    {
        WindUp = WaffleWeaponCharges.Instance.EepyCharge;
    }

    public void OnDisable()
    {
        WaffleWeaponCharges.Instance.EepyCharge = WindUp;
    }

    public IEnumerator Shoot(float heldTime, float time)
    {
        yield return new WaitForSeconds(time);

        Grenade hugeGrenade = HugeRocket.GetComponent<Grenade>();
        float startSpeed = hugeGrenade.rocketSpeed;
        GameObject old = rock.rocket;

        rock.rocket = HugeRocket;
        //hugeGrenade.rocketSpeed = 25f + heldTime * (hugeGrenade.rocketSpeed);
        PreviousHeldTime = heldTime;
        rock.Shoot();

        hugeGrenade.rocketSpeed = startSpeed;
        rock.rocket = old;
    }
}