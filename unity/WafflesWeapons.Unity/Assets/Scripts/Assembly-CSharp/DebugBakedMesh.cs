using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]
[ExecuteAlways]
public class DebugBakedMesh : MonoBehaviour
{
	public int lookupIndex;

	public ushort firstSubmesh;

	public ushort subMeshCount;

	public StaticSceneData sceneData;

	private int previousLookupIndex;

	private ushort previousFirstSubmesh;

	private ushort previousSubmeshCount;

	private void Update()
	{
	}

	private void SetData()
	{
	}
}
