using System.Collections.Generic;
using Sandbox;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.AddressableAssets;

public class SpiderBody : MonoBehaviour, IEnrage, IAlter, IAlterOptions<bool>
{
	private NavMeshAgent nma;

	private Quaternion followPlayerRot;

	public GameObject proj;

	private RaycastHit hit2;

	private bool readyToShoot;

	private float burstCharge;

	private int maxBurst;

	private int currentBurst;

	public float health;

	public bool stationary;

	private Rigidbody rb;

	private bool falling;

	private Enemy enemy;

	private Transform firstChild;

	private CharacterJoint[] cjs;

	private CharacterJoint cj;

	public GameObject impactParticle;

	public GameObject impactSprite;

	private Quaternion spriteRot;

	private Vector3 spritePos;

	public Transform mouth;

	private GameObject currentProj;

	private bool charging;

	public GameObject chargeEffect;

	[HideInInspector]
	public GameObject currentCE;

	private float beamCharge;

	private AudioSource ceAud;

	private Light ceLight;

	private Vector3 predictedPlayerPos;

	public GameObject spiderBeam;

	private GameObject currentBeam;

	public AssetReference beamExplosion;

	private GameObject currentExplosion;

	private float beamProbability;

	private Quaternion predictedRot;

	private bool rotating;

	public GameObject dripBlood;

	private GameObject currentDrip;

	public AudioClip hurtSound;

	private StyleCalculator scalc;

	private EnemyIdentifier eid;

	public GameObject spark;

	private int difficulty;

	private float coolDownMultiplier;

	private int beamsAmount;

	private float maxHealth;

	public GameObject enrageEffect;

	[HideInInspector]
	public GameObject currentEnrageEffect;

	private Material origMaterial;

	public Material woundedMaterial;

	public Material woundedEnrageMaterial;

	public GameObject woundedParticle;

	private bool parryable;

	private MusicManager muman;

	private bool requestedMusic;

	private GoreZone gz;

	[SerializeField]
	private Transform headModel;

	public GameObject breakParticle;

	private bool corpseBroken;

	public AssetReference shockwave;

	private EnemySimplifier[] ensims;

	public Renderer mainMesh;

	public float targetHeight;

	private float defaultHeight;

	[SerializeField]
	private Collider headCollider;

	private List<EnemyIdentifier> fallEnemiesHit;

	private int parryFramesLeft;

	private EnemyTarget target => null;

	public string alterKey => null;

	public string alterCategoryName => null;

	public AlterOption<bool>[] options => null;

	public bool isEnraged { get; private set; }

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void OnDisable()
	{
	}

	private void Update()
	{
	}

	private void FixedUpdate()
	{
	}

	public void GetHurt(GameObject target, Vector3 force, Vector3 hitPoint, float multiplier, GameObject sourceWeapon = null)
	{
	}

	public void Die()
	{
	}

	private void ShootProj()
	{
	}

	private void ChargeBeam()
	{
	}

	private void BeamChargeEnd()
	{
	}

	private void BeamFire()
	{
	}

	private void StopWaiting()
	{
	}

	private void ReadyToShoot()
	{
	}

	public void TriggerHit(Collider other)
	{
	}

	private void FallKillEnemy(EnemyIdentifier targetEid)
	{
	}

	private void OnCollisionEnter(Collision other)
	{
	}

	public void BreakCorpse()
	{
	}

	private void ResolveStuckness()
	{
	}

	public void Enrage()
	{
	}

	public void UnEnrage()
	{
	}
}
