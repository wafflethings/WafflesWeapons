using Sandbox;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.AddressableAssets;

public class StatueBoss : MonoBehaviour, IEnrage, IAlter, IAlterOptions<bool>
{
	private Animator anim;

	private NavMeshAgent nma;

	private NavMeshPath nmp;

	private CameraController cc;

	private Rigidbody rb;

	[HideInInspector]
	public bool inAction;

	public bool stationary;

	public Transform stompPos;

	public AssetReference stompWave;

	private bool tracking;

	private bool dashing;

	private float dashPower;

	private GameObject currentStompWave;

	private float meleeRecharge;

	private float playerInCloseRange;

	private bool dontFall;

	[HideInInspector]
	public bool damaging;

	[HideInInspector]
	public bool launching;

	[HideInInspector]
	public int damage;

	private int tackleChance;

	private int extraTackles;

	private float rangedRecharge;

	private int throwChance;

	public float attackCheckCooldown;

	public AssetReference orbProjectile;

	private Light orbLight;

	private Vector3 projectedPlayerPos;

	private bool orbGrowing;

	public GameObject stepSound;

	private ParticleSystem part;

	private AudioSource partAud;

	private Statue st;

	public GameObject backUp;

	public GameObject statueChargeSound;

	public GameObject statueChargeSound2;

	public GameObject statueChargeSound3;

	public bool enraged;

	public GameObject enrageEffect;

	public GameObject currentEnrageEffect;

	private EnemySimplifier[] ensims;

	private int difficulty;

	private SwingCheck2 swingCheck;

	private GroundCheckEnemy gc;

	private EnemyIdentifier eid;

	private Collider enemyCollider;

	private float originalLightRange;

	private float originalNmaRange;

	private float originalNmaSpeed;

	private float originalNmaAcceleration;

	private float originalNmaAngularSpeed;

	private float realSpeedModifier;

	private static readonly int WalkSpeed;

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

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void SlowUpdate()
	{
	}

	private void SetDestination(Vector3 position)
	{
	}

	private void Update()
	{
	}

	private void FixedUpdate()
	{
	}

	private void Stomp()
	{
	}

	private void Tackle()
	{
	}

	private void Throw()
	{
	}

	public void StompHit()
	{
	}

	public void OrbSpawn()
	{
	}

	public void OrbRespawn()
	{
	}

	public void StopAction()
	{
	}

	public void StopTracking()
	{
	}

	public void Dash()
	{
	}

	public void StopDash()
	{
	}

	private void DelayedTackle()
	{
	}

	public void ForceStopDashSound()
	{
	}

	public void StartDamage()
	{
	}

	public void StopDamage()
	{
	}

	public void Step()
	{
	}

	public void EnrageDelayed()
	{
	}

	public void UnEnrage()
	{
	}

	public void Enrage()
	{
	}
}
