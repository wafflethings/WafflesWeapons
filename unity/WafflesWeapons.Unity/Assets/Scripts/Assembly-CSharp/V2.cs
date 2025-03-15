using System.Collections.Generic;
using Sandbox;
using UnityEngine;
using UnityEngine.AI;

public class V2 : MonoBehaviour, IEnrage, IAlter, IAlterOptions<bool>
{
	private Animator anim;

	private Transform overrideTarget;

	private Rigidbody overrideTargetRb;

	private Vector3 targetPos;

	private Quaternion targetRot;

	public Transform[] aimAtTarget;

	private Rigidbody rb;

	private NavMeshAgent nma;

	private int currentWeapon;

	public SkinnedMeshRenderer smr;

	private EnemySimplifier[] ensims;

	public Texture[] wingTextures;

	public GameObject wingChangeEffect;

	public Color[] wingColors;

	public GameObject[] weapons;

	private GameObject currentWingChangeEffect;

	private TrailRenderer[] wingTrails;

	private DragBehind[] drags;

	private int currentPattern;

	private bool inPattern;

	public GroundCheckEnemy gc;

	public GroundCheckEnemy wc;

	private int pattern1direction;

	public GameObject jumpSound;

	public GameObject dashJumpSound;

	public bool secondEncounter;

	public bool slowMode;

	public float movementSpeed;

	private float originalMovementSpeed;

	public float jumpPower;

	public float wallJumpPower;

	public float airAcceleration;

	public bool intro;

	[HideInInspector]
	public bool inIntro;

	public bool active;

	private bool running;

	private bool aiming;

	private bool sliding;

	private bool dodging;

	private bool jumping;

	private float patternCooldown;

	private float dodgeCooldown;

	private float dodgeLeft;

	public GameObject dodgeEffect;

	public GameObject slideEffect;

	private int difficulty;

	private float slideStopTimer;

	private TimeSince randomSlideCheck;

	private float shootCooldown;

	private float altShootCooldown;

	public GameObject gunFlash;

	public GameObject altFlash;

	private bool aboutToShoot;

	private bool chargingAlt;

	private float predictAmount;

	private bool aimAtGround;

	public bool dontDie;

	public Transform escapeTarget;

	private bool escaping;

	private bool dead;

	public bool longIntro;

	private bool staringAtPlayer;

	private bool introHitGround;

	private EnemyIdentifierIdentifier[] eidids;

	private BossHealthBar bhb;

	public GameObject shockwave;

	public GameObject KoScream;

	private RaycastHit rhit;

	private float distancePatience;

	private bool enraged;

	public GameObject enrageEffect;

	private GameObject currentEnrageEffect;

	private Machine mac;

	private EnemyIdentifier eid;

	private bool drilled;

	private float circleTimer;

	public GameObject spawnOnDeath;

	private bool playerInSight;

	private int coinsToThrow;

	private bool shootingForCoin;

	public GameObject coin;

	[HideInInspector]
	public bool firstPhase;

	public float knockOutHealth;

	public bool slideOnly;

	public bool dontEnrage;

	public bool alwaysAimAtGround;

	public Vector3 forceSlideDirection;

	private bool cowardPattern;

	public UltrakillEvent onKnockout;

	private float flashTimer;

	private List<Coin> coins;

	private bool bossVersion;

	private float coinsInSightCooldown;

	private EnemyTarget target => null;

	public bool isEnraged => false;

	public string alterKey => null;

	public string alterCategoryName => null;

	public AlterOption<bool>[] options => null;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void UpdateBuff()
	{
	}

	private void SetSpeed()
	{
	}

	private void Update()
	{
	}

	private void SlowUpdate()
	{
	}

	private void ThrowCoins()
	{
	}

	private void FixedUpdate()
	{
	}

	private void ShootWeapon()
	{
	}

	private void AltShootWeapon()
	{
	}

	private void Move()
	{
	}

	private void LateUpdate()
	{
	}

	private void Jump()
	{
	}

	private void WallJump()
	{
	}

	private void CheckPattern()
	{
	}

	private void ChangeDirection(float degrees)
	{
	}

	public void Dodge(Transform projectile)
	{
	}

	public void ForceDodge(Vector3 direction)
	{
	}

	private void NotJumping()
	{
	}

	private void Slide()
	{
	}

	private void StopSlide()
	{
	}

	private void SwitchWeapon(int weapon)
	{
	}

	public void SwitchPattern(int pattern)
	{
	}

	public void Die()
	{
	}

	public void KnockedOut(string triggerName = "KnockedDown")
	{
	}

	public void Undie()
	{
	}

	public void IntroEnd()
	{
	}

	public void StareAtPlayer()
	{
	}

	public void BeginEscape()
	{
	}

	public void InstaEnrage()
	{
	}

	public void Enrage()
	{
	}

	public void UnEnrage()
	{
	}

	public void SlideOnly(bool value)
	{
	}
}
