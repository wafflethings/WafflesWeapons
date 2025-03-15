using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ScreenZone : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CPlayMusicRoutine_003Ed__25 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ScreenZone _003C_003E4__this;

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
		public _003CPlayMusicRoutine_003Ed__25(int _003C_003E1__state)
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
	private sealed class _003CStopMusicRoutine_003Ed__26 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ScreenZone _003C_003E4__this;

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
		public _003CStopMusicRoutine_003Ed__26(int _003C_003E1__state)
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

	protected bool inZone;

	protected bool touchMode;

	private GunControl gc;

	private FistControl pun;

	[SerializeField]
	private AudioSource music;

	private float originalVolume;

	[SerializeField]
	private AudioSource jingleMusic;

	[SerializeField]
	private float jingleEndTime;

	private float originalJingleVolume;

	public bool muteMusic;

	[SerializeField]
	private float angleLimit;

	[SerializeField]
	private Transform angleSourceOverride;

	[Space]
	[SerializeField]
	protected UnityEvent onEnterZone;

	[SerializeField]
	protected UnityEvent onExitZone;

	protected GraphicRaycaster raycaster;

	private bool hasEntered;

	private Coroutine musicRoutine;

	private void Awake()
	{
	}

	private void OnDisable()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
	}

	private void OnTriggerExit(Collider other)
	{
	}

	public virtual void UpdatePlayerState(bool active)
	{
	}

	protected virtual void Update()
	{
	}

	private void PlayMusic()
	{
	}

	private void StopMusic()
	{
	}

	[IteratorStateMachine(typeof(_003CPlayMusicRoutine_003Ed__25))]
	private IEnumerator PlayMusicRoutine()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CStopMusicRoutine_003Ed__26))]
	private IEnumerator StopMusicRoutine()
	{
		return null;
	}
}
