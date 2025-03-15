using UnityEngine;

public class RoomCubemap : MonoBehaviour
{
	public bool automaticPosition;

	public CubemapMode cubemapMode;

	public float cubemapStrength;

	private Transform room;

	private MeshRenderer[] roomObjects;

	private Bounds roomBounds;

	private Cubemap cubemap;

	private Camera cam;

	private MaterialPropertyBlock propertyBlock;

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	public void UpdateCubemap()
	{
	}

	public void DelayUpdate(float delayTime)
	{
	}
}
