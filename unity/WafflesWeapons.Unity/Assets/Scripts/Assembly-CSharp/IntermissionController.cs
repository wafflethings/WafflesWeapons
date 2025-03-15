using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class IntermissionController : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CDotAppear_003Ed__18 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public IntermissionController _003C_003E4__this;

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
		public _003CDotAppear_003Ed__18(int _003C_003E1__state)
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

	[CompilerGenerated]
	private sealed class _003CTextAppear_003Ed__17 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public IntermissionController _003C_003E4__this;

		private int _003Cj_003E5__2;

		private int _003Ci_003E5__3;

		private char _003Cc_003E5__4;

		private float _003CwaitTime_003E5__5;

		private bool _003CplaySound_003E5__6;

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
		public _003CTextAppear_003Ed__17(int _003C_003E1__state)
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

	private Text txt;

	private string fullString;

	private string tempString;

	private StringBuilder sb;

	private AudioSource aud;

	private float origPitch;

	private bool waitingForInput;

	private bool skipToInput;

	public UnityEvent onTextEvent;

	public UnityEvent onComplete;

	public string preText;

	[SerializeField]
	private Text preTextText;

	private bool restart;

	private void Start()
	{
	}

	private void OnDisable()
	{
	}

	private void OnEnable()
	{
	}

	private void Update()
	{
	}

	[IteratorStateMachine(typeof(_003CTextAppear_003Ed__17))]
	private IEnumerator TextAppear()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CDotAppear_003Ed__18))]
	private IEnumerator DotAppear()
	{
		return null;
	}
}
