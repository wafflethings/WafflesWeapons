using Atlas.Modules.Guns;
using HarmonyLib;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WafflesWeapons.Components;

namespace WafflesWeapons.Weapons
{
    public class FerryOar : Fist
    {
        public static GameObject Oar;
        public static GameObject LightningIndicator;
        public static GameObject LightningExplosion;
        public static GameObject ThrowableOar;

        static FerryOar()
        {
            Oar = Core.Assets.LoadAsset<GameObject>("Arm Ferry.prefab");
            LightningIndicator = Core.Assets.LoadAsset<GameObject>("Ferry Expose Indicator.prefab");
            LightningExplosion = Core.Assets.LoadAsset<GameObject>("Ferry Lightning Explosion.prefab");
            ThrowableOar = Core.Assets.LoadAsset<GameObject>("Ferry Throw Oar.prefab");
            Core.Harmony.PatchAll(typeof(FerryOar));
        }

        public override GameObject Create(Transform parent)
        {
            base.Create(parent);
            GameObject thing = GameObject.Instantiate(Oar, parent);
            return thing;
        }

        public override int Slot()
        {
            return 1;
        }

        public override string Pref()
        {
            return "arm4";
        }

        [HarmonyPatch(typeof(Punch), nameof(Punch.BlastCheck)), HarmonyPrefix]
        public static bool CancelBlast(Punch __instance)
        {
            LoaderBehaviour lb = __instance.GetComponent<LoaderBehaviour>();

            if (lb != null)
            {
                return false;
            }

            return true;
        }

        [HarmonyPatch(typeof(FistControl), nameof(FistControl.UpdateFistIcon)), HarmonyPostfix]
        public static void FixColour(FistControl __instance)
        {
            try
            {
                if (__instance.currentArmObject?.GetComponent<FerryOarBehaviour>() != null)
                {
                    __instance.fistIcon.color = ColorBlindSettings.Instance.variationColors[4];
                }
            }
            catch
            {
                Debug.LogError($"whar? {ColorBlindSettings.Instance.variationColors.Length}");
            }
        }

        [HarmonyPatch(typeof(Punch), nameof(Punch.PunchStart)), HarmonyPrefix]
        public static bool DoRealPunch(Punch __instance)
        {
            if (__instance.TryGetComponent(out FerryOarBehaviour fo))
            {
                if (fo.CanPunch)
                {
                    return false;
                }

                if (__instance.ready)
                {
                    // lb.anim.Play("Armature|ES_HookPunch", 0, 0);
                    fo.Punch();
                }
            }

            return true;
        }

        [HarmonyPatch(typeof(Punch), nameof(Punch.PunchSuccess)), HarmonyPrefix]
        public static void ExposePunchedEnemy(Punch __instance, ref string __state, Transform target)
        {
            if (__instance.TryGetComponent(out FerryOarBehaviour fo))
            {
                if (fo.ExposeThisHit && (target.gameObject.tag == "Enemy" || target.gameObject.tag == "Armor" || target.gameObject.tag == "Head" || target.gameObject.tag == "Body" || target.gameObject.tag == "Limb" || target.gameObject.tag == "EndLimb"))
                {
                    if (target.TryGetComponent(out EnemyIdentifierIdentifier eidid))
                    {
                        if (eidid.eid.gameObject.GetComponent<ExposeTag>() == null)
                        {
                            eidid.eid.gameObject.AddComponent<ExposeTag>();
                        }

                        if (eidid.eid.enemyType != EnemyType.Idol)
                        {
                            __state = __instance.hitter;
                            __instance.hitter = "exposalpunch"; //dont want to break idols
                        }
                    }
                }
            }
        }

        [HarmonyPatch(typeof(Punch), nameof(Punch.AltHit)), HarmonyPatch(typeof(Punch), nameof(Punch.PunchSuccess)), HarmonyPrefix]
        public static void SwingReflect(Punch __instance, Transform target)
        {
            if (__instance.TryGetComponent(out FerryOarBehaviour fo))
            {
                NewMovement nm = NewMovement.Instance;

                Debug.Log("checking: " + target.gameObject.layer);
                if (LayerMaskDefaults.Get(LMD.Environment).Contains(target.gameObject.layer) || (!nm.gc.touchingGround && LayerMaskDefaults.Get(LMD.Enemies).Contains(target.gameObject.layer)))
                {
                    nm.jumpPower /= 4;
                    nm.Jump();
                    nm.jumpPower *= 4;
                    Debug.Log("jump");
                    nm.rb.AddForce(-CameraController.Instance.transform.forward * 1000, ForceMode.Impulse);
                }
            }
        }

        [HarmonyPatch(typeof(Punch), nameof(Punch.PunchSuccess)), HarmonyPostfix]
        public static void ResetHitter(Punch __instance, string __state)
        {
            if (__instance.hitter == "exposalpunch")
            {
                __instance.hitter = __state;
            }
        }

        public static List<EnemyIdentifier> HitRecently = new List<EnemyIdentifier>();
        public static IEnumerator Ensure(EnemyIdentifier eid)
        {
            HitRecently.Add(eid);
            yield return new WaitForSeconds(0.01f);
            HitRecently.Remove(eid);
        }

        [HarmonyPatch(typeof(EnemyIdentifier), nameof(EnemyIdentifier.DeliverDamage)), HarmonyPrefix]
        public static void ExplodeExposed(EnemyIdentifier __instance)
        {
            if (!__instance.dead && !HitRecently.Contains(__instance) && __instance.TryGetComponent(out ExposeTag et) && !et.Done)
            {
                if (__instance.hitter == "exposalpunch") 
                {
                    return;
                }

                et.Done = true;
                Object.Instantiate(LightningExplosion, __instance.transform.position, __instance.transform.rotation);
                Object.Destroy(et);
            }

            __instance.StartCoroutine(Ensure(__instance)); //TODO fix this it sucks
        }

        [HarmonyPatch(typeof(EnemyIdentifier), nameof(EnemyIdentifier.DeliverDamage)), HarmonyPostfix]
        public static void UnexposeIfDead(EnemyIdentifier __instance)
        {
            if (__instance.TryGetComponent(out ExposeTag et) && !et.Done && __instance.dead)
            {
                et.Done = true;
                Object.Destroy(et);
            }
        }
    }

    public class FerryOarBehaviour : GunBehaviour<FerryOarBehaviour>
    {
        public GameObject OarInHand;
        public ParticleSystem ExposeParticleSystem;
        [HideInInspector] public bool CanPunch;
        [HideInInspector] public bool ExposeThisHit;
        private int _punchesDone;
        private float _timeHeld;
        private Punch _punch;
        private bool _hasSpear = true;
        private Boomerang _currentBoomerang;
        private float _lastSwingTime;

        public void Start()
        {
            _punch = GetComponent<Punch>();
        }

        public void OnDisable()
        {
            if (_punch.anim != null)
            {
                _punch.anim.Play("Idle");
            }
        }

        public void Punch()
        {
            _punchesDone++;

            ExposeThisHit = _punchesDone == 3;

            if (_punchesDone > 3)
            {
                _punchesDone = 1;
            }

            float cooldownReal = 0;

            switch (_punchesDone)
            {
                case 1:
                    cooldownReal = 0.5f;
                    break;
                case 2:
                    cooldownReal = 0.5f;
                    break;
                case 3:
                    cooldownReal = 2f;
                    break;
            }

            _punch.damage = 0f;
            _punch.screenShakeMultiplier = 0f;
            _punch.force = 0f;
            _punch.tryForExplode = false;

            _punch.ActiveStart();
            _punch.Invoke("ActiveEnd", 3f / 30f);
            Invoke("ReadyToPunch_WithoutHolding", 10f / 30f);
            _punch.Invoke("PunchEnd", 28f / 30f);
            _punch.fc.weightCooldown = cooldownReal;
            _punch.fc.fistCooldown = cooldownReal;
            _lastSwingTime = Time.time;

            if (_punchesDone == 3)
            {
                ExposeParticleSystem.Play();
                Invoke("DisableParticles", 0.5f);
            }
        }

        private void DisableParticles()
        {
            ExposeParticleSystem.Stop();
        }

        private void ReadyToPunch_WithoutHolding()
        {
            _punch.returnToOrigRot = true;
            _punch.ready = true;
            _punch.alreadyBoostedProjectile = false;
            _punch.ignoreDoublePunch = false;
        }

        public void Update()
        {
            if (GunControl.Instance.activated)
            {
                _punch.ready = _hasSpear;

                if (_hasSpear)
                {
                    if (Fist.OnPunchHeld())
                    {
                        _timeHeld += Time.deltaTime;
                    }
                    else
                    {
                        if (_timeHeld > 0.3f && Time.time - _lastSwingTime < 1)
                        {
                            ThrowBoomerang();
                        }
                        _timeHeld = 0;
                    }
                }
            }
        }

        public void ThrowBoomerang()
        {
            GameObject throwOar = Instantiate(FerryOar.ThrowableOar, CameraController.Instance.transform.position, CameraController.Instance.transform.rotation);
            _currentBoomerang = throwOar.GetComponent<Boomerang>();

            _currentBoomerang.Target = GetRaycastPoint(out _currentBoomerang.HitSomething);
            _currentBoomerang.Speed = 50;
            OarInHand.SetActive(false);
            _hasSpear = false;
        }

        public void Return()
        {
            OarInHand.SetActive(true);
            _hasSpear = true;
        }

        public static Vector3 GetRaycastPoint(out bool hitSomething)
        {
            Debug.Log("getting point");
            hitSomething = true;

            if (Physics.Raycast(CameraController.Instance.transform.position, CameraController.Instance.transform.forward, out RaycastHit hit, 10000, LayerMaskDefaults.Get(LMD.EnemiesAndEnvironment)))
            {
                return hit.point;
            }

            if (Physics.Raycast(CameraController.Instance.transform.position, CameraController.Instance.transform.forward, out RaycastHit hit2, 10000, LayerMaskDefaults.Get(LMD.Environment)))
            {
                return hit2.point;
            }

            Debug.Log("somehow hit nothing");
            hitSomething = false;
            return CameraController.Instance.transform.position + CameraController.Instance.transform.forward * 100;
        }
    }

    public class Boomerang : MonoBehaviour
    {
        public BoxCollider ParryBox;
        public GameObject HitWallDecal;
        [HideInInspector] public float Speed;
        [HideInInspector] public Vector3 Target;
        [HideInInspector] public bool MoveTowardsPlayer;
        [HideInInspector] public bool HitSomething;
        private List<Vector3> _curvePoints;
        private int _currentPoint;
        private float _speedMult = 1;
        private float _targetSpeedMult = 1;
        private bool _reachedPeakHeight;
        private float _currentPeak;
        private int _parriesDone;
        private int _bouncesLeft = 0;

        public void Start()
        {
            Quaternion rotation = transform.rotation;
            transform.LookAt(Target);
            transform.rotation = rotation;

            _speedMult = 2;
            _targetSpeedMult = 2;
            Vector3 midPoint = ((transform.position + Target) / 2) + (Vector3.up * 2.5f);
            _curvePoints = BezierCurve.PointList3(new List<Vector3>() { transform.position, midPoint, Target });

            if (HitSomething)
            {
                _bouncesLeft = 1;
            }
        }

        public void Update()
        {
            ParryBox.enabled = !MoveTowardsPlayer;

            if (!MoveTowardsPlayer)
            {
                /*if (_goingBack)
                {
                    Target = CameraController.Instance.transform.position + CameraController.Instance.transform.forward;
                    Vector3 midPoint = ((transform.position + Target) / 2) + (Vector3.up * 5);
                    _curvePoints = BezierCurve.PointList3(new List<Vector3>() { transform.position, midPoint, _targetAtParry, Target });
                }*/

                if (_currentPoint <= _curvePoints.Count - 1)
                {
                    // sometimes the distance between points is smaller than the amount to travel
                    float toTravelThisFrame = Time.deltaTime * Speed * _speedMult;
                    while (toTravelThisFrame >= 0.0001f && !MoveTowardsPlayer)
                    {
                        transform.LookAt(_curvePoints[_currentPoint + 1 <= _curvePoints.Count - 1 ? _currentPoint + 1 : _currentPoint]);

                        Vector3 oldPos = transform.position;
                        transform.position = Vector3.MoveTowards(transform.position, _curvePoints[_currentPoint], toTravelThisFrame);
                        toTravelThisFrame -= Vector3.Distance(oldPos, transform.position);


                        if (_reachedPeakHeight)
                        {
                            _speedMult = Mathf.MoveTowards(_speedMult, _targetSpeedMult, Time.deltaTime);
                        }
                        else
                        {
                            _reachedPeakHeight = transform.position.y == _currentPeak;
                        }

                        if (transform.position == _curvePoints[_currentPoint])
                        {
                            _currentPoint += 1;

                            if (_currentPoint > _curvePoints.Count - 1)
                            {
                                End();
                                return; 
                            }
                        }
                    }
                }

                if (Physics.Raycast(transform.position, transform.forward, out RaycastHit raycastHit, 1f, LayerMaskDefaults.Get(LMD.Environment)))
                {
                    End();
                }
            }
            else
            {
                transform.LookAt(CameraController.Instance.transform.position);
                transform.position += transform.forward * 100 * Time.deltaTime;

                if (Vector3.Distance(CameraController.Instance.transform.position, transform.position) < 1.5f)
                {
                    FerryOarBehaviour.Instances[0].Return();
                    Destroy(gameObject);
                }
            }
        }

        public void Parry()
        {
            _parriesDone += 1;
            _speedMult = 1.5f;
            _targetSpeedMult = 1.5f;

            Target = FerryOarBehaviour.GetRaycastPoint(out HitSomething);
            if (HitSomething)
            {
                _bouncesLeft = 1;
            }
            Vector3 midPoint = ((transform.position + Target) / 2) + (Vector3.up);
            _curvePoints = BezierCurve.PointList3(new List<Vector3>() { transform.position, midPoint, Target });

            Reset();
        }

        public void Reset()
        {
            _currentPoint = 0;
            MoveTowardsPlayer = false;
            _reachedPeakHeight = false;
            _currentPeak = PeakHeight(_curvePoints);
        }

        public void End()
        {
            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit shockwaveHit, 2f, LayerMaskDefaults.Get(LMD.Environment)))
            {
                GameObject decal = Instantiate(HitWallDecal, shockwaveHit.point, Quaternion.identity);
                decal.transform.rotation = Quaternion.LookRotation(shockwaveHit.normal);
                decal.transform.position += decal.transform.forward * 0.25f;
            }

            if (_bouncesLeft > 0)
            {
                _bouncesLeft--;

                Vector3 defaultReturn = CameraController.Instance.transform.position + CameraController.Instance.transform.forward * 2;

                if (!NewMovement.Instance.gc.onGround && Physics.Raycast(NewMovement.Instance.transform.position,
                        -NewMovement.Instance.transform.forward * 1.5f + Vector3.down, out RaycastHit hit, 100, LayerMaskDefaults.Get(LMD.Environment)))
                {
                    Debug.Log("FOUND THING");
                    Target = hit.point;
                }
                else
                {
                    Target = defaultReturn;
                }

                Vector3 midPoint = ((transform.position + Target) / 2) + (Vector3.up * 10);
                if (midPoint.y < NewMovement.Instance.transform.position.y)
                {
                    midPoint.y = NewMovement.Instance.transform.position.y;
                }
                _curvePoints = BezierCurve.PointList3(new List<Vector3> { transform.position, midPoint, Target });

                _speedMult = 0.5f + Vector3.Distance(Target, transform.position) / 75 + (_parriesDone * 0.1f);
                _targetSpeedMult = 0.5f + Vector3.Distance(Target, transform.position) / 75 + (_parriesDone * 0.1f);

                Reset();

                if (Vector3.Distance(transform.position, NewMovement.Instance.transform.position) < 2)
                {
                    MoveTowardsPlayer = true;
                }
            }
            else
            {
                MoveTowardsPlayer = true;
            }
        }

        public float PeakHeight(List<Vector3> vecs)
        {
            float cur = float.MinValue;

            foreach (Vector3 vec in vecs)
            {
                if (vec.y > cur)
                {
                    cur = vec.y;
                }
            }

            return cur;
        }

        public Vector3 ClosestPoint(Vector3 nearPoint, List<Vector3> points)
        {
            float distance = float.MaxValue;
            Vector3 closest = Vector3.zero;

            foreach (Vector3 point in points)
            {
                if (Vector3.Distance(nearPoint, point) <= distance)
                {
                    distance = Vector3.Distance(nearPoint, point);
                    closest = point;
                }
            }

            return closest;
        }

        public void OnTriggerEnter(Collider col)
        {
            if ((col.gameObject.tag == "Head" || col.gameObject.tag == "Body" || col.gameObject.tag == "Limb" || col.gameObject.tag == "EndLimb") && col.gameObject.tag != "Armor") 
            {
                if (col.gameObject.TryGetComponent(out EnemyIdentifierIdentifier eidid) && EnemyHitTracker.CheckAndHit(gameObject, eidid.eid, 0.5f))
                {
                    _bouncesLeft = 1;
                    eidid.eid.hitter = "heavypunch";
                    eidid.eid.DeliverDamage(col.gameObject, transform.rotation.eulerAngles, transform.position, 3 + _parriesDone * 1.5f, false, 0, gameObject);

                    if (LayerMaskDefaults.Get(LMD.EnemiesAndEnvironment).Contains(eidid.gameObject.layer))
                    {
                        End();
                    }
                }
            }
        }
    }

    public class ExposeTag : MonoBehaviour
    {
        public const float ExposeLength = 2.5f;
        public bool Done = false;
        public float TimeLeft = 0;
        private float _growTime;
        private Vector3 _targetScale;
        private GameObject _lightning;

        public void Start()
        {
            TimeLeft += ExposeLength;
            _lightning = Instantiate(FerryOar.LightningIndicator, transform.position, Quaternion.identity);
            _lightning.GetComponent<Follow>().target = transform;
            StartCoroutine(DestroyOverTime());
        }

        public void Update()
        {
            float rate = _targetScale.x == 0 ? Time.deltaTime * 5 : Time.deltaTime * (_targetScale.x / _growTime);
            _lightning.transform.localScale = Vector3.MoveTowards(_lightning.transform.localScale, _targetScale, rate);
        }

        public IEnumerator DestroyOverTime()
        {
            _growTime = 1f;
            _targetScale = new Vector3(0.5f, 1, 0.5f);
            while (TimeLeft > 0)
            {
                yield return null;
                TimeLeft -= Time.deltaTime;
            }
            _targetScale = new Vector3(0, 1, 0);
            _growTime = 0.1f;
            yield return new WaitForSeconds(0.1f);
            Destroy(this);
        }

        public void OnDestroy()
        {
            Destroy(_lightning);
        }
    }
}
