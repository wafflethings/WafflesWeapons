using System.Collections.Generic;
using UnityEngine;

public class Nail : MonoBehaviour
{
	public GameObject sourceWeapon;

	[HideInInspector]
	public bool hit;

	public float damage;

	private AudioSource aud;

	[HideInInspector]
	public Rigidbody rb;

	public AudioClip environmentHitSound;

	public AudioClip enemyHitSound;

	public Material zapMaterial;

	public GameObject zapParticle;

	private bool zapped;

	public bool fodderDamageBoost;

	public string weaponType;

	public bool heated;

	[HideInInspector]
	public List<Magnet> magnets;

	private bool launched;

	[HideInInspector]
	public NailBurstController nbc;

	public bool enemy;

	public EnemyType safeEnemyType;

	private Vector3 startPosition;

	[Header("Sawblades")]
	public bool sawblade;

	public bool chainsaw;

	public float hitAmount;

	private EnemyIdentifier currentHitEnemy;

	private float sameEnemyHitCooldown;

	[SerializeField]
	private GameObject sawBreakEffect;

	[SerializeField]
	private GameObject sawBounceEffect;

	[SerializeField]
	private GameObject sawHitEffect;

	[HideInInspector]
	public int magnetRotationDirection;

	private List<Transform> hitLimbs;

	private float removeTimeMultiplier;

	public bool bounceToSurfaceNormal;

	[HideInInspector]
	public bool stopped;

	public int multiHitAmount;

	private int currentMultiHitAmount;

	private float multiHitCooldown;

	private Transform hitTarget;

	[HideInInspector]
	public Vector3 originalVelocity;

	public AudioSource stoppedAud;

	[HideInInspector]
	public bool punchable;

	[HideInInspector]
	public bool punched;

	[HideInInspector]
	public float punchDistance;

	private TimeSince sinceLastEnviroParticle;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void OnDestroy()
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

	public Magnet GetTargetMagnet()
	{
		return null;
	}

	private void OnCollisionEnter(Collision other)
	{
	}

	private void OnTriggerEnter(Collider other)
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

	public void MagnetCaught(Magnet mag)
	{
	}

	public void MagnetRelease(Magnet mag)
	{
	}

	public void Zap()
	{
	}

	private void RemoveTime()
	{
	}

	private void MasterRemoveTime()
	{
	}

	public void SawBreak()
	{
	}

	private float GetFodderDamageMultiplier(EnemyType et)
	{
		return 0f;
	}

	public void ForceCheckSawbladeRicochet()
	{
	}
}
