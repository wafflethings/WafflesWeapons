using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Sandbox;
using UnityEngine;
using plog;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class SandboxSaver : MonoSingleton<SandboxSaver>
{
	[CompilerGenerated]
	private sealed class _003CPostLoadAndBake_003Ed__14 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public List<SandboxEnemy> enemies;

		private List<SandboxEnemy> _003CenemiesToFreezeBack_003E5__2;

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
		public _003CPostLoadAndBake_003Ed__14(int _003C_003E1__state)
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

	public const string SaveExtension = ".pitr";

	[SerializeField]
	private SpawnableObjectsDatabase objects;

	private Dictionary<string, SpawnableObject> registeredObjects;

	public string activeSave;

	public static string SavePath => null;

	private static void SetupDirs()
	{
	}

	public string[] ListSaves()
	{
		return null;
	}

	public void QuickSave()
	{
	}

	public void QuickLoad()
	{
	}

	public void Delete(string name)
	{
	}

	public void Save(string name)
	{
	}

	public void Load(string name)
	{
	}

	[IteratorStateMachine(typeof(_003CPostLoadAndBake_003Ed__14))]
	private IEnumerator PostLoadAndBake(List<SandboxEnemy> enemies)
	{
		return null;
	}

	public SandboxEnemy RecreateEnemy(SavedGeneric genericObject, bool newSizing)
	{
		return null;
	}

	private void RecreateProp(SavedProp prop, bool newSizing)
	{
	}

	private void RecreateBlock(SavedBlock block)
	{
	}

	private void ApplyData(GameObject go, SavedAlterData[] data)
	{
	}

	public void RebuildObjectList()
	{
	}

	private void RegisterObjects(SpawnableObject[] objs)
	{
	}

	public static void Clear()
	{
	}

	private static void CreateSaveAndWrite(string name)
	{
	}
}
