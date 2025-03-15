using UnityEngine;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class ClimbStep : MonoSingleton<ClimbStep>
{
	private InputManager inman;

	private Rigidbody rb;

	private int layerMask;

	private NewMovement newMovement;

	private float step;

	private float allowedAngle;

	private float allowedSpeed;

	private float allowedInput;

	private float cooldown;

	private float cooldownMax;

	private float deltaVertical;

	private float deltaHorizontal;

	private Vector3 position;

	private Vector3 gizmoPosition1;

	private Vector3 gizmoPosition2;

	private Vector3 movementDirection;

	private new void Awake()
	{
	}

	private void Start()
	{
	}

	private void FixedUpdate()
	{
	}

	private void OnCollisionStay(Collision collisionInfo)
	{
	}
}
