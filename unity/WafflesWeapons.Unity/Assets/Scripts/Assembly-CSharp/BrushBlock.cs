using Sandbox;
using UnityEngine;

public class BrushBlock : SandboxProp, IAlter, IAlterOptions<Vector3>
{
	public Vector3 DataSize;

	public BlockType Type;

	public BoxCollider OverrideCollider;

	public BoxCollider WaterTrigger;

	public string alterKey => null;

	public string alterCategoryName => null;

	public AlterOption<Vector3>[] options => null;

	public SavedBlock SaveBrushBlock()
	{
		return null;
	}

	public void RegenerateMesh()
	{
	}
}
