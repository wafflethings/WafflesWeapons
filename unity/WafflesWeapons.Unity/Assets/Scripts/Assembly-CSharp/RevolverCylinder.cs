using UnityEngine;

public class RevolverCylinder : MonoBehaviour
{
	public int bulletAmount;

	public Vector3 rotationAxis;

	public float speed;

	private AudioSource aud;

	private int target;

	private Quaternion currentRotation;

	private Quaternion[] allRotations;

	private bool freeSpinning;

	[HideInInspector]
	public float spinSpeed;

	private void Start()
	{
	}

	private void LateUpdate()
	{
	}

	public void DoTurn()
	{
	}

	private int GetClosestTarget()
	{
		return 0;
	}
}
