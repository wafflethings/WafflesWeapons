using System.Collections.Generic;
using UnityEngine;

public class VoxelProxy : MonoBehaviour
{
	[HideInInspector]
	public bool isStatic;

	public StainVoxel voxel;

	[HideInInspector]
	public Transform parent;

	private BurningVoxel burningVoxel;

	private VoxelProxyDebug debug;

	private bool exploded;

	public bool isBurning => false;

	public List<GasolineStain> stains { get; }

	private void Awake()
	{
	}

	public void SetParent(Transform parent, bool isStatic)
	{
	}

	private Vector3 ComputeCombinedHierarchyScale(Transform parent)
	{
		return default(Vector3);
	}

	public void Add(GasolineStain stain)
	{
	}

	public bool IsMatch(ProxySearchMode searchMode)
	{
		return false;
	}

	public void DestroySelf()
	{
	}

	public void StartBurningOrRefuel()
	{
	}

	public void ExplodeAndDestroy()
	{
	}

	private void Update()
	{
	}

	private void OnDestroy()
	{
	}

	public void SetStainSize(float size)
	{
	}
}
