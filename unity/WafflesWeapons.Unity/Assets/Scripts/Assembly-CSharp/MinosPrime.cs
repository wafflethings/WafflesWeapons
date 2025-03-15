using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MinosPrime : MonoBehaviour, IHitTargetCallback
{
	private NavMeshAgent nma;

	private Animator anim;

	private Machine mach;

	private EnemyIdentifier eid;

	private GroundCheckEnemy gce;

	private Rigidbody rb;

	private Collider col;

	private AudioSource aud;

	private float originalHp;

	private bool inAction;

	private float cooldown;

	private MPAttack lastAttack;

	private Vector3 playerPos;

	private bool tracking;

	private bool fullTracking;

	private bool aiming;

	private bool jumping;

	public GameObject explosion;

	public GameObject rubble;

	public GameObject bigRubble;

	public GameObject groundWave;

	public GameObject swoosh;

	public Transform aimingBone;

	private Transform head;

	public GameObject projectileCharge;

	public GameObject snakeProjectile;

	private bool hasProjectiled;

	public GameObject warningFlash;

	public GameObject parryableFlash;

	private bool gravityInAction;

	private bool hasRiderKicked;

	private bool previouslyRiderKicked;

	private int downSwingAmount;

	private bool ignoreRiderkickAngle;

	public GameObject attackTrail;

	public GameObject swingSnake;

	private List<GameObject> currentSwingSnakes;

	private bool uppercutting;

	private bool hitSuccessful;

	private bool gotParried;

	public Transform[] swingLimbs;

	private bool swinging;

	private bool boxing;

	private int attacksSinceBoxing;

	private SwingCheck2 sc;

	private GoreZone gz;

	private int attackAmount;

	private bool enraged;

	public GameObject passiveEffect;

	private GameObject currentPassiveEffect;

	public GameObject flameEffect;

	public GameObject phaseChangeEffect;

	private int difficulty;

	private MPAttack previousCombo;

	private bool activated;

	private bool ascending;

	private bool vibrating;

	private Vector3 origPos;

	public GameObject lightShaft;

	public GameObject outroExplosion;

	public UltrakillEvent onOutroEnd;

	private Vector3 spawnPoint;

	[Header("Voice clips")]
	public AudioClip[] riderKickVoice;

	public AudioClip[] dropkickVoice;

	public AudioClip[] dropAttackVoice;

	public AudioClip[] boxingVoice;

	public AudioClip[] comboVoice;

	public AudioClip[] overheadVoice;

	public AudioClip[] projectileVoice;

	public AudioClip[] uppercutVoice;

	public AudioClip phaseChangeVoice;

	public AudioClip[] hurtVoice;

	private bool bossVersion;

	private EnemyTarget target => null;

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

	private void OnDisable()
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

	private void LateUpdate()
	{
	}

	private void CustomPhysics()
	{
	}

	private void PickAttack(int type)
	{
	}

	private void Dropkick()
	{
	}

	private void ProjectilePunch()
	{
	}

	private void Jump()
	{
	}

	private void Uppercut()
	{
	}

	private void RiderKick()
	{
	}

	private void DropAttack()
	{
	}

	private void DownSwing()
	{
	}

	public void UppercutActivate()
	{
	}

	public void UppercutCancel(int parryable = 0)
	{
	}

	public void Combo()
	{
	}

	public void Boxing()
	{
	}

	private void RiderKickActivate()
	{
	}

	private void DropAttackActivate()
	{
	}

	public void SnakeSwingStart(int limb)
	{
	}

	public void DamageStart()
	{
	}

	public void DamageStop()
	{
	}

	public void Explosion()
	{
	}

	public void ProjectileCharge()
	{
	}

	public void ProjectileShoot()
	{
	}

	public void TeleportOnGround()
	{
	}

	public void TeleportAnywhere()
	{
	}

	public void TeleportSide(int side)
	{
	}

	public void Teleport(Vector3 teleportTarget, Vector3 startPos)
	{
	}

	public void Death()
	{
	}

	public void Ascend()
	{
	}

	private void LightShaft()
	{
	}

	public void OutroEnd()
	{
	}

	public void EnableGravity(int earlyCancel)
	{
	}

	public void Parryable()
	{
	}

	public void GotParried()
	{
	}

	public void Rubble()
	{
	}

	public void ResetRotation()
	{
	}

	public void DisableGravity()
	{
	}

	public void StopTracking()
	{
	}

	public void StopAction()
	{
	}

	public void TargetBeenHit()
	{
	}

	public void OutOfBounds()
	{
	}

	public void Vibrate()
	{
	}

	public void PlayVoice(AudioClip[] voice)
	{
	}

	public void ResolveStuckness()
	{
	}
}
