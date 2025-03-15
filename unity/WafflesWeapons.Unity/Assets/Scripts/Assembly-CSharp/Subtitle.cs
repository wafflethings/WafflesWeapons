using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class Subtitle : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CFitAsync_003Ed__22 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Subtitle _003C_003E4__this;

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
		public _003CFitAsync_003Ed__22(int _003C_003E1__state)
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

	public AudioSource distanceCheckObject;

	public Subtitle nextInChain;

	[SerializeField]
	private float fadeInSpeed;

	[SerializeField]
	private float holdForBase;

	[SerializeField]
	private float holdForPerChar;

	[SerializeField]
	private float fadeOutSpeed;

	[SerializeField]
	private float paddingHorizontal;

	[SerializeField]
	private TMP_Text uiText;

	private CanvasGroup group;

	private float currentAlpha;

	private bool isFadingIn;

	private bool chainContinue;

	private float holdFor;

	private bool isFadingOut;

	private TimeSince holdingSince;

	private RectTransform rectTransform;

	private float baseAlpha;

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	public void ContinueChain()
	{
	}

	private void Update()
	{
	}

	private void Fit()
	{
	}

	[IteratorStateMachine(typeof(_003CFitAsync_003Ed__22))]
	private IEnumerator FitAsync()
	{
		return null;
	}
}
