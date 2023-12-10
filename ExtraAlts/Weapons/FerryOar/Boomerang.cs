using System.Collections.Generic;
using UnityEngine;
using WafflesWeapons.Components;
using WafflesWeapons.Utils;

namespace WafflesWeapons.Weapons.FerryOar
{
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
}
