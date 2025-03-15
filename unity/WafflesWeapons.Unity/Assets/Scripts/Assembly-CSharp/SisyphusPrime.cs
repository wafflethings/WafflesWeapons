using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SisyphusPrime : MonoBehaviour, IHitTargetCallback
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

	private SPAttack lastPrimaryAttack;

	private SPAttack lastSecondaryAttack;

	private int secondariesSinceLastPrimary;

	private int attacksSinceLastExplosion;

	private Vector3 heightAdjustedTargetPos;

	private bool tracking;

	private bool fullTracking;

	private bool aiming;

	private bool jumping;

	public GameObject explosion;

	public GameObject explosionChargeEffect;

	private GameObject currentExplosionChargeEffect;

	public GameObject rubble;

	public GameObject bigRubble;

	public GameObject groundWave;

	public GameObject swoosh;

	public Transform aimingBone;

	private Transform head;

	public GameObject projectileCharge;

	private GameObject currentProjectileCharge;

	public GameObject sparkleExplosion;

	private bool hasProjectiled;

	public GameObject warningFlash;

	public GameObject parryableFlash;

	private bool gravityInAction;

	public GameObject attackTrail;

	public GameObject swingSnake;

	private List<GameObject> currentSwingSnakes;

	private bool uppercutting;

	private bool hitSuccessful;

	private bool gotParried;

	private Vector3 teleportToGroundFailsafe;

	public Transform[] swingLimbs;

	private bool swinging;

	private bool boxing;

	private SwingCheck2 sc;

	private GoreZone gz;

	private int attackAmount;

	private bool enraged;

	public GameObject passiveEffect;

	private GameObject currentPassiveEffect;

	public GameObject flameEffect;

	public GameObject phaseChangeEffect;

	private int difficulty;

	private SPAttack previousCombo;

	private bool activated;

	private bool ascending;

	private bool vibrating;

	private Vector3 origPos;

	public GameObject lightShaft;

	public GameObject outroExplosion;

	public UltrakillEvent onPhaseChange;

	public UltrakillEvent onOutroEnd;

	private Vector3 spawnPoint;

	[Header("Voice clips")]
	public AudioClip[] uppercutComboVoice;

	public AudioClip[] stompComboVoice;

	public AudioClip phaseChangeVoice;

	public AudioClip[] hurtVoice;

	public AudioClip[] explosionVoice;

	public AudioClip[] tauntVoice;

	public AudioClip[] clapVoice;

	private bool bossVersion;

	private bool taunting;

	private bool tauntCheck;

	private int attacksSinceTaunt;

	private float defaultMoveSpeed;

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

	private void PickAnyAttack()
	{
	}

	private void PickPrimaryAttack(int type = -1)
	{
	}

	private void PickSecondaryAttack(int type = -1)
	{
	}

	public void CancelIntoSecondary()
	{
	}

	public void Taunt()
	{
	}

	public void UppercutCombo()
	{
	}

	public void StompCombo()
	{
	}

	private void Chop()
	{
	}

	private void Clap()
	{
	}

	private void AirStomp()
	{
	}

	private void AirKick()
	{
	}

	private void ExplodeAttack()
	{
	}

	public void ClapStart()
	{
	}

	public void ClapShockwave()
	{
	}

	public void StompShockwave()
	{
	}

	private PhysicalShockwave CreateShockwave(Vector3 position)
	{
		return null;
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

	public void DelayedExplosion(Vector3 target)
	{
	}

	public void TeleportOnGround(int forceNoPrediction = 0)
	{
	}

	public void TeleportAnywhere()
	{
	}

	public void TeleportAnywhere(bool predictive = false)
	{
	}

	public void TeleportAbove()
	{
	}

	public void TeleportAbove(bool predictive = true)
	{
	}

	public void TeleportSideRandom(int predictive)
	{
	}

	public void TeleportSideRandomAir(int predictive)
	{
	}

	public void TeleportSide(int side, bool inAir = false, bool predictive = false)
	{
	}

	public void Teleport(Vector3 teleportTarget, Vector3 startPos)
	{
	}

	public void LookAtTarget()
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

	public void Unparryable()
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

	public void StartTracking()
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

	public void ForceKnockbackDown()
	{
	}

	public void SwingIgnoreSliding()
	{
	}

	public void ResolveStuckness()
	{
	}
}
