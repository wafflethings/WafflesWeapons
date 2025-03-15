using System.Collections.Generic;
using Sandbox;
using UnityEngine;
using UnityEngine.Serialization;

public class HurtZone : MonoBehaviour, IAlter, IAlterOptions<float>
{
	public EnviroDamageType damageType;

	public bool trigger;

	public AffectedSubjects affected;

	public bool ignoreDashingPlayer;

	public bool ignoreInvincibility;

	private bool ignoringDash;

	public float bounceForce;

	private Collider col;

	public float hurtCooldown;

	[FormerlySerializedAs("damage")]
	public float setDamage;

	public float hardDamagePercentage;

	public float enemyDamageOverride;

	private int hurtingPlayer;

	private float playerHurtCooldown;

	private Rigidbody rb;

	private List<Collider> childColliders;

	private List<HurtZoneEnemyTracker> enemies;

	public GameObject hurtParticle;

	private int difficulty;

	private float damageMultiplier;

	private NewMovement newMovement;

	private PlayerTracker playerTracker;

	private PlatformerMovement platformerMovement;

	public List<EnemyType> ignoredEnemyTypes;

	public GameObject sourceWeapon;

	private float damage => 0f;

	public string alterKey => null;

	public string alterCategoryName => null;

	public AlterOption<float>[] options => null;

	private void Start()
	{
	}

	private void OnDisable()
	{
	}

	private void FixedUpdate()
	{
	}

	private bool DamageEnemy(EnemyIdentifier eid, int i)
	{
		return false;
	}

	private HurtZoneEnemyTracker EnemiesContains(EnemyIdentifier eid)
	{
		return null;
	}

	private void Enter(Collider other)
	{
	}

	private void Exit(Collider other)
	{
	}

	private void OnTriggerEnter(Collider other)
	{
	}

	private void OnCollisionEnter(Collision other)
	{
	}

	private void OnTriggerExit(Collider other)
	{
	}

	private void OnCollisionExit(Collision other)
	{
	}
}
