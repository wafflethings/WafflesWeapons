using Atlas.Modules.Guns;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace WafflesWeapons.Weapons
{
    public class Mindrender : Gun
    {
        public static GameObject RendNail;
        public static GameObject RendSaw;

        public static void LoadAssets()
        {
            RendNail = Core.Assets.LoadAsset<GameObject>("Nailgun Mindrender.prefab");
            RendSaw = Core.Assets.LoadAsset<GameObject>("Sawblade Launcher Mindrender.prefab");
            Core.Harmony.PatchAll(typeof(Mindrender));
        }

        public override GameObject Create(Transform parent)
        {
            base.Create(parent);
            MindrenderBehaviour.Charge = 0;

            GameObject thing;
            if (Enabled() == 2)
            {
                thing = GameObject.Instantiate(RendSaw, parent);
            }
            else
            {
                thing = GameObject.Instantiate(RendNail, parent);
            }

            StyleHUD.Instance.weaponFreshness.Add(thing, 10);
            return thing;
        }

        public override int Slot()
        {
            return 2;
        }

        public override string Pref()
        {
            return "nai4";
        }

        [HarmonyPatch(typeof(WeaponCharges), nameof(WeaponCharges.MaxCharges))]
        [HarmonyPostfix]
        public static void MaxCharge()
        {
            MindrenderBehaviour.Charge = 1;
        }

        [HarmonyPatch(typeof(StyleCalculator), nameof(StyleCalculator.HitCalculator))]
        [HarmonyPrefix]
        public static bool ReduceBeamCripplingStyle(StyleCalculator __instance, string hitter, bool dead, EnemyIdentifier eid = null, GameObject sourceWeapon = null)
        {
            if (hitter == "mindrend beam :3")
            {
                StyleHUD.Instance.SetFreshness(sourceWeapon, StyleHUD.Instance.GetFreshness(sourceWeapon) - 0.125f);

                // have to do this bc addpoints is an int (cringe)
                float old = StyleHUD.Instance.GetFreshness(sourceWeapon);
                __instance.AddPoints(2, "", eid, sourceWeapon);

                // adding points decay style, so we add it back
                StyleHUD.Instance.SetFreshness(sourceWeapon, old);

                if (dead)
                {
                    __instance.AddToMultiKill(sourceWeapon);
                }

                return false;
            }

            return true;
        }

        [HarmonyPatch(typeof(Nail), nameof(Nail.HitEnemy))]
        [HarmonyPostfix]
        public static void AddStuff(Nail __instance, EnemyIdentifierIdentifier eidid = null)
        {
            if (eidid != null && eidid.eid != null && !eidid.eid.dead)
            {
                float amount = 0;

                if (__instance.gameObject.name.Contains("Nail"))
                {
                    amount = 0.0125f;
                }
                else if (__instance.gameObject.name.Contains("Saw"))
                {
                    amount = 0.025f;

                }
                if (!__instance.gameObject.name.Contains("Flay"))
                {
                    amount /= 3;
                }

                MindrenderBehaviour.Charge += amount;

                if (MindrenderBehaviour.Charge > 1)
                {
                    MindrenderBehaviour.Charge = 1;
                }
            }
        }
    }

    public class MindrenderBehaviour : MonoBehaviour
    {
        public Slider ChargeSlider;
        [Header("Normal")]
        public GameObject VisualBeam;
        [Header("Alt")]
        public GameObject Ball;

        private const float DrainRate = 0.25f;

        private bool Shooting = false;
        private Nailgun nai;
        private GameObject curVis;
        private LineRenderer lr;
        [HideInInspector] public static float Charge;

        private LayerMask enemyLayerMask;

        private const float BEAM_DAMAGE = 0.25f;
        private const float BEAM_MILLISECOND_DELAY = 50;
        private const float ALT_BALL_COST = 0.2f;
        private const float ALT_BALL_RATE = 0.175f;
        private const float ALT_BALL_COUNT = 5;

        private Dictionary<EnemyIdentifier, DateTime> timeSinceHit = new Dictionary<EnemyIdentifier, DateTime>();

        public void Start()
        {
            enemyLayerMask |= 1024;
            enemyLayerMask |= 2048;
            nai = GetComponent<Nailgun>();
        }

        public void Update()
        {
            nai.heatSlider = null;
            ChargeSlider.value = Charge;

            if (nai.altVersion)
            {
                nai.fireRate = 30f;
            }
            else
            {
                nai.fireRate = 20f;
            }

            if (nai.gc.activated)
            {
                if (Charge <= 0)
                {
                    Charge = 0;
                    Stop();
                }

                if (!nai.altVersion)
                {
                    if (Shooting)
                    {
                        if (nai.wid.delay == 0)
                        {
                            Charge -= DrainRate * Time.deltaTime;
                        }

                        transform.localPosition = new Vector3(nai.wpos.currentDefault.x + 0.3f * UnityEngine.Random.Range(-0.1f, 0.1f),
                            nai.wpos.currentDefault.y + 0.3f * UnityEngine.Random.Range(-0.1f, 0.1f),
                            nai.wpos.currentDefault.z + 0.3f * UnityEngine.Random.Range(-0.1f, 0.1f));

                        RaycastHit hit;
                        curVis.transform.LookAt(CameraController.Instance.transform.forward * 99999);
                        if (Physics.Raycast(CameraController.Instance.transform.position, CameraController.Instance.transform.forward, out hit, float.PositiveInfinity, enemyLayerMask))
                        {
                            curVis.transform.LookAt(hit.point);

                            if (hit.transform.gameObject.tag == "Enemy" || hit.transform.gameObject.tag == "Body" || hit.transform.gameObject.tag == "Limb" ||
                                hit.transform.gameObject.tag == "EndLimb" || hit.transform.gameObject.tag == "Head")
                            {
                                EnemyIdentifier eid = hit.transform.GetComponentInParent<EnemyIdentifierIdentifier>().eid;

                                if (!timeSinceHit.ContainsKey(eid))
                                {
                                    timeSinceHit.Add(eid, DateTime.Now);
                                }
                                else
                                {
                                    if ((DateTime.Now - timeSinceHit[eid]).TotalMilliseconds > BEAM_MILLISECOND_DELAY)
                                    {
                                        eid.hitter = "mindrend beam :3";
                                        eid.DeliverDamage(hit.transform.gameObject, CameraController.Instance.transform.forward, hit.point, BEAM_DAMAGE, false, 0, gameObject);
                                        timeSinceHit[eid] = DateTime.Now;
                                    }
                                }

                            }
                            else if (hit.transform.gameObject.tag == "Coin")
                            {
                                if (hit.transform.gameObject.GetComponent<Coin>() != null && hit.transform.gameObject.GetComponent<Rigidbody>() != null)
                                {
                                    hit.transform.gameObject.GetComponent<Coin>().checkingSpeed = false;
                                    Vector3 newVelo = hit.transform.gameObject.GetComponent<Rigidbody>().velocity;
                                    newVelo.y = 0;
                                    newVelo.x /= 2;
                                    newVelo.z /= 2;
                                    hit.transform.gameObject.GetComponent<Rigidbody>().velocity = newVelo; //NewMovement.Instance.rb.velocity;

                                    lr.SetPosition(1, hit.transform.position);
                                }

                                GameObject potentialEnemy = UltrakillUtils.NearestEnemy(hit.transform.position, 10000);

                                if (potentialEnemy != null && potentialEnemy.GetComponent<EnemyIdentifier>() != null)
                                {
                                    EnemyIdentifier eid = potentialEnemy.GetComponent<EnemyIdentifier>();

                                    if (!timeSinceHit.ContainsKey(eid))
                                    {
                                        timeSinceHit.Add(eid, DateTime.Now);
                                    }
                                    else
                                    {
                                        if ((DateTime.Now - timeSinceHit[eid]).TotalMilliseconds > BEAM_MILLISECOND_DELAY)
                                        {
                                            lr.positionCount = 3;
                                            lr.SetPosition(2, potentialEnemy.transform.position);

                                            eid.hitter = "mindrend beam :3";
                                            eid.DeliverDamage(hit.transform.gameObject, CameraController.Instance.transform.forward, hit.point, BEAM_DAMAGE, false, 0, gameObject);
                                            timeSinceHit[eid] = DateTime.Now;

                                            eid.DeliverDamage(potentialEnemy, CameraController.Instance.transform.forward, hit.point, BEAM_DAMAGE, false, 0, gameObject);
                                        }
                                    }

                                }
                                else
                                {
                                    lr.positionCount = 2;
                                }
                            }
                        }
                        else
                        {
                            lr.positionCount = 2;
                        }

                        
                        NewMovement.Instance.rb.AddForce(CameraController.Instance.transform.forward * -25 * Time.deltaTime, ForceMode.VelocityChange);
                        CameraController.Instance.CameraShake(0.2f);
                    }
                    else
                    {
                        if (Charge > 0.05f && Gun.OnAltFire())
                        {
                            curVis = Instantiate(VisualBeam, nai.shootPoints[0].transform);
                            lr = curVis.GetComponent<LineRenderer>();
                            curVis.transform.localPosition = new Vector3(0, -0.35f, -3.5f);

                            Shooting = true;
                        }

                        nai.canShoot = false;
                        if (Gun.OnFireHeld() && nai.fireCooldown == 0)
                        {
                            nai.fireCooldown = nai.fireRate;
                            for (int i = 0; i < 5; i++)
                            {
                                nai.Invoke("Shoot", nai.wid.delay);
                            }
                        }
                    }
                }
                else
                {
                    if (Shooting)
                    {
                        Charge -= Time.deltaTime * ALT_BALL_COST / ALT_BALL_RATE;
                    }
                    else
                    {
                        if (Charge > ALT_BALL_COST && Gun.OnAltFire())
                        {
                            Shooting = true;

                            float Time = 0;

                            for (int i = 0; i < Charge * ALT_BALL_COUNT; i++)
                            {
                                Invoke("ShootAltBall", Time + nai.wid.delay);
                                Time += ALT_BALL_RATE;
                            }

                            Invoke("ResetShooting", (ALT_BALL_COUNT * ALT_BALL_RATE) + nai.wid.delay);
                        }
                    }
                }
            }
        }

        public void ResetShooting()
        {
            Shooting = false;
        }

        public void ShootAltBall()
        {
            Instantiate(Ball, CameraController.Instance.transform.position + CameraController.Instance.transform.forward, CameraController.Instance.transform.rotation);
            nai.anim.SetTrigger("SuperShoot");
            NewMovement.Instance.rb.AddForce(CameraController.Instance.transform.forward * -500 * Time.deltaTime, ForceMode.VelocityChange);
            CameraController.Instance.CameraShake(0.25f);
        }

        public void OnDisable()
        {
            Stop();
        }

        public void Stop()
        {
            if (Shooting)
            {
                Shooting = false;
                Destroy(curVis);
                Charge = 0;
            }
        }
    }
}
