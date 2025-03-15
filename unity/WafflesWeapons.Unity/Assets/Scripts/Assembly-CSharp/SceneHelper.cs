using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

[ConfigureSingleton(SingletonFlags.NoAutoInstance | SingletonFlags.PersistAutoInstance | SingletonFlags.DestroyDuplicates)]
public class SceneHelper : MonoSingleton<SceneHelper>
{
	public struct HitSurfaceData
	{
		public Material material;

		public RaycastHit hit;

		public Mesh mesh;

		public bool useSecondaryBlend;

		public SurfaceType surfaceType;

		public Color particleColor;

		public HitSurfaceData(SurfaceType surfaceType = SurfaceType.Generic, Color surfaceColor = default(Color))
		{
			material = null;
			hit = default(RaycastHit);
			mesh = null;
			useSecondaryBlend = false;
			this.surfaceType = default(SurfaceType);
			particleColor = default(Color);
		}
	}

	public readonly struct PhysicsSceneObjectData
	{
		public Mesh Mesh { get; }

		public Material[] Materials { get; }

		public Vector3 Position { get; }

		public Quaternion Rotation { get; }

		public Vector3 Scale { get; }

		public int Layer { get; }

		public string Name { get; }

		public PhysicsSceneObjectData(Mesh mesh, Material[] materials, Vector3 position, Quaternion rotation, Vector3 scale, int layer, string name)
		{
			Mesh = null;
			Materials = null;
			Position = default(Vector3);
			Rotation = default(Quaternion);
			Scale = default(Vector3);
			Layer = 0;
			Name = null;
		}

		public static bool TryCreateFromObject(Transform transform, out PhysicsSceneObjectData data, bool ignorePhysicsChecks = false)
		{
			data = default(PhysicsSceneObjectData);
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003CLoadSceneAsync_003Ed__70 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public string sceneName;

		public SceneHelper _003C_003E4__this;

		public bool noSplash;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CLoadSceneAsync_003Ed__70(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	private static LayerMask? _footstepLayerMask;

	private readonly List<Material> reusableMaterials;

	[SerializeField]
	private AssetReference finalRoomPit;

	[SerializeField]
	private GameObject loadingBlocker;

	[SerializeField]
	private TMP_Text loadingBar;

	[SerializeField]
	private GameObject preloadingBadge;

	[SerializeField]
	private GameObject eventSystem;

	[Space]
	[SerializeField]
	private AudioMixerGroup masterMixer;

	[SerializeField]
	private AudioMixerGroup musicMixer;

	[SerializeField]
	private AudioMixer allSound;

	[SerializeField]
	private AudioMixer goreSound;

	[SerializeField]
	private AudioMixer musicSound;

	[SerializeField]
	private AudioMixer doorSound;

	[SerializeField]
	private AudioMixer unfreezeableSound;

	[Space]
	[SerializeField]
	private EmbeddedSceneInfo embeddedSceneInfo;

	private Scene footstepScene;

	private PhysicsScene footstepPhysicsScene;

	public bool environmentalHitParticles;

	private readonly List<Color> reusableColors;

	private readonly List<int> reusableTriangles;

	private static LayerMask footstepLayerMask => default(LayerMask);

	public static bool IsPlayingCustom => false;

	public static bool IsSceneRankless => false;

	public static int CurrentLevelNumber => 0;

	public static string CurrentScene { get; private set; }

	public static string LastScene { get; private set; }

	public static string PendingScene { get; private set; }

	public bool TryGetSurfaceData(Vector3 pos, out HitSurfaceData hitSurfaceData)
	{
		hitSurfaceData = default(HitSurfaceData);
		return false;
	}

	public bool TryGetSurfaceData(Vector3 pos, Vector3 direction, float distance, out HitSurfaceData hitSurfaceData)
	{
		hitSurfaceData = default(HitSurfaceData);
		return false;
	}

	private bool TryGetRaycastHitSurfaceData(ref HitSurfaceData hitSurfaceData)
	{
		return false;
	}

	private bool ResolveHitSurfaceData(ref HitSurfaceData hitSurfaceData)
	{
		return false;
	}

	public void ResolveSurfaceType(ref HitSurfaceData hitSurfaceData)
	{
	}

	public void CreateEnviroGibs(RaycastHit hit, int gibAmount = 3, float sizeMultiplier = 1f)
	{
	}

	public void CreateEnviroGibs(ContactPoint hit, int gibAmount = 3, float sizeMultiplier = 1f)
	{
	}

	public void CreateEnviroGibs(Vector3 position, Vector3 direction, float distance, int gibAmount = 3, float sizeMultiplier = 1f)
	{
	}

	public void SetParticlesColors(GameObject target, ref HitSurfaceData hitSurfaceData)
	{
	}

	public void SetParticlesColors(EnviroGibModifier[] modifiers, ref HitSurfaceData hitSurfaceData)
	{
	}

	public void SetParticlesColors(EnviroGibModifier[] modifiers, Color clr)
	{
	}

	private ParticleSystem.MinMaxCurve MultiplyCurve(ParticleSystem.MinMaxCurve curve, float multiplier)
	{
		return default(ParticleSystem.MinMaxCurve);
	}

	protected override void OnEnable()
	{
	}

	private void OnPrefChanged(string key, object value)
	{
	}

	private void OnDisable()
	{
	}

	public bool IsSceneSpecial(string sceneName)
	{
		return false;
	}

	public static bool IsStaticEnvironment(RaycastHit hit)
	{
		return false;
	}

	public static bool IsStaticEnvironment(Collider col)
	{
		return false;
	}

	private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
	}

	public static bool IsValidForPhysicsScene(Transform transform, out MeshRenderer mr, out Collider col)
	{
		mr = null;
		col = null;
		return false;
	}

	private GameObject CreatePhysicsSceneObject(PhysicsSceneObjectData data)
	{
		return null;
	}

	public GameObject AddToPhysicsScene(PhysicsSceneObjectData data, GameObject sourceObject = null)
	{
		return null;
	}

	public GameObject AddMeshToPhysicsScene(Mesh mesh, Material[] materials, Vector3 position, Quaternion rotation, Vector3 scale, int layer, GameObject sourceObject = null)
	{
		return null;
	}

	private void SetUpFootstepPhysicsScene(Scene scene)
	{
	}

	private void DuplicateColliders(Transform[] transforms)
	{
	}

	public static string SanitizeLevelPath(string scene)
	{
		return null;
	}

	public static void ShowLoadingBlocker()
	{
	}

	public static void DismissBlockers()
	{
	}

	public static void LoadScene(string sceneName, bool noBlocker = false)
	{
	}

	[IteratorStateMachine(typeof(_003CLoadSceneAsync_003Ed__70))]
	private IEnumerator LoadSceneAsync(string sceneName, bool noSplash = false)
	{
		return null;
	}

	public static void RestartScene()
	{
	}

	public static void LoadPreviousScene()
	{
	}

	public static void SpawnFinalPitAndFinish()
	{
	}

	public static void SetLoadingSubtext(string text)
	{
	}

	public int? GetLevelIndexAfterIntermission(string intermissionScene)
	{
		return null;
	}
}
