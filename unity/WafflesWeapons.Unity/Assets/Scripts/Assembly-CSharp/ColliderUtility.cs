using System.Collections.Generic;
using NewBlood.Rendering;
using UnityEngine;

public static class ColliderUtility
{
	private static readonly List<Vector3> s_Vertices;

	private static readonly List<int> s_Triangles;

	private static Triangle<Vector3> GetTriangle(int index)
	{
		return default(Triangle<Vector3>);
	}

	private static Plane GetTrianglePlane(Transform collider, int index)
	{
		return default(Plane);
	}

	private static Plane GetTrianglePlane(Triangle<Vector3> source)
	{
		return default(Plane);
	}

	private static bool InTriangle(Vector3 a, Vector3 b, Vector3 c, Vector3 p)
	{
		return false;
	}

	public static Vector3 FindClosestPoint(Collider collider, Vector3 position)
	{
		return default(Vector3);
	}

	public static Vector3 FindClosestPoint(Collider collider, Vector3 position, bool ignoreVerticalTriangles)
	{
		return default(Vector3);
	}
}
