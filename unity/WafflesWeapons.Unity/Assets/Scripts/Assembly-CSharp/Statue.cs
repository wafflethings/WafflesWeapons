using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Statue : MonoBehaviour
{
	public float health;

	[HideInInspector]
	public float originalHealth;

	private BloodsplatterManager bsm;

	public bool limp;

	private EnemyIdentifier eid;

	public GameObject chest;

	private float chestHP;

	private AudioSource aud;

	public AudioClip[] hurtSounds;

	private StyleCalculator scalc;

	private GoreZone gz;

	public Material deadMaterial;

	public Material woundedMaterial;

	public Material woundedEnrageMaterial;

	public GameObject woundedParticle;

	public GameObject woundedModel;

	private Material originalMaterial;

	public SkinnedMeshRenderer smr;

	private NavMeshAgent nma;

	private Rigidbody rb;

	private Rigidbody[] rbs;

	private Animator anim;

	public AudioClip deathSound;

	private bool noheal;

	public List<GameObject> extraDamageZones;

	public float extraDamageMultiplier;

	private StatueBoss sb;

	private Mass mass;

	private Vector3 origPos;

	private List<Transform> transforms;

	public bool grounded;

	private GroundCheckEnemy gc;

	public bool knockedBack;

	private float knockBackCharge;

	public float brakes;

	public float juggleWeight;

	public bool falling;

	private float fallSpeed;

	private float fallTime;

	private bool affectedByGravity;

	[HideInInspector]
	public bool musicRequested;

	public bool bigBlood;

	public bool massDeath;

	private bool massDying;

	public bool specialDeath;

	public bool parryable;

	public bool partiallyParryable;

	[HideInInspector]
	public List<Transform> parryables;

	private int parryFramesLeft;

	private bool parryFramesOnPartial;

	private void Start()
	{
	}

	private void OnDestroy()
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

	public void GetHurt(GameObject target, Vector3 force, float multiplier, float critMultiplier, Vector3 hurtPos, GameObject sourceWeapon = null, bool fromExplosion = false)
	{
	}

	public void GoLimp()
	{
	}

	private void StopHealing()
	{
	}

	private void BloodExplosion()
	{
	}

	private void DeathEnd()
	{
	}

	private void ReadyGib(GameObject tempGib, GameObject target)
	{
	}

	public void ParryableCheck(bool partial = false)
	{
	}
}
