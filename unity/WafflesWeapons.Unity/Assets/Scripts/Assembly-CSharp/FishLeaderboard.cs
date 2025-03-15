using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using Steamworks.Data;
using TMPro;
using UnityEngine;

public class FishLeaderboard : MonoBehaviour
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CFetch_003Ed__3 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public FishLeaderboard _003C_003E4__this;

		private StringBuilder _003CstrBlrd_003E5__2;

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

	[SerializeField]
	private TMP_Text globalText;

	[SerializeField]
	private TMP_Text friendsText;

	private void OnEnable()
	{
	}

	[AsyncStateMachine(typeof(_003CFetch_003Ed__3))]
	private void Fetch()
	{
	}
}
