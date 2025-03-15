using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BurningVoxel : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CBurningCoroutine_003Ed__15 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public BurningVoxel _003C_003E4__this;

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
		public _003CBurningCoroutine_003Ed__15(int _003C_003E1__state)
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

	private const float BurnTime = 6f;

	private const float ExtinguishTime = 2f;

	private const float KeepPlayerDamageForFraction = 0.5f;

	private const float KeepDamageForFraction = 0.85f;

	[SerializeField]
	[HideInInspector]
	private VoxelProxy proxy;

	private HurtCooldownCollection hurtCooldownCollection;

	[SerializeField]
	[HideInInspector]
	private FireZone fireZone;

	[SerializeField]
	[HideInInspector]
	private Transform fireParticles;

	[SerializeField]
	[HideInInspector]
	private TimeSince timeSinceInitialized;

	private TimeSince? timeSinceStartedExtinguishing;

	public void Initialize(VoxelProxy proxy)
	{
	}

	private void OnEnable()
	{
	}

	public void Refuel()
	{
	}

	private void Remove()
	{
	}

	private void ReturnFire()
	{
	}

	[IteratorStateMachine(typeof(_003CBurningCoroutine_003Ed__15))]
	private IEnumerator BurningCoroutine()
	{
		return null;
	}

	private void SetSize(float size)
	{
	}
}
