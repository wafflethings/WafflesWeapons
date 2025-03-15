using System.Collections.Generic;
using UnityEngine;

public class ScrollingTexture : MonoBehaviour
{
	private static MaterialPropertyBlock _propertyBlock;

	public float scrollSpeedX;

	public float scrollSpeedY;

	private int scrollOffsetID;

	private bool[] usesMasterShader;

	private Dictionary<int, int[]> propertyNames;

	private List<Material> materials;

	private MeshRenderer mr;

	private Vector2 offset;

	public bool scrollAttachedObjects;

	public Vector3 force;

	public bool relativeDirection;

	public List<Transform> attachedObjects;

	[HideInInspector]
	public Bounds bounds;

	[HideInInspector]
	public bool valuesSet;

	[HideInInspector]
	public List<GameObject> cleanUp;

	[HideInInspector]
	public List<WaterDryTracker> specialScrollers;

	[HideInInspector]
	public List<Rigidbody> touchingRbs;

	public BloodstainParent parent;

	private void Start()
	{
	}

	private void SlowUpdate()
	{
	}

	private void OnDestroy()
	{
	}

	private void Update()
	{
	}

	private void FixedUpdate()
	{
	}
}
