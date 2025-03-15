using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class CustomContentGui : MonoBehaviour
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CRefreshCustomMaps_003Ed__43 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

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
	private struct _003CRefreshWorkshopItems_003Ed__41 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

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
	private GameObject typeSelectionMenu;

	[Space]
	[SerializeField]
	private GameObject grid;

	[SerializeField]
	private GameObject gridLoadingBlocker;

	[SerializeField]
	private CustomLevelPanel itemTemplate;

	[SerializeField]
	private CustomContentCategory categoryTemplate;

	[SerializeField]
	private CustomContentGrid gridTemplate;

	[SerializeField]
	private GameObject pagination;

	[Space]
	[SerializeField]
	private ScrollRect scrollRect;

	[SerializeField]
	private ForceLayoutRebuilds forceLayoutRebuilds;

	[SerializeField]
	private GameObject workshopError;

	[SerializeField]
	private GameObject fetchingPanel;

	[SerializeField]
	private GameObject loadingFailed;

	[SerializeField]
	private InputField workshopSearch;

	[SerializeField]
	private Dropdown difficultyDropdown;

	[SerializeField]
	private GameObject workshopButtons;

	[SerializeField]
	private Button[] workshopTabButtons;

	[SerializeField]
	private GameObject localButtons;

	[SerializeField]
	private Dropdown localSortModeDropdown;

	[Space]
	[SerializeField]
	public CampaignViewScreen campaignView;

	private Action afterLegacyAgonyInterrupt;

	private UnscaledTimeSince timeSinceStart;

	private FileSystemWatcher watcher;

	private bool localListUpdatePending;

	private int currentPage;

	private static LocalSortMode currentLocalSortMode;

	private static WorkshopTab currentWorkshopTab;

	private static bool lastTabWorkshop;

	public static CustomCampaign lastCustomCampaign;

	public static bool wasAgonyOpen { get; private set; }

	public void ShowLocalMaps()
	{
	}

	public void ShowWorkshopMaps()
	{
	}

	public void ReturnToTypeSelection()
	{
	}

	private void ResetItems()
	{
	}

	public void DismissBlockers()
	{
	}

	public void ShowInExplorer()
	{
	}

	public void SetLocalSortMode(int option)
	{
	}

	public void SetDifficulty(int dif)
	{
	}

	public void SetWorkshopTab(int tab)
	{
	}

	[AsyncStateMachine(typeof(_003CRefreshWorkshopItems_003Ed__41))]
	public void RefreshWorkshopItems(int page = 1, bool lockScroll = false)
	{
	}

	public void LoadMore()
	{
	}

	[AsyncStateMachine(typeof(_003CRefreshCustomMaps_003Ed__43))]
	public void RefreshCustomMaps()
	{
	}

	private void Update()
	{
	}
}
