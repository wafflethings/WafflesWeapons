using Atlas.Modules.Guns;
using HarmonyLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using WafflesWeapons.Components;

namespace WafflesWeapons.Weapons
{
    public class Conductor : Gun
    {
        public static GameObject ConductorNail;
        public static GameObject ConductorSaw;
        public static GameObject MagnetZapEffect;
        public static GameObject FullExplosion;
        public static GameObject SawExplosion;
        public static GameObject RocketExplosion;
        public static GameObject HitProjectileExplosion;
        public static GameObject MagnetZap;

        static Conductor()
        {
            ConductorNail = Core.Assets.LoadAsset<GameObject>("Nailgun Conductor.prefab");
            ConductorSaw = Core.Assets.LoadAsset<GameObject>("Sawblade Launcher Conductor.prefab");
            MagnetZapEffect = Core.Assets.LoadAsset<GameObject>("Magnet Zap Effect.prefab");
            FullExplosion = Core.Assets.LoadAsset<GameObject>("Fully Charged Beam Explosion.prefab");
            SawExplosion = Core.Assets.LoadAsset<GameObject>("Fully Charged Saw Explosion.prefab");
            RocketExplosion = Core.Assets.LoadAsset<GameObject>("Shot Rocket Explosion.prefab");
            HitProjectileExplosion = Core.Assets.LoadAsset<GameObject>("Shot Projectile Explosion.prefab");
            MagnetZap = Core.Assets.LoadAsset<GameObject>("Magnet Zap.prefab");
            Core.Harmony.PatchAll(typeof(Conductor));
        }

        public override GameObject Create(Transform parent)
        {
            base.Create(parent);

            GameObject thing;
            if (Enabled() == 2)
            {
                thing = GameObject.Instantiate(ConductorSaw, parent);
            }
            else
            {
                thing = GameObject.Instantiate(ConductorNail, parent);
            }

            OrderInSlot = GunSetter.Instance.CheckWeaponOrder("nai")[3];
            StyleHUD.Instance.weaponFreshness.Add(thing, 10);
            return thing;
        }

        public override int Slot()
        {
            return 2;
        }

        public override string Pref()
        {
            return "nai3";
        }

        [HarmonyPatch(typeof(RevolverBeam), nameof(RevolverBeam.ExecuteHits)), HarmonyPostfix]
        public static void StunHitEnemies(RevolverBeam __instance, RaycastHit currentHit)
        {
            if (__instance.sourceWeapon == null)
            {
                return;
            }

            if (currentHit.transform != null && __instance.sourceWeapon.TryGetComponent(out ConductorBehaviour c) && currentHit.transform.GetComponentInParent<EnemyIdentifierIdentifier>())
            {
                EnemyIdentifier eid = currentHit.transform.GetComponentInParent<EnemyIdentifierIdentifier>().eid;
                if (eid != null)
                {
                    Stunner.EnsureAndStun(eid, c.LastCharge * StunMult(eid));
                }
            }
        }

        [HarmonyPatch(typeof(Nail), nameof(Nail.HitEnemy)), HarmonyPostfix]
        public static void StunSaws(Nail __instance, EnemyIdentifierIdentifier eidid)
        {
            if (__instance.GetComponent<StunTag>() && EnemyHitTracker.CheckAndHit(__instance.gameObject, eidid.eid))
            {
                Stunner.EnsureAndStun(eidid.eid, (__instance.damage / 3) * StunMult(eidid.eid));

                if (__instance.sawBounceEffect == SawExplosion)
                {
                    GameObject.Instantiate(__instance.sawBounceEffect, __instance.transform.position, __instance.transform.rotation);
                }
            }
        }

        [HarmonyPatch(typeof(RevolverBeam), nameof(RevolverBeam.ExecuteHits)), HarmonyPrefix]
        public static void EditHitProjectiles(RevolverBeam __instance, RaycastHit currentHit)
        {
            if (__instance.sourceWeapon?.GetComponent<ConductorBehaviour>() == null)
            {
                return;
            }

            if (currentHit.transform != null && currentHit.transform.gameObject.layer == 14 && 
                currentHit.transform.gameObject.TryGetComponent(out Projectile projectile) && (projectile.speed != 0f || projectile.decorative))
            {
                TimeController.Instance.ParryFlash();
                projectile.transform.forward = CameraController.Instance.transform.forward;
                projectile.friendly = true;
                projectile.homingType = HomingType.None;
                projectile.explosionEffect = HitProjectileExplosion;

                if (projectile.TryGetComponent(out Rigidbody rb))
                {
                    rb.useGravity = false;
                }

                if (projectile.speed < 50)
                {
                    projectile.speed = 50;
                }
            }
        }

        [HarmonyPatch(typeof(Explosion), nameof(Explosion.Collide)), HarmonyPrefix]
        public static void StunEnemiesHitByExplosion(Explosion __instance, Collider other)
        {
            if (__instance.canHit == AffectedSubjects.PlayerOnly || __instance.GetComponent<StunTag>() == null)
            {
                return;
            }

            if (other.gameObject.layer == 10 || other.gameObject.layer == 11)
            {
                EnemyIdentifierIdentifier eidid = other.GetComponentInParent<EnemyIdentifierIdentifier>();
                if (eidid != null && eidid.eid != null && EnemyHitTracker.CheckAndHit(__instance.gameObject, eidid.eid, 0.5f))
                {
                    Stunner.EnsureAndStun(eidid.eid, 1 * StunMult(eidid.eid));
                }
            }
        }

        private static MethodInfo m_Breakable_Break = typeof(Breakable).GetMethod("Break");
        private static MethodInfo m_Conductor_BreakReplacement = typeof(Conductor).GetMethod("BreakReplacement");

        [HarmonyPatch(typeof(RevolverBeam), nameof(RevolverBeam.PiercingShotCheck)), HarmonyTranspiler]
        public static IEnumerable<CodeInstruction> ReplaceBreak(IEnumerable<CodeInstruction> instructions)
        {
            foreach (CodeInstruction instruction in instructions)
            {
                if (instruction.opcode == OpCodes.Callvirt && instruction.OperandIs(m_Breakable_Break))
                {
                    yield return new CodeInstruction(OpCodes.Ldarg_0);
                    yield return new CodeInstruction(OpCodes.Call, m_Conductor_BreakReplacement);
                }
                else
                {
                    yield return instruction;
                }
            }
        }

        public static void BreakReplacement(Breakable breakable, RevolverBeam revolverBeam)
        {
            Debug.Log($"BreakReplacement called! Breakable {breakable}, RevolverBeam {revolverBeam}.");

            if (revolverBeam.sourceWeapon.TryGetComponent(out ConductorBehaviour cb))
            {
                breakable.StartCoroutine(MagnetElecEffect(breakable.transform));

                Debug.Log("Source has CB");

                float length = cb.LastCharge * 30f;

                GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy").Where(enemy => !enemy.GetComponent<EnemyIdentifier>().dead && 
                    Vector3.Distance(enemy.transform.position, breakable.transform.position) <= length).ToArray();

                Debug.Log($"{enemies.Length} enemies in {length} radius");

                if (enemies.Length > 0)
                {
                    foreach (GameObject enemy in enemies)
                    {
                        EnemyIdentifier eid = enemy.GetComponent<EnemyIdentifier>();
                        eid.hitterAttributes.Add(HitterAttribute.Electricity);
                        eid.DeliverDamage(eid.gameObject, Vector3.zero, eid.transform.position, revolverBeam.damage, false);
                        Stunner.EnsureAndStun(eid, 1 * StunMult(eid));

                        SingularityBallLightning sbl = GameObject.Instantiate(MagnetZap).GetComponent<SingularityBallLightning>();
                        sbl.enemy = eid.weakPoint ? eid.weakPoint : enemy;
                        sbl.ball = breakable.gameObject;
                    }
                    StyleCalculator.Instance.AddPoints(50 * enemies.Length, $"<color=cyan>GROUNDED</color> x{enemies.Length}", enemies[0].GetComponent<EnemyIdentifier>(), revolverBeam.sourceWeapon);
                }

                TimeController.Instance.ParryFlash();
            }
            else
            {
                breakable.Break();
            }
        }

        public static IEnumerator MagnetElecEffect(Transform t)
        {
            GameObject effect = GameObject.Instantiate(MagnetZapEffect, t);
            effect.transform.localPosition = Vector3.zero;
            effect.transform.rotation = t.rotation;

            yield return new WaitForSeconds(1);

            effect.GetComponent<ParticleSystem>().Stop();
        }

        private static MethodInfo m_Grenade_Explode = typeof(Grenade).GetMethod("Explode");
        private static MethodInfo m_Conductor_ExplodeReplacement = typeof(Conductor).GetMethod("ExplodeReplacement");

        [HarmonyPatch(typeof(RevolverBeam), nameof(RevolverBeam.ExecuteHits)), HarmonyTranspiler]
        public static IEnumerable<CodeInstruction> ReplaceGrenadeExplode(IEnumerable<CodeInstruction> instructions)
        {
            foreach (CodeInstruction instruction in instructions)
            {
                if (instruction.opcode == OpCodes.Callvirt && instruction.OperandIs(m_Grenade_Explode))
                {
                    yield return new CodeInstruction(OpCodes.Ldarg_0);
                    yield return new CodeInstruction(OpCodes.Call, m_Conductor_ExplodeReplacement);
                }
                else
                {
                    yield return instruction;
                }
            }
        }

        public static void ExplodeReplacement(Grenade grenade, bool big, bool harmless, bool super, float sizeMultiplier, bool ultrabooster, GameObject exploderWeapon, RevolverBeam revolverBeam)
        {
            Debug.Log($"ExplodeReplacement called! Grenade {grenade}, RevolverBeam {revolverBeam}.");

            if (revolverBeam.sourceWeapon.TryGetComponent(out ConductorBehaviour cb))
            {
                if (grenade.harmlessExplosion != RocketExplosion)
                {
                    GameObject effect = GameObject.Instantiate(MagnetZapEffect, grenade.transform);
                    effect.transform.localScale *= 1.5f;
                    ParticleSystem.EmissionModule emit = effect.GetComponent<ParticleSystem>().emission;
                    emit.rateOverTimeMultiplier *= 2;

                    if (grenade.rocket)
                    {
                        grenade.rocketSpeed *= 2f;
                    }
                }

                grenade.harmlessExplosion = RocketExplosion;
                grenade.explosion = RocketExplosion;
                grenade.superExplosion = RocketExplosion;
            }
            else
            {
                grenade.Explode(big, harmless, super, sizeMultiplier, ultrabooster, exploderWeapon);
            }
        }

        public static float StunMult(EnemyIdentifier eid)
        {
            return (eid.GetComponent<BossIdentifier>() ? 0.65f : 1.25f);
        }
    }

    public class StunTag : MonoBehaviour
    {
        // this is just a flag, custom tags dont work :3
    }

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

    public class ConductorBehaviour : GunBehaviour<ConductorBehaviour>
    {
        private Nailgun nail;
        [HideInInspector] public float Charge;
        [HideInInspector] public float ChargeLength;
        [HideInInspector] public float LastCharge;
        public GameObject Beam;
        public GameObject Saw;
        public Slider ChargeSlider;
        public Slider HoldLengthSlider;
        public AudioSource ChargeSound;
        public AudioSource ShootSound;
        public AudioSource FinishChargeSound;
        public MeshRenderer[] Barrels;
        public Material NormalBarrelHeat;
        public Material BlueBarrelHeat;
        public ParticleSystem ElecParticles;
        public Color ShootColour;
        public Color ElecColour;
        private float fireRate = 0;
        private float cooldown = 0;

        public void MaxCharge()
        {
            Charge = 1;
        }

        public void Start()
        {
            nail = GetComponent<Nailgun>();
            fireRate = nail.fireRate;
            SetBarrelsOrange();
        }

        public void Update()
        {
            if (ULTRAKILL.Cheats.NoWeaponCooldown.NoCooldown)
            {
                Charge = 1;
            }

            if (nail.gc.activated)
            {
                nail.fireRate = fireRate;
                cooldown = Mathf.MoveTowards(cooldown, 0, Time.deltaTime);
                Charge = Mathf.MoveTowards(Charge, 1, Time.deltaTime * 0.1f);

                nail.heatSlider = null;
                ChargeSlider.value = Charge;
                HoldLengthSlider.value = ChargeLength == 0 ? 0 : ChargeLength + (1 - Charge);

                if (cooldown == 0)
                {
                    if (Charge >= 0.1f && Gun.OnAltFireHeld())
                    {
                        nail.heatUp = ChargeLength;
                        nail.spinSpeed = 250f + nail.heatUp * 2250f;
                        SetBarrelsBlue();

                        nail.canShoot = false;
                        if (ChargeLength < 1)
                        {
                            ChargeLength = Mathf.MoveTowards(ChargeLength, Charge, Time.deltaTime / 1.5f);
                            if (ChargeLength == 1)
                            {
                                FinishChargeSound.Play();
                            }
                        }
                        if (!ChargeSound.isPlaying)
                        {
                            ChargeSound.Play();
                        }
                        ChargeSound.pitch = 0.5f + ChargeLength;
                        CameraController.Instance.CameraShake(ChargeLength * 0.25f);
                    }
                    else
                    {
                        nail.canShoot = true;
                    }

                    if (Gun.OnAltFireReleased() && Charge >= 0.1f)
                    {
                        LastCharge = ChargeLength;
                        if (ChargeLength <= 0.1f)
                        {
                            ChargeLength = 0.1f;
                        }

                        ChargeSound.Stop();
                        ShootSound.Play();

                        if (ChargeLength < 0.1f)
                        {
                            ChargeLength = 0.1f;
                        }

                        nail.anim.SetTrigger("Shoot");
                        CameraController.Instance.CameraShake(2 * ChargeLength);

                        if (!nail.altVersion)
                        {
                            RevolverBeam beam = GameObject.Instantiate(Beam, nail.cc.transform.position + nail.cc.transform.forward, nail.cc.transform.rotation).GetComponent<RevolverBeam>();
                            if (ChargeLength == 1)
                            {
                                beam.hitParticle = Conductor.FullExplosion;
                                foreach (Explosion e in beam.hitParticle.GetComponentsInChildren<Explosion>(true))
                                {
                                    e.sourceWeapon = gameObject;
                                }
                            }
                            beam.alternateStartPoint = nail.shootPoints[0].transform.position;
                            beam.damage *= ChargeLength;
                            beam.sourceWeapon = gameObject;
                            beam.enemyLayerMask |= (1 << 14); // have to add the Projectile layer, but can't use rb.canHitProjectiles as it will cause the sharpshooter behaviour
                            foreach (LineRenderer lr in beam.GetComponentsInChildren<LineRenderer>())
                            {
                                lr.startWidth *= 2 * ChargeLength;
                            }
                        } 
                        else
                        {
                            Nail saw = GameObject.Instantiate(Saw, nail.cc.transform.position, nail.cc.transform.rotation).GetComponent<Nail>();
                            if (ChargeLength == 1)
                            {
                                saw.sawBounceEffect = Conductor.SawExplosion;
                            }
                            saw.damage *= ChargeLength;
                            saw.weaponType = nail.projectileVariationTypes[nail.variation];
                            saw.sourceWeapon = gameObject;
                            saw.ForceCheckSawbladeRicochet();
                            saw.sourceWeapon = gameObject;
                            saw.rb.velocity = saw.transform.forward * 200;
                            saw.transform.forward = CameraController.Instance.transform.forward;

                            Vector3 newScale = Vector3.one * 0.1f * ChargeLength * 2;
                            newScale.y = 0.1f;
                            saw.transform.localScale = newScale;
                            saw.transform.position -= transform.forward * ChargeLength * 2;
                        }

                        Charge -= ChargeLength;
                        ChargeLength = 0;
                        cooldown = 0.25f;

                        SetBarrelsOrange();
                    }
                }
            }
        }

        public void SetBarrelsOrange()
        {
            foreach (MeshRenderer mr in Barrels)
            {
                mr.material = NormalBarrelHeat;
                Light light = mr.TryGetComponent(out Light l) ? l : mr.transform.parent.GetComponentInChildren<Light>();
                light.color = ShootColour;
            }

            ParticleSystem.EmissionModule em = ElecParticles.emission;
            em.rateOverTime = 0;
        }

        public void SetBarrelsBlue()
        {
            foreach (MeshRenderer mr in Barrels)
            {
                mr.material = BlueBarrelHeat;
                Light light = mr.TryGetComponent(out Light l) ? l : mr.transform.parent.GetComponentInChildren<Light>();
                light.color = ElecColour;
            }

            ParticleSystem.EmissionModule em = ElecParticles.emission;
            em.rateOverTime = ChargeLength * 100;
        }

        public void OnEnable()
        {
            ChargeLength = 0;
            Charge = WaffleWeaponCharges.Instance.ConductorCharge;
        }

        public void OnDisable()
        {
            WaffleWeaponCharges.Instance.ConductorCharge = Charge;
        }
    }
}