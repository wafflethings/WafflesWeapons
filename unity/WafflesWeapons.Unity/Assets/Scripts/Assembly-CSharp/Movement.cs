using UnityEngine;

public class Movement : MonoBehaviour
{
	public float walkSpeed;

	public float jumpPower;

	private bool jumpCooldown;

	private bool falling;

	private Rigidbody rb;

	private Vector3 movementDirection;

	private Vector3 airDirection;

	public float timeBetweenSteps;

	private float stepTime;

	private int currentStep;

	public Animator anim;

	private GameObject body;

	private Quaternion tempRotation;

	private GameObject forwardPoint;

	private GroundCheck gc;

	private WallCheck wc;

	private PlayerAnimations pa;

	private Vector3 wallJumpPos;

	private int currentWallJumps;

	private AudioSource aud;

	private AudioSource aud2;

	private AudioSource aud3;

	private int currentSound;

	public AudioClip[] jumpSounds;

	public AudioClip landingSound;

	public AudioClip finalWallJump;

	private void Awake()
	{
	}

	private void Update()
	{
	}

	private void JumpReady()
	{
	}
}
