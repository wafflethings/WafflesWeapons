using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CustomMusicFileBrowser : DirectoryTreeBrowser<FileInfo>
{
	[SerializeField]
	private CyberGrindSettingsNavigator navigator;

	[SerializeField]
	private CustomMusicPlaylistEditor playlistEditorLogic;

	[SerializeField]
	private GameObject playlistEditor;

	[SerializeField]
	private GameObject loadingPrefab;

	[SerializeField]
	private Sprite defaultIcon;

	private AudioClip selectedClip;

	public static Dictionary<string, AudioType> extensionTypeDict;

	private AudioClip currentSong;

	protected override int maxPageLength => 0;

	protected override IDirectoryTree<FileInfo> baseDirectory => null;

	protected override Action BuildLeaf(FileInfo file, int indexInPage)
	{
		return null;
	}
}
