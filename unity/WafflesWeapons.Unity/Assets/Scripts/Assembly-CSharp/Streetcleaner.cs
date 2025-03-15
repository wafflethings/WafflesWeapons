using UnityEngine;
using UnityEngine.AI;
using UnityEngine.AddressableAssets;

public class Streetcleaner : MonoBehaviour
{
	private Animator anim;

	private NavMeshAgent nma;

	private Rigidbody rb;

	public bool dead;

	private TrailRenderer handTrail;

	private LayerMask enviroMask;

	public bool dodging;

	private float dodgeSpeed;

	private float dodgeCooldown;

	public GameObject dodgeSound;

	public Transform hose;

	public Transform hoseTarget;

	public GameObject canister;

	public AssetReference explosion;

	public bool canisterHit;

	public GameObject firePoint;

	private Transform warningFlame;

	private ParticleSystem firePart;

	private Light fireLight;

	private AudioSource fireAud;

	public GameObject fireStopSound;

	public bool damaging;

	private bool attacking;

	public GameObject warningFlash;

	[SerializeField]
	private Transform aimBone;

	private Quaternion torsoDefaultRotation;

	[SerializeField]
	private Transform flameThrowerBone;

	private int difficulty;

	private float cooldown;

	private RaycastHit rhit;

	private GroundCheck playergc;

	private bool playerInAir;

	private GroundCheckEnemy gc;

	private Machine mach;

	[HideInInspector]
	public EnemyIdentifier eid;

	private EnemyTarget target => null;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void OnDisable()
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

	public void StartFire()
	{
	}

	public void StartDamaging()
	{
	}

	public void StopFire()
	{
	}

	public void Dodge()
	{
	}

	public void StopMoving()
	{
	}

	public void DodgeEnd()
	{
	}

	public void DeflectShot()
	{
	}

	public void SlapOver()
	{
	}

	public void OverrideOver()
	{
	}

	private float GetDistanceToTarget()
	{
		return 0f;
	}

	private void TryIgniteStains()
	{
	}
}
