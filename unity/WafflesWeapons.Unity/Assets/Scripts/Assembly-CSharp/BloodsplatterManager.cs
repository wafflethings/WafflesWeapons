using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class BloodsplatterManager : MonoSingleton<BloodsplatterManager>
{
	public struct InstanceProperties
	{
		public Vector3 pos;

		public Vector3 norm;

		public int parentIndex;

		public int clipToSurface;

		public const int SIZE = 32;
	}

	public struct ClearJob : IJobParallelFor
	{
		[WriteOnly]
		public NativeArray<InstanceProperties> props;

		public void Execute(int index)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CInitPools_003Ed__84 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public BloodsplatterManager _003C_003E4__this;

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
		public _003CInitPools_003Ed__84(int _003C_003E1__state)
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

	public float normalForgiveness;

	public bool forceOn;

	public bool forceGibs;

	public bool neverFreezeGibs;

	public bool overrideBloodstainChance;

	public float bloodstainChance;

	public GameObject head;

	public GameObject limb;

	public GameObject body;

	public GameObject small;

	public GameObject smallest;

	public GameObject splatter;

	public GameObject underwater;

	public GameObject sand;

	public GameObject blessing;

	public GameObject chestExplosion;

	public GameObject brainChunk;

	public GameObject skullChunk;

	public GameObject eyeball;

	public GameObject jawChunk;

	public GameObject[] gib;

	public GameObject bloodStain;

	public Shader bloodCompositeShader;

	private Material bloodCompositeMaterial;

	public Mesh stainMesh;

	public Material stainMat;

	public NativeArray<InstanceProperties> checkpointProps;

	public NativeArray<InstanceProperties> props;

	public NativeArray<Matrix4x4> parents;

	public ComputeBuffer instanceBuffer;

	public ComputeBuffer parentBuffer;

	private int checkpointPropIndex;

	private int propIndex;

	private int parentIndex;

	private Dictionary<BSType, Queue<GameObject>> gorePool;

	private Dictionary<BSType, int> defaultHPValues;

	private int order;

	private Transform goreStore;

	public bool hasBloodFillers;

	public HashSet<GameObject> bloodFillers;

	public AudioMixerGroup goreAudioGroup;

	public AudioClip splatterClip;

	[HideInInspector]
	public int bloodDestroyers;

	[HideInInspector]
	public int bloodAbsorbers;

	[HideInInspector]
	public int bloodAbsorberChildren;

	public ClearJob clearJob;

	public const float PARTICLE_COLLISION_STEP_DT = 0.128f;

	public TimeSince sinceLastStep;

	private OptionsManager opm;

	private CommandBuffer cb;

	public bool usedComputeShadersAtStart;

	public bool goreOn => false;

	public event Action<int> reuseParentIndex
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event Action<int> reuseStainIndex
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event Action StainsCleared
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event Action<float> ParticleCollisionStep
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event Action PostCollisionStep
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public void SaveBloodstains()
	{
	}

	public void LoadBloodstains()
	{
	}

	public int CreateBloodstain(Vector3 pos, Vector3 norm, bool clipToSurface, int parent = 0)
	{
		return 0;
	}

	public void DeleteBloodstain(int index)
	{
	}

	public int CreateParent(Matrix4x4 initialMatrix)
	{
		return 0;
	}

	public float GetBloodstainChance()
	{
		return 0f;
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void LateUpdate()
	{
	}

	public void ClearStains()
	{
	}

	public void SetupBloodCommandBuffer(Camera mainCam, RenderTexture mainTex, RenderTexture bloodCopy, RenderTexture depth)
	{
	}

	protected override void OnEnable()
	{
	}

	protected override void OnDestroy()
	{
	}

	private GameObject GetPrefabByBSType(BSType bloodType)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CInitPools_003Ed__84))]
	private IEnumerator InitPools()
	{
		return null;
	}

	private void InitPool(BSType bloodSplatterType)
	{
	}

	public void RepoolGore(Bloodsplatter bs, BSType type)
	{
	}

	public void RepoolGore(GameObject go, BSType type)
	{
	}

	private void ReturnToQueue(GameObject go, BSType type)
	{
	}

	public GameObject GetFromQueue(BSType type)
	{
		return null;
	}

	public GameObject GetGore(GoreType got, EnemyIdentifier eid, bool fromExplosion = false)
	{
		return null;
	}

	public GameObject GetGore(GoreType got, bool isUnderwater = false, bool isSandified = false, bool isBlessed = false, EnemyIdentifier eid = null, bool fromExplosion = false)
	{
		return null;
	}

	private void PrepareGore(GameObject gob, int healthChange = -1, EnemyIdentifier eid = null, bool fromExplosion = false)
	{
	}

	public GameObject GetGib(BSType type)
	{
		return null;
	}

	private AudioSource GetOriginalAudio(GoreType got)
	{
		return null;
	}

	private float GetSplatterWeight(GoreType got)
	{
		return 0f;
	}
}
