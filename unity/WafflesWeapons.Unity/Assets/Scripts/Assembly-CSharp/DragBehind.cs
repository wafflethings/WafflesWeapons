using UnityEngine;

public class DragBehind : MonoBehaviour
{
	private Vector3 previousPosition;

	private Quaternion currentRotation;

	private Quaternion nextRotation;

	private Quaternion previousRotation;

	public bool active;

	public bool notAnimated;

	public float dragAmount;

	private Quaternion defaultRotation;

	private void Awake()
	{
	}

	private void LateUpdate()
	{
	}
}
