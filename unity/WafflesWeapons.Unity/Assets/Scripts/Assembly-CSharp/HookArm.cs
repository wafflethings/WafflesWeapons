using System.Collections.Generic;
using UnityEngine;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class HookArm : MonoSingleton<HookArm>
{
	public bool equipped;

	private LineRenderer lr;

	private Animator anim;

	private Vector3 hookPoint;

	private Vector3 previousHookPoint;

	[HideInInspector]
	public HookState state;

	private bool returning;

	[SerializeField]
	private GameObject model;

	private CapsuleCollider playerCollider;

	public Transform hand;

	public Transform hook;

	public GameObject hookModel;

	private Vector3 throwDirection;

	private float returnDistance;

	private LayerMask throwMask;

	private LayerMask enviroMask;

	private LayerMask enemyMask;

	private float throwWarp;

	private Transform caughtTransform;

	private Vector3 caughtPoint;

	private Collider caughtCollider;

	private EnemyIdentifier caughtEid;

	private List<EnemyType> deadIgnoreTypes;

	private List<EnemyType> lightEnemies;

	private GroundCheckEnemy enemyGroundCheck;

	private Rigidbody enemyRigidbody;

	private HookPoint caughtHook;

	private bool lightTarget;

	[SerializeField]
	private LineRenderer inspectLr;

	private bool forcingGroundCheck;

	private bool forcingFistControl;

	private AudioSource aud;

	[Header("Sounds")]
	public GameObject throwSound;

	public GameObject hitSound;

	public GameObject pullSound;

	public GameObject pullDoneSound;

	public GameObject catchSound;

	public GameObject errorSound;

	public AudioClip throwLoop;

	public AudioClip pullLoop;

	public GameObject wooshSound;

	private GameObject currentWoosh;

	public GameObject clinkSparks;

	public GameObject clinkObjectSparks;

	private float cooldown;

	private CameraFrustumTargeter targeter;

	[HideInInspector]
	public bool beingPulled;

	private List<Rigidbody> caughtObjects;

	private float semiBlocked;

	private Grenade caughtGrenade;

	private Cannonball caughtCannonball;

	private void Start()
	{
	}

	public void Inspect()
	{
	}

	private void Update()
	{
	}

	private void LateUpdate()
	{
	}

	private void FixedUpdate()
	{
	}

	private void SolveDeadIgnore()
	{
	}

	private void ItemGrabError(RaycastHit rhit)
	{
	}

	public void StopThrow(float animationTime = 0f, bool sparks = false)
	{
	}

	public void Cancel()
	{
	}

	public void CatchOver()
	{
	}

	private void ForceGroundCheck()
	{
	}

	private void StopForceGroundCheck()
	{
	}

	private void SemiBlockCheck()
	{
	}
}
