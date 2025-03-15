using System.Collections.Generic;
using UnityEngine;

public class Chainsaw : MonoBehaviour
{
	[HideInInspector]
	public Rigidbody rb;

	public float damage;

	public Transform attachedTransform;

	[HideInInspector]
	public Transform lineStartTransform;

	[SerializeField]
	private AudioSource ropeSnapSound;

	private AudioSource aud;

	public AudioSource stoppedAud;

	[SerializeField]
	private GameObject ricochetEffect;

	[SerializeField]
	private AudioClip enemyHitSound;

	[SerializeField]
	private GameObject enemyHitParticle;

	private LineRenderer lr;

	[HideInInspector]
	public bool stopped;

	public bool heated;

	public int hitAmount;

	private int currentHitAmount;

	private Transform hitTarget;

	private List<Transform> hitLimbs;

	private EnemyIdentifier currentHitEnemy;

	private float multiHitCooldown;

	private float sameEnemyHitCooldown;

	[HideInInspector]
	public Vector3 originalVelocity;

	[HideInInspector]
	public bool beingPunched;

	private bool beenPunched;

	private bool inPlayer;

	private float playerHitTimer;

	private TimeSince ignorePlayerTimer;

	private float raycastBlockedTimer;

	[HideInInspector]
	public string weaponType;

	[HideInInspector]
	public GameObject sourceWeapon;

	public Nail sawbladeVersion;

	[SerializeField]
	private Renderer model;

	[SerializeField]
	private Transform sprite;

	private void Start()
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

	private void Update()
	{
	}

	private void FixedUpdate()
	{
	}

	private void TouchPlayer()
	{
	}

	private void TouchEnemy(Transform other)
	{
	}

	private void HitEnemy(Transform other, EnemyIdentifierIdentifier eidid = null)
	{
	}

	private void DamageEnemy(Transform other, EnemyIdentifier eid)
	{
	}

	public void CheckMultipleRicochets(bool onStart = false)
	{
	}

	public void GetPunched()
	{
	}

	public void TurnIntoSawblade()
	{
	}
}
