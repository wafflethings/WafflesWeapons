using UnityEngine;
using UnityEngine.AddressableAssets;

public class BreakChunks : MonoBehaviour
{
	public AssetReference[] chunks;

	public bool getEnviroMaterial;

	public Vector3 getDirection;

	public bool relativeDirection;

	private void Start()
	{
	}

	private bool GetMaterial(out Material mat)
	{
		mat = null;
		return false;
	}
}
