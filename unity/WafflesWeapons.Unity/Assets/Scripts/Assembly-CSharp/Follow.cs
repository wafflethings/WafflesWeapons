using UnityEngine;

public class Follow : MonoBehaviour
{
	public float speed;

	public Transform target;

	public bool mimicPosition;

	public bool applyPositionLocally;

	public bool followX;

	public bool followY;

	public bool followZ;

	public bool mimicRotation;

	public bool applyRotationLocally;

	public bool rotX;

	public bool rotY;

	public bool rotZ;

	private bool followingPlayer;

	public Collider[] restrictToColliderBounds;

	private Bounds area;

	public bool destroyIfNoTarget;

	private void Awake()
	{
	}

	private void Update()
	{
	}

	public void SetTarget(Transform newTarget)
	{
	}
}
