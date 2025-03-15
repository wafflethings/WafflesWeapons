using UnityEngine;

public class GasolineStain : MonoBehaviour
{
	private Vector3 initialSize;

	private int index;

	private MeshRenderer mRend;

	private MaterialPropertyBlock propBlock;

	public Transform Parent { get; private set; }

	public bool IsStatic { get; private set; }

	public bool IsFloor { get; private set; }

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private float CalculateDot()
	{
		return 0f;
	}

	public void AttachTo(Collider other, bool clipToSurface)
	{
	}

	public void OnTransformParentChanged()
	{
	}

	public void SetSize(float size)
	{
	}
}
