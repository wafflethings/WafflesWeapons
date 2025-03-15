using UnityEngine;

[ExecuteInEditMode]
public class ObjectBoundsToShader : MonoBehaviour
{
	public bool useCustomCenter;

	public Vector3 customCenter;

	private MeshRenderer rend;

	private MaterialPropertyBlock propertyBlock;

	[HideInInspector]
	public CausticVolumeManager manager;

	private Vector3 lastCustomBounds;

	private void OnValidate()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnDestroy()
	{
	}

	private void Update()
	{
	}

	public void UpdateRendererBounds()
	{
	}
}
