using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Machine : MonoBehaviour
{
	public float health;

	private BloodsplatterManager bsm;

	public bool limp;

	private EnemyIdentifier eid;

	public GameObject chest;

	private float chestHP;

	private AudioSource aud;

	public AudioClip[] hurtSounds;

	[HideInInspector]
	public StyleCalculator scalc;

	private GoreZone gz;

	public Material deadMaterial;

	private Material originalMaterial;

	public SkinnedMeshRenderer smr;

	private NavMeshAgent nma;

	private Rigidbody rb;

	private Rigidbody[] rbs;

	private Animator anim;

	public AudioClip deathSound;

	public AudioClip scream;

	private bool noheal;

	public bool bigKill;

	public bool thickLimbs;

	public bool parryable;

	public bool partiallyParryable;

	[HideInInspector]
	public List<Transform> parryables;

	private SwordsMachine sm;

	private Streetcleaner sc;

	private V2 v2;

	private Mindflayer mf;

	private Sisyphus sisy;

	private Turret tur;

	private Ferryman fm;

	private Mannequin man;

	private Minotaur min;

	private Gutterman gm;

	public GameObject[] destroyOnDeath;

	public Machine symbiote;

	private bool symbiotic;

	private bool healing;

	public bool grounded;

	[HideInInspector]
	public GroundCheckEnemy gc;

	public bool knockedBack;

	public bool overrideFalling;

	private float knockBackCharge;

	public float brakes;

	public float juggleWeight;

	public bool falling;

	private LayerMask lmask;

	private LayerMask lmaskWater;

	private float fallSpeed;

	private float fallTime;

	private float reduceFallTime;

	public bool noFallDamage;

	public bool dontDie;

	public bool dismemberment;

	public bool specialDeath;

	public bool simpleDeath;

	[HideInInspector]
	public bool musicRequested;

	public UnityEvent onDeath;

	private int parryFramesLeft;

	private bool parryFramesOnPartial;

	public Transform hitJiggleRoot;

	private Vector3 jiggleRootPosition;

	private void Awake()
	{
	}

	private void Start()
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

	public void KnockBack(Vector3 force)
	{
	}

	public void StopKnockBack()
	{
	}

	public void GetHurt(GameObject target, Vector3 force, float multiplier, float critMultiplier, GameObject sourceWeapon = null, bool fromExplosion = false)
	{
	}

	public void GoLimp()
	{
	}

	public void GoLimp(bool fromExplosion = false)
	{
	}

	private void StartHealing()
	{
	}

	private void StopHealing()
	{
	}

	public void CanisterExplosion()
	{
	}

	public void ReadyGib(GameObject tempGib, GameObject target)
	{
	}

	public void ParryableCheck(bool partial = false)
	{
	}
}
