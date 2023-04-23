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
        public static Sprite Icon;
        public static Sprite IconGlow;
        public static Sprite IconAlt;
        public static Sprite IconGlowAlt;
        public static GameObject Beam;
        public static GameObject Vis;
        public static GameObject NailObj;
        public static GameObject SawObj;
        public static GameObject Ball;

        public static void LoadAssets()
        {
            Icon = Core.Assets.LoadAsset<Sprite>("MIF ico.png");
            IconGlow = Core.Assets.LoadAsset<Sprite>("MIF glow.png");
            IconAlt = Core.Assets.LoadAsset<Sprite>("MIF saw.png");
            IconGlowAlt = Core.Assets.LoadAsset<Sprite>("MIF saw glow.png");
            Beam = Core.Assets.LoadAsset<GameObject>("MindflayerBeam.prefab");
            Vis = Core.Assets.LoadAsset<GameObject>("VisualMIF.prefab");
            NailObj = Core.Assets.LoadAsset<GameObject>("FlayNail.prefab");
            SawObj = Core.Assets.LoadAsset<GameObject>("FlaySaw.prefab");
            Ball = Core.Assets.LoadAsset<GameObject>("MindrenderProjectile.prefab");

            foreach (Transform t in SawObj.GetComponentsInChildren<Transform>())
            {
                t.gameObject.tag = "Metal";
            }

            NailObj.tag = "Metal";

            Core.Harmony.PatchAll(typeof(Mindrender));
        }

        public override GameObject Create(Transform parent)
        {
            base.Create(parent);

            GameObject thing;

            if (Enabled() == 2)
            {
                thing = GameObject.Instantiate(GunSetter.Instance.nailOverheat[1], parent);
            }
            else
            {
                thing = GameObject.Instantiate(GunSetter.Instance.nailOverheat[0], parent);
            }

            var nai = thing.GetComponent<Nailgun>();
            nai.variation = 4;

            if (!nai.altVersion)
            {
                nai.nail = NailObj;
            }
            else
            {
                nai.nail = SawObj;
            }

            var ico = thing.GetComponent<WeaponIcon>();
            ico.variationColor = 5;
            if (nai.altVersion)
            {
                ico.glowIcon = IconGlowAlt;
                ico.weaponIcon = IconAlt;
            }
            else
            {
                ico.glowIcon = IconGlow;
                ico.weaponIcon = Icon;
            }

            thing.AddComponent<MindrenderBehaviour>();

            thing.name = "Mindrender Nailgun";

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

        public class MindrenderBehaviour : MonoBehaviour
        {
            private const float DrainRate = 0.25f;

            private bool Shooting = false;
            private Nailgun nai;
            private GameObject curBeam;
            private GameObject curVis;
            private LineRenderer lr;
            public float Delay;
            public static float Charge;

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

                nai.heatSlider.gameObject.ChildByName("Fill Area").ChildByName("Fill").GetComponent<Image>().color = ColorBlindSettings.Instance.variationColors[5];
                nai.heatSlider.transform.parent.transform.localPosition += new Vector3(0, -4, 0);
                foreach (Image img in nai.heatSinkImages)
                {
                    img.gameObject.SetActive(false);
                }

                nai.spread *= 0.75f;

                Charge = 0;
                Delay = GetComponent<WeaponIdentifier>().delay;
            }

            public void Update()
            {
                nai.sliderBg.color = ColorBlindSettings.Instance.variationColors[5];
                nai.heatSlider.value = Charge;

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
                            if (Delay == 0)
                            {
                                Charge -= DrainRate * Time.deltaTime;
                            }

                            transform.localPosition = new Vector3(nai.wpos.currentDefault.x + 0.3f * UnityEngine.Random.Range(-0.1f, 0.1f),
                                nai.wpos.currentDefault.y + 0.3f * UnityEngine.Random.Range(-0.1f, 0.1f),
                                nai.wpos.currentDefault.z + 0.3f * UnityEngine.Random.Range(-0.1f, 0.1f));

                            curVis.transform.LookAt(curBeam.GetComponent<ContinuousBeam>().impactEffect.transform);

                            RaycastHit hit;

                            if (Physics.Raycast(CameraController.Instance.transform.position, CameraController.Instance.transform.forward, out hit, float.PositiveInfinity, enemyLayerMask))
                            {
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
                            if (Charge > 0.05f && OnAltFire())
                            {
                                curBeam = Instantiate(Beam, CameraController.Instance.transform);
                                curVis = Instantiate(Vis, nai.shootPoints[0].transform);
                                lr = curVis.GetComponent<LineRenderer>();
                                curVis.transform.localPosition = new Vector3(0, -0.35f, -3.5f);

                                Shooting = true;
                            }

                            nai.canShoot = false;
                            if (OnFireHeld() && nai.fireCooldown == 0)
                            {
                                nai.fireCooldown = nai.fireRate;
                                for (int i = 0; i < 5; i++)
                                {
                                    nai.Invoke("Shoot", Delay);
                                }
                            }
                        }
                    } else
                    {
                        if (Shooting)
                        {
                            Charge -= Time.deltaTime * ALT_BALL_COST / ALT_BALL_RATE;
                        }
                        else
                        {
                            if (Charge > ALT_BALL_COST && OnAltFire())
                            {
                                Shooting = true;

                                float Time = 0;

                                for (int i = 0; i < Charge * ALT_BALL_COUNT; i++)
                                {
                                    Invoke("ShootAltBall", Time + Delay);
                                    Time += ALT_BALL_RATE;
                                }

                                Invoke("ResetShooting", (ALT_BALL_COUNT * ALT_BALL_RATE) + Delay);
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
                    Destroy(curBeam);
                    Charge = 0;
                }
            }
        }
    }
}
