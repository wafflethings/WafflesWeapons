using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using TMPro;
using UnityEngine;

public class IntroText : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CDotsAppear_003Ed__23 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public IntroText _003C_003E4__this;

		private int _003Ci_003E5__2;

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
		public _003CDotsAppear_003Ed__23(int _003C_003E1__state)
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
	private sealed class _003CTextAppear_003Ed__20 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public IntroText _003C_003E4__this;

		private int _003Cj_003E5__2;

		private int _003Ci_003E5__3;

		private float _003CwaitTime_003E5__4;

		private bool _003CplaySound_003E5__5;

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
		public _003CTextAppear_003Ed__20(int _003C_003E1__state)
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

	private TMP_Text txt;

	private string fullString;

	private string tempString;

	private StringBuilder sb;

	private bool doneWithDots;

	private bool readyToContinue;

	private bool waitingForInput;

	private AudioSource aud;

	private int dotsAmount;

	private int calibrated;

	public GameObject[] calibrationWindows;

	public GameObject[] activateOnEnd;

	public GameObject[] deactivateOnEnd;

	public GameObject[] activateOnTextTrigger;

	private string colorString;

	private List<int> colorsPositions;

	private List<int> colorsClosePositions;

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void DoneWithSetting()
	{
	}

	[IteratorStateMachine(typeof(_003CTextAppear_003Ed__20))]
	private IEnumerator TextAppear()
	{
		return null;
	}

	private void PlaceColor(int i)
	{
	}

	private void Over()
	{
	}

	[IteratorStateMachine(typeof(_003CDotsAppear_003Ed__23))]
	private IEnumerator DotsAppear()
	{
		return null;
	}
}
