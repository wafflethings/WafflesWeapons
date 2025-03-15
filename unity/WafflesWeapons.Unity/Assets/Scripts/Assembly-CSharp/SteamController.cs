using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Sandbox;
using Steamworks;
using Steamworks.Data;
using UnityEngine;
using UnityEngine.UI;
using plog;

public class SteamController : MonoBehaviour
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CFetchAvatar_003Ed__9 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public Friend user;

		public RawImage target;

		private TaskAwaiter<Steamworks.Data.Image?> _003C_003Eu__1;

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
	private struct _003CFetchSteamLeaderboard_003Ed__14 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Leaderboard?> _003C_003Et__builder;

		public bool createIfNotFound;

		public string key;

		public LeaderboardSort sort;

		public LeaderboardDisplay display;

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

	private static readonly plog.Logger Log;

	public static SteamController Instance;

	private Leaderboard? fishBoard;

	[SerializeField]
	private uint appId;

	private static string fishLeaderboard;

	public static readonly ulong[] BuiltInVerifiedSteamIds;

	public static int FishSizeMulti => 0;

	private void Awake()
	{
	}

	[AsyncStateMachine(typeof(_003CFetchAvatar_003Ed__9))]
	public static void FetchAvatar(RawImage target, Friend user)
	{
	}

	public void UpdateTimeInSandbox(float deltaTime)
	{
	}

	public void AddToStatInt(string statKey, int amount)
	{
	}

	public SandboxStats GetSandboxStats()
	{
		return null;
	}

	public void UpdateWave(int wave)
	{
	}

	[AsyncStateMachine(typeof(_003CFetchSteamLeaderboard_003Ed__14))]
	public static Task<Leaderboard?> FetchSteamLeaderboard(string key, bool createIfNotFound = false, LeaderboardSort sort = LeaderboardSort.Descending, LeaderboardDisplay display = LeaderboardDisplay.TimeMilliSeconds)
	{
		return null;
	}

	public void FetchSceneActivity(string scene)
	{
	}

	private void OnApplicationQuit()
	{
	}
}
