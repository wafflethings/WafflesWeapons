using UnityEngine;

public class ShadowCamera
{
	public static (Matrix4x4 viewMatrix, Matrix4x4 projectionMatrix) RenderShadowMap(Light light, Bounds groupBounds, ref RenderTexture shadowMap, int shadowIndex)
	{
		return default((Matrix4x4, Matrix4x4));
	}

	public static Bounds CalculateGroupBounds(Renderer[] rends)
	{
		return default(Bounds);
	}

	public static (Vector3, Vector3) CalculateCameraParams(Transform lightTransform, Bounds groupBounds)
	{
		return default((Vector3, Vector3));
	}

	private static Vector3[] GetBoundsVertices(Bounds bounds)
	{
		return null;
	}
}
