using UnityEngine;

public class Lerp : MonoBehaviour
{
	[SerializeField]
	private Vector3 position;

	[SerializeField]
	private Vector3 rotation;

	[SerializeField]
	private float moveSpeed;

	[SerializeField]
	private float rotateSpeed;

	private Quaternion qRot;

	[SerializeField]
	private bool ease;

	[SerializeField]
	private float easeSpeed;

	private float currentEaseMultiplier;

	[SerializeField]
	private bool onEnable;

	[SerializeField]
	private bool inFixedUpdate;

	[SerializeField]
	private bool inLocalSpace;

	private bool moving;

	[SerializeField]
	private UltrakillEvent onComplete;

	private void Start()
	{
	}

	private void OnEnable()
	{
	}

	private void Update()
	{
	}

	private void FixedUpdate()
	{
	}

	private void Move(float amount)
	{
	}

	public void Activate()
	{
	}

	public void Skip()
	{
	}
}
