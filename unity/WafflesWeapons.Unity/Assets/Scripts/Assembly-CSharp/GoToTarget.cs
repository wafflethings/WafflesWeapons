using UnityEngine;

public class GoToTarget : MonoBehaviour
{
	public ToDo onTargetReach;

	public float speed;

	public bool easeIn;

	public float easeInSpeed;

	private float currentSpeed;

	public Transform target;

	private Rigidbody rb;

	private bool stopped;

	public UltrakillEvent events;

	[HideInInspector]
	public bool activated;

	private void Start()
	{
	}

	private void FixedUpdate()
	{
	}

	private void Activate()
	{
	}
}
