using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Steamworks.Data;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class FinalCyberRank : MonoBehaviour
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CFetchTheScores_003Ed__56 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public FinalCyberRank _003C_003E4__this;

		private int _003Cdifficulty_003E5__2;

		private TaskAwaiter<LeaderboardEntry[]> _003C_003Eu__1;

		private void MoveNext()
		{
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[CompilerGenerated]
	private sealed class _003CInvokeRealtimeCoroutine_003Ed__61 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public float seconds;

		public UnityAction action;

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
		public _003CInvokeRealtimeCoroutine_003Ed__61(int _003C_003E1__state)
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

	public TMP_Text waveText;

	public TMP_Text killsText;

	public TMP_Text styleText;

	public TMP_Text timeText;

	public TMP_Text bestWaveText;

	public TMP_Text bestKillsText;

	public TMP_Text bestStyleText;

	public TMP_Text bestTimeText;

	public TMP_Text pointsText;

	public int totalPoints;

	public GameObject[] toAppear;

	private bool skipping;

	private float timeBetween;

	private bool countTime;

	public float savedTime;

	private float checkedSeconds;

	private float seconds;

	private float minutes;

	private bool countWaves;

	public float savedWaves;

	private float checkedWaves;

	private bool countKills;

	public int savedKills;

	private float checkedKills;

	private bool countStyle;

	public int savedStyle;

	private float checkedStyle;

	private bool flashFade;

	private UnityEngine.Color flashColor;

	private UnityEngine.UI.Image flashPanel;

	private int i;

	private bool gameOver;

	private bool complete;

	private CyberRankData previousBest;

	private bool newBest;

	private TimeController timeController;

	private OptionsManager opm;

	private bool wasPaused;

	private StatsManager sman;

	private bool highScoresDisplayed;

	[SerializeField]
	private GameObject[] previousElements;

	[SerializeField]
	private GameObject highScoreElement;

	[SerializeField]
	private GameObject friendContainer;

	[SerializeField]
	private GameObject globalContainer;

	[SerializeField]
	private GameObject friendPlaceholder;

	[SerializeField]
	private GameObject globalPlaceholder;

	[SerializeField]
	private GameObject template;

	[SerializeField]
	private TMP_Text tRank;

	[SerializeField]
	private TMP_Text tUsername;

	[SerializeField]
	private TMP_Text tScore;

	[SerializeField]
	private TMP_Text tPercent;

	private void Start()
	{
	}

	public void GameOver()
	{
	}

	private void NewBest()
	{
	}

	private void Update()
	{
	}

	private int CalculatePerc(float value)
	{
		return 0;
	}

	[AsyncStateMachine(typeof(_003CFetchTheScores_003Ed__56))]
	private void FetchTheScores()
	{
	}

	private static string TruncateUsername(string value, int maxChars)
	{
		return null;
	}

	public void Appear()
	{
	}

	public void FlashPanel(GameObject panel)
	{
	}

	private void PointsShow()
	{
	}

	[IteratorStateMachine(typeof(_003CInvokeRealtimeCoroutine_003Ed__61))]
	private IEnumerator InvokeRealtimeCoroutine(UnityAction action, float seconds)
	{
		return null;
	}
}
