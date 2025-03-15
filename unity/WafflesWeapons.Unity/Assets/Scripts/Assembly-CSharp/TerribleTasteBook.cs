using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TerribleTasteBook : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CSpinShelf_003Ed__5 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public TerribleTasteBook _003C_003E4__this;

		private Renderer _003Crend_003E5__2;

		private MeshCollider _003Ccol_003E5__3;

		private Transform _003Cparent_003E5__4;

		private Quaternion _003CstartRot_003E5__5;

		private Quaternion _003CendRot_003E5__6;

		private float _003Cprogress_003E5__7;

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
		public _003CSpinShelf_003Ed__5(int _003C_003E1__state)
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

	public float spinTime;

	public Coroutine crt;

	public TerribleTasteBook otherSideBook;

	private void Start()
	{
	}

	public void ActivateBookShelf()
	{
	}

	[IteratorStateMachine(typeof(_003CSpinShelf_003Ed__5))]
	private IEnumerator SpinShelf()
	{
		return null;
	}
}
