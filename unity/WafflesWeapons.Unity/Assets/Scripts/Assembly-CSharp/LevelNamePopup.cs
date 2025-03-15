using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class LevelNamePopup : MonoSingleton<LevelNamePopup>
{
	[CompilerGenerated]
	private sealed class _003CShowLayerText_003Ed__14 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public LevelNamePopup _003C_003E4__this;

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
		public _003CShowLayerText_003Ed__14(int _003C_003E1__state)
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
	private sealed class _003CShowNameText_003Ed__15 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public LevelNamePopup _003C_003E4__this;

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
		public _003CShowNameText_003Ed__15(int _003C_003E1__state)
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

	public TMP_Text layerText;

	private string layerString;

	public TMP_Text nameText;

	private string nameString;

	private bool activated;

	private bool fadingOut;

	private AudioSource aud;

	private float textTimer;

	private int currentLetter;

	private bool countTime;

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void NameAppearDelayed(float delay)
	{
	}

	public void NameAppear()
	{
	}

	[IteratorStateMachine(typeof(_003CShowLayerText_003Ed__14))]
	private IEnumerator ShowLayerText()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CShowNameText_003Ed__15))]
	private IEnumerator ShowNameText()
	{
		return null;
	}
}
