using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class LevelSelectAct : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CSwitchLeaderboardsSequence_003Ed__7 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public LayerSelect layer;

		public bool pRank;

		private LevelSelectLeaderboard[] _003C_003E7__wrap1;

		private int _003C_003E7__wrap2;

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
		public _003CSwitchLeaderboardsSequence_003Ed__7(int _003C_003E1__state)
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

	private LayerSelect[] childLayers;

	private PlayerInput inputSource;

	private bool currentLeaderboardMode;

	private void Awake()
	{
	}

	private void Update()
	{
	}

	public void ChangeLeaderboardType(bool pRank)
	{
	}

	private void OnDisable()
	{
	}

	[IteratorStateMachine(typeof(_003CSwitchLeaderboardsSequence_003Ed__7))]
	private IEnumerator SwitchLeaderboardsSequence(LayerSelect layer, bool pRank)
	{
		return null;
	}
}
