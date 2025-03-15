using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public sealed class SelectionRedirector : Selectable
{
	[CompilerGenerated]
	private sealed class _003CSelectAtEndOfFrame_003Ed__2 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Selectable selectable;

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
		public _003CSelectAtEndOfFrame_003Ed__2(int _003C_003E1__state)
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

	public Selectable[] Selectables;

	public override void OnSelect(BaseEventData eventData)
	{
	}

	[IteratorStateMachine(typeof(_003CSelectAtEndOfFrame_003Ed__2))]
	private IEnumerator SelectAtEndOfFrame(Selectable selectable)
	{
		return null;
	}
}
