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

        [HarmonyPatch(typeof(EnemyIdentifier), nameof(EnemyIdentifier.DeliverDamage)), HarmonyPostfix]
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
    }

    public class FerryOarBehaviour : MonoBehaviour
    {
        [HideInInspector] public bool CanPunch;
        [HideInInspector] public bool ExposeThisHit;
        private int _punchesDone;
        private bool _shouldExpose = true;
        private float _timeHeld;
        private Punch _punch;

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

            ExposeThisHit = false;
            if (_shouldExpose && _punchesDone == 3)
            {
                ExposeThisHit = true;
            }

            if (_punchesDone > 3)
            {
                _punchesDone = 1;
            }

            _punch.damage = 0f;
            _punch.screenShakeMultiplier = 0f;
            _punch.force = 0f;
            _punch.tryForExplode = false;
            _punch.cooldownCost = 0f;

            _punch.ActiveStart();
            _punch.Invoke("ActiveEnd", 3f / 30f);
            Invoke("ReadyToPunch_WithoutHolding", 10f / 30f);
            _punch.Invoke("PunchEnd", 28f / 30f);
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
                if (_punch.holdingInput)
                {
                    _timeHeld += Time.deltaTime;
                }
                else
                {
                    _timeHeld = 0;
                }

                if (_timeHeld > 0.2f)
                {
                    ThrowBoomerang();
                    _timeHeld = 0;
                }
            }
        }

        public void ThrowBoomerang()
        {
            GameObject throwOar = Instantiate(FerryOar.ThrowableOar, CameraController.Instance.transform.position, CameraController.Instance.transform.rotation);
            Boomerang boomerang = throwOar.GetComponent<Boomerang>();
            if (Physics.Raycast(CameraController.Instance.transform.position, CameraController.Instance.transform.forward, out RaycastHit hit, 1000, LayerMaskDefaults.Get(LMD.EnemiesAndEnvironment)))
            {
                Debug.Log("just hit " + hit.collider.gameObject.name);
                boomerang.Target = hit.point;
            }
            else
            {
                boomerang.Target = CameraController.Instance.transform.position + CameraController.Instance.transform.forward * 50;
            }

            Debug.Log("magni " + NewMovement.Instance.rb.velocity.magnitude);
            boomerang.Speed = 50 + (NewMovement.Instance.rb.velocity.magnitude);
        }
    }

    public class Boomerang : MonoBehaviour
    {
        public GameObject RotateThing;
        [HideInInspector] public float Speed;
        [HideInInspector] public Vector3 Target;
        private Vector3 _startPos;
        private Vector3 _startPlayerPos;
        private int _currentPoint;
        private Vector3 _lastPoint;
        private bool _done;

        public void Start()
        {
            _startPos = transform.position;
            _startPlayerPos = PlayerTracker.Instance.PredictPlayerPosition(2);
            _startPlayerPos.y = Target.y;

            Quaternion rotation = transform.rotation;
            transform.LookAt(Target);
            Target += transform.forward * 5f;
            transform.rotation = rotation;
        }

        public void Update()
        {
            RotateThing.transform.rotation *= Quaternion.Euler(0, 720 * Time.deltaTime, 0);
            if (!_done)
            {
                List<Vector3> curvePoints = BezierCurve.PointList3(new List<Vector3>() { _startPos, Target, _startPlayerPos });
                _currentPoint = curvePoints.IndexOf(ClosestPoint(_lastPoint, curvePoints)) + 1;
                if (_currentPoint == -1 || _currentPoint > curvePoints.Count)
                {
                    _currentPoint = curvePoints.Count;
                }
                GetComponent<LineRenderer>().positionCount = curvePoints.Count;
                GetComponent<LineRenderer>().SetPositions(curvePoints.ToArray());

                Debug.Log($"{_currentPoint + 1} of {curvePoints.Count}");
                if (_currentPoint + 1 < curvePoints.Count)
                {
                    transform.LookAt(curvePoints[_currentPoint + 1]);
                    transform.position = Vector3.MoveTowards(transform.position, curvePoints[_currentPoint], Time.deltaTime * Speed);
                    _lastPoint = transform.position;
                }
                else
                {
                    _done = true;
                }
            } 
            else
            {
                transform.LookAt(CameraController.Instance.transform.position);
                transform.position += transform.forward * 50 * Time.deltaTime;

                if (Vector3.Distance(CameraController.Instance.transform.position, transform.position) < 1)
                {
                    Destroy(gameObject);
                }
            }
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
                    eidid.eid.DeliverDamage(col.gameObject, transform.rotation.eulerAngles, transform.position, 2, false, 0, gameObject);
                    for (int i = 0; i < 4; i++)
                    {
                        eidid.eid.DeliverDamage(col.gameObject, transform.rotation.eulerAngles, transform.position, 0.25f, false, 0, gameObject);
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
