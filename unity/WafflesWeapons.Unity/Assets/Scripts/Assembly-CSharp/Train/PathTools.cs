using UnityEngine;

namespace Train
{
    public static class PathTools
    {
        public static Vector3 InterpolateAlongCircle(Vector3 start, Vector3 end, Vector3 center, float t)
        {
            Vector3 a = start - center;
            Vector3 b = end - center;
            Vector3 b2 = Vector3.Slerp(a, b, t);
            return center + b2;
        }

        public static Vector3 ComputeSphericalCurveCenter(Vector3 start, Vector3 end, bool reverse = false, float angle = 45f)
        {
            Vector3 vector = (start + end) * 0.5f;
            Vector3 vector2 = vector - start;
            Vector3 vector3 = end - start;
            bool flag = vector3.x * vector2.z - vector3.z * vector2.x < 0f;
            if (reverse)
            {
                flag = !flag;
            }
            Vector3 axis = flag ? new Vector3(0f, -1f, 0f) : new Vector3(0f, 1f, 0f);
            return vector + (Quaternion.AngleAxis(90f, axis) * (start - vector)).normalized * (start - vector).magnitude / Mathf.Tan(0.017453292f * angle / 2f);
        }
    }
}
