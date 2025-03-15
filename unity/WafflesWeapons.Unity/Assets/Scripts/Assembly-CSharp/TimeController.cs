using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Audio;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class TimeController : MonoSingleton<TimeController>
{
	[CompilerGenerated]
	private sealed class _003CTimeIsStopped_003Ed__21 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public float length;

		public TimeController _003C_003E4__this;

		public bool trueStop;

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
		public _003CTimeIsStopped_003Ed__21(int _003C_003E1__state)
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
	private GameObject parryLight;

	[SerializeField]
	private GameObject parryFlash;

	private float currentStop;

	private AudioMixer[] audmix;

	[HideInInspector]
	public bool controlTimeScale;

	[HideInInspector]
	public bool controlPitch;

	[HideInInspector]
	public bool parryFlashEnabled;

	public float timeScale;

	public float timeScaleModifier;

	private float slowDown;

	protected override void Awake()
	{
	}

	protected override void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnPrefChanged(string id, object value)
	{
	}

	private void Update()
	{
	}

	private void FixedUpdate()
	{
	}

	public void ParryFlash()
	{
	}

	private void HideFlash()
	{
	}

	public void SlowDown(float amount)
	{
	}

	public void HitStop(float length)
	{
	}

	public void TrueStop(float length)
	{
	}

	[IteratorStateMachine(typeof(_003CTimeIsStopped_003Ed__21))]
	private IEnumerator TimeIsStopped(float length, bool trueStop)
	{
		return null;
	}

	private void ContinueTime(float length, bool trueStop)
	{
	}

	public void RestoreTime()
	{
	}

	public void SetAllPitch(float pitch)
	{
	}
}
