using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

public interface ICheat
{
	[CompilerGenerated]
	private sealed class _003CCoroutine_003Ed__18 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

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
		public _003CCoroutine_003Ed__18(int _003C_003E1__state)
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

	string LongName { get; }

	string Identifier { get; }

	string ButtonEnabledOverride { get; }

	string ButtonDisabledOverride { get; }

	string Icon { get; }

	bool DefaultState { get; }

	StatePersistenceMode PersistenceMode { get; }

	bool IsActive { get; }

	void Enable(CheatsManager manager);

	void Disable();

	[IteratorStateMachine(typeof(_003CCoroutine_003Ed__18))]
	IEnumerator Coroutine(CheatsManager manager)
	{
		return null;
	}
}
