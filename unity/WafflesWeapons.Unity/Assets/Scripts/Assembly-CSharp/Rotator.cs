using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Rotator : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CRotate_003Ed__9 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Rotator _003C_003E4__this;

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
		public _003CRotate_003Ed__9(int _003C_003E1__state)
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

	public Vector3 rotation;

	public float rotationTime;

	private Quaternion initialRotation;

	private float rotationProgress;

	public AnimationCurve customCurve;

	public EasingFunction.Ease easingFunction;

	private EasingFunction.Function selectedEasingFunction;

	public UltrakillEvent doAThing;

	public void StartRotate()
	{
	}

	[IteratorStateMachine(typeof(_003CRotate_003Ed__9))]
	private IEnumerator Rotate()
	{
		return null;
	}
}
