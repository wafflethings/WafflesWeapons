using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class PlatformerMovement : MonoSingleton<PlatformerMovement>
{
	public Transform platformerCamera;

	public Vector3 cameraTarget;

	public Vector3 defaultCameraTarget;

	public Vector3 defaultFreeCameraTarget;

	public Vector3 cameraRotation;

	private Vector3 defaultCameraRotation;

	[HideInInspector]
	public List<CameraTargetInfo> cameraTargets;

	private bool cameraTrack;

	private bool cameraLowered;

	public bool freeCamera;

	[HideInInspector]
	public float rotationY;

	[HideInInspector]
	public float rotationX;

	private float lastYPos;

	private float currentYPos;

	private bool beenOverYPosMax;

	private float yPosDifferential;

	public GroundCheck groundCheck;

	[SerializeField]
	private GroundCheck slopeCheck;

	public Transform playerModel;

	[HideInInspector]
	public Rigidbody rb;

	private AudioSource aud;

	private CapsuleCollider playerCollider;

	private Animator anim;

	[SerializeField]
	private AudioClip jumpSound;

	[SerializeField]
	private AudioClip dodgeSound;

	[SerializeField]
	private AudioClip bounceSound;

	[HideInInspector]
	public bool activated;

	private Vector3 movementDirection;

	private Vector3 movementDirection2;

	private Vector3 airDirection;

	private Vector3 dodgeDirection;

	private float walkSpeed;

	private float jumpPower;

	private bool airFrictionless;

	private bool boost;

	private float boostCharge;

	private float boostLeft;

	[SerializeField]
	private GameObject staminaFailSound;

	[SerializeField]
	private GameObject dodgeParticle;

	[SerializeField]
	private GameObject dashJumpSound;

	private MaterialPropertyBlock block;

	private SkinnedMeshRenderer smr;

	[HideInInspector]
	public bool sliding;

	private bool crouching;

	private bool slideEnding;

	private float preSlideSpeed;

	private float preSlideDelay;

	private float slideSafety;

	private float slideLength;

	[SerializeField]
	private GameObject slideStopSound;

	[SerializeField]
	private GameObject slideEffect;

	[SerializeField]
	private GameObject slideScrape;

	private GameObject currentSlideEffect;

	private GameObject currentSlideScrape;

	[SerializeField]
	private GameObject fallParticle;

	private GameObject currentFallParticle;

	private bool jumping;

	private bool inSpecialJump;

	private bool jumpCooldown;

	[HideInInspector]
	public CustomGroundProperties groundProperties;

	public Transform jumpShadow;

	private bool falling;

	private float fallSpeed;

	private float fallTime;

	private bool aboutToSlam;

	private TimeSince slamWindUp;

	[SerializeField]
	private AudioSource slamReadySound;

	private bool slamming;

	public float slamForce;

	[SerializeField]
	private GameObject impactDust;

	private bool spinning;

	private float spinJuice;

	private Vector3 spinDirection;

	private float spinSpeed;

	private float spinCooldown;

	public Transform holder;

	private int difficulty;

	[SerializeField]
	private GameObject spinZone;

	[SerializeField]
	private GameObject coinGet;

	private float coinTimer;

	private float coinPitch;

	private int queuedCoins;

	private float coinEffectTimer;

	public int extraHits;

	private bool invincible;

	private float blinkTimer;

	public GameObject[] protectors;

	private float superTimer;

	public GameObject protectorGet;

	public GameObject protectorLose;

	public GameObject protectorOof;

	private InputBinding rbSlide;

	private InputBinding dpadMove;

	[Header("Death Stuff")]
	[SerializeField]
	private Material burnMaterial;

	[SerializeField]
	private GameObject defaultBurnEffect;

	[SerializeField]
	private GameObject ashParticle;

	[SerializeField]
	private GameObject ashSound;

	private GameObject currentCorpse;

	[SerializeField]
	private GameObject fallSound;

	[HideInInspector]
	public bool dead;

	protected override void Awake()
	{
	}

	private void Start()
	{
	}

	public void CheckItem()
	{
	}

	protected override void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void UpdateWings()
	{
	}

	private void Update()
	{
	}

	private void CheckCameraTarget(bool instant = false)
	{
	}

	private void FixedUpdate()
	{
	}

	public void Jump(bool silent = false, float multiplier = 1f)
	{
	}

	private void Dodge()
	{
	}

	public void Slam()
	{
	}

	public void SlamEnd(bool cancel = false)
	{
	}

	private void Spin()
	{
	}

	private void StopSpin()
	{
	}

	private void StartSlide()
	{
	}

	public void StopSlide()
	{
	}

	private void SlideValues()
	{
	}

	public void EmptyStamina()
	{
	}

	public void FullStamina()
	{
	}

	private void JumpReady()
	{
	}

	private void NotJumping()
	{
	}

	public void AddExtraHit(int amount = 1)
	{
	}

	private void CheckProtector()
	{
	}

	private void GetHit()
	{
	}

	private void StopInvincibility()
	{
	}

	private void Death()
	{
	}

	public void Fall()
	{
	}

	public void Explode(bool ignoreInvincible = false)
	{
	}

	public void Burn(bool ignoreInvincible = false)
	{
	}

	private void BecomeAsh()
	{
	}

	private void DeathOver()
	{
	}

	public void Respawn()
	{
	}

	public void CoinGet()
	{
	}

	public void CoinGetEffect()
	{
	}

	public void SnapCamera()
	{
	}

	public void SnapCamera(Vector3 targetPos, Vector3 targetRot)
	{
	}

	public void ResetCamera(float degreesY, float degreesX = 0f)
	{
	}
}
