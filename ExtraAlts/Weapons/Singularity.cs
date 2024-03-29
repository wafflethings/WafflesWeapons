﻿using Atlas.Modules.Guns;
using HarmonyLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using WafflesWeapons.Components;

namespace WafflesWeapons.Weapons
{
    public class Singularity : Gun
    {
        public static GameObject SingularityShotgun;

        static Singularity()
        {
            SingularityShotgun = Core.Assets.LoadAsset<GameObject>("Shotgun Singularity.prefab");
            Core.Harmony.PatchAll(typeof(Singularity));
        }

        public override GameObject Create(Transform parent)
        {
            base.Create(parent);

            GameObject thing = GameObject.Instantiate(SingularityShotgun, parent);
            OrderInSlot = GunSetter.Instance.CheckWeaponOrder("sho")[5];
            StyleHUD.Instance.weaponFreshness.Add(thing, 10);

            return thing;
        }

        public override int Slot()
        {
            return 1;
        }

        public override string Pref()
        {
            return "sho5";
        }

        [HarmonyPatch(typeof(RevolverBeam), nameof(RevolverBeam.Shoot)), HarmonyPostfix]
        public static void ShootBall(RevolverBeam __instance)
        {
            if (Physics.Raycast(__instance.transform.position, __instance.transform.forward, out RaycastHit hit, float.PositiveInfinity, LayerMask.GetMask("Projectile")))
            {
                if (hit.transform.TryGetComponent(out SingularityBallBehaviour sbb))
                {
                    sbb.GetHit(__instance);
                }
            }
        }

        [HarmonyPatch(typeof(Coin), nameof(Coin.ReflectRevolver)), HarmonyPrefix]
        public static bool ReflectToBall(Coin __instance)
        {
            SingularityBallBehaviour[] balls = GameObject.FindObjectsOfType<SingularityBallBehaviour>();

            if (balls.Length > 0)
            {
                float closestCoin = float.MaxValue;
                Vector3 nmPos = NewMovement.Instance.transform.position;

                foreach (Coin coin in CoinList.Instance.revolverCoinsList)
                {
                    if (coin != __instance && (!coin.shot || coin.shotByEnemy))
                    {
                        if (closestCoin > Vector3.Distance(nmPos, coin.transform.position) 
                            && !Physics.Raycast(nmPos, coin.transform.position - nmPos, out RaycastHit raycastHit, Vector3.Distance(nmPos, coin.transform.position) - 0.5f, __instance.lmask))
                        {
                            closestCoin = (coin.transform.position - nmPos).sqrMagnitude;
                        }
                    }
                }

                int closestIndex = -1;
                for (int i = 0; i < balls.Length; i++)
                {
                    Vector3 directionToTarget = balls[i].transform.position - __instance.transform.position;
                    if (Physics.Raycast(__instance.transform.position, directionToTarget, out RaycastHit rayHit, directionToTarget.magnitude, LayerMask.GetMask("Projectile", "Limb", "BigCorpse", "Outdoors", "Environment", "Default")))
                    {
                        if (rayHit.collider.GetComponent<SingularityBallBehaviour>() == null && rayHit.collider.GetComponentInParent<SingularityBallBehaviour>() == null)
                        {
                            balls[i] = null;
                        }
                        else if (directionToTarget.sqrMagnitude < closestCoin)
                        {
                            closestIndex = i;
                        }
                    }
                }

                if (closestIndex != -1)
                {
                    LineRenderer beam = GameObject.Instantiate<GameObject>(__instance.refBeam, __instance.transform.position, Quaternion.identity).GetComponent<LineRenderer>();
                    beam.gameObject.GetComponent<RevolverBeam>().sourceWeapon = __instance.sourceWeapon;


                    if (__instance.hitPoint == Vector3.zero)
                    {
                        beam.SetPosition(0, __instance.transform.position);
                    }
                    else
                    {
                        beam.SetPosition(0, __instance.hitPoint);
                    }
                    beam.SetPosition(1, balls[closestIndex].transform.position);
                    balls[closestIndex].GetHit(beam.GetComponent<RevolverBeam>());

                    __instance.GetComponent<SphereCollider>().enabled = false;
                    __instance.hitTimes--;
                    __instance.gameObject.SetActive(false);
                    new GameObject().AddComponent<CoinCollector>().coin = __instance.gameObject;
                    __instance.CancelInvoke("GetDeleted");
                    return false;
                }
            }

            return true;
        }

        [HarmonyPatch(typeof(Bloodsplatter), nameof(Bloodsplatter.OnTriggerEnter)), HarmonyPostfix]
        public static void ChargeGauge(Bloodsplatter __instance, Collider other)
        {
            if (__instance.ready && other.gameObject.CompareTag("Player"))
            {
                float charge = 0;
                if (__instance.hpAmount < 50)
                {
                    charge += __instance.hpAmount;
                }
                else
                {
                    charge += 50 + (__instance.hpAmount / 5);
                }

                foreach (SingularityBehaviour sb in SingularityBehaviour.Instances)
                {
                    sb.charge += charge;
                }

                WaffleWeaponCharges.Instance.SingularityShoCharge += charge;
            }
        }

        public static SingularityBallBehaviour GrabbedBall;

        [HarmonyPatch(typeof(HookArm), nameof(HookArm.FixedUpdate)), HarmonyPostfix]
        public static void GrabBall(HookArm __instance)
        {
            if (__instance.state == HookState.Throwing)
            {
                if (!InputManager.Instance.InputSource.Hook.IsPressed && (__instance.cooldown <= 0.1f || __instance.caughtObjects.Count > 0))
                {
                    __instance.StopThrow(0f, false);
                }
                else
                {
                    RaycastHit[] array = Physics.SphereCastAll(__instance.hookPoint, Mathf.Min(Vector3.Distance(__instance.transform.position, __instance.hookPoint) / 15f, 5f), __instance.throwDirection, 250f * Time.fixedDeltaTime, __instance.throwMask, QueryTriggerInteraction.Collide);
                    Array.Sort(array, (RaycastHit x, RaycastHit y) => x.distance.CompareTo(y.distance));

                    foreach (RaycastHit hit in array)
                    {
                        if (hit.transform.gameObject.layer == 14 && hit.transform.gameObject.TryGetComponent(out SingularityBallBehaviour sbb))
                        {
                            GrabbedBall = sbb;
                            __instance.caughtTransform = sbb.transform;
                            __instance.caughtCollider = sbb.GetComponent<Collider>();
                            __instance.state = HookState.Caught;
                        }
                    }
                }
            }
        }

        [HarmonyPatch(typeof(HookArm), nameof(HookArm.Cancel)), HarmonyPostfix]
        public static void Cancel()
        {
            GrabbedBall = null;
        }
    }

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

    public class SingularityBallBehaviour : MonoBehaviour
    {
        [Header("Function")]
        public float speed;
        public float maxTime;
        public float drillInterval;
        private float elapsedTime;
        private List<EnemyIdentifier> eidsOnCooldown = new List<EnemyIdentifier>();
        private List<Rigidbody> caughtList = new List<Rigidbody>();
        private int drills = 0;
        private float drillCooldown;
        [Header("Visual")]
        public ParticleSystem suck;
        public GameObject lightning;
        public GameObject implodeEffect;
        public GameObject destroyEffect;

        private Rigidbody rb;
        private RevolverBeam lastBeam;

        public void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        public void Update()
        {
            rb.velocity = transform.forward * speed;

            if (Physics.Raycast(transform.position, rb.velocity.normalized, out RaycastHit raycastHit, transform.localScale.x, LayerMaskDefaults.Get(LMD.Environment)))
            {
                DetectCollision(raycastHit.normal);
            }

            if (transform.localScale == Vector3.zero)
            {
                Instantiate(destroyEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);
                return;
            }
            else
            {
                if (maxTime <= elapsedTime)
                {
                    float oldX = transform.localScale.x;
                    transform.localScale = Vector3.MoveTowards(transform.localScale, Vector3.zero, Time.deltaTime * 3);

                    if (oldX > 0.1f && transform.localScale.x <= 0.1f)
                    {
                        int i = 0;
                        foreach (EnemyIdentifierIdentifier eidid in GetComponentsInChildren<EnemyIdentifierIdentifier>().Where(eidid => eidid.eid != null))
                        {
                            if (i % 2 == 0) //prob a better way to do this but its 2am and im eepy :3
                            {
                                eidid.eid.hitter = "enemy";
                                eidid.eid.DeliverDamage(eidid.gameObject, Vector3.zero, eidid.gameObject.transform.position, 25f, false);
                            }
                            i++;
                        }

                        foreach (Breakable breakable in GetComponentsInChildren<Breakable>())
                        {
                            breakable.Break();
                        }

                        foreach (Projectile proj in GetComponentsInChildren<Projectile>())
                        {
                            proj.TimeToDie();
                        }

                        foreach (Grenade gren in GetComponentsInChildren<Grenade>())
                        {
                            gren.Explode();
                        }

                        foreach (Cannonball c in GetComponentsInChildren<Cannonball>())
                        {
                            c.Explode();
                        }

                        foreach (EventOnDestroy e in GetComponentsInChildren<EventOnDestroy>())
                        {
                            e.OnDestroy();
                        }
                    }
                }
            }

            elapsedTime += Time.deltaTime;

            if (drills > 0)
            {
                drillCooldown += Time.deltaTime;
                if (drillCooldown > drillInterval / drills)
                {
                    drillCooldown = 0;
                    Implode(15);
                }
            }

            if (caughtList.Count != 0)
            {
                List<Rigidbody> toRemove = new List<Rigidbody>();
                foreach (Rigidbody rigidbody in caughtList)
                {
                    if (rigidbody == null)
                    {
                        toRemove.Add(rigidbody);
                    }
                    else
                    {
                        if (Vector3.Distance(rigidbody.transform.position, transform.position) < 9f)
                        {
                            rigidbody.transform.position = Vector3.MoveTowards(rigidbody.transform.position, transform.position, 3 * Time.deltaTime * (10f - Vector3.Distance(rigidbody.transform.position, transform.position)));
                        }
                        else
                        {
                            rigidbody.transform.position = Vector3.MoveTowards(rigidbody.transform.position, transform.position, 3 * Time.deltaTime);
                        }
                        if (Vector3.Distance(rigidbody.transform.position, transform.position) < 1f)
                        {
                            if (rigidbody.TryGetComponent(out CharacterJoint cj))
                            {
                                Destroy(cj);
                            }
                            rigidbody.GetComponent<Collider>().enabled = false;
                        }
                        if (Vector3.Distance(rigidbody.transform.position, transform.position) < 0.25f)
                        {
                            toRemove.Add(rigidbody);
                            rigidbody.useGravity = false;
                            rigidbody.velocity = Vector3.zero;
                            rigidbody.isKinematic = true;
                            rigidbody.transform.SetParent(transform);
                            rigidbody.transform.localPosition = Vector3.zero;
                        }
                    }
                }
                if (toRemove.Count != 0)
                {
                    foreach (Rigidbody removeRb in toRemove)
                    {
                        caughtList.Remove(removeRb);
                    }
                }
            }
        }

        public void DetectCollision(Vector3 normal)
        {
            transform.forward = Vector3.Reflect(transform.forward, normal); 
        }

        public void GetHit(RevolverBeam beam)
        {
            lastBeam = beam;
            Implode(25 + (beam.damage * beam.maxHitsPerTarget / 2));
            TimeController.Instance.ParryFlash();
        }

        public void GetParried()
        {
            transform.forward = CameraController.Instance.transform.forward;
            Implode(15);

            if (maxTime > elapsedTime)
            {
                elapsedTime -= 1;
            }
        }

        public void OnTriggerEnter(Collider other)
        {
            if ((other.gameObject.tag == "Head" || other.gameObject.tag == "Body" || other.gameObject.tag == "Limb" || other.gameObject.tag == "EndLimb") && other.gameObject.tag != "Armor")
            {
                EnemyIdentifierIdentifier eidid = other.gameObject.GetComponentInParent<EnemyIdentifierIdentifier>();
                
                if (eidid != null && eidid.eid != null)
                {
                    HurtEnemy(eidid.eid);

                    if (eidid.eid.TryGetComponent(out Rigidbody rb))
                    {
                        rb.velocity /= 2;
                    }
                }
            }

            if (other.TryGetComponent(out Harpoon harp) && !caughtList.Contains(other.transform.GetComponent<Rigidbody>()))
            {
                caughtList.Add(harp.rb);

                Magnet mag = harp.GetComponentInChildren<Magnet>();
                if (mag != null)
                {
                    mag.maxWeight *= 0.75f;
                }

                if (harp.drill)
                {
                    harp.rb.isKinematic = true;
                    drills++;
                }

                harp.CancelInvoke("DestroyIfNotHit");
            }

            Projectile proj = null;
            Cannonball c = null;

            if ((other.GetComponent<Grenade>() || other.TryGetComponent(out proj) ||  (other.TryGetComponent(out c) && c.physicsCannonball)) && 
                !caughtList.Contains(other.GetComponent<Rigidbody>()))
            {
                Rigidbody rb = other.GetComponent<Rigidbody>();

                if (!rb.isKinematic)
                {
                    if (c)
                    {
                        rb.useGravity = false;
                    }

                    if (proj)
                    {
                        rb.useGravity = false;
                        proj.undeflectable = true;
                    }

                    caughtList.Add(rb);
                }
            }
        }

        public void HurtEnemy(EnemyIdentifier eid)
        {
            if (!eidsOnCooldown.Contains(eid))
            {
                bool wasDead = eid.dead;
                StartCoroutine(AddAndRemove(eid));
                eid.hitter = "singularity";
                eid.DeliverDamage(eid.gameObject, rb.velocity, transform.position, 2.5f, false, 0, SingularityBehaviour.Instances[0].gameObject);

                if (eid.dead && !wasDead)
                {
                    StyleCalculator.Instance.AddPoints(200, "<color=#b400ff>COMPRESSED</color>", eid, SingularityBehaviour.Instances[0].gameObject);
                    AddRbs(eid);
                }
            }
        }

        public void AddRbs(EnemyIdentifier eid)
        {
            foreach (Rigidbody rb in eid.GetComponentsInChildren<Rigidbody>())
            {
                caughtList.Add(rb);
            }
        }

        public IEnumerator AddAndRemove(EnemyIdentifier eid)
        {
            eidsOnCooldown.Add(eid);
            yield return new WaitForSeconds(0.25f);
            eidsOnCooldown.Remove(eid);
        }

        public void Implode(float length)
        {
            GameObject effect = Instantiate(implodeEffect);
            effect.GetComponent<Follow>().target = gameObject.transform;

            foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                if (Vector3.Distance(enemy.transform.position, transform.position) >= length)
                {
                    break;
                }

                if (enemy?.GetComponent<EnemyIdentifier>()?.dead ?? false)
                {
                    break;
                }

                EnemyIdentifier eid = enemy.GetComponent<EnemyIdentifier>();
                eid.hitter = "singularity_tendril";

                float amount = 2;
                if (eid.health < amount)
                    amount = eid.health - 0.1f;

                eid.DeliverDamage(eid.gameObject, rb.velocity, eid.transform.position, amount, false);

                SingularityBallLightning sbl;
                if (lastBeam?.sourceWeapon?.GetComponent<ConductorBehaviour>() != null)
                {
                    Stunner.EnsureAndStun(eid, lastBeam.damage / 4);
                    sbl = Instantiate(Conductor.MagnetZap).GetComponent<SingularityBallLightning>();
                }
                else
                {
                    sbl = Instantiate(lightning).GetComponent<SingularityBallLightning>();
                }
                sbl.enemy = enemy;
                sbl.ball = gameObject;

                if (eid.dead)
                {
                    AddRbs(eid);
                }

                if (enemy.TryGetComponent(out Rigidbody enemyRb))
                {
                    Vector3 force = enemyRb.transform.up / 10;

                    switch (eid.enemyClass)
                    {
                        case EnemyClass.Husk:
                            eid.zombie?.KnockBack(force);
                            break;
                        case EnemyClass.Machine:
                            eid.machine?.KnockBack(force);
                            break;
                        case EnemyClass.Demon:
                            eid.statue?.KnockBack(force);
                            break;
                        default:
                            enemyRb.AddForce(force, ForceMode.VelocityChange);
                            break;
                    }
                    enemyRb.velocity = (transform.position - enemy.transform.position).normalized * (6f * Vector3.Distance(transform.position, enemy.transform.position));
                }
            }

            foreach (Projectile projectile in FindObjectsOfType<Projectile>())
            {
                if (caughtList.Contains(projectile.rb))
                {
                    break;
                }


                if (projectile.rb?.useGravity ?? true)
                {
                    break;
                }

                if (Vector3.Distance(gameObject.transform.position, projectile.gameObject.transform.position) >= length)
                {
                    break;
                }

                if (projectile.GetComponent<StickyBombBehaviour>())
                {
                    break;
                }

                projectile.transform.LookAt(gameObject.transform);
                projectile.speed /= 2;

                SingularityBallLightning sbl = Instantiate(lightning).GetComponent<SingularityBallLightning>();
                sbl.enemy = projectile.gameObject;
                sbl.ball = gameObject;
            }

            suck.Play();
        }
    }

    public class SingularityBallLightning : MonoBehaviour
    {
        [HideInInspector] public GameObject ball;
        [HideInInspector] public GameObject enemy;
        public LineRenderer lr;

        public void Update()
        {
            if (enemy == null || ball == null)
            {
                Destroy(gameObject);
                return;
            }

            lr?.SetPosition(0, ball?.transform.position ?? lr.GetPosition(0));
            lr?.SetPosition(1, enemy?.transform.position ?? lr.GetPosition(1));
        }
    }
}
