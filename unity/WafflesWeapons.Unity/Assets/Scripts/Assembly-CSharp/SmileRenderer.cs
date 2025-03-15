using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Camera))]
[RequireComponent(typeof(RawImage))]
public class SmileRenderer : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CWaitSetup_003Ed__11 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public SmileRenderer _003C_003E4__this;

		private HudOpenEffect _003Copener_003E5__2;

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
		public _003CWaitSetup_003Ed__11(int _003C_003E1__state)
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

	public float width;

	public float height;

	private Camera cam;

	private RenderTexture rt;

	private RawImage displayImage;

	private CanvasScaler scaler;

	private float pixelScale;

	private int pixelWidth;

	private int pixelHeight;

	private void OnValidate()
	{
	}

	private void OnEnable()
	{
	}

	[IteratorStateMachine(typeof(_003CWaitSetup_003Ed__11))]
	private IEnumerator WaitSetup()
	{
		return null;
	}

	private void Setup()
	{
	}

	private void CreateTex()
	{
	}
}
