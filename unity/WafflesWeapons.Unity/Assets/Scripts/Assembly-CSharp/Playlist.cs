using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using UnityEngine;

[JsonObject(MemberSerialization.OptIn)]
public class Playlist
{
	public enum LoopMode
	{
		Loop = 0,
		LoopOne = 1
	}

	public class SongMetadata
	{
		public string displayName;

		public Sprite icon;

		public int maxClips;

		public SongMetadata(string displayName, Sprite icon, int maxClips = 1)
		{
		}
	}

	public class SongIdentifier
	{
		public enum IdentifierType
		{
			Addressable = 0,
			File = 1
		}

		public string path;

		public IdentifierType type;

		public SongIdentifier(string id, IdentifierType type)
		{
		}

		public static implicit operator SongIdentifier(string id)
		{
			return null;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}

	[JsonProperty]
	private List<SongIdentifier> _ids;

	[JsonProperty]
	private LoopMode _loopMode;

	[JsonProperty]
	private int _selected;

	[JsonProperty]
	private bool _shuffled;

	public static DirectoryInfo directory => null;

	public static string currentPath => null;

	public List<SongIdentifier> ids => null;

	public LoopMode loopMode
	{
		get
		{
			return default(LoopMode);
		}
		set
		{
		}
	}

	public int selected
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public bool shuffled
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public int Count => 0;

	public event Action OnChanged
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public Playlist()
	{
	}

	public Playlist(IEnumerable<SongIdentifier> passedIds)
	{
	}

	public void Add(SongIdentifier id)
	{
	}

	public void Remove(int index)
	{
	}

	public void Swap(int index1, int index2)
	{
	}
}
