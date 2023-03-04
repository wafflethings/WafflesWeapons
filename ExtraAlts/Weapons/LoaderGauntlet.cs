using Atlas.Modules.Guns;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ExtraAlts.Weapons
{
    public class LoaderGauntlet : Fist
    {
        public static GameObject Arm;
        public static GameObject Click;
        public static GameObject ChargeSound;
        public static GameObject Release;
        public static GameObject ChargeParticle;

        public static void LoadAssets()
        {
            Arm = Core.Assets.LoadAsset<GameObject>("ESARM.prefab");
            Arm.GetComponentInChildren<SkinnedMeshRenderer>().material.shader = Shader.Find("psx/vertexlit/vertexlit");
            Click = Core.Assets.LoadAsset<GameObject>("LoaderReady.prefab");
            ChargeSound = Core.Assets.LoadAsset<GameObject>("LoaderCharge.prefab");
            ChargeParticle = Core.Assets.LoadAsset<GameObject>("ArmCharge.prefab");
            Release = Core.Assets.LoadAsset<GameObject>("LoaderRelease.prefab");
            LoaderArmCollisionHandler.NotifyGrounded = Core.Assets.LoadAsset<GameObject>("LoaderBell.prefab");
            Core.Harmony.PatchAll(typeof(LoaderGauntlet));
        }

        public override GameObject Create(Transform parent)
        {
            base.Create(parent);

            GameObject thing = GameObject.Instantiate(Arm, parent);
            //GameObject thing = GameObject.Instantiate(ArmObj);
            thing.AddComponent<LoaderBehaviour>();

            return thing;
        }

        public override int Slot()
        {
            return 0;
        }

        public override string Pref()
        {
            return "newfis0";
        }

        public override int ArmNum()
        {
            return 2;
        }

        [HarmonyPatch(typeof(NewMovement), nameof(NewMovement.Start))]
        [HarmonyPostfix]
        public static void AddLoaderCheck(NewMovement __instance)
        {
            __instance.gameObject.AddComponent<LoaderArmCollisionHandler>();
        }

        [HarmonyPatch(typeof(FistControl), nameof(FistControl.UpdateFistIcon))]
        [HarmonyPostfix]
        public static void FixColour(FistControl __instance)
        {
            if (GameObject.FindObjectOfType<LoaderBehaviour>() != null)
            {
                if (__instance.currentArmObject == GameObject.FindObjectOfType<LoaderBehaviour>().gameObject)
                {
                    __instance.fistIcon.color = ColorBlindSettings.Instance.variationColors[4];
                }
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
            LoaderArmCollisionHandler.Instance.MidCharge = false;
        }


        [HarmonyPatch(typeof(NewMovement), nameof(NewMovement.Slamdown))]
        [HarmonyPostfix]
        public static void StopOnSlam()
        {
            LoaderArmCollisionHandler.Instance.MidCharge = false;
        }

        [HarmonyPatch(typeof(NewMovement), nameof(NewMovement.WallJump))]
        [HarmonyPostfix]
        public static void StopOnWallJump()
        {
            LoaderArmCollisionHandler.Instance.MidCharge = false;
        }

        [HarmonyPatch(typeof(HookArm), nameof(HookArm.Update))]
        [HarmonyPostfix]
        public static void StopOnHook(HookArm __instance)
        {
            if (__instance.state == HookState.Caught)
            {
                LoaderArmCollisionHandler.Instance.MidCharge = false;
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
                if (other.gameObject.layer == 8 || other.gameObject.layer == 24)
                {
                    if (other.CompareTag("Floor") || other.CompareTag("Moving"))
                    {
                        if(CanCharge)
                        {
                            MidCharge = false;
                        }
                        if (!CanCharge)
                        {
                            var nm = NewMovement.Instance;
                            if (nm.rb.velocity.y < -60)
                            {
                                Instantiate(nm.gc.shockwave, nm.gc.transform.position, Quaternion.identity).GetComponent<PhysicalShockwave>().force *= Charge * 1.5f;
                            }
                            ResetDash(true);
                        }
                    }
                }

                if (MidCharge)
                {
                    Breakable br;
                    if (other.TryGetComponent(out br))
                    {
                        br.Break();
                    }

                    if (other.GetComponent<Coin>() != null)
                    {
                        var coin = other.GetComponent<Coin>();
                        if (!BadCoins.Contains(coin))
                        {
                            ResetDash(false);
                            coin.Punchflection();
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
                            eid.hitter = "heavypunch";
                            eid.DeliverDamage(eid.gameObject, NewMovement.Instance.rb.velocity, other.gameObject.transform.position, Charge * 1.1f, false, 0, gameObject);
                            if (eid.dead)
                            {
                                eid.gameObject.AddComponent<Bleeder>().GetHit(eid.gameObject.transform.position, GoreType.Head);
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
            public Vector3 StartPos;
            public NewMovement nm;
            public CameraController cc;
            public static Punch pu;
            public AudioSource CeSrc;
            public static float Charge;
            public static Dictionary<int, int> ChargeToDmg = new Dictionary<int, int>
            {
                { 2, 0 },
                { 3, 5 },
                { 4, 10 },
                { 5, 15 },
                { 6, 20 }
            };

            public void Start()
            {
                StartPos = transform.localPosition;
                CeSrc = Instantiate(ChargeSound, gameObject.transform).GetComponent<AudioSource>();

                Charge = 0;

                nm = NewMovement.Instance;
                cc = CameraController.Instance;
                pu = GetComponent<Punch>();

                pu.anim = GetComponentsInChildren<Animator>()[1];
            }

            public void Update()
            {
                pu.ready = false;
                // should be 100 at finish
                float CoolCharge = 0;
                CoolCharge = Charge * 100 / 6;
                CeSrc.volume = 0.25f + CoolCharge * 0.005f;
                CeSrc.pitch = CoolCharge * 0.005f;

                //Debug.Log(Charge);
                if (OnPunchHeld() && LoaderArmCollisionHandler.Instance.CanCharge)
                {
                    if(!pu.anim.GetCurrentAnimatorStateInfo(0).IsName("Charge"))
                    {
                        pu.anim.Play("Charge", 0);
                    }

                    if(!CeSrc.isPlaying)
                    {
                        CeSrc.Play();
                    }

                    transform.localPosition = new Vector3(
                        StartPos.x + Charge / 10 * UnityEngine.Random.Range(-0.01f, 0.01f),
                        StartPos.y + Charge / 10 * UnityEngine.Random.Range(-0.01f, 0.01f),
                        StartPos.z + Charge / 10 * UnityEngine.Random.Range(-0.01f, 0.01f));
                    // cc.CameraShake(Charge / 10);

                    float ChargePreAdd = Charge;

                    if (Charge < 4)
                    {
                        if (Charge < 2 && Charge + (Time.deltaTime * 3) >= 2)
                        {
                            cc.CameraShake(1.5f);
                            Instantiate(Click, nm.transform.position, Quaternion.identity);
                        }

                        if (Charge < 2)
                        {
                            Charge += Time.deltaTime * 1.5f;
                        }

                        Charge += Time.deltaTime * 2.5f;
                    } else
                    {
                        Charge += Time.deltaTime * 1.5f;
                    }
                    

                    if(Charge > 6)
                    {
                        Charge = 6;
                    }

                    Debug.Log($"{ChargePreAdd} => {Charge} | {(int)ChargePreAdd} => {(int)Charge}");

                    if((int)ChargePreAdd < (int)Charge && (int)Charge > 2)
                    {
                        Instantiate(Click, nm.transform.position, Quaternion.identity);
                    }
                } else
                {
                    if (CeSrc.isPlaying)
                    {
                        CeSrc.Stop();
                    }
                }

                // cancel if released early
                if (OnPunchReleased() && Charge <= 2f && LoaderArmCollisionHandler.Instance.CanCharge)
                {
                    Charge = 0;
                    pu.anim.CrossFade("Idle", 0.25f);
                }

                if (LoaderArmCollisionHandler.Instance.CanCharge && Charge >= 2f && OnPunchReleased())
                {
                    pu.anim.CrossFade("Idle", 0.25f);
                    LoaderArmCollisionHandler.Instance.Charge = Charge;

                    if (nm.ridingRocket != null)
                    {
                        nm.ridingRocket.rocketSpeed *= Charge / 2;
                        nm.ridingRocket.transform.rotation = cc.transform.rotation;
                    }

                    if (FindObjectOfType<GroundCheck>().touchingGround)
                    {
                        nm.Jump();
                    }

                    Instantiate(Release);

                    cc.CameraShake(Charge);

                    float CalcCharge = Charge;
                    float Mult = 1.25f;
                    float AddTo = 1 - (1 / Mult);
                    CalcCharge /= AddTo + ((LoaderArmCollisionHandler.Instance.Dashes + 1) / Mult);

                    Debug.Log($"{Charge} / {AddTo + ((LoaderArmCollisionHandler.Instance.Dashes + 1) / Mult)} = {CalcCharge} => {cc.transform.forward * nm.walkSpeed * CalcCharge * Time.deltaTime}");

                    LoaderArmCollisionHandler.Instance.MidCharge = true;
                    LoaderArmCollisionHandler.Instance.CanCharge = false;
                    LoaderArmCollisionHandler.Instance.BadCoins.Clear();

                    nm.rb.velocity = (cc.transform.forward * nm.walkSpeed * CalcCharge) / 60;
                    nm.GetHurt(ChargeToDmg[(int)Charge], false, 0);
                    nm.ForceAddAntiHP(ChargeToDmg[(int)Charge] * 1.5f, true, true);
                    Charge = 0;
                }
            }
        }
    }
}
