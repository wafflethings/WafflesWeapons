using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class FishingHUD : MonoSingleton<FishingHUD>
{
	[CompilerGenerated]
	private sealed class _003CAutoDismissFishCaught_003Ed__49 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public float time;

		public FishingHUD _003C_003E4__this;

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
		public _003CAutoDismissFishCaught_003Ed__49(int _003C_003E1__state)
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
	private sealed class _003CShowSize_003Ed__48 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public FishingHUD _003C_003E4__this;

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
		public _003CShowSize_003Ed__48(int _003C_003E1__state)
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
	private GameObject powerMeterContainer;

	[SerializeField]
	private Slider powerMeter;

	[SerializeField]
	private GameObject hookedContainer;

	[Space]
	[SerializeField]
	private GameObject fishCaughtContainer;

	[SerializeField]
	private Text fishCaughtText;

	[SerializeField]
	private GameObject fishRenderContainer;

	[SerializeField]
	private GameObject fishSizeContainer;

	[Space]
	[SerializeField]
	private GameObject struggleContainer;

	[SerializeField]
	private GameObject outOfWaterMessage;

	[SerializeField]
	private Image struggleProgressIcon;

	[SerializeField]
	private Image struggleProgressIconOverlay;

	[SerializeField]
	private Image struggleNub;

	[SerializeField]
	private RectTransform desireBar;

	[SerializeField]
	private RectTransform fishIcon;

	[SerializeField]
	private Slider struggleProgressSlider;

	[SerializeField]
	private Text struggleLMB;

	[SerializeField]
	private Text struggleRMB;

	[SerializeField]
	private Image upArrow;

	[SerializeField]
	private Image downArrow;

	[Space]
	[SerializeField]
	private Image fishIconTemplate;

	[SerializeField]
	private Transform fishIconContainer;

	private Dictionary<FishObject, Image> fishHudIcons;

	private static Color orangeColor;

	private TimeSince timeSinceLMBReleased;

	private TimeSince timeSinceRMBReleased;

	[HideInInspector]
	public TimeSince timeSinceFishCaught;

	[SerializeField]
	private AudioSource audioSource;

	[SerializeField]
	private AudioClip snareroll;

	[SerializeField]
	private AudioClip snarehit;

	private int amountOfCatches;

	private int longWaits;

	private float containerHeight => 0f;

	private void Start()
	{
	}

	public void ShowHUD()
	{
	}

	public void SetFishHooked(bool hooked)
	{
	}

	private void OnFishUnlocked(FishObject obj)
	{
	}

	protected override void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	public void SetState(FishingRodState state)
	{
	}

	public void SetPowerMeter(float value, bool canFish)
	{
	}

	private void Update()
	{
	}

	public void ShowFishCaught(bool show = true, FishObject fish = null)
	{
	}

	public void ShowOutOfWater()
	{
	}

	public void SetStruggleProgress(float progress, Sprite fishIconLocked, Sprite fishIconUnlocked)
	{
	}

	public void SetStruggleSatisfied(bool satisfied)
	{
	}

	public void SetPlayerStrugglePosition(float pos)
	{
	}

	public void SetFishDesire(float top, float bottom)
	{
	}

	[IteratorStateMachine(typeof(_003CShowSize_003Ed__48))]
	private IEnumerator ShowSize()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CAutoDismissFishCaught_003Ed__49))]
	private IEnumerator AutoDismissFishCaught(float time)
	{
		return null;
	}

	private float RandomizeWaitTime()
	{
		return 0f;
	}
}
