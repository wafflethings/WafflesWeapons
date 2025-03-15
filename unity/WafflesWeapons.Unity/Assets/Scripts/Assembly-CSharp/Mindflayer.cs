using Sandbox;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class Mindflayer : MonoBehaviour, IEnrage, IAlter, IAlterOptions<bool>
{
	private Animator anim;

	private float defaultAnimSpeed;

	[HideInInspector]
	public bool active;

	public Transform model;

	public GameObject homingProjectile;

	public GameObject decorativeProjectile;

	public GameObject warningFlash;

	public GameObject warningFlashUnparriable;

	public GameObject decoy;

	public Transform[] tentacles;

	private SwingCheck2 sc;

	public float cooldown;

	private bool inAction;

	private bool overrideRotation;

	private Vector3 overrideTarget;

	private bool dontTeleport;

	private EnemyIdentifier eid;

	private Machine mach;

	private LayerMask environmentMask;

	private float decoyThreshold;

	private int teleportAttempts;

	private int teleportInterval;

	public GameObject bigHurt;

	public GameObject windUp;

	public GameObject windUpSmall;

	public GameObject teleportSound;

	private bool goingLeft;

	private bool goForward;

	private Rigidbody rb;

	private bool beaming;

	private bool beamCooldown;

	private bool beamNext;

	public GameObject beam;

	[HideInInspector]
	public GameObject tempBeam;

	public Transform rightHand;

	private float beamDistance;

	private LineRenderer lr;

	private float outOfSightTime;

	public AssetReference deathExplosion;

	public ParticleSystem chargeParticle;

	private bool vibrate;

	private Vector3 origPos;

	private float timeSinceMelee;

	private float spawnAttackDelay;

	private int difficulty;

	private float cooldownMultiplier;

	private bool enraged;

	public GameObject enrageEffect;

	private GameObject currentEnrageEffect;

	private EnemySimplifier[] ensims;

	public GameObject originalGlow;

	public GameObject enrageGlow;

	public Gradient originalTentacleGradient;

	public SkinnedMeshRenderer smr;

	public EnemySimplifier ensim;

	public Mesh maleMesh;

	public Material maleMaterial;

	public Material maleMaterialEnraged;

	[HideInInspector]
	public bool dying;

	private bool launched;

	private Collider[] ownColliders;

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

	private void OnDisable()
	{
	}

	private void UpdateRigidbodySettings()
	{
	}

	private void Update()
	{
	}

	private void FixedUpdate()
	{
	}

	private void RandomizeDirection()
	{
	}

	public void Teleport(bool closeRange = false)
	{
	}

	public void Death()
	{
	}

	private void DeathExplosion()
	{
	}

	public void DeadLaunch(Vector3 direction)
	{
	}

	private void HomingAttack()
	{
	}

	private void BeamAttack()
	{
	}

	private void MeleeAttack()
	{
	}

	public void SwingStart()
	{
	}

	public void DamageStart()
	{
	}

	public void DamageEnd()
	{
	}

	public void LockTarget()
	{
	}

	public void StartBeam()
	{
	}

	private void StopBeam()
	{
	}

	public void ShootProjectiles()
	{
	}

	public void HighDifficultyTeleport()
	{
	}

	public void MeleeTeleport()
	{
	}

	public void ResetAnimSpeed()
	{
	}

	public void StopAction()
	{
	}

	public void Enrage()
	{
	}

	public void UnEnrage()
	{
	}
}
