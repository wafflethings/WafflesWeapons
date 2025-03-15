using System.Collections.Generic;
using UnityEngine;
using plog;

public class BlackHoleProjectile : MonoBehaviour
{
	private static readonly plog.Logger Log;

	public EnemyTarget target;

	private Rigidbody rb;

	public float speed;

	private Light bhlight;

	private float targetRange;

	private RaycastHit rhit;

	private AudioSource aud;

	public GameObject lightningBolt;

	public GameObject lightningBolt2;

	private Transform aura;

	public Material additive;

	private bool activated;

	private bool collapsing;

	private float power;

	private StyleCalculator scalc;

	private int killAmount;

	public List<EnemyIdentifier> shootList;

	private List<Rigidbody> caughtList;

	public bool enemy;

	public EnemyType safeType;

	private Collider col;

	[HideInInspector]
	public bool fadingIn;

	private Vector3 origScale;

	public GameObject spawnEffect;

	public GameObject explosionEffect;

	private void Start()
	{
	}

	private void FixedUpdate()
	{
	}

	private void OnDisable()
	{
	}

	private void OnEnable()
	{
	}

	private void Update()
	{
	}

	private void ShootRandomLightning()
	{
	}

	private void ShootTargetLightning()
	{
	}

	public void Activate()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
	}

	private void Collapse()
	{
	}

	public void FadeIn()
	{
	}

	public void Explode()
	{
	}
}
