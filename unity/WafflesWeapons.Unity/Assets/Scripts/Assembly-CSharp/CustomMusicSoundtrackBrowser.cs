using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class CustomMusicSoundtrackBrowser : DirectoryTreeBrowser<AssetReferenceSoundtrackSong>
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass26_0
	{
		public CustomMusicSoundtrackBrowser _003C_003E4__this;

		public AssetReferenceSoundtrackSong reference;

		public GameObject btn;

		public SoundtrackSong song;

		internal bool _003CLoadSongButton_003Eb__1()
		{
			return false;
		}

		internal void _003CLoadSongButton_003Eb__0()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass26_1
	{
		public AsyncOperationHandle<SoundtrackSong> handle;

		public _003C_003Ec__DisplayClass26_0 CS_0024_003C_003E8__locals1;

		internal bool _003CLoadSongButton_003Eb__2()
		{
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003CLoadSongButton_003Ed__26 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public CustomMusicSoundtrackBrowser _003C_003E4__this;

		public AssetReferenceSoundtrackSong reference;

		public GameObject btn;

		private _003C_003Ec__DisplayClass26_0 _003C_003E8__1;

		private _003C_003Ec__DisplayClass26_1 _003C_003E8__2;

		private GameObject _003Cplaceholder_003E5__2;

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
		public _003CLoadSongButton_003Ed__26(int _003C_003E1__state)
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

	[Header("References")]
	[SerializeField]
	private CustomMusicPlaylistEditor playlistEditorLogic;

	[SerializeField]
	private GameObject playlistEditorPanel;

	[SerializeField]
	private CyberGrindSettingsNavigator navigator;

	[SerializeField]
	private TMP_Text songName;

	[SerializeField]
	private Image songIcon;

	[Header("Assets")]
	[SerializeField]
	private GameObject loadingPrefab;

	[SerializeField]
	private Sprite lockedLevelSprite;

	[SerializeField]
	private Sprite defaultIcon;

	[SerializeField]
	private GameObject buySound;

	public List<AssetReferenceSoundtrackSong> rootFolder;

	public List<SoundtrackFolder> levelFolders;

	public List<AssetReferenceSoundtrackSong> secretLevelFolder;

	public List<AssetReferenceSoundtrackSong> primeFolder;

	public List<AssetReferenceSoundtrackSong> encoreFolder;

	public List<AssetReferenceSoundtrackSong> miscFolder;

	private FakeDirectoryTree<AssetReferenceSoundtrackSong> _baseDirectory;

	private Dictionary<AssetReferenceSoundtrackSong, SoundtrackSong> referenceCache;

	private SoundtrackSong songBeingBought;

	protected override int maxPageLength => 0;

	protected override IDirectoryTree<AssetReferenceSoundtrackSong> baseDirectory => null;

	private void Start()
	{
	}

	private void OnEnable()
	{
	}

	private void SelectSong(string id, SoundtrackSong song)
	{
	}

	private void OnDestroy()
	{
	}

	[IteratorStateMachine(typeof(_003CLoadSongButton_003Ed__26))]
	public IEnumerator LoadSongButton(AssetReferenceSoundtrackSong reference, GameObject btn)
	{
		return null;
	}

	protected override Action BuildLeaf(AssetReferenceSoundtrackSong reference, int indexInPage)
	{
		return null;
	}

	private void SetActiveAll(List<GameObject> objects, bool active)
	{
	}
}
