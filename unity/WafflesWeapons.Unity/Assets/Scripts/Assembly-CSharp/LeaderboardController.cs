using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Steamworks.Data;

[ConfigureSingleton(SingletonFlags.PersistAutoInstance)]
public class LeaderboardController : MonoSingleton<LeaderboardController>
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CFetchLeaderboard_003Ed__8 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Leaderboard?> _003C_003Et__builder;

		public LeaderboardController _003C_003E4__this;

		public string key;

		public bool createIfNotFound;

		public LeaderboardSort defaultSortMode;

		private TaskAwaiter<Leaderboard?> _003C_003Eu__1;

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

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CFetchLeaderboardEntries_003Ed__7 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<LeaderboardEntry[]> _003C_003Et__builder;

		public LeaderboardController _003C_003E4__this;

		public string key;

		public bool createIfNotFound;

		public LeaderboardSort defaultSortMode;

		public LeaderboardType type;

		public int count;

		private TaskAwaiter<Leaderboard?> _003C_003Eu__1;

		private TaskAwaiter<LeaderboardEntry[]> _003C_003Eu__2;

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

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CGetCyberGrindScores_003Ed__4 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<LeaderboardEntry[]> _003C_003Et__builder;

		public int difficulty;

		public LeaderboardController _003C_003E4__this;

		public LeaderboardType type;

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

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CGetFishScores_003Ed__5 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<LeaderboardEntry[]> _003C_003Et__builder;

		public LeaderboardController _003C_003E4__this;

		public LeaderboardType type;

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

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CGetLevelScores_003Ed__3 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<LeaderboardEntry[]> _003C_003Et__builder;

		public string levelName;

		public bool pRank;

		public LeaderboardController _003C_003E4__this;

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

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CSubmitCyberGrindScore_003Ed__1 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public int difficulty;

		public LeaderboardController _003C_003E4__this;

		public float wave;

		public int kills;

		public int style;

		public float seconds;

		private int _003CmajorVersion_003E5__2;

		private int _003CminorVersion_003E5__3;

		private int _003CstartWave_003E5__4;

		private StringBuilder _003CstringBuilder_003E5__5;

		private TaskAwaiter<Leaderboard?> _003C_003Eu__1;

		private TaskAwaiter<LeaderboardUpdate?> _003C_003Eu__2;

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

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CSubmitFishSize_003Ed__6 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public LeaderboardController _003C_003E4__this;

		public int fishSize;

		private int _003CmajorVersion_003E5__2;

		private int _003CminorVersion_003E5__3;

		private TaskAwaiter<Leaderboard?> _003C_003Eu__1;

		private TaskAwaiter<LeaderboardUpdate?> _003C_003Eu__2;

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

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CSubmitLevelScore_003Ed__2 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public string levelName;

		public bool pRank;

		public LeaderboardController _003C_003E4__this;

		public float seconds;

		public int difficulty;

		public int kills;

		public int style;

		public int restartCount;

		private int _003CmajorVersion_003E5__2;

		private int _003CminorVersion_003E5__3;

		private StringBuilder _003CstringBuilder_003E5__4;

		private TaskAwaiter<Leaderboard?> _003C_003Eu__1;

		private TaskAwaiter<LeaderboardUpdate?> _003C_003Eu__2;

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

	private readonly Dictionary<string, Leaderboard> cachedLeaderboards;

	[AsyncStateMachine(typeof(_003CSubmitCyberGrindScore_003Ed__1))]
	public void SubmitCyberGrindScore(int difficulty, float wave, int kills, int style, float seconds)
	{
	}

	[AsyncStateMachine(typeof(_003CSubmitLevelScore_003Ed__2))]
	public void SubmitLevelScore(string levelName, int difficulty, float seconds, int kills, int style, int restartCount, bool pRank = false)
	{
	}

	[AsyncStateMachine(typeof(_003CGetLevelScores_003Ed__3))]
	public Task<LeaderboardEntry[]> GetLevelScores(string levelName, bool pRank)
	{
		return null;
	}

	[AsyncStateMachine(typeof(_003CGetCyberGrindScores_003Ed__4))]
	public Task<LeaderboardEntry[]> GetCyberGrindScores(int difficulty, LeaderboardType type)
	{
		return null;
	}

	[AsyncStateMachine(typeof(_003CGetFishScores_003Ed__5))]
	public Task<LeaderboardEntry[]> GetFishScores(LeaderboardType type)
	{
		return null;
	}

	[AsyncStateMachine(typeof(_003CSubmitFishSize_003Ed__6))]
	public void SubmitFishSize(int fishSize)
	{
	}

	[AsyncStateMachine(typeof(_003CFetchLeaderboardEntries_003Ed__7))]
	private Task<LeaderboardEntry[]> FetchLeaderboardEntries(string key, LeaderboardType type, int count = 10, bool createIfNotFound = false, LeaderboardSort defaultSortMode = LeaderboardSort.Descending)
	{
		return null;
	}

	[AsyncStateMachine(typeof(_003CFetchLeaderboard_003Ed__8))]
	private Task<Leaderboard?> FetchLeaderboard(string key, bool createIfNotFound = false, LeaderboardSort defaultSortMode = LeaderboardSort.Descending)
	{
		return null;
	}
}
