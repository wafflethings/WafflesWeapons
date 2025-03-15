using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Train
{
    public class TramPath
    {
        public TramPath(TrainTrackPoint start, bool forward)
        {
            this.start = start;
            end = start.GetDestination(forward);
            DistanceTotal = CalculateFullDistance();
        }

        public TramPath(TrainTrackPoint start, TrainTrackPoint end)
        {
            this.start = start;
            this.end = end;
            DistanceTotal = CalculateFullDistance();
        }

        private float CalculateFullDistance()
        {
            return CalculateFullDistance(start, end);
        }

        private float CalculateFullDistance(TrainTrackPoint startPoint, TrainTrackPoint endPoint)
        {
            PathInterpolation curve = startPoint.forwardCurveSettings.curve;
            if (curve == PathInterpolation.Linear)
            {
                return Vector3.Distance(startPoint.transform.position, endPoint.transform.position);
            }
            if (curve - PathInterpolation.SphericalManual > 1)
            {
                return 0f;
            }
            float num = 0f;
            Vector3 a = startPoint.transform.position;
            for (int i = 0; i < 16; i++)
            {
                Vector3 pointOnSimulatedPath = TramPath.GetPointOnSimulatedPath((float)i / 16f, startPoint, endPoint);
                float num2 = Vector3.Distance(a, pointOnSimulatedPath);
                a = pointOnSimulatedPath;
                if (i > 0)
                {
                    num += num2;
                }
            }
            return num;
        }

        public Vector3 GetPointOnPath(float progress)
        {
            return TramPath.GetPointOnSimulatedPath(progress, start, end);
        }

        public static Vector3 GetPointOnSimulatedPath(float progress, TrainTrackPoint startPoint, TrainTrackPoint endPoint)
        {
            Vector3 position = startPoint.transform.position;
            Vector3 position2 = endPoint.transform.position;
            TrackCurveSettings forwardCurveSettings = startPoint.forwardCurveSettings;
            PathInterpolation curve = forwardCurveSettings.curve;
            Vector3 result;
            if (curve != PathInterpolation.SphericalManual)
            {
                if (curve == PathInterpolation.SphericalAutomatic)
                {
                    float angle = forwardCurveSettings.angle;
                    bool flipCurve = forwardCurveSettings.flipCurve;
                    Vector3 vector = position;
                    Vector3 vector2 = position2;
                    float angle2 = angle;
                    Vector3 center = PathTools.ComputeSphericalCurveCenter(vector, vector2, flipCurve, angle2);
                    result = PathTools.InterpolateAlongCircle(position, position2, center, progress);
                }
                else
                {
                    result = Vector3.Lerp(position, position2, progress);
                }
            }
            else
            {
                Transform handle = forwardCurveSettings.handle;
                result = PathTools.InterpolateAlongCircle(position, position2, handle.position, progress);
            }
            return result;
        }

        public float MaxSpeedMultiplier(TramMovementDirection direction, float speed)
        {
            if (!IsDeadEnd(direction))
            {
                return 1f;
            }
            StopBehaviour stopBehaviour = GetNextPoint(direction).stopBehaviour;
            if (stopBehaviour != StopBehaviour.EaseOut)
            {
                return 1f;
            }
            float num = 1.5f;
            float p = 0.85f;
            float num2 = (direction == TramMovementDirection.Forward) ? (DistanceTotal - distanceTravelled) : distanceTravelled;
            num2 = Mathf.Abs(num2);
            if (num2 < speed * num)
            {
                return Mathf.Clamp(Mathf.Pow(num2 / (speed * num), p), 0.0125f, 1f);
            }
            return 1f;
        }

        private Vector3 CalculateCurrentMovementDirection()
        {
            float num = Progress + 0.05f / DistanceTotal;
            Vector3 a;
            if (num > 1f)
            {
                TrainTrackPoint destination = end.GetDestination(true);
                if (destination != null)
                {
                    float num2 = num - 1f;
                    float num3 = CalculateFullDistance(end, destination);
                    a = TramPath.GetPointOnSimulatedPath(num2 * DistanceTotal / num3, end, destination);
                }
                else
                {
                    a = GetPointOnPath(Mathf.Clamp01(num));
                }
            }
            else
            {
                a = GetPointOnPath(num);
            }
            float num4 = Progress - 0.05f / DistanceTotal;
            Vector3 b;
            if (num4 < 0f)
            {
                TrainTrackPoint destination2 = start.GetDestination(false);
                if (destination2 != null)
                {
                    float num5 = -num4;
                    float num6 = CalculateFullDistance(destination2, start);
                    float num7 = num5 * DistanceTotal / num6;
                    b = TramPath.GetPointOnSimulatedPath(1f - num7, destination2, start);
                }
                else
                {
                    b = GetPointOnPath(Mathf.Clamp01(num4));
                }
            }
            else
            {
                b = GetPointOnPath(num4);
            }
            return (a - b).normalized;
        }

        public string PrintPathDirectional(TramMovementDirection direction)
        {
            if (direction == TramMovementDirection.None)
            {
                return string.Concat(new string[]
                {
                    "(",
                    start.gameObject.name,
                    ") --- (",
                    end.gameObject.name,
                    ")"
                });
            }
            if (direction == TramMovementDirection.Forward)
            {
                return string.Concat(new string[]
                {
                    "(",
                    start.gameObject.name,
                    ") --> (",
                    end.gameObject.name,
                    ")"
                });
            }
            return string.Concat(new string[]
            {
                "(",
                start.gameObject.name,
                ") <-- (",
                end.gameObject.name,
                ")"
            });
        }

        public bool IsDeadEnd(TramMovementDirection direction)
        {
            return direction != TramMovementDirection.None && GetNextPoint(direction).GetDestination(direction == TramMovementDirection.Forward) == null;
        }

        public TrainTrackPoint GetNextPoint(TramMovementDirection direction)
        {
            if (direction == TramMovementDirection.None)
            {
                return null;
            }
            if (direction != TramMovementDirection.Forward)
            {
                return start;
            }
            return end;
        }

        public float DistanceTotal { get; private set; }

        public Vector3 MovementDirection()
        {
            return CalculateCurrentMovementDirection();
        }

        public float Progress
        {
            get
            {
                if (distanceTravelled != 0f || DistanceTotal != 0f)
                {
                    return distanceTravelled / DistanceTotal;
                }
                return 0f;
            }
        }

        public override bool Equals(object obj)
        {
            TramPath tramPath;
            return (tramPath = (obj as TramPath)) != null && start == tramPath.start && end == tramPath.end;
        }

        public override int GetHashCode()
        {
            return new ValueTuple<TrainTrackPoint, TrainTrackPoint>(start, end).GetHashCode();
        }

        private const int CurveDistanceCalculationSteps = 16;

        private const float TramDirectionCalcStepLength = 0.05f;

        private const float MinSpeedMultiplier = 0.0125f;

        public readonly TrainTrackPoint start;

        public readonly TrainTrackPoint end;

        public float distanceTravelled;
    }
}
