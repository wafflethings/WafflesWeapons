using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class ForceLayoutRebuilds : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CDelayedRebuild_003Ed__8 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ForceLayoutRebuilds _003C_003E4__this;

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
		public _003CDelayedRebuild_003Ed__8(int _003C_003E1__state)
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

	public int iterations;

	public bool onEnable;

	public bool allChildLayoutElements;

	public ScrollRect scrollRectToReset;

	private RectTransform rectTransform;

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	public void ForceRebuild()
	{
	}

	[IteratorStateMachine(typeof(_003CDelayedRebuild_003Ed__8))]
	private IEnumerator DelayedRebuild()
	{
		return null;
	}
}
