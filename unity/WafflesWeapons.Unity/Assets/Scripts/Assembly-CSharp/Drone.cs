using System.Collections.Generic;
using Sandbox;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class Drone : MonoBehaviour, IEnrage, IAlter, IAlterOptions<bool>
{
	public bool dontStartAware;

	public bool stationary;

	public float health;

	public bool crashing;

	private Vector3 crashTarget;

	private Rigidbody rb;

	private bool canInterruptCrash;

	private Transform modelTransform;

	public bool targetSpotted;

	public bool toLastKnownPos;

	private Vector3 lastKnownPos;

	private Vector3 nextRandomPos;

	public float checkCooldown;

	public float blockCooldown;

	public float preferredDistanceToTarget;

	private BloodsplatterManager bsm;

	public AssetReference explosion;

	public AssetReference gib;

	private StyleCalculator scalc;

	private EnemyIdentifier eid;

	private EnemyType type;

	private AudioSource aud;

	public AudioClip hurtSound;

	public AudioClip deathSound;

	public AudioClip windUpSound;

	public AudioClip spotSound;

	public AudioClip loseSound;

	private float dodgeCooldown;

	private float attackCooldown;

	public AssetReference projectile;

	private Material origMaterial;

	public Material shootMaterial;

	private EnemySimplifier[] ensims;

	public ParticleSystem chargeParticle;

	private bool killedByPlayer;

	private bool parried;

	private bool exploded;

	private bool parryable;

	private Vector3 viewTarget;

	[HideInInspector]
	public bool musicRequested;

	private GoreZone gz;

	private int difficulty;

	private Animator anim;

	public bool enraged;

	public GameObject enrageEffect;

	private int usedAttacks;

	[HideInInspector]
	public List<VirtueInsignia> childVi;

	private EnemyCooldowns vc;

	private KeepInBounds kib;

	private bool checkingForCrash;

	private bool canHurtOtherDrones;

	[HideInInspector]
	public bool lockRotation;

	[HideInInspector]
	public bool lockPosition;

	private bool hooked;

	private bool homeRunnable;

	public bool cantInstaExplode;

	private GameObject currentEnrageEffect;

	[HideInInspector]
	public bool fleshDrone;

	private int parryFramesLeft;

	public GameObject ghost;

	private EnemyTarget target => null;

	private int relevantSightBlockMask => 0;

	public bool isEnraged { get; private set; }

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

	private void OnDisable()
	{
	}

	private void OnEnable()
	{
	}

	private void UpdateRigidbodySettings()
	{
	}

	private void Update()
	{
	}

	private void SlowUpdate()
	{
	}

	private void FixedUpdate()
	{
	}

	public void RandomDodge()
	{
	}

	public void Dodge(Vector3 direction)
	{
	}

	public void GetHurt(Vector3 force, float multiplier, GameObject sourceWeapon = null, bool fromExplosion = false)
	{
	}

	public void PlaySound(AudioClip clippe)
	{
	}

	public void Explode()
	{
	}

	private void Death(bool fromExplosion = false)
	{
	}

	public void Shoot()
	{
	}

	private void SetProjectileSettings(Projectile proj)
	{
	}

	public void SpawnInsignia()
	{
	}

	private void OnCollisionStay(Collision collision)
	{
	}

	private void OnTriggerEnter(Collider other)
	{
	}

	private void CanInterruptCrash()
	{
	}

	public void Hooked()
	{
	}

	public void Unhooked()
	{
	}

	private void DelayedUnhooked()
	{
	}

	private void NoMoreHomeRun()
	{
	}

	public void Enrage()
	{
	}

	public void UnEnrage()
	{
	}
}
