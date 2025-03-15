using UnityEngine;
using UnityEngine.AI;

public class Ferryman : MonoBehaviour, IHitTargetCallback
{
	private Animator anim;

	private Machine mach;

	private NavMeshAgent nma;

	private Rigidbody rb;

	private GroundCheckEnemy gce;

	private EnemyIdentifier eid;

	private NavMeshPath path;

	private int difficulty;

	private bool inAction;

	private bool tracking;

	private bool moving;

	private float movingSpeed;

	private bool uppercutting;

	private Vector3 playerPos;

	private bool playerApproaching;

	private bool playerRetreating;

	private bool playerAbove;

	private bool playerBelow;

	private float overheadChance;

	private float stingerChance;

	private float kickComboChance;

	[HideInInspector]
	public float defaultMovementSpeed;

	[SerializeField]
	private GameObject parryableFlash;

	[SerializeField]
	private GameObject unparryableFlash;

	[SerializeField]
	private Transform head;

	[SerializeField]
	private GameObject slamExplosion;

	[SerializeField]
	private GameObject lightningBoltWindup;

	[HideInInspector]
	public GameObject currentWindup;

	[SerializeField]
	private LightningStrikeExplosive lightningBolt;

	[SerializeField]
	private AudioSource lightningBoltChimes;

	[SerializeField]
	private EnemySimplifier oarSimplifier;

	private Material originalOar;

	[SerializeField]
	private Material chargedOar;

	[Header("SwingChecks")]
	[SerializeField]
	private SwingCheck2 mainSwingCheck;

	[SerializeField]
	private SwingCheck2 oarSwingCheck;

	[SerializeField]
	private SwingCheck2 kickSwingCheck;

	private SwingCheck2[] swingChecks;

	[SerializeField]
	private AudioSource swingAudioSource;

	[SerializeField]
	private AudioClip[] swingSounds;

	private bool useMain;

	private bool useOar;

	private bool useKick;

	private bool knockBack;

	[Header("Trails")]
	[SerializeField]
	private TrailRenderer frontTrail;

	[SerializeField]
	private TrailRenderer backTrail;

	[SerializeField]
	private TrailRenderer bodyTrail;

	private bool backTrailActive;

	[Header("Footsteps")]
	[SerializeField]
	private ParticleSystem[] footstepParticles;

	[SerializeField]
	private AudioSource footstepAudio;

	private float rollCooldown;

	private float vaultCooldown;

	[Header("Boss Version")]
	[SerializeField]
	private bool bossVersion;

	[SerializeField]
	private float phaseChangeHealth;

	[SerializeField]
	private Transform[] phaseChangePositions;

	private int currentPosition;

	[SerializeField]
	private UltrakillEvent onPhaseChange;

	private bool inPhaseChange;

	private bool hasPhaseChanged;

	private bool hasReachedFinalPosition;

	private bool jumping;

	private float lightningBoltCooldown;

	private float lightningOutOfReachCharge;

	private bool lightningCancellable;

	private Vector3 lastGroundedPosition;

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

	private void SlowUpdate()
	{
	}

	private void Update()
	{
	}

	private void FixedUpdate()
	{
	}

	private void Downslam()
	{
	}

	private void BackstepAttack()
	{
	}

	private void Stinger()
	{
	}

	private void Vault()
	{
	}

	private void VaultSwing()
	{
	}

	private void KickCombo()
	{
	}

	private void OarCombo()
	{
	}

	private void Uppercut()
	{
	}

	public void Roll(bool toPlayerSide = false)
	{
	}

	public void LightningBolt(bool quick = false)
	{
	}

	public void LightningBoltWindup(int quick = 0)
	{
	}

	public void LightningBoltWindupOver()
	{
	}

	public void LightningBoltStrike()
	{
	}

	public void SpawnLightningBolt(Vector3 position, bool safeForPlayer = false)
	{
	}

	public void CancelLightningBolt()
	{
	}

	public void OnDeath()
	{
	}

	private void StartTracking()
	{
	}

	private void StopTracking()
	{
	}

	private void StartMoving(float speed)
	{
	}

	private void StopMoving()
	{
	}

	public void SlamHit()
	{
	}

	private void Footstep(float volume = 0.5f)
	{
	}

	private void StartUppercut()
	{
	}

	private void StopUppercut()
	{
	}

	private void StartDamage(int damage = 25)
	{
	}

	private void StopDamage()
	{
	}

	public void TargetBeenHit()
	{
	}

	private void StopAction()
	{
	}

	public void ParryableFlash()
	{
	}

	public void UnparryableFlash()
	{
	}

	public void GotParried()
	{
	}

	private void PlayerStatus()
	{
	}

	private Vector3 PredictPlayerPos(bool vertical = false, float maxPrediction = 5f)
	{
		return default(Vector3);
	}

	private void SnapToGround()
	{
	}

	public void PhaseChange()
	{
	}

	public void EndPhaseChange()
	{
	}
}
