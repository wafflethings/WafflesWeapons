using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using plog;

[ConfigureSingleton(SingletonFlags.NoAutoInstance | SingletonFlags.PersistAutoInstance | SingletonFlags.DestroyDuplicates)]
public class AssetHelper : MonoSingleton<AssetHelper>
{
	[CompilerGenerated]
	private sealed class _003CLoadPrefab_003Ed__6 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public string prefab;

		public Vector3 position;

		public Quaternion rotation;

		private AsyncOperationHandle<GameObject> _003CloadOperation_003E5__2;

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
		public _003CLoadPrefab_003Ed__6(int _003C_003E1__state)
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

	private static readonly plog.Logger Log;

	private Dictionary<string, GameObject> prefabCache;

	protected override void OnEnable()
	{
	}

	public static GameObject LoadPrefab(string address)
	{
		return null;
	}

	public static GameObject LoadPrefab(AssetReference reference)
	{
		return null;
	}

	public static void SpawnPrefabAsync(string prefab, Vector3 position, Quaternion rotation)
	{
	}

	[IteratorStateMachine(typeof(_003CLoadPrefab_003Ed__6))]
	public IEnumerator LoadPrefab(string prefab, Vector3 position, Quaternion rotation)
	{
		return null;
	}
}
