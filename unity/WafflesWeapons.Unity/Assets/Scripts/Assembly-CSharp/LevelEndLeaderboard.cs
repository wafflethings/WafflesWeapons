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

public class LevelEndLeaderboard : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CFetch_003Ed__12 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public string levelName;

		public LevelEndLeaderboard _003C_003E4__this;

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
		public _003CFetch_003Ed__12(int _003C_003E1__state)
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
	private GameObject template;

	[SerializeField]
	private TMP_Text templateUsername;

	[SerializeField]
	private TMP_Text templateTime;

	[SerializeField]
	private TMP_Text templateDifficulty;

	[Space]
	[SerializeField]
	private Transform container;

	[SerializeField]
	private TMP_Text leaderboardType;

	[SerializeField]
	private TMP_Text switchTypeInput;

	[Space]
	[SerializeField]
	private GameObject loadingPanel;

	private bool displayPRank;

	private InputControlScheme keyboardControlScheme;

	private const string LeftBracket = "<color=white>[";

	private const string RightBracket = "]</color>";

	private void Start()
	{
	}

	private void OnEnable()
	{
	}

	[IteratorStateMachine(typeof(_003CFetch_003Ed__12))]
	private IEnumerator Fetch(string levelName)
	{
		return null;
	}

	private void ResetEntries()
	{
	}

	private void Update()
	{
	}
}
