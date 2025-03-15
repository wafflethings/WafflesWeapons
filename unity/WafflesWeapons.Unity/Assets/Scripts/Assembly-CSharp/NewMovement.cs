using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class NewMovement : MonoSingleton<NewMovement>
{
	[HideInInspector]
	public bool modNoDashSlide;

	[HideInInspector]
	public bool modNoJump;

	[HideInInspector]
	public float modForcedFrictionMultip;

	private float friction;

	private InputManager inman;

	[HideInInspector]
	public AssistController asscon;

	public float walkSpeed;

	public float jumpPower;

	public float airAcceleration;

	public float wallJumpPower;

	private bool jumpCooldown;

	[HideInInspector]
	public bool falling;

	[HideInInspector]
	public Rigidbody rb;

	private Vector3 movementDirection;

	private Vector3 movementDirection2;

	private Vector3 airDirection;

	public float timeBetweenSteps;

	private float stepTime;

	private int currentStep;

	private Quaternion tempRotation;

	private GameObject forwardPoint;

	public GroundCheck gc;

	public GroundCheck slopeCheck;

	private WallCheck wc;

	private Vector3 wallJumpPos;

	public int currentWallJumps;

	private AudioSource aud;

	private AudioSource aud2;

	private AudioSource aud3;

	private int currentSound;

	public AudioClip jumpSound;

	public AudioClip landingSound;

	public AudioClip finalWallJump;

	public bool walking;

	public int hp;

	public float antiHp;

	private float antiHpCooldown;

	private bool cantInstaHeal;

	public Image hurtScreen;

	private AudioSource hurtAud;

	private Color hurtColor;

	private Color currentColor;

	private float hurtInvincibility;

	public bool dead;

	public bool endlessMode;

	public DeathSequence deathSequence;

	public FlashImage hpFlash;

	public FlashImage antiHpFlash;

	private AudioSource greenHpAud;

	private float currentAllVolume;

	public bool boost;

	public Vector3 dodgeDirection;

	private float boostLeft;

	private float dashStorage;

	public float boostCharge;

	public AudioClip dodgeSound;

	public CameraController cc;

	public GameObject staminaFailSound;

	public GameObject screenHud;

	private Vector3 hudOriginalPos;

	public GameObject dodgeParticle;

	public GameObject scrnBlood;

	private Canvas fullHud;

	public GameObject hudCam;

	private Vector3 camOriginalPos;

	private RigidbodyConstraints defaultRBConstraints;

	private GameObject revolver;

	private StyleHUD shud;

	private GameObject wallScrape;

	private SurfaceType currentScrapeSurfaceType;

	public StyleCalculator scalc;

	public bool activated;

	public int gamepadFreezeCount;

	private float fallSpeed;

	public bool jumping;

	private float fallTime;

	public GameObject impactDust;

	public GameObject fallParticle;

	private GameObject currentFallParticle;

	[HideInInspector]
	public CapsuleCollider playerCollider;

	public bool sliding;

	private float slideSafety;

	public GameObject slideParticle;

	private GameObject currentSlideParticle;

	private ParticleSystem.TrailModule slideTrail;

	private ParticleSystem.MinMaxGradient normalSlideGradient;

	public ParticleSystem.MinMaxGradient invincibleSlideGradient;

	private GameObject slideScrape;

	private SurfaceType currentSlideSurfaceType;

	private Vector3 slideMovDirection;

	public GameObject slideStopSound;

	private bool crouching;

	public bool standing;

	private bool slideEnding;

	private Vector3 groundCheckPos;

	public AudioSource oilSlideEffect;

	private bool onGasoline;

	private GameObject currentFrictionlessSlideParticle;

	private SurfaceType currentFricSlideSurfaceType;

	private AudioSource[] fricSlideAuds;

	private float[] fricSlideAudVols;

	private float[] fricSlideAudPitches;

	private LayerMask frictionlessSurfaceMask;

	private GunControl gunc;

	public float currentSpeed;

	private FistControl punch;

	public GameObject dashJumpSound;

	public bool slowMode;

	public Vector3 pushForce;

	private float slideLength;

	[HideInInspector]
	public float longestSlide;

	private float preSlideSpeed;

	private float preSlideDelay;

	public bool quakeJump;

	public GameObject quakeJumpSound;

	[HideInInspector]
	public bool exploded;

	[HideInInspector]
	public float safeExplosionLaunchCooldown;

	private float clingFade;

	public bool stillHolding;

	public float slamForce;

	private bool slamStorage;

	[HideInInspector]
	public float slamCooldown;

	private bool launched;

	private int difficulty;

	[HideInInspector]
	public int sameCheckpointRestarts;

	public CustomGroundProperties groundProperties;

	[HideInInspector]
	public int rocketJumps;

	[HideInInspector]
	public int hammerJumps;

	[HideInInspector]
	public Grenade ridingRocket;

	[HideInInspector]
	public int rocketRides;

	private float ssjMaxFrames;

	public Light pointLight;

	public TimeSince sinceSlideEnd;

	[HideInInspector]
	public bool levelOver;

	[HideInInspector]
	public HashSet<Water> touchingWaters;

	private Vector3Int? lastCheckedGasolineVoxel;

	private int framesSinceSlide;

	private Vector3 velocityAfterSlide;

	protected override void Awake()
	{
	}

	private void OnDisable()
	{
	}

	private void OnPrefChanged(string key, object value)
	{
	}

	private void Start()
	{
	}

	protected override void OnDestroy()
	{
	}

	public AudioSource DuplicateDetachWhoosh()
	{
		return null;
	}

	public AudioSource RestoreWhoosh()
	{
		return null;
	}

	private void FrictionlessSlideParticle()
	{
	}

	private void Update()
	{
	}

	private void FixedUpdate()
	{
	}

	private void Move()
	{
	}

	private void Dodge()
	{
	}

	public void Jump()
	{
	}

	private void TrySSJ(Vector3 direction, float speedMultiplier, Func<int, float> speedLossFormula)
	{
	}

	private void WallJump()
	{
	}

	private void OnCollisionEnter(Collision other)
	{
	}

	public void LaunchUp(float multiplier)
	{
	}

	public void Launch(Vector3 direction, float multiplier = 8f, bool ignoreMass = false)
	{
	}

	public void LaunchFromPoint(Vector3 position, float strength, float maxDistance = 1f)
	{
	}

	public void LaunchFromPointAtSpeed(Vector3 position, float speed)
	{
	}

	public void Slamdown(float strength)
	{
	}

	private void JumpReady()
	{
	}

	public void FakeHurt(bool silent = false)
	{
	}

	public void GetHurt(int damage, bool invincible, float scoreLossMultiplier = 1f, bool explosion = false, bool instablack = false, float hardDamageMultiplier = 0.35f, bool ignoreInvincibility = false)
	{
	}

	public void ForceAntiHP(float amount, bool silent = false, bool dontOverwriteHp = false, bool addToCooldown = true, bool stopInstaHeal = false)
	{
	}

	public void ForceAddAntiHP(float amount, bool silent = false, bool dontOverwriteHp = false, bool addToCooldown = true, bool stopInstaHeal = false)
	{
	}

	public void GetHealth(int health, bool silent, bool fromExplosion = false, bool bloodsplatter = true)
	{
	}

	public void FullHeal(bool silent)
	{
	}

	public void Parry(EnemyIdentifier eid = null, string customParryText = "")
	{
	}

	public void SuperCharge()
	{
	}

	public void Respawn()
	{
	}

	public void ResetHardDamage()
	{
	}

	private void NotJumping()
	{
	}

	public void EnemyStepResets()
	{
	}

	public void LandingImpact()
	{
	}

	private void StartSlide()
	{
	}

	private void CreateSlideScrape(bool ignorePrevious = false, bool frictionlessVersion = false)
	{
	}

	private void SetFrictionlessSlideValues()
	{
	}

	private void CreateWallScrape(Vector3 position, bool ignorePrevious = false)
	{
	}

	private void CheckForGasoline()
	{
	}

	public void StopSlide()
	{
	}

	private void DetachSlideScrape()
	{
	}

	private void DetachWallScrape()
	{
	}

	private void DetachScrape(GameObject scrape)
	{
	}

	public void EmptyStamina()
	{
	}

	public void FullStamina()
	{
	}

	public void DeactivatePlayer()
	{
	}

	public void ActivatePlayer()
	{
	}

	public void StopMovement()
	{
	}

	public void DeactivateMovement()
	{
	}

	public void ReactivateMovement()
	{
	}

	public void LockMovementAxes()
	{
	}

	public void UnlockMovementAxes()
	{
	}
}
