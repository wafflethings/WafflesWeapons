using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GhostMode : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CEndGhostMode_003Ed__18 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public GhostMode _003C_003E4__this;

		private float _003Ctime_003E5__2;

		private MaterialPropertyBlock _003Cprops_003E5__3;

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
		public _003CEndGhostMode_003Ed__18(int _003C_003E1__state)
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
	private sealed class _003CRunGhostMode_003Ed__17 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public GhostMode _003C_003E4__this;

		private float _003Ctime_003E5__2;

		private MaterialPropertyBlock _003Cprops_003E5__3;

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
		public _003CRunGhostMode_003Ed__17(int _003C_003E1__state)
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

	public GameObject ghostGroup;

	public GameObject ghostLights;

	private GameObject duplicateGhosts;

	private List<GhostDrone> ghostDrones;

	private bool isInGhostMode;

	public GameObject insideLightsGroup;

	public Light[] otherLights;

	private List<Light> lightsToDim;

	private List<float> defaultIntensities;

	private Coroutine crt;

	private Color defaultAmbientColor;

	public Color dimmedAmbientColor;

	public Renderer godRays;

	private Color defaultRayTint;

	public UltrakillEvent onFinish;

	private void Start()
	{
	}

	public void StartGhostMode()
	{
	}

	[IteratorStateMachine(typeof(_003CRunGhostMode_003Ed__17))]
	private IEnumerator RunGhostMode()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CEndGhostMode_003Ed__18))]
	private IEnumerator EndGhostMode()
	{
		return null;
	}

	public void ResetOnRespawn()
	{
	}
}
