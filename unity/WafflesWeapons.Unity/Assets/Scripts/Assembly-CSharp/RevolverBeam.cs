using System.Collections.Generic;
using CustomRay;
using UnityEngine;

public class RevolverBeam : MonoBehaviour
{
	private const float ForceBulletPropMulti = 0.005f;

	public EnemyTarget target;

	public BeamType beamType;

	public HitterAttribute[] attributes;

	private LineRenderer lr;

	private AudioSource aud;

	private Light muzzleLight;

	public Vector3 alternateStartPoint;

	public GameObject sourceWeapon;

	[HideInInspector]
	public int bodiesPierced;

	private int enemiesPierced;

	private RaycastHit[] allHits;

	[HideInInspector]
	public List<RaycastResult> hitList;

	private GunControl gc;

	private RaycastHit hit;

	private Vector3 shotHitPoint;

	public CameraController cc;

	private bool maliciousIgnorePlayer;

	public GameObject hitParticle;

	public int bulletForce;

	public bool quickDraw;

	public int gunVariation;

	public float damage;

	[HideInInspector]
	public float addedDamage;

	public float enemyDamageOverride;

	public float critDamageOverride;

	public float screenshakeMultiplier;

	public int hitAmount;

	public int maxHitsPerTarget;

	private int currentHits;

	public bool noMuzzleflash;

	private bool fadeOut;

	private bool didntHit;

	private LayerMask ignoreEnemyTrigger;

	private LayerMask enemyLayerMask;

	private LayerMask pierceLayerMask;

	public int ricochetAmount;

	[HideInInspector]
	public bool hasBeenRicocheter;

	public GameObject ricochetSound;

	public GameObject enemyHitSound;

	public bool fake;

	public EnemyType ignoreEnemyType;

	public bool deflected;

	private bool chargeBacked;

	public bool strongAlt;

	public bool ultraRicocheter;

	public bool canHitProjectiles;

	private bool hasHitProjectile;

	[HideInInspector]
	public List<EnemyIdentifier> hitEids;

	[HideInInspector]
	public Transform previouslyHitTransform;

	[HideInInspector]
	public bool aimAssist;

	[HideInInspector]
	public bool intentionalRicochet;

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void FakeShoot(Vector3 target)
	{
	}

	private void Shoot()
	{
	}

	private void CheckWater(float distance)
	{
	}

	private void HitSomething(RaycastHit hit)
	{
	}

	private void PiercingShotOrder()
	{
	}

	private void PiercingShotCheck()
	{
	}

	public void ExecuteHits(RaycastHit currentHit)
	{
	}

	private void RicochetAimAssist(GameObject beam, bool aimAtHead = false)
	{
	}
}
