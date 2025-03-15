using System.Collections.Generic;
using DebugOverlays;
using UnityEngine;
using plog;

public class SwingCheck2 : MonoBehaviour
{
	private static readonly plog.Logger Log;

	[HideInInspector]
	public EnemyIdentifier eid;

	public EnemyType type;

	public List<Collider> hitColliders;

	private NewMovement nmov;

	public int damage;

	public int enemyDamage;

	public float knockBackForce;

	public bool knockBackDirectionOverride;

	public Vector3 knockBackDirection;

	private LayerMask lmask;

	private List<EnemyIdentifier> hitEnemies;

	public bool strong;

	[HideInInspector]
	public Collider col;

	public Collider[] additionalColliders;

	public bool useRaycastCheck;

	private AudioSource aud;

	private bool physicalCollider;

	[HideInInspector]
	public bool damaging;

	public bool ignoreSlidingPlayer;

	public bool canHitPlayerMultipleTimes;

	public bool startActive;

	public bool interpolateBetweenFrames;

	public Transform checkForCollisionsBetween;

	private Vector3 previousPosition;

	private SwingCheckDebugOverlay debugOverlay;

	private bool hasPrinted;

	private bool playerOnly => false;

	private LayerMask relevantLMask => default(LayerMask);

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void OnEnable()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
	}

	private void OnCollisionEnter(Collision collision)
	{
	}

	private void Update()
	{
	}

	private void CheckCollision(Collider other)
	{
	}

	private void CheckEidCollision(EnemyIdentifier enid, Collider other)
	{
	}

	private void NotifyTargetBeenHit()
	{
	}

	public void DamageStart()
	{
	}

	public void DamageStop()
	{
	}

	public void OverrideEnemyIdentifier(EnemyIdentifier newEid)
	{
	}

	private void UpdateDebugOverlay()
	{
	}

	public void CanHitPlayerMultipleTimes(bool yes)
	{
	}
}
