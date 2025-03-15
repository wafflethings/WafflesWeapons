using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TimeBomb : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CCheckDisabled_003Ed__19 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public TimeBomb _003C_003E4__this;

		private WaitForEndOfFrame _003CwaitForEnd_003E5__2;

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
		public _003CCheckDisabled_003Ed__19(int _003C_003E1__state)
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

	public bool dontStartOnAwake;

	private bool activated;

	public float timer;

	public float beeptimer;

	public bool freezeOnNoCooldown;

	private AudioSource aud;

	public GameObject beepLight;

	public float beeperSize;

	[HideInInspector]
	public float beeperSizeMultiplier;

	private GameObject beeper;

	private Vector3 origScale;

	public Color beeperColor;

	private SpriteRenderer beeperSpriteRenderer;

	public float beeperPitch;

	public GameObject explosion;

	public bool dontExplode;

	private bool isActive;

	private void Start()
	{
	}

	private void OnEnable()
	{
	}

	[IteratorStateMachine(typeof(_003CCheckDisabled_003Ed__19))]
	private IEnumerator CheckDisabled()
	{
		return null;
	}

	private void OnDestroy()
	{
	}

	private void Update()
	{
	}

	public void StartCountdown()
	{
	}

	private void Beep()
	{
	}
}
