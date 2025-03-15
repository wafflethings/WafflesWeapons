using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

[Serializable]
public class StainVoxel
{
	[CompilerGenerated]
	private sealed class _003CGetProxies_003Ed__17 : IEnumerable<VoxelProxy>, IEnumerable, IEnumerator<VoxelProxy>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private VoxelProxy _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private ProxySearchMode mode;

		public ProxySearchMode _003C_003E3__mode;

		public StainVoxel _003C_003E4__this;

		private Dictionary<Transform, List<VoxelProxy>>.ValueCollection.Enumerator _003C_003E7__wrap1;

		private List<VoxelProxy>.Enumerator _003C_003E7__wrap2;

		VoxelProxy IEnumerator<VoxelProxy>.Current
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
		public _003CGetProxies_003Ed__17(int _003C_003E1__state)
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

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}

		[DebuggerHidden]
		IEnumerator<VoxelProxy> IEnumerable<VoxelProxy>.GetEnumerator()
		{
			return null;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}
	}

	public readonly Vector3Int VoxelPosition;

	public readonly Vector3 RoundedWorldPosition;

	public readonly int HashCode;

	public VoxelProxy staticProxy;

	public Dictionary<Transform, List<VoxelProxy>> dynamicProxies;

	private readonly Collider[] waterOverlapResult;

	private const string StaticVoxelName = "VoxelProxy";

	public bool isEmpty => false;

	public bool isBurning => false;

	public StainVoxel(Vector3Int voxelPosition)
	{
	}

	public VoxelProxy CreateOrGetProxyFor(GasolineStain stain)
	{
		return null;
	}

	public void AcknowledgeNewStain()
	{
	}

	public void AddProxy(VoxelProxy existingProxy)
	{
	}

	public void RemoveProxy(VoxelProxy proxy, bool destroy = true)
	{
	}

	public void DestroySelf()
	{
	}

	[IteratorStateMachine(typeof(_003CGetProxies_003Ed__17))]
	public IEnumerable<VoxelProxy> GetProxies(ProxySearchMode mode)
	{
		return null;
	}

	public bool HasFloorStains()
	{
		return false;
	}

	public bool HasBurningProxies()
	{
		return false;
	}

	public bool HasStains(ProxySearchMode mode)
	{
		return false;
	}

	public bool TryIgnite()
	{
		return false;
	}

	private VoxelProxy CreateNewProxy(GasolineStain stain, bool isStatic)
	{
		return null;
	}

	public string GetProxyName()
	{
		return null;
	}

	public override int GetHashCode()
	{
		return 0;
	}

	public override bool Equals(object obj)
	{
		return false;
	}
}
