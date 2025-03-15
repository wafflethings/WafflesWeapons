using Sandbox;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.AddressableAssets;
using plog;

public class SwordsMachine : MonoBehaviour, IEnrage, IAlter, IAlterOptions<bool>, IEnemyRelationshipLogic
{
	private static readonly plog.Logger Log;

	public Transform targetZone;

	private NavMeshAgent nma;

	private Animator anim;

	private Rigidbody rb;

	private Machine mach;

	public float phaseChangeHealth;

	public bool firstPhase;

	public bool active;

	public Transform rightArm;

	[SerializeField]
	private Transform[] aimBones;

	private float aimLerp;

	public bool inAction;

	public bool inSemiAction;

	[HideInInspector]
	public bool moveAtTarget;

	private Vector3 moveTarget;

	private float moveSpeed;

	public TrailRenderer swordTrail;

	public TrailRenderer slapTrail;

	public SkinnedMeshRenderer swordMR;

	public Material enragedSword;

	public Material heatMat;

	private Material origMat;

	private AudioSource swordAud;

	public GameObject swingSound;

	public GameObject head;

	public AssetReference flash;

	public AssetReference gunFlash;

	private bool runningAttack;

	public float runningAttackCharge;

	public bool damaging;

	public int damage;

	public float runningAttackChance;

	private EnemyShotgun shotgun;

	private bool shotgunning;

	private bool gunDelay;

	public GameObject shotgunPickUp;

	public GameObject activateOnPhaseChange;

	private bool usingShotgun;

	public Transform secondPhasePosTarget;

	[SerializeField]
	private GameObject teleportEffect;

	public CheckPoint cpToReset;

	public float swordThrowCharge;

	public int throwType;

	public GameObject[] thrownSword;

	private GameObject currentThrownSword;

	public Transform handTransform;

	private float swordThrowChance;

	private float spiralSwordChance;

	public float chaseThrowCharge;

	public GameObject bigPainSound;

	private Vector3 targetFuturePos;

	private int difficulty;

	public bool enraged;

	private float rageLeft;

	public EnemySimplifier ensim;

	private float normalAnimSpeed;

	private float normalMovSpeed;

	public GameObject enrageEffect;

	public GameObject currentEnrageEffect;

	private AudioSource enrageAud;

	public Door[] doorsInPath;

	public bool eternalRage;

	public bool bothPhases;

	private bool knockedDown;

	public bool downed;

	[SerializeField]
	private SwingCheck2[] swordSwingCheck;

	[SerializeField]
	private SwingCheck2 slapSwingCheck;

	private GroundCheckEnemy gc;

	private bool bossVersion;

	private EnemyIdentifier eid;

	private BloodsplatterManager bsm;

	private float idleFailsafe;

	private bool idling;

	private bool inPhaseChange;

	private float moveSpeedMultiplier;

	private bool breakableInWay;

	private bool targetViewBlocked;

	private bool targetingStalker;

	public float spawnAttackDelay;

	private EnemyTarget target => null;

	public bool isEnraged => false;

	public string alterKey => null;

	public string alterCategoryName => null;

	AlterOption<bool>[] IAlterOptions<bool>.options => null;

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

	private void SlowUpdate()
	{
	}

	private void NavigationUpdate()
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

	public void RunningSwing()
	{
	}

	private void Combo()
	{
	}

	private void SwordThrow()
	{
	}

	private void SwordSpiral()
	{
	}

	public void StartMoving()
	{
	}

	public void StopMoving()
	{
	}

	public void LookAt()
	{
	}

	public void StopAction()
	{
	}

	public void SemiStopAction()
	{
	}

	public void HeatSword()
	{
	}

	public void HeatSwordThrow()
	{
	}

	public void CoolSword()
	{
	}

	public void DamageStart()
	{
	}

	public void DamageStop()
	{
	}

	public void ShootGun()
	{
	}

	public void StopShootAnimation()
	{
	}

	private void ShootDelay()
	{
	}

	public void FlashGun()
	{
	}

	public void SwordSpawn()
	{
	}

	public void SwordCatch()
	{
	}

	private void EndFirstPhase()
	{
	}

	public void Knockdown(bool light = false, bool fromExplosion = false)
	{
	}

	public void Down(bool fromExplosion = false)
	{
	}

	public void Disappear()
	{
	}

	public void Enrage()
	{
	}

	public void UnEnrage()
	{
	}

	public void CheckLoop()
	{
	}

	public bool ShouldAttackEnemies()
	{
		return false;
	}

	public bool ShouldIgnorePlayer()
	{
		return false;
	}
}
