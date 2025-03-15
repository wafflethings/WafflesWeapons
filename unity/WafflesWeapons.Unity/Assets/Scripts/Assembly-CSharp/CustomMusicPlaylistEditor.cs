using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomMusicPlaylistEditor : DirectoryTreeBrowser<Playlist.SongIdentifier>
{
	[SerializeField]
	private CustomMusicSoundtrackBrowser browser;

	[SerializeField]
	private Sprite defaultIcon;

	[SerializeField]
	private Sprite loopSprite;

	[SerializeField]
	private Sprite loopOnceSprite;

	[Header("UI Elements")]
	[SerializeField]
	private Image loopModeImage;

	[SerializeField]
	private Image shuffleImage;

	[SerializeField]
	private RectTransform selectedControls;

	[SerializeField]
	private List<Transform> anchors;

	public Playlist playlist;

	private Coroutine moveControlsRoutine;

	private Dictionary<Transform, Coroutine> changeAnchorRoutines;

	private List<Transform> buttons;

	private Dictionary<Playlist.SongIdentifier, Playlist.SongMetadata> metadataDict;

	protected override int maxPageLength => 0;

	protected override IDirectoryTree<Playlist.SongIdentifier> baseDirectory => null;

	private Playlist.SongIdentifier selectedSongId => null;

	private CustomContentButton currentButton => null;

	public Playlist.SongMetadata GetSongMetadata(Playlist.SongIdentifier id)
	{
		return null;
	}

	private Playlist.SongMetadata GetSongMetadataFromAddressable(Playlist.SongIdentifier id)
	{
		return null;
	}

	private Playlist.SongMetadata GetSongMetadataFromFilepath(Playlist.SongIdentifier id)
	{
		return null;
	}

	public void SavePlaylist()
	{
	}

	public void LoadPlaylist()
	{
	}

	public void Remove()
	{
	}

	public void MoveUp()
	{
	}

	public void MoveDown()
	{
	}

	public void Move(int amount)
	{
	}

	public void ChangeAnchorOf(Transform obj, Transform anchor, float time = 0.15f)
	{
	}

	public void ToggleLoopMode()
	{
	}

	private void SetLoopMode(Playlist.LoopMode mode)
	{
	}

	public void ToggleShuffle()
	{
	}

	private void SetShuffle(bool shuffle)
	{
	}

	public void Select(int newIndex, bool rebuild = true)
	{
	}

	public override void Rebuild(bool setToPageZero = true)
	{
	}

	protected override Action BuildLeaf(Playlist.SongIdentifier id, int currentIndex)
	{
		return null;
	}

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}
}
