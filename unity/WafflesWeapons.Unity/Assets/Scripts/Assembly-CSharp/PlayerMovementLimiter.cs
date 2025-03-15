using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovementLimiter : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CCancelOnNext_003Ed__8 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PlayerMovementLimiter _003C_003E4__this;

		public Vector3 lastVelocity;

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
		public _003CCancelOnNext_003Ed__8(int _003C_003E1__state)
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

	[SerializeField]
	private float animatorInteractionSpeedCap;

	private Rigidbody rigidbody;

	private Vector3 lastVel;

	private void Awake()
	{
	}

	private void LateUpdate()
	{
	}

	private bool AnimatorCheck(Collision collision)
	{
		return false;
	}

	private void OnCollisionEnter(Collision collision)
	{
	}

	private void OnCollisionStay(Collision collision)
	{
	}

	[IteratorStateMachine(typeof(_003CCancelOnNext_003Ed__8))]
	private IEnumerator CancelOnNext(Vector3 lastVelocity, Vector3 newDelta)
	{
		return null;
	}
}
