using System;
using System.Collections.Generic;
using System.Linq;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using Vertx.Debugging;
using Object = UnityEngine.Object;

namespace Train
{
    public class TrainTrackPoint : MonoBehaviour
    {
        [HideInInspector] public int instanceId;
        public List<TrainTrackPoint> forwardPoints;
        public List<TrainTrackPoint> backwardPoints;
        
        public StopBehaviour stopBehaviour;
        
        [HideInInspector] public int forwardPath;
        [HideInInspector] public int backwardPath;
        
        // Dynamic depending on the type
        [HideInInspector] public TrackCurveSettings forwardCurveSettings;

        public TrainTrackPoint GetDestination(bool forward = true)
        {
            TrainTrackPoint resultPoint;
            if (forward)
            {
                if (forwardPoints == null || forwardPoints.Count == 0 || forwardPoints.All(point => point == null))
                    return null;
                resultPoint = forwardPoints[forwardPath];
            }
            else
            {
                if (backwardPoints == null || backwardPoints.Count == 0 || backwardPoints.All(point => point == null))
                    return null;
                resultPoint = backwardPoints[backwardPath];
            }
            
            if (resultPoint == null || !resultPoint.gameObject.activeSelf) return null;
            return resultPoint;
        }

        private void OnDrawGizmos()
        {
            var origin = transform.position;
        
            D.raw(new Shape.Text(origin, gameObject.name));
        
            DrawPaths(forwardPoints, forwardPath, false);
            DrawPaths(backwardPoints, backwardPath, true);
        }

        private void Update()
        {
            DrawPaths(forwardPoints, forwardPath, false);
            DrawPaths(backwardPoints, backwardPath, true);
        }

        private void DrawPaths(IReadOnlyList<TrainTrackPoint> points, int path, bool backward)
        {
            var origin = transform.position;

            if (points == null) return;
            for (var i = 0; i < points.Count; i++)
            {
                var point = points[i];
                if (point == null) continue;

                var destination = point.transform.position;
                var unreachable = !point.gameObject.activeSelf;
                
                var color = (path == i && !unreachable) ? (backward ? BackwardActive : ForwardActive) : Color.red;
                
                var settings = backward ? point.forwardCurveSettings : forwardCurveSettings;

                if (settings.curve == PathInterpolation.Linear)
                {
                    var middleGround = Vector3.Lerp(origin, destination, unreachable ? 1f : 0.5f);
                    var line = new Shape.Line(a: origin, b: middleGround);
            
                    D.raw(line, color);
                }
                else
                {
                    // curves
                    if (settings.curve == PathInterpolation.SphericalManual)
                    {
                        var handle = settings.handle;
                        if (handle == null) continue;
                    }
                    
                    var steps = 16;
                    var pointA = backward ? point : this;
                    var pointB = backward ? this : point;

                    var lastPoint = origin;
                    
                    for (var j = 0; j <= steps; j++)
                    {
                        var t = j / (float) steps;
                        if (!unreachable) t *= 0.5f;
                        if (backward) t = 1 - t;

                        var computedPosition = TramPath.GetPointOnSimulatedPath(t, pointA, pointB);
                        
                        D.raw(new Shape.Line(lastPoint, computedPosition), color);
                        lastPoint = computedPosition;
                    }
                }
            }
        }

        private static readonly Color ForwardActive = Color.green;
        private static readonly Color BackwardActive = new Color(0.4f, 0.6f, 0.5f);
        
#if UNITY_EDITOR
        private void Reset()
        {
            if (instanceId == 0) instanceId = GetInstanceID();
        }
    
        private void OnValidate()
        {
            var point = this;

            if (point.instanceId == 0)
            {
                point.instanceId = point.GetInstanceID();
                EditorUtility.SetDirty(point);
                return;
            }
        
            if (point.instanceId != point.GetInstanceID())
            {
                var oldPoint = EditorUtility.InstanceIDToObject(point.instanceId) as TrainTrackPoint;
                TryConnectNewPoint(oldPoint, point);
            
                point.instanceId = point.GetInstanceID();
                EditorUtility.SetDirty(point);
                return;
            }
        }
    
        private void TryConnectNewPoint(TrainTrackPoint pointA, TrainTrackPoint pointB)
        {
            if (pointA == null || pointB == null) return;
            var originalTarget = pointA;

            var createdPoint = pointB;

            Debug.Log($"{originalTarget} ==> {createdPoint}");
        
            Undo.RecordObjects(new Object[]{ originalTarget, createdPoint }, "Connect New TrainTrackPoint");
            if (originalTarget.forwardPoints == null || originalTarget.forwardPoints.Count == 0 ||
                originalTarget.forwardPoints.All(point => point == null))
            {
                originalTarget.forwardPoints = new List<TrainTrackPoint>();
            }

            originalTarget.forwardPoints.Add(createdPoint);
            
            createdPoint.backwardPoints = new List<TrainTrackPoint> { originalTarget };
            createdPoint.backwardPath = 0;
            createdPoint.forwardPoints = new List<TrainTrackPoint>();
            createdPoint.forwardPath = 0;
            
            PrefabUtility.RecordPrefabInstancePropertyModifications(originalTarget);
            PrefabUtility.RecordPrefabInstancePropertyModifications(createdPoint);
        }
#endif
    }

    public enum PathInterpolation
    {
        Linear,
        SphericalManual,
        SphericalAutomatic,
    }

    public enum StopBehaviour
    {
        InstantClank,
        EaseOut,
    }

    [Serializable]
    public class TrackCurveSettings
    {
        [HideInInspector] public PathInterpolation curve;
        [HideInInspector] public Transform handle;
        [HideInInspector] [Range(1, 90)] public float angle = 90;
        [HideInInspector] public bool flipCurve;
    }
}