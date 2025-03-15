using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Cork : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CWiggle_003Ed__15 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Cork _003C_003E4__this;

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
		public _003CWiggle_003Ed__15(int _003C_003E1__state)
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

	public float wiggleTime;

	public float wiggleStrength;

	public GameObject vortex;

	public Pond tinter;

	public bool insideSuckZone;

	private Vector3 basePos;

	private float wiggleTimer;

	private Rigidbody rb;

	private Coroutine crt;

	private FloatOnWater floater;

	private bool disallowWiggle;

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void StartWiggle()
	{
	}

	public void StopWiggle()
	{
	}

	[IteratorStateMachine(typeof(_003CWiggle_003Ed__15))]
	private IEnumerator Wiggle()
	{
		return null;
	}
}
