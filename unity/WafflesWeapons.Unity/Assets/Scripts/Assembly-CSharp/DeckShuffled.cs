using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

internal class DeckShuffled<T> : IEnumerable<T>, IEnumerable
{
	[CompilerGenerated]
	private sealed class _003CRandomize_003Ed__3 : IEnumerable<T>, IEnumerable, IEnumerator<T>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private T _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private IEnumerable<T> source;

		public IEnumerable<T> _003C_003E3__source;

		private T[] _003Carr_003E5__2;

		private int _003Ci_003E5__3;

		private int _003CswapIndex_003E5__4;

		T IEnumerator<T>.Current
		{
			[DebuggerHidden]
			get
			{
				return default(T);
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
		public _003CRandomize_003Ed__3(int _003C_003E1__state)
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

		[DebuggerHidden]
		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			return null;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}
	}

	private List<T> current;

	public DeckShuffled(IEnumerable<T> target)
	{
	}

	public void Reshuffle()
	{
	}

	[IteratorStateMachine(typeof(DeckShuffled<>._003CRandomize_003Ed__3))]
	private static IEnumerable<T> Randomize(IEnumerable<T> source)
	{
		return null;
	}

	public IEnumerator<T> GetEnumerator()
	{
		return null;
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return null;
	}
}
