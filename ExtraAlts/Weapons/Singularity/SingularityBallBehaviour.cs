using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace WafflesWeapons.Weapons.Singularity
{
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

            if (Physics.Raycast(transform.position, rb.velocity.normalized, out RaycastHit raycastHit,
                    transform.localScale.x, LayerMaskDefaults.Get(LMD.Environment)))
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
                        foreach (EnemyIdentifierIdentifier eidid in GetComponentsInChildren<EnemyIdentifierIdentifier>()
                                     .Where(eidid => eidid.eid != null))
                        {
                            if (i % 2 == 0) //prob a better way to do this but its 2am and im eepy :3
                            {
                                eidid.eid.hitter = "enemy";
                                eidid.eid.DeliverDamage(eidid.gameObject, Vector3.zero,
                                    eidid.gameObject.transform.position, 25f, false);
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
                            rigidbody.transform.position = Vector3.MoveTowards(rigidbody.transform.position,
                                transform.position,
                                3 * Time.deltaTime *
                                (10f - Vector3.Distance(rigidbody.transform.position, transform.position)));
                        }
                        else
                        {
                            rigidbody.transform.position = Vector3.MoveTowards(rigidbody.transform.position,
                                transform.position, 3 * Time.deltaTime);
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
            if ((other.gameObject.tag == "Head" || other.gameObject.tag == "Body" || other.gameObject.tag == "Limb" ||
                 other.gameObject.tag == "EndLimb") && other.gameObject.tag != "Armor")
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

            if (other.TryGetComponent(out Harpoon harp) &&
                !caughtList.Contains(other.transform.GetComponent<Rigidbody>()))
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

            if ((other.GetComponent<Grenade>() || other.TryGetComponent(out proj) ||
                 (other.TryGetComponent(out c) && c.physicsCannonball)) &&
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
                eid.DeliverDamage(eid.gameObject, rb.velocity, transform.position, 2.5f, false, 0,
                    SingularityBehaviour.Instances[0].gameObject);

                if (eid.dead && !wasDead)
                {
                    StyleCalculator.Instance.AddPoints(200, "<color=#b400ff>COMPRESSED</color>", eid,
                        SingularityBehaviour.Instances[0].gameObject);
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

                    enemyRb.velocity = (transform.position - enemy.transform.position).normalized *
                                       (6f * Vector3.Distance(transform.position, enemy.transform.position));
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
}
