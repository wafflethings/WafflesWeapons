using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class HudMessageReceiver : MonoSingleton<HudMessageReceiver>
{
	[CompilerGenerated]
	private sealed class _003CPrepText_003Ed__17 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public HudMessageReceiver _003C_003E4__this;

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
		public _003CPrepText_003Ed__17(int _003C_003E1__state)
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

	private Image img;

	[HideInInspector]
	public TMP_Text text;

	private AudioSource aud;

	private AudioSource clickAud;

	private HudOpenEffect hoe;

	private string message;

	private string input;

	private bool inputPreProcessed;

	private string message2;

	private bool noSound;

	private Coroutine messageRoutine;

	private bool timer;

	private string fullMessage;

	private void Start()
	{
	}

	private void Done()
	{
	}

	public void SendHudMessage(string newmessage, string newinput = "", string newmessage2 = "", int delay = 0, bool silent = false, bool inputBeenProcessed = false, bool automaticTimer = true)
	{
	}

	private void ShowHudMessage()
	{
	}

	[IteratorStateMachine(typeof(_003CPrepText_003Ed__17))]
	private IEnumerator PrepText()
	{
		return null;
	}

	public void ForceEnable()
	{
	}

	public void ClearMessage()
	{
	}
}
