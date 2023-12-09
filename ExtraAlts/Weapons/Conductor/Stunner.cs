using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace WafflesWeapons.Weapons.Conductor
{
    public class Stunner : MonoBehaviour
    {
        bool stunned;
        EnemyIdentifier eid;
        float timeLeft;
        List<GameObject> stunGlows = new List<GameObject>();

        public static void EnsureAndStun(EnemyIdentifier eid, float charge)
        {
            if (eid.GetComponent<Stunner>() == null)
            {
                eid.gameObject.AddComponent<Stunner>();
            }

            eid.GetComponent<Stunner>().Stun(charge);
        }

        public void Stun(float charge)
        {
            timeLeft += charge;

            if (!stunned)
            {
                StartCoroutine(StunRoutine());
            }
        }

        private IEnumerator StunRoutine()
        {
            if (eid == null)
            {
                eid = GetComponent<EnemyIdentifier>();
            }

            if (eid != null)
            {
                bool isLevi = GetComponentInChildren<LeviathanHead>(true) != null && GetComponentInChildren<LeviathanTail>(true) != null;
                bool shouldntGrav = (eid.enemyType == EnemyType.MaliciousFace || eid.enemyType == EnemyType.Cerberus) || isLevi;
                /*EnemyIdentifierIdentifier[] eidids = eid.GetComponentsInChildren<EnemyIdentifierIdentifier>();
                foreach (EnemyIdentifierIdentifier eidid in eidids)
                {
                    GameObject stunGlow = GameObject.Instantiate<GameObject>(Conductor.StunEffect, eidid.transform.position, eidid.transform.rotation);
                    stunGlow.AddComponent<Follow>().target = eidid.gameObject.transform; //cant set parent bc then scale changes :3

                    stunGlows.Add(stunGlow);
                }*/
;
                stunned = true;

                Animator anim = eid.GetComponentInChildren<Animator>();
                Rigidbody rb = eid.GetComponent<Rigidbody>();
                NavMeshAgent nma = eid.GetComponent<NavMeshAgent>();

                if (anim)
                {
                    anim.enabled = false;
                }

                if (nma)
                {
                    nma.enabled = false;
                }

                List<MonoBehaviour> mbs = GetEnemyScript(eid);
                foreach (MonoBehaviour mb in mbs)
                {
                    mb.enabled = false;
                }

                eid.enabled = false;

                bool usedGrav = false;
                bool wasKine = false;
                if (rb && !shouldntGrav)
                {
                    usedGrav = rb.useGravity;
                    wasKine = rb.isKinematic;
                    rb.useGravity = true;
                    rb.isKinematic = false;
                }

                while (timeLeft >= 0)
                {
                    timeLeft -= Time.deltaTime;
                    yield return null;
                }

                if (anim)
                {
                    anim.enabled = true;
                }

                if (nma)
                {
                    nma.enabled = true;
                }

                foreach (MonoBehaviour mb in mbs)
                {
                    if (mb != null)
                    {
                        mb.enabled = true;
                    }
                }

                if (eid)
                {
                    eid.enabled = true;
                }

                if (rb && !shouldntGrav)
                {
                    rb.useGravity = usedGrav;
                    rb.isKinematic = wasKine;
                }

                stunned = false;

                foreach (GameObject stunGlow in stunGlows)
                {
                    stunGlow.GetComponent<ParticleSystem>()?.Stop();
                }
            }
            yield return null;
        }

        public static List<MonoBehaviour> GetEnemyScript(EnemyIdentifier eid)
        {
            Type[] types = { typeof(ZombieMelee), typeof(ZombieProjectiles), typeof(Stalker), typeof(Sisyphus), typeof(Ferryman),
                             typeof(SwordsMachine), typeof(Drone), typeof(DroneFlesh), typeof(Streetcleaner), typeof(V2), typeof(Mindflayer),
                             typeof(Turret), typeof(SpiderBody), typeof(StatueBoss), typeof(Mass), typeof(Idol), typeof(Gabriel), typeof(GabrielSecond),
                             typeof(CancerousRodent), typeof(Mandalore), typeof(FleshPrison), typeof(MinosPrime), typeof(SisyphusPrime),
                             typeof(MinosArm), typeof(MinosBoss), typeof(Parasite), typeof(LeviathanHead), typeof(LeviathanTail)};

            Dictionary<Type, MonoBehaviour> allComps = new Dictionary<Type, MonoBehaviour>();

            foreach (MonoBehaviour mb in eid.gameObject.GetComponentsInChildren<MonoBehaviour>())
            {
                Type type = mb.GetType();
                if (!allComps.ContainsKey(type))
                {
                    allComps.Add(type, mb);
                }
            }

            List<MonoBehaviour> mbs = new List<MonoBehaviour>();
            foreach (Type type in types)
            {
                if (allComps.ContainsKey(type))
                {
                    mbs.Add(allComps[type]);
                }
            }

            return mbs;
        }
    }
}
