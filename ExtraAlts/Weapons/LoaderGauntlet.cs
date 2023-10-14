using Atlas.Modules.Guns;
using HarmonyLib;
using System.Collections.Generic;
using UnityEngine;

namespace WafflesWeapons.Weapons
{
    public class LoaderGauntlet : Fist
    {
        public static GameObject EsArm;
        public static LoaderBehaviour curOne;

        static LoaderGauntlet()
        {
            EsArm = Core.Assets.LoadAsset<GameObject>("Arm Earthshatter.prefab");
            Core.Harmony.PatchAll(typeof(LoaderGauntlet));
        }

        public override GameObject Create(Transform parent)
        {
            base.Create(parent);
            GameObject thing = GameObject.Instantiate(EsArm, parent);
            return thing;
        }

        public override int Slot()
        {
            return 2;
        }

        public override string Pref()
        {
            return "arm5";
        }

        [HarmonyPatch(typeof(NewMovement), nameof(NewMovement.Start))]
        [HarmonyPostfix]
        public static void AddLoaderCheck(NewMovement __instance)
        {
            __instance.gameObject.AddComponent<LoaderArmCollisionHandler>();
        }

        [HarmonyPatch(typeof(Punch), nameof(Punch.CoinFlip))]
        [HarmonyPrefix]
        public static bool CancelIfCharging(Punch __instance)
        {
            if (__instance.GetComponent<LoaderBehaviour>() != null && !__instance.holdingInput)
            {
                __instance.anim.SetTrigger("CoinFlip");
                return false;
            }

            return true;
        }

        [HarmonyPatch(typeof(Punch), nameof(Punch.PunchStart))]
        [HarmonyPrefix]
        public static bool LoaderPunch(Punch __instance)
        {
            LoaderBehaviour lb = __instance.GetComponent<LoaderBehaviour>();

            if (lb != null)
            {
                if (LoaderArmCollisionHandler.Instance.MidCharge)
                {
                    return false;
                }

                if (__instance.ready)
                {
                    // lb.anim.Play("Armature|ES_HookPunch", 0, 0);
                    lb.Punch();
                }
            }

            return true;
        }

        [HarmonyPatch(typeof(Punch), nameof(Punch.BlastCheck))]
        [HarmonyPrefix]
        public static bool CancelBlast(Punch __instance)
        {
            LoaderBehaviour lb = __instance.GetComponent<LoaderBehaviour>();

            if (lb != null)
            {
                return false;
            }

            return true;
        }

        [HarmonyPatch(typeof(FistControl), nameof(FistControl.UpdateFistIcon))]
        [HarmonyPostfix]
        public static void FixColour(FistControl __instance)
        {
            try
            {
                if (__instance.currentArmObject.GetComponent<LoaderBehaviour>() != null)
                {
                    __instance.fistIcon.color = ColorBlindSettings.Instance.variationColors[5];
                }
            }
            catch
            {
                Debug.LogError($"whar? {ColorBlindSettings.Instance.variationColors.Length}");
            }
        }

        [HarmonyPatch(typeof(Coin), nameof(Coin.Start))]
        [HarmonyPostfix]
        public static void CheckIfMadeWhenLaunching(Coin __instance)
        {
            if(LoaderArmCollisionHandler.Instance.MidCharge)
            {
                LoaderArmCollisionHandler.Instance.BadCoins.Add(__instance);
            }
        }

        [HarmonyPatch(typeof(NewMovement), nameof(NewMovement.Dodge))]
        [HarmonyPostfix]
        public static void StopOnDodge()
        {
            if (curOne != null && LoaderArmCollisionHandler.Instance != null)
            {
                LoaderArmCollisionHandler.Instance.MidCharge = false;
                curOne.anim.SetBool("Midflight", false);
            }
        }


        [HarmonyPatch(typeof(NewMovement), nameof(NewMovement.Slamdown))]
        [HarmonyPostfix]
        public static void StopOnSlam()
        {
            if (curOne != null && LoaderArmCollisionHandler.Instance != null)
            {
                LoaderArmCollisionHandler.Instance.MidCharge = false;
                curOne.anim.SetBool("Midflight", false);
            }
        }

        [HarmonyPatch(typeof(NewMovement), nameof(NewMovement.WallJump))]
        [HarmonyPostfix]
        public static void StopOnWallJump()
        {
            if (curOne != null && LoaderArmCollisionHandler.Instance != null)
            {
                LoaderArmCollisionHandler.Instance.MidCharge = false;
                curOne.anim.SetBool("Midflight", false);
            }
        }

        [HarmonyPatch(typeof(HookArm), nameof(HookArm.Update))]
        [HarmonyPostfix]
        public static void StopOnHook(HookArm __instance)
        {
            if (curOne != null && LoaderArmCollisionHandler.Instance != null && __instance.state == HookState.Caught)
            {
                LoaderArmCollisionHandler.Instance.MidCharge = false;
                curOne.anim.SetBool("Midflight", false);
            }

        }
    }

    public class LoaderArmCollisionHandler : MonoSingleton<LoaderArmCollisionHandler>
    {
        public static GameObject NotifyGrounded;

        public bool CanCharge = true;
        public bool MidCharge = false;
        public GroundCheck gc;
        public float Charge;
        public List<GameObject> AlrHit = new List<GameObject>();
        public List<Coin> BadCoins = new List<Coin>();
        public int Dashes = 0;

        private void Start()
        {
            gc = FindObjectOfType<GroundCheck>();
        }

        //FromGround = the reset came from touching ground (not from coin)
        public void ResetDash(bool FromGround)
        {
            LoaderGauntlet.curOne.anim.SetBool("Midflight", false);

            if (FromGround)
            {
                Dashes = 0;
                MidCharge = false;
            }
            else
            {
                Dashes += 1;
            }

            Instantiate(NotifyGrounded);
            CanCharge = true;
            AlrHit.Clear();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (MidCharge)
            {
                Breakable br;
                if (other.TryGetComponent(out br))
                {
                    br.Break();
                    return;
                }

                Glass gl;
                if (other.TryGetComponent(out gl))
                {
                    gl.Shatter();
                    return;
                }
            }


            if (other.gameObject.layer == 8 || other.gameObject.layer == 24)
            {
                if (other.CompareTag("Floor") || other.CompareTag("Moving"))
                {
                    if (CanCharge)
                    {
                        MidCharge = false;
                    }
                    if (!CanCharge)
                    {
                        var nm = NewMovement.Instance;
                        if (nm.rb.velocity.y < -40)
                        {
                            GameObject wave = Instantiate(nm.gc.shockwave, nm.gc.transform.position, Quaternion.identity);
                            wave.GetComponent<PhysicalShockwave>().force *= Charge * 0.75f;
                            wave.GetComponent<PhysicalShockwave>().maxSize *= (Charge / 2);
                            wave.transform.localScale = new Vector3(wave.transform.localScale.x, wave.transform.localScale.y, wave.transform.localScale.z);
                        }
                        ResetDash(true);
                    }
                }
            }

            if (MidCharge)
            {
                if (other.GetComponent<Coin>() != null)
                {
                    var coin = other.GetComponent<Coin>();
                    if (!BadCoins.Contains(coin))
                    {
                        ResetDash(false);
                        coin.Punchflection();
                        TimeController.Instance.ParryFlash();
                    }
                }

                if (other.GetComponent<EnemyIdentifierIdentifier>() != null || other.GetComponent<EnemyIdentifier>() != null)
                {
                    EnemyIdentifier eid;
                    if (!other.GetComponent<EnemyIdentifier>())
                    {
                        eid = other.GetComponent<EnemyIdentifierIdentifier>().eid;
                    }
                    else
                    {
                        eid = other.GetComponent<EnemyIdentifier>();
                    }

                    if (!eid.dead && !AlrHit.Contains(eid.gameObject))
                    {
                        Debug.Log($"{NewMovement.Instance.rb.velocity.magnitude} from charge {Charge}: damage {NewMovement.Instance.rb.velocity.magnitude * 0.075f}");
                        eid.hitter = "heavypunch";
                        eid.DeliverDamage(eid.gameObject, NewMovement.Instance.rb.velocity, other.gameObject.transform.position, NewMovement.Instance.rb.velocity.magnitude * 0.075f, false, 0, gameObject);
                        if (eid.dead)
                        {
                            eid.gameObject.AddComponent<Bleeder>().GetHit(eid.gameObject.transform.position, GoreType.Head);
                            ResetDash(false);
                        }
                        else 
                        {
                            NewMovement.Instance.ForceAddAntiHP((int)(NewMovement.Instance.rb.velocity.magnitude * 0.5f), false, true);
                        }
                        CameraController.Instance.CameraShake(0.5f);
                        TimeController.Instance.HitStop(0.05f);
                        AlrHit.Add(eid.gameObject);
                    }
                }
            }
        }
    }

    public class LoaderBehaviour : MonoBehaviour
    {
        public const float ChargeSpeedMult = 6f / 100 * 45; // 35% of 6, old one was 1.5f * 1.125f which is roughly 28%;
        public const float FastChargeSpeedMult = 6f / 100 * 60; // 50% of 6, old one was  2.5f * 1.125f which is roughly 46%;

        private Vector3 StartPos;
        private NewMovement nm;
        private CameraController cc;
        private static Punch pu;
        private AudioSource CeSrc;
        [HideInInspector] public static float Charge;

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
            if (Fist.OnPunchReleased() && Charge <= 2f && LoaderArmCollisionHandler.Instance.CanCharge)
            {
                if (anim.GetCurrentAnimatorClipInfo(0)[0].clip.name != "Armature|ES_HookPunch")
                {
                    // anim.Play("NewES Idle");
                }
                Charge = 0;
            }

            if (LoaderArmCollisionHandler.Instance.CanCharge && Charge >= 2f && Fist.OnPunchReleased())
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

                nm.rb.AddForce((cc.transform.forward * nm.walkSpeed * Charge) / 125, ForceMode.VelocityChange);
                Charge = 0;
                anim.SetBool("Midflight", true);
            }
        }
    }
}
