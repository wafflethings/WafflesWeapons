using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;

public class BloodAbsorber : MonoBehaviour, IBloodstainReceiver
{
	private struct CollisionData
	{
		public Vector3 position;

		public float distance;
	}

	[CompilerGenerated]
	private sealed class _003CCheckFill_003Ed__45 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public BloodAbsorber _003C_003E4__this;

		private int _003CtimesChecked_003E5__2;

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
		public _003CCheckFill_003Ed__45(int _003C_003E1__state)
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

	[CompilerGenerated]
	private sealed class _003CClearedAbsorber_003Ed__46 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public BloodAbsorber _003C_003E4__this;

		private float _003Ctime_003E5__2;

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
		public _003CClearedAbsorber_003Ed__46(int _003C_003E1__state)
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

	public string painterName;

	public Shader absorptionShader;

	public Texture noiseTex;

	public Texture2D visibilityMask;

	public int texelsPerWorldUnit;

	public float forgivenessCutoff;

	public float bloodUpdateRate;

	public float timeUntilSleep;

	public bool clearBlood;

	public bool fillBlood;

	[SerializeField]
	private float maxFill;

	[HideInInspector]
	public float fillAmount;

	public bool isCompleted;

	private float sleepTimer;

	private bool isWashing;

	private float bloodTimer;

	private bool isSleeping;

	private CommandBuffer cb;

	private Material absMat;

	public RenderTexture paintBuffer;

	public RenderTexture bloodMap;

	public RenderTexture clampedMap;

	public RenderTexture dilationMask;

	public RenderTexture bloodMapCheckpoint;

	private MeshRenderer[] absorbers;

	private MeshFilter[] absorberMFs;

	private MaterialPropertyBlock propBlock;

	private ComputeBuffer cbuff;

	[HideInInspector]
	public GameObject owningRoom;

	private BloodCheckerManager bcm;

	[SerializeField]
	private AudioSource cleanSuccess;

	public Cubemap cleanedMap;

	private List<CollisionData> collisionDataList;

	private Coroutine checkFillRoutine;

	private float baseAccuracy;

	private void Start()
	{
	}

	public void ToggleHigherAccuracy(bool isOn)
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	public void StartCheckingFill()
	{
	}

	public void StoreBloodCopy()
	{
	}

	public void RestoreBloodCopy()
	{
	}

	private void OnCollisionEnter(Collision collision)
	{
	}

	private void OnCollisionExit(Collision collision)
	{
	}

	[IteratorStateMachine(typeof(_003CCheckFill_003Ed__45))]
	private IEnumerator CheckFill()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CClearedAbsorber_003Ed__46))]
	private IEnumerator ClearedAbsorber()
	{
		return null;
	}

	private void UnclearedAbsorber()
	{
	}

	private void AsyncGetFilledSpace(AsyncGPUReadbackRequest request)
	{
	}

	private void AsyncGetCurrentFillAmount(AsyncGPUReadbackRequest request)
	{
	}

	private void OnValidate()
	{
	}

	private void InitializeRTs()
	{
	}

	private void InitializeDilationMask()
	{
	}

	private void Update()
	{
	}

	public bool HandleBloodstainHit(ref RaycastHit hit)
	{
		return false;
	}

	public void ProcessWasherSpray(ref List<ParticleCollisionEvent> pEvents, Vector3 position)
	{
	}
}
