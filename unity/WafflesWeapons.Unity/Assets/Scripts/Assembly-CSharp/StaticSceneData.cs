using System.Collections.Generic;
using UnityEngine;

public class StaticSceneData : ScriptableObject
{
	public Texture2D mainTexAtlas;

	public Texture2D blendTexAtlas;

	public List<Mesh> bakedMeshes;

	public List<int> backingMeshHashes;

	public List<int> mrLightIndices;

	public List<int> mrMeshIndices;

	public List<ushort> firstSubMesh;

	public List<ushort> subMeshCount;

	public void ClearData()
	{
	}
}
