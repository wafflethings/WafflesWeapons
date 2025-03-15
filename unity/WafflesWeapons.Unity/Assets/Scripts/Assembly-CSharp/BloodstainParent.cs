using System.Collections.Generic;
using UnityEngine;

public class BloodstainParent : MonoBehaviour
{
	public int parentIndex;

	public Matrix4x4 matrixAtStep;

	private HashSet<int> children;

	private BloodsplatterManager bsm;

	public void OnStep()
	{
	}

	public Matrix4x4 GetMatrix()
	{
		return default(Matrix4x4);
	}

	private void Start()
	{
	}

	public void OnStainsCleared()
	{
	}

	public void CreateChild(Vector3 pos, Vector3 norm, bool clipToSurface, bool fromStep)
	{
	}

	private void OnStainIndexReuse(int index)
	{
	}

	private void OnParentIndexReuse(int index)
	{
	}

	private void Update()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	public void ClearChildren()
	{
	}
}
