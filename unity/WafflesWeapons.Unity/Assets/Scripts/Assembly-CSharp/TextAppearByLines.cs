using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class TextAppearByLines : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CAppearText_003Ed__9 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public TextAppearByLines _003C_003E4__this;

		private int _003CcurrentChar_003E5__2;

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
		public _003CAppearText_003Ed__9(int _003C_003E1__state)
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
	private float delay;

	private AudioSource aud;

	private TMP_Text tmp;

	private string fullText;

	private Coroutine coroutine;

	[SerializeField]
	private AudioClip errorSound;

	[SerializeField]
	private AudioClip warningSound;

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	[IteratorStateMachine(typeof(_003CAppearText_003Ed__9))]
	private IEnumerator AppearText()
	{
		return null;
	}

	private void OnDisable()
	{
	}

	public void Stop()
	{
	}
}
