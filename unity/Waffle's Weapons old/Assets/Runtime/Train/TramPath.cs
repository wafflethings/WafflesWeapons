using UnityEngine;
using Vertx.Debugging;

namespace Train
{
    public class TramPath
    {
        public TramPath(TrainTrackPoint start, bool forward)
        {
            this.start = start;
            this.end = start.GetDestination(forward: forward);
            
            DistanceTotal = CalculateFullDistance();
        }
        
        public TramPath(TrainTrackPoint start, TrainTrackPoint end)
        {
            this.start = start;
            this.end = end;

            DistanceTotal = CalculateFullDistance();
        }
        
        private const int CurveDistanceCalculationSteps = 16;
        private const float TramDirectionCalcStepLength = 0.05f;
        private const float MinSpeedMultiplier = 0.0125f;

        private float CalculateFullDistance()
        {
            return CalculateFullDistance(start, end);
        }
        
        private float CalculateFullDistance(TrainTrackPoint startPoint, TrainTrackPoint endPoint)
        {
            switch (startPoint.forwardCurveSettings.curve)
            {
                case PathInterpolation.Linear:
                    return Vector3.Distance(startPoint.transform.position, endPoint.transform.position);
          
                case PathInterpolation.SphericalAutomatic:
                case PathInterpolation.SphericalManual:
                    var distance = 0f;
                    var lastPosition = startPoint.transform.position;
                    for (var i = 0; i < CurveDistanceCalculationSteps; i++)
                    {
                        var progress = (float) i / CurveDistanceCalculationSteps;
                        var point = GetPointOnSimulatedPath(progress, startPoint, endPoint);
                        
                        var delta = Vector3.Distance(lastPosition, point);
                        lastPosition = point;
                        
                        if (i > 0) distance += delta;
                    }

                    return distance;
            }
            
            return 0f;
        }
        
        public Vector3 GetPointOnPath(float progress)
        {
            return GetPointOnSimulatedPath(progress, start, end);
        }
        
        public static Vector3 GetPointOnSimulatedPath(float progress, TrainTrackPoint startPoint, TrainTrackPoint endPoint)
        {
            var startPosition = startPoint.transform.position;
            var endPosition = endPoint.transform.position;

            var curveSettings = startPoint.forwardCurveSettings;
            
            Vector3 result;
            
            switch (curveSettings.curve)
            {
                case PathInterpolation.SphericalAutomatic:
                    var angle = curveSettings.angle;
                    var flipped = curveSettings.flipCurve;
                    var center = PathTools.ComputeSphericalCurveCenter(startPosition, endPosition, angle: angle, reverse: flipped);
                    result = PathTools.InterpolateAlongCircle(startPosition, endPosition, center, progress);
                    break;
                case PathInterpolation.SphericalManual:
                    var handle = curveSettings.handle;
                    result = PathTools.InterpolateAlongCircle(startPosition, endPosition, handle.position, progress);
                    break;
                default:
                    result = Vector3.Lerp(startPosition, endPosition, progress);
                    break;
            }
            
            return result;
        }

        
        public float MaxSpeedMultiplier(TramMovementDirection direction, float speed)
        {
            if (IsDeadEnd(direction))
            {
                var nextPoint = GetNextPoint(direction);
                switch (nextPoint.stopBehaviour)
                {
                    case StopBehaviour.EaseOut:
                        var decelerationSpeedMulti = 1.5f;
                        var power = 0.85f;
                        
                        var distanceToStop = direction == TramMovementDirection.Forward ? DistanceTotal - distanceTravelled : distanceTravelled;
                        distanceToStop = Mathf.Abs(distanceToStop);
                        
                        if (distanceToStop < speed * decelerationSpeedMulti)
                        {
                            var speedMultiplier = Mathf.Pow(distanceToStop / (speed * decelerationSpeedMulti), power); 
                            return Mathf.Clamp(speedMultiplier, MinSpeedMultiplier, 1);
                        }

                        return 1;

                    default:
                        return 1;
                }
            }

            return 1;
        }

        private Vector3 CalculateCurrentMovementDirection()
        {
            var forwardPointProgress = Progress + TramDirectionCalcStepLength / DistanceTotal;
            Vector3 forwardPoint;
            if (forwardPointProgress > 1)
            {
                var futureDestination = end.GetDestination();
                if (futureDestination != null)
                {
                    var leftover = forwardPointProgress - 1;
                    // This value is for the current path's total distance.
                    // We have to convert it to compensate for the next path possibly having a different length,
                    // And then convert it back
                    var nextDistanceTotal = CalculateFullDistance(end, futureDestination);
                    var nextLeftover = leftover * DistanceTotal / nextDistanceTotal;
                    
                    forwardPoint = GetPointOnSimulatedPath(nextLeftover, end, futureDestination);
                }
                else
                {
                    forwardPoint = GetPointOnPath(Mathf.Clamp01(forwardPointProgress));
                }
                
            }
            else
            {
                forwardPoint = GetPointOnPath(forwardPointProgress);
            }
            
            
            
            // var backwardPointProgress = Progress - TramDirectionCalcStepLength / DistanceTotal;
            // var backwardPoint = GetPointOnPath(backwardPointProgress);
            // D.raw(new Shape.Point(backwardPoint, 5f), Color.red);
            var backwardPointProgress = Progress - TramDirectionCalcStepLength / DistanceTotal;
            Vector3 backwardPoint;
            if (backwardPointProgress < 0)
            {
                var previousStart = start.GetDestination(forward: false);
                if (previousStart != null)
                {
                    var leftover = -backwardPointProgress;
                    var nextDistanceTotal = CalculateFullDistance(previousStart, start);
                    var nextLeftover = leftover * DistanceTotal / nextDistanceTotal ;
                    
                    backwardPoint = GetPointOnSimulatedPath(1 - nextLeftover, previousStart, start);
                }
                else
                {
                    backwardPoint = GetPointOnPath(Mathf.Clamp01(backwardPointProgress));
                }
            }
            else
            {
                backwardPoint = GetPointOnPath(backwardPointProgress);
            }
            
            return (forwardPoint - backwardPoint).normalized;
        }

        public string PrintPathDirectional(TramMovementDirection direction)
        {
            if (direction == TramMovementDirection.None) return $"({start.gameObject.name}) --- ({end.gameObject.name})";
            if (direction == TramMovementDirection.Forward) return $"({start.gameObject.name}) --> ({end.gameObject.name})";
            return $"({start.gameObject.name}) <-- ({end.gameObject.name})";
        }

        public bool IsDeadEnd(TramMovementDirection direction)
        {
            if (direction == TramMovementDirection.None) return false;

            var nextPoint = GetNextPoint(direction);
            return nextPoint.GetDestination(direction == TramMovementDirection.Forward) == null;
        }
        
        public TrainTrackPoint GetNextPoint(TramMovementDirection direction)
        {
            if (direction == TramMovementDirection.None) return null;
            
            var nextPoint = direction == TramMovementDirection.Forward ? end : start;
            return nextPoint;
        }

        public readonly TrainTrackPoint start;
        public readonly TrainTrackPoint end;
        
        public float DistanceTotal { get; private set; }
        public float distanceTravelled;

        public Vector3 MovementDirection()
        {
            return CalculateCurrentMovementDirection();
        }

        public float Progress =>
            (distanceTravelled == 0 && DistanceTotal == 0) ? 0 : distanceTravelled / DistanceTotal; // Avoid NaNs hah

        public override bool Equals(object obj)
        {
            // Compare only start and end
            return obj is TramPath other && (start == other.start && end == other.end);
        }
        
        public override int GetHashCode()
        {
            // Compare only start and end
            return (start, end).GetHashCode();
        }
    }
}