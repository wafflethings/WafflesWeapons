using UnityEngine;
using UnityEngine.AI;

public class Mannequin : MonoBehaviour
{
	private bool gotValues;

	private Animator anim;

	private NavMeshAgent nma;

	private NavMeshPath nmp;

	private Machine mach;

	private EnemyIdentifier eid;

	private Rigidbody rb;

	private SwingCheck2 sc;

	public GameObject bloodSpray;

	private bool skitterMode;

	private float walkSpeed;

	private float skitterSpeed;

	private int difficulty;

	public bool inAction;

	public MannequinBehavior behavior;

	public bool dontChangeBehavior;

	public bool dontAutoDrop;

	public bool dontMeleeBehavior;

	public bool stationary;

	private Vector3 randomMovementTarget;

	private bool trackTarget;

	private bool moveForward;

	[SerializeField]
	private TrailRenderer[] trails;

	[SerializeField]
	private Transform shootPoint;

	private bool aiming;

	[SerializeField]
	private Transform aimBone;

	private Vector3 aimPoint;

	public Projectile projectile;

	public GameObject chargeProjectile;

	[HideInInspector]
	public GameObject currentChargeProjectile;

	private bool chargingProjectile;

	private float meleeCooldown;

	private float projectileCooldown;

	private float jumpCooldown;

	private float meleeBehaviorCancel;

	public bool inControl;

	private bool canCling;

	[HideInInspector]
	public bool clinging;

	private Collider clungSurfaceCollider;

	private int attacksWhileClinging;

	private Vector3 clingNormal;

	private Vector3? clungMovementTarget;

	[SerializeField]
	private float clungMovementTolerance;

	private bool firstClingCheck;

	public AudioSource clingSound;

	private Collider col;

	[SerializeField]
	private AudioSource skitterSound;

	public string mostRecentAction;

	[HideInInspector]
	public bool jumping;

	private static bool debug => false;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void OnEnable()
	{
	}

	private void GetValues()
	{
	}

	private void UpdateBuff()
	{
	}

	private void SetSpeed()
	{
	}

	private void SlowUpdate()
	{
	}

	private void Update()
	{
	}

	private void FixedUpdate()
	{
	}

	private void LateUpdate()
	{
	}

	private float EvaluateMaxClingWalkDistance(Vector3 origin, Vector3 movementDirection, Vector3 backToWallDirection, float maxDistance = 20f, float incrementLength = 1.5f)
	{
		return 0f;
	}

	private void RelocateWhileClinging(ClungMannequinMovementDirection direction)
	{
	}

	private void CheckClings()
	{
	}

	private void ClingToSurface(RaycastHit hit)
	{
	}

	public void Uncling()
	{
	}

	private void MeleeAttack()
	{
	}

	private void ProjectileAttack()
	{
	}

	private void Jump()
	{
	}

	private void JumpNow()
	{
	}

	private void MoveToTarget(Vector3 target, bool forceSkitter = false, bool clungMode = false)
	{
	}

	public void OnDeath()
	{
	}

	private void StopTracking(int parryable = 0)
	{
	}

	private void SwingStart(int limb = 0)
	{
	}

	private void SwingEnd(int parryEnd = 0)
	{
	}

	private void ChargeProjectile()
	{
	}

	private void ShootProjectile()
	{
	}

	public void ChangeBehavior(bool noMelee = false)
	{
	}

	public void ResetMovementTarget()
	{
	}

	private void StopAiming()
	{
	}

	public void Landing()
	{
	}

	public void StopAction()
	{
	}

	public void StopAction(bool changeBehavior = true)
	{
	}

	public void CancelActions(bool changeBehavior = true)
	{
	}

	public void SetMovementTarget(Vector3 direction, float distance = -1f)
	{
	}

	private void DelayedGroundCheckReenable()
	{
	}

	private float GetRealDistance(NavMeshPath path)
	{
		return 0f;
	}

	private Vector3 GetTargetPosition()
	{
		return default(Vector3);
	}
}
