using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Steamworks.Data;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class LevelSelectLeaderboard : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CFetch_003Ed__26 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public string levelName;

		public LevelSelectLeaderboard _003C_003E4__this;

		private Task<LeaderboardEntry[]> _003CentryTask_003E5__2;

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
		public _003CFetch_003Ed__26(int _003C_003E1__state)
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

	public string layerLevelNumber;

	[SerializeField]
	private GameObject scrollRectContainer;

	[SerializeField]
	private GameObject template;

	[SerializeField]
	private TMP_Text templateUsername;

	[SerializeField]
	private TMP_Text templateTime;

	[SerializeField]
	private TMP_Text templateDifficulty;

	[Space]
	[SerializeField]
	private ScrollRect scrollRect;

	[SerializeField]
	private Transform container;

	[Space]
	[SerializeField]
	private Sprite unselectedSprite;

	[SerializeField]
	private Sprite selectedSprite;

	[SerializeField]
	private UnityEngine.UI.Image anyPercentButton;

	[SerializeField]
	private UnityEngine.UI.Image pRankButton;

	[SerializeField]
	private TMP_Text anyPercentLabel;

	[SerializeField]
	private TMP_Text pRankLabel;

	[Space]
	[SerializeField]
	private GameObject loadingPanel;

	[SerializeField]
	private GameObject noItemsPanel;

	[Space]
	[SerializeField]
	private InputActionAsset inputActionAsset;

	[SerializeField]
	private float controllerScrollSpeed;

	private bool pRankSelected;

	private LevelSelectPanel levelSelect;

	private InputAction scrollSublistAction;

	public void RefreshAnyPercent()
	{
	}

	public void RefreshPRank()
	{
	}

	private void OnEnable()
	{
	}

	private void ResetEntries()
	{
	}

	private bool IsLayerSelected()
	{
		return false;
	}

	[IteratorStateMachine(typeof(_003CFetch_003Ed__26))]
	private IEnumerator Fetch(string levelName)
	{
		return null;
	}

	private void Update()
	{
	}

	public void SwitchLeaderboardType(bool pRank)
	{
	}

	private void UpdateLeaderboardScroll()
	{
	}

	private void Start()
	{
	}

	private void Awake()
	{
	}
}
