using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class ScrollingText : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CPrepText_003Ed__15 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ScrollingText _003C_003E4__this;

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
		public _003CPrepText_003Ed__15(int _003C_003E1__state)
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
	private sealed class _003CShowText_003Ed__16 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public TMP_Text text;

		public float secondsBetweenLetters;

		public string message;

		public bool writingCursor;

		public bool skipLineBreaks;

		public bool fillMissingText;

		public AudioSource clickAudio;

		private TimeSince _003CtextTimer_003E5__2;

		private int _003CcurrentLetter_003E5__3;

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
		public _003CShowText_003Ed__16(int _003C_003E1__state)
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

	public bool oneTime;

	[HideInInspector]
	public bool activated;

	[HideInInspector]
	public bool gotValues;

	[HideInInspector]
	public TMP_Text text;

	[HideInInspector]
	public string message;

	[HideInInspector]
	public AudioSource aud;

	private Coroutine messageRoutine;

	public float secondsBetweenLetters;

	public bool fillMissingText;

	public bool writingCursor;

	public UltrakillEvent onComplete;

	private void Awake()
	{
	}

	private void GetValues()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	[IteratorStateMachine(typeof(_003CPrepText_003Ed__15))]
	private IEnumerator PrepText()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CShowText_003Ed__16))]
	public static IEnumerator ShowText(TMP_Text text, string message, float secondsBetweenLetters = 0.005f, AudioSource clickAudio = null, bool fillMissingText = false, bool skipLineBreaks = false, bool writingCursor = false)
	{
		return null;
	}
}
