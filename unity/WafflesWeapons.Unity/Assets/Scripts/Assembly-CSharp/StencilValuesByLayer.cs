using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class StencilValuesByLayer : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CLateStart_003Ed__6 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public StencilValuesByLayer _003C_003E4__this;

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
		public _003CLateStart_003Ed__6(int _003C_003E1__state)
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

	public bool applyStencilValue;

	public bool applyRainOutdoors;

	public Shader masterShader;

	private Renderer[] rends;

	private List<Material> reusableMaterials;

	private void Start()
	{
	}

	[IteratorStateMachine(typeof(_003CLateStart_003Ed__6))]
	private IEnumerator LateStart()
	{
		return null;
	}

	public void EnableRain(bool doEnable)
	{
	}
}
