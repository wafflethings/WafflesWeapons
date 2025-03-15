using System.Collections.Generic;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

public class SeaBodies : MonoBehaviour
{
	[BurstCompile]
	public struct VibrateSeaBodiesJob : IJobParallelFor
	{
		public float intensity;

		public float deltaTime;

		public float3 cameraPosition;

		public NativeArray<float3> originalPos;

		public NativeArray<float3> originalScale;

		public NativeArray<float3> targetPos;

		public NativeArray<float> speeds;

		public NativeArray<float3> currentPos;

		public NativeArray<Matrix4x4> instanceMatrices;

		public NativeArray<Unity.Mathematics.Random> randomArray;

		public void Execute(int i)
		{
		}
	}

	public float intensity;

	public float speedMin;

	public float speedMax;

	public Texture2D textureAtlas;

	private NativeArray<float3> originalPositions;

	private NativeArray<float3> originalScales;

	private NativeArray<float3> targetPositions;

	private NativeArray<float> speeds;

	private NativeArray<float3> currentPositions;

	private NativeArray<Unity.Mathematics.Random> randomStates;

	private NativeArray<Matrix4x4> instanceMatricesNative;

	private JobHandle jobHandle;

	public Mesh seaBodyMesh;

	public int atlasCount;

	public Material seaBodyMaterial;

	private int[] instanceAtlasOffset;

	private Vector4[] instanceColors;

	private int instanceCount;

	private MaterialPropertyBlock mpb;

	private float[] atlasOffsetBuffer;

	private Vector4[] colorsBuffer;

	private Matrix4x4[] subMatrices;

	private void Start()
	{
	}

	private static List<Transform> FindAllChildrenContainingName(Transform parent, string substring)
	{
		return null;
	}

	public static List<Transform> GetAllLeafChildren(Transform parent)
	{
		return null;
	}

	public static List<Transform> GetLeafChildrenOfAllChunks(Transform root)
	{
		return null;
	}

	private void Update()
	{
	}

	private void LateUpdate()
	{
	}

	private void OnDestroy()
	{
	}
}
