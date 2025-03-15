using UnityEngine;

public class Pond : MonoBehaviour, IBloodstainReceiver
{
	public GameObject owningRoom;

	public float bloodFillSpeed;

	public float bloodDrainSpeed;

	public Color surfaceBloodColor;

	public Color underwaterBloodColor;

	public float bloodFillAmount;

	private Color underwaterColor;

	private Color waterSurfaceColor;

	private Water waterComponent;

	public Renderer waterSurface;

	private MaterialPropertyBlock propertyBlock;

	public bool isDraining;

	public float bloodFillAmountCopy;

	private float lastBloodFillAmount;

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void StoreBlood()
	{
	}

	public void RestoreBlood()
	{
	}

	private void UpdateVisuals()
	{
	}

	public bool HandleBloodstainHit(ref RaycastHit rhit)
	{
		return false;
	}

	private void OnTriggerEnter(Collider col)
	{
	}

	private void OnTriggerExit(Collider col)
	{
	}
}
