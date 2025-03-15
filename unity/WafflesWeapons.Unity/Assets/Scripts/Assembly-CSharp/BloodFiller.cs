using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BloodFiller : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CFillBlood_003Ed__22 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public BloodFiller _003C_003E4__this;

		public float amount;

		private float _003Ctimer_003E5__2;

		private float _003CinitialFillAmount_003E5__3;

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
		public _003CFillBlood_003Ed__22(int _003C_003E1__state)
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

	public float fullFillThreshold;

	public float fillSpeed;

	public float fillTimePerHit;

	public float fillAmount;

	[HideInInspector]
	public bool fullyFilled;

	private AudioSource aud;

	private Bounds meshBounds;

	private Renderer rend;

	private MaterialPropertyBlock propBlock;

	private MeshFilter mf;

	private Collider col;

	public GameObject bloodIngestParticle;

	private float heartBeatCooldown;

	public UltrakillEvent onFullyFilled;

	private List<int> eids;

	private List<float> eidCooldowns;

	private List<float> eidAmounts;

	private void Start()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void Update()
	{
	}

	public void FillBloodSlider(float amount, Vector3 position, int eidID = 0)
	{
	}

	[IteratorStateMachine(typeof(_003CFillBlood_003Ed__22))]
	private IEnumerator FillBlood(float amount)
	{
		return null;
	}

	private void FullyFilled()
	{
	}

	public void InstaFill()
	{
	}
}
