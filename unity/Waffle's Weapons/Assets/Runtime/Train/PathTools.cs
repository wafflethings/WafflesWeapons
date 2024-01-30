using UnityEngine;

namespace Train
{
    public static class PathTools
    {
        public static Vector3 InterpolateAlongCircle(Vector3 start, Vector3 end, Vector3 center, float t)
        {
            var startOffset = start - center;
            var endOffset = end - center;
            var interpolatedOffset = Vector3.Slerp(startOffset, endOffset, t);
            return center + interpolatedOffset;
        }

        public static Vector3 ComputeSphericalCurveCenter(Vector3 start, Vector3 end, bool reverse = false, float angle = 45)
        {
            var middle = (start + end) * 0.5f;

            var startToMiddle = middle - start;
            var startToEnd = end - start;

            var isClockwiseTurn = startToEnd.x * startToMiddle.z - startToEnd.z * startToMiddle.x < 0;
            if (reverse) isClockwiseTurn = !isClockwiseTurn;
    
            var rotateAxis = isClockwiseTurn ? new Vector3(0, -1, 0) : new Vector3(0, 1, 0);
            var perpendicularVector = Quaternion.AngleAxis(90, rotateAxis) * (start - middle);

            var center = middle + perpendicularVector.normalized * (start - middle).magnitude / Mathf.Tan(Mathf.Deg2Rad * angle / 2);

            return center;
        }
    }
}