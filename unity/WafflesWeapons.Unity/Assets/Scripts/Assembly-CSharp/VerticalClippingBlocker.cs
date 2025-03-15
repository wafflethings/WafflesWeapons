using UnityEngine;

public class VerticalClippingBlocker : MonoBehaviour
{
	private CapsuleCollider col;

	private LayerMask lmask;

	private Rigidbody rb;

	private NewMovement nm;

	private GroundCheck gc;

	[SerializeField]
	private float ceilingCheckDistance;

	[SerializeField]
	private float heavyFallMaxExtraHeight;

	private Vector3 lastVelocity;

	private float computedHeavyFallOffset;

	private bool ceilingDetected;

	private void Awake()
	{
	}

	private void FixedUpdate()
	{
	}

	private void LateUpdate()
	{
	}

	private bool PerformCeilingCheck()
	{
		return false;
	}

	private void PerformClippingCheck(bool heavyFall)
	{
	}

	private float CalculateHeavyFallOffset()
	{
		return 0f;
	}
}
