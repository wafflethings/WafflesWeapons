using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class SimpleMeshCombineManager : MonoSingleton<SimpleMeshCombineManager>
{
	[CompilerGenerated]
	private sealed class _003CProcessCombiners_003Ed__3 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public SimpleMeshCombineManager _003C_003E4__this;

		private WaitForSeconds _003CwaitTime_003E5__2;

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
		public _003CProcessCombiners_003Ed__3(int _003C_003E1__state)
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

	public float waitTimeUntilProcess;

	private Queue<SimpleMeshCombiner> combinersQueue;

	private void Start()
	{
	}

	[IteratorStateMachine(typeof(_003CProcessCombiners_003Ed__3))]
	private IEnumerator ProcessCombiners()
	{
		return null;
	}
}
