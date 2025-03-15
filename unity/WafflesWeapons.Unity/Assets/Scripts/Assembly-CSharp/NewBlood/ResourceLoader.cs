using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Networking;

namespace NewBlood
{
	internal static class ResourceLoader
	{
		[CompilerGenerated]
		private sealed class _003CLoadAudioClip_003Ed__3<TState> : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public string path;

			public Action<TState, AudioClip> onCompleted;

			public AudioType audioType;

			public AudioClipLoadType loadType;

			public TState state;

			private UnityWebRequest _003Crequest_003E5__2;

			private DownloadHandlerAudioClip _003Chandler_003E5__3;

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
			public _003CLoadAudioClip_003Ed__3(int _003C_003E1__state)
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

		public static IEnumerator LoadAudioClip(string path, AudioClipLoadType loadType, Action<AudioClip> onCompleted)
		{
			return null;
		}

		public static IEnumerator LoadAudioClip(string path, AudioClipLoadType loadType, AudioType audioType, Action<AudioClip> onCompleted)
		{
			return null;
		}

		public static IEnumerator LoadAudioClip<TState>(string path, AudioClipLoadType loadType, TState state, Action<TState, AudioClip> onCompleted)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CLoadAudioClip_003Ed__3<>))]
		public static IEnumerator LoadAudioClip<TState>(string path, AudioClipLoadType loadType, AudioType audioType, TState state, Action<TState, AudioClip> onCompleted)
		{
			return null;
		}

		private static void DisposeAndThrowIfRequestFailed(UnityWebRequest request)
		{
		}

		private static Exception GetExceptionForWebRequest(UnityWebRequest request)
		{
			return null;
		}

		private static Uri GetFileUri(string path)
		{
			return null;
		}
	}
}
