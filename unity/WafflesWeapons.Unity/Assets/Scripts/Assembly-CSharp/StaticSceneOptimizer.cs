using System;
using System.Collections.Generic;
using NewBlood.Interop;
using UnityEngine;
using UnityEngine.Rendering;

[ExecuteInEditMode]
[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class StaticSceneOptimizer : MonoSingleton<StaticSceneOptimizer>
{
	public enum BakingMode
	{
		Stationary = 0
	}

	public struct LightData
	{
		public Vector3 lightPosition;

		public Vector3 lightAtten;

		public Vector3 lightDir;

		public Vector3 lightColor;
	}

	public struct FullLightData
	{
		public Vector4 lightPosition_shadowFormat;

		public Vector4 lightAtten_shadowIndex;

		public Vector4 lightDir_shadowStrength;

		public Vector4 lightColor;

		public Matrix4x4 viewMatrix;

		public Matrix4x4 projectionMatrix;
	}

	public BakingMode bakeMode;

	[Space(10f)]
	[SerializeField]
	private StaticSceneData bakedDataAsset;

	[SerializeField]
	private List<Texture2D> devTexturesToSpot;

	[SerializeField]
	public List<Type> ignoreTypes;

	public bool warnNonStaticLights;

	public bool warnLightInGoreZone;

	public bool warnNonStaticObjects;

	public bool warnWrongObjectLayers;

	public bool warnNotUsingMasterShader;

	public bool warnMismatchedShaderKeywords;

	public bool warnMissingMeshFilter;

	public bool warnMissingMesh;

	public bool warnSubmeshIssues;

	public bool warnOddNegativeScaling;

	public bool randomColorAtlas;

	[HideInInspector]
	[SerializeField]
	private BakingMode currentBakedMode;

	[HideInInspector]
	[SerializeField]
	public List<Light> globalLights;

	[HideInInspector]
	[SerializeField]
	private List<MeshRenderer> staticMRends;

	[HideInInspector]
	[SerializeField]
	private int bakedTextureCount;

	[HideInInspector]
	[SerializeField]
	private bool nothingBaked;

	[HideInInspector]
	[SerializeField]
	private bool isDirty;

	[HideInInspector]
	[SerializeField]
	private bool uv0Baked;

	[HideInInspector]
	[SerializeField]
	private bool uv1Baked;

	[HideInInspector]
	[SerializeField]
	public Material batchMaterialOutdoors;

	[HideInInspector]
	[SerializeField]
	private Material batchMaterialEnvironment;

	private int enviroLayer;

	private int enviroBakedLayer;

	private int outdoorLayer;

	private int outdoorBakedLayer;

	private Vector3 disabledLight;

	private List<Material> reusableMaterials;

	private HashSet<int> testHashes;

	private LocalKeyword[] matchKeywords;

	private LightData[] globalLightData;

	private ComputeBuffer cbMRLightIndices;

	private ComputeBuffer cbGlobalLightsData;

	private ComputeBuffer cbGlobalFullLightsData;

	private RenderTexture directionalShadows;

	private RenderTexture pointSpotShadows;

	private List<MeshRenderer> tempMRends;

	private List<Color> reusableColors;

	private string VERTEX_LIGHTING;

	private string VERTEX_BLENDING;

	private static readonly Action<Renderer, int, int> s_SetStaticBatchInfo;

	[HideInInspector]
	[SerializeField]
	private bool bakeCompleted => false;

	public static void SetStaticBatchInfo(Renderer renderer, int firstSubMesh, int subMeshCount)
	{
	}

	private void SetupMaterial(bool isBaking = false)
	{
	}

	private void Start()
	{
	}

	private void FixPosition()
	{
	}

	private void SetGlobalBufferData()
	{
	}

	private void SetupMeshes()
	{
	}

	private StaticBatchInfo ApplyStaticBatchingInfo(int i, Renderer destination)
	{
		return default(StaticBatchInfo);
	}

	private void Update()
	{
	}

	private void LateUpdate()
	{
	}

	public void UpdateRain(bool doEnable)
	{
	}

	private void UpdateLightBuffer()
	{
	}

	public void GetSurfaceType(MeshRenderer mRend)
	{
	}

	private new void OnDestroy()
	{
	}
}
