using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class CustomMusicPlayer : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CPlaylistRoutine_003Ed__15 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public CustomMusicPlayer _003C_003E4__this;

		private WaitUntil _003CsongFinished_003E5__2;

		private Playlist.SongIdentifier _003ClastSong_003E5__3;

		private bool _003Cfirst_003E5__4;

		private Playlist _003Cplaylist_003E5__5;

		private IEnumerable<Playlist.SongIdentifier> _003CcurrentOrder_003E5__6;

		private IEnumerator<Playlist.SongIdentifier> _003C_003E7__wrap6;

		private Playlist.SongIdentifier _003Cid_003E5__8;

		private UnityWebRequest _003Crequest_003E5__9;

		private DownloadHandlerAudioClip _003Chandler_003E5__10;

		private AsyncOperationHandle<SoundtrackSong> _003Chandle_003E5__11;

		private SoundtrackSong _003Csong_003E5__12;

		private int _003CclipsPlayed_003E5__13;

		private List<AudioClip>.Enumerator _003C_003E7__wrap13;

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
		public _003CPlaylistRoutine_003Ed__15(int _003C_003E1__state)
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

		private void _003C_003Em__Finally1()
		{
		}

		private void _003C_003Em__Finally2()
		{
		}

		private void _003C_003Em__Finally3()
		{
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CShowPanelRoutine_003Ed__14 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public CustomMusicPlayer _003C_003E4__this;

		public Playlist.SongMetadata song;

		private float _003Ctime_003E5__2;

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
		public _003CShowPanelRoutine_003Ed__14(int _003C_003E1__state)
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

	[SerializeField]
	private CanvasGroup panelGroup;

	[SerializeField]
	private Text panelText;

	[SerializeField]
	private Image panelIcon;

	[SerializeField]
	private CustomMusicPlaylistEditor playlistEditor;

	[SerializeField]
	private Sprite defaultIcon;

	public AudioSource source;

	public float panelApproachTime;

	public float panelStayTime;

	private System.Random random;

	private bool stopped;

	public Dictionary<string, AudioClip> fileClipCache;

	public void OnEnable()
	{
	}

	public void StartPlaylist()
	{
	}

	public void StopPlaylist()
	{
	}

	[IteratorStateMachine(typeof(_003CShowPanelRoutine_003Ed__14))]
	private IEnumerator ShowPanelRoutine(Playlist.SongMetadata song)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CPlaylistRoutine_003Ed__15))]
	private IEnumerator PlaylistRoutine()
	{
		return null;
	}
}
