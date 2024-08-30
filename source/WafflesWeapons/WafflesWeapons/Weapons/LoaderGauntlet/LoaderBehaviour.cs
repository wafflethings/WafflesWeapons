using AtlasLib.Utils;
using UnityEngine;
using WafflesWeapons.Components;

namespace WafflesWeapons.Weapons.LoaderGauntlet;

public class LoaderBehaviour : MonoBehaviour
{
    public const float ChargeSpeedMult = 6f / 100 * 45; // 35% of 6, old one was 1.5f * 1.125f which is roughly 28%;
    public const float FastChargeSpeedMult = 6f / 100 * 60; // 50% of 6, old one was  2.5f * 1.125f which is roughly 46%;

    private Vector3 StartPos;
    private NewMovement nm;
    private CameraController cc;
    private static Punch pu;
    private AudioSource CeSrc;
    public static float Charge;


    public Animator anim;
    public GameObject Click;
    public GameObject ChargeSound;
    public GameObject Release;
    public GameObject GroundedBell;
    public GameObject DoinkSound;

    public void Start()
    {
        nm = NewMovement.Instance;
        cc = CameraController.Instance;
        pu = GetComponent<Punch>();
        LoaderArmCollisionHandler.NotifyGrounded = GroundedBell;

        StartPos = transform.localPosition;
        CeSrc = Instantiate(ChargeSound, gameObject.transform).GetComponent<AudioSource>();
        Charge = 0;
        LoaderGauntlet.curOne = this;
        anim.SetBool("Midflight", false);
    }

    public void OnDisable()
    {
        if (anim != null)
        {
            anim.Play("NewES Idle");
        }
    }

    public void Punch()
    {

        pu.damage = 1.5f;
        pu.screenShakeMultiplier = 2f;
        pu.force = 50f;
        pu.tryForExplode = true;
        pu.cooldownCost = 1.5f;

        pu.ActiveStart();
        pu.Invoke("ActiveEnd", 3f / 30f);
        Invoke("ReadyToPunch_WithoutHolding", 10f / 30f);
        pu.Invoke("PunchEnd", 28f / 30f);
    }

    private void ReadyToPunch_WithoutHolding()
    {
        pu.returnToOrigRot = true;
//this.holdingInput = false;
        pu.ready = true;
        pu.alreadyBoostedProjectile = false;
        pu.ignoreDoublePunch = false;
    }

    public void Update()
    {
        pu.anim = anim;

// should be 100 at finish
        float CoolCharge = Charge * 100 / 6;
        CeSrc.volume = 0.3f + CoolCharge * 0.005f;
        CeSrc.pitch = 0.1f + (CoolCharge * 0.0125f);

        if (pu.holdingInput && LoaderArmCollisionHandler.Instance.CanCharge)
        {
            if (!CeSrc.isPlaying)
            {
                CeSrc.Play();
            }

            transform.localPosition = new Vector3(
                StartPos.x + Charge / 10 * Random.Range(-0.01f, 0.01f),
                StartPos.y + Charge / 10 * Random.Range(-0.01f, 0.01f),
                StartPos.z + Charge / 10 * Random.Range(-0.01f, 0.01f));

            float ChargePreAdd = Charge;

            if (Charge < 4)
            {
                Debug.Log(FastChargeSpeedMult);

                if (Charge < 2 && Charge + (Time.deltaTime * FastChargeSpeedMult) >= 2)
                {
                    cc.CameraShake(1.5f);
                    Instantiate(Click, nm.transform.position, Quaternion.identity);
                }

                Charge += Time.deltaTime * FastChargeSpeedMult;
            }
            else
            {
                Charge += Time.deltaTime * ChargeSpeedMult;
            }


            if (Charge > 6)
            {
                Charge = 6;
            }

            if ((int)ChargePreAdd < (int)Charge && (int)Charge > 2)
            {
                Instantiate(Click, nm.transform.position, Quaternion.identity);
            }

            anim.SetBool("Charging", true);
        }
        else
        {
            if (CeSrc.isPlaying)
            {
                CeSrc.Stop();
            }

            anim.SetBool("Charging", false);
        }

// cancel if released early
        if (Inputs.PunchReleased && Charge <= 2f && LoaderArmCollisionHandler.Instance.CanCharge)
        {
            if (anim.GetCurrentAnimatorClipInfo(0)[0].clip.name != "Armature|ES_HookPunch")
            {
                // anim.Play("NewES Idle");
            }

            Charge = 0;
        }

        if (LoaderArmCollisionHandler.Instance.CanCharge && Charge >= 2f && Inputs.PunchReleased)
        {
            anim.Play("Armature|ES_ChargeHold");
            LoaderArmCollisionHandler.Instance.Charge = Charge;

            if (nm.ridingRocket != null)
            {
                nm.ridingRocket.rocketSpeed *= Charge / 2;
                nm.ridingRocket.transform.rotation = cc.transform.rotation;
            }

            if (nm.gc.touchingGround)
            {
                nm.Jump();
            }

            Instantiate(Release);
            cc.CameraShake(Charge);

            LoaderArmCollisionHandler.Instance.MidCharge = true;
            LoaderArmCollisionHandler.Instance.CanCharge = false;
            LoaderArmCollisionHandler.Instance.BadCoins.Clear();

            float xzMagnitude = new Vector3(nm.rb.velocity.x, 0, nm.rb.velocity.z).magnitude;
            nm.rb.velocity = ((xzMagnitude + 40) * Charge * 0.15f * cc.transform.forward);
            Charge = 0;
            anim.SetBool("Midflight", true);
        }
    }
}
