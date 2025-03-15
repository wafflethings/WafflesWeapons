using UnityEngine;

public class Harpoon : MonoBehaviour
{
	[SerializeField]
	private Magnet magnet;

	public bool drill;

	private bool drilling;

	private float drillCooldown;

	private bool hit;

	private bool stopped;

	private bool punched;

	public float damage;

	private float damageLeft;

	private AudioSource aud;

	public AudioClip environmentHitSound;

	public AudioClip enemyHitSound;

	private Rigidbody rb;

	private EnemyIdentifierIdentifier target;

	public AudioSource drillSound;

	private AudioSource currentDrillSound;

	public int drillHits;

	private int drillHitsLeft;

	private Vector3 startPosition;

	[SerializeField]
	private GameObject breakEffect;

	private FixedJoint fj;

	private TrailRenderer tr;

	[HideInInspector]
	public GameObject sourceWeapon;

	private void Start()
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

	private void OnDestroy()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
	}

	public void Punched()
	{
	}

	private void DestroyIfNotHit()
	{
	}

	private void MasterDestroy()
	{
	}

	public void DelayedDestroyIfOnCorpse(float delay = 1f)
	{
	}

	private void DestroyIfOnCorpse()
	{
	}
}
