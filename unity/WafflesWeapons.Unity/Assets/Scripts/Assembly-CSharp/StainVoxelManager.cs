using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Jobs;
using UnityEngine.Rendering;
using plog;

public class StainVoxelManager : MonoSingleton<StainVoxelManager>
{
	public struct InstanceProperties
	{
		public int index;

		public int clipToSurface;

		public const int SIZE = 8;
	}

	[BurstCompile]
	private struct UpdateMatrixJob : IJobParallelForTransform
	{
		public NativeArray<float4x4> OutMatrices;

		public void Execute(int index, TransformAccess transform)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CIterateBox_003Ed__53 : IEnumerable<Vector3Int>, IEnumerable, IEnumerator<Vector3Int>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private Vector3Int _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private int size;

		public int _003C_003E3__size;

		private Vector3Int center;

		public Vector3Int _003C_003E3__center;

		private int _003ChalfSize_003E5__2;

		private int _003Cx_003E5__3;

		private int _003Cy_003E5__4;

		private int _003Cz_003E5__5;

		Vector3Int IEnumerator<Vector3Int>.Current
		{
			[DebuggerHidden]
			get
			{
				return default(Vector3Int);
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
		public _003CIterateBox_003Ed__53(int _003C_003E1__state)
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

		[DebuggerHidden]
		IEnumerator<Vector3Int> IEnumerable<Vector3Int>.GetEnumerator()
		{
			return null;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}
	}

	[CompilerGenerated]
	private sealed class _003CIterateCross_003Ed__55 : IEnumerable<Vector3Int>, IEnumerable, IEnumerator<Vector3Int>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private Vector3Int _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private int size;

		public int _003C_003E3__size;

		private Vector3Int center;

		public Vector3Int _003C_003E3__center;

		private int height;

		public int _003C_003E3__height;

		private int _003ChalfSize_003E5__2;

		private int _003Cy_003E5__3;

		private int _003Cx_003E5__4;

		Vector3Int IEnumerator<Vector3Int>.Current
		{
			[DebuggerHidden]
			get
			{
				return default(Vector3Int);
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
		public _003CIterateCross_003Ed__55(int _003C_003E1__state)
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

		[DebuggerHidden]
		IEnumerator<Vector3Int> IEnumerable<Vector3Int>.GetEnumerator()
		{
			return null;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}
	}

	[CompilerGenerated]
	private sealed class _003CIteratePole_003Ed__56 : IEnumerable<Vector3Int>, IEnumerable, IEnumerator<Vector3Int>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private Vector3Int _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private int size;

		public int _003C_003E3__size;

		private Vector3Int center;

		public Vector3Int _003C_003E3__center;

		private int _003ChalfSize_003E5__2;

		private int _003Ci_003E5__3;

		Vector3Int IEnumerator<Vector3Int>.Current
		{
			[DebuggerHidden]
			get
			{
				return default(Vector3Int);
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
		public _003CIteratePole_003Ed__56(int _003C_003E1__state)
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

		[DebuggerHidden]
		IEnumerator<Vector3Int> IEnumerable<Vector3Int>.GetEnumerator()
		{
			return null;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}
	}

	[CompilerGenerated]
	private sealed class _003CIterateVerticalBox_003Ed__54 : IEnumerable<Vector3Int>, IEnumerable, IEnumerator<Vector3Int>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private Vector3Int _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private int size;

		public int _003C_003E3__size;

		private Vector3Int center;

		public Vector3Int _003C_003E3__center;

		private int height;

		public int _003C_003E3__height;

		private int _003ChalfSize_003E5__2;

		private int _003Cx_003E5__3;

		private int _003Cz_003E5__4;

		private int _003Cy_003E5__5;

		Vector3Int IEnumerator<Vector3Int>.Current
		{
			[DebuggerHidden]
			get
			{
				return default(Vector3Int);
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
		public _003CIterateVerticalBox_003Ed__54(int _003C_003E1__state)
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

		[DebuggerHidden]
		IEnumerator<Vector3Int> IEnumerable<Vector3Int>.GetEnumerator()
		{
			return null;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}
	}

	private static readonly plog.Logger Log;

	private const int FireSpreadDistance = 5;

	public const float VoxelSize = 2.75f;

	public const float VoxelOverlapSphereRadius = 1.375f;

	public const int ExplosionMargin = 2;

	private readonly Dictionary<Vector3Int, StainVoxel> stainVoxels;

	private readonly HashSet<Vector3Int> pendingIgnitions;

	private TimeSince? lastPropagationTick;

	private readonly HashSet<Vector3Int> explodedVoxels;

	public readonly HurtCooldownCollection SharedHurtCooldownCollection;

	public Shader gasolineCompositeShader;

	private Material gasolineCompositeMaterial;

	public Mesh gasStainMesh;

	public Material gasStainMat;

	public NativeArray<float4x4> gasolineTransforms;

	private NativeArray<InstanceProperties> instanceProps;

	private ComputeBuffer propBuffer;

	private ComputeBuffer stainBuffer;

	private CommandBuffer cb;

	private Dictionary<Transform, int> stainIndices;

	private int currentStainCount;

	public TransformAccessArray stainTransforms;

	private JobHandle jobHandle;

	private bool removeLate;

	private ComputeBuffer argsBuffer;

	private uint[] argsData;

	public bool usedComputeShadersAtStart;

	private StainVoxel[] debugVoxels => null;

	private Vector3Int[] debugPendingIgnitions => null;

	private Vector3Int[] debugExplodedVoxels => null;

	private void UpdateStainVisuals()
	{
	}

	private void Start()
	{
	}

	public void AddGasolineStain(Transform stain, bool shouldClipToSurface)
	{
	}

	private void CleanupStaleTransforms()
	{
	}

	private void RemoveStainAtIndex(int removeIndex)
	{
	}

	public void RemoveAllStains()
	{
	}

	private void LateUpdate()
	{
	}

	public void SetupStainCommandBuffer(Camera mainCam, RenderTexture mainTex, RenderTexture stainCopy, RenderTexture depth)
	{
	}

	public void AcknowledgeNewStain(StainVoxel voxel)
	{
	}

	private void Update()
	{
	}

	private new void OnDestroy()
	{
	}

	public StainVoxel CreateOrGetVoxel(Vector3 worldPosition, bool dontCreate = false)
	{
		return null;
	}

	public void RefreshVoxel(StainVoxel voxel)
	{
	}

	public void UpdateProxyPosition(VoxelProxy proxy, Vector3Int newPosition)
	{
	}

	public bool ShouldExplodeAt(Vector3Int voxelPosition)
	{
		return false;
	}

	public bool TryIgniteAt(Vector3 worldPosition, int checkSize = 3)
	{
		return false;
	}

	public bool TryIgniteAt(Vector3Int voxelPosition, int checkSize = 3)
	{
		return false;
	}

	public void ScheduleFirePropagation(StainVoxel voxel)
	{
	}

	public void DoneBurning(VoxelProxy proxy)
	{
	}

	public bool TryGetVoxelsWorld(Vector3 worldPosition, out List<StainVoxel> voxels, int checkSize = 3, VoxelCheckingShape shape = VoxelCheckingShape.Box, bool returnOnHit = false)
	{
		voxels = null;
		return false;
	}

	public bool TryGetVoxels(Vector3Int voxelPosition, out List<StainVoxel> voxels, int checkSize = 3, VoxelCheckingShape shape = VoxelCheckingShape.Box, bool returnOnHit = false)
	{
		voxels = null;
		return false;
	}

	public bool HasProxiesAt(Vector3Int voxelPosition, int checkSize = 3, VoxelCheckingShape shape = VoxelCheckingShape.Box, ProxySearchMode searchMode = ProxySearchMode.Any, bool returnOnHit = true)
	{
		return false;
	}

	private IEnumerable<Vector3Int> GetShapeIterator(Vector3Int center, VoxelCheckingShape shape, int size)
	{
		return null;
	}

	private bool ProxyExistsAt(Vector3Int voxelPosition, ProxySearchMode searchMode = ProxySearchMode.Any)
	{
		return false;
	}

	[IteratorStateMachine(typeof(_003CIterateBox_003Ed__53))]
	private static IEnumerable<Vector3Int> IterateBox(Vector3Int center, int size)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CIterateVerticalBox_003Ed__54))]
	private static IEnumerable<Vector3Int> IterateVerticalBox(Vector3Int center, int size, int height)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CIterateCross_003Ed__55))]
	private static IEnumerable<Vector3Int> IterateCross(Vector3Int center, int size, int height)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CIteratePole_003Ed__56))]
	private static IEnumerable<Vector3Int> IteratePole(Vector3Int center, int size)
	{
		return null;
	}

	public static Vector3Int WorldToVoxelPosition(Vector3 position)
	{
		return default(Vector3Int);
	}

	public static Vector3 VoxelToWorldPosition(Vector3Int position)
	{
		return default(Vector3);
	}

	private static void DrawVoxel(Vector3Int voxelPosition, bool success)
	{
	}

	private static void DrawVoxel(Vector3 roundedWorldPosition, bool success)
	{
	}

	public void IgniteAll()
	{
	}

	public void ClearAll()
	{
	}
}
