using System.Collections.Generic;
using UnityEngine;

public class Cannonball : MonoBehaviour
{
	public bool launchable;

	[SerializeField]
	public bool launched;

	private Rigidbody rb;

	private Collider col;

	[SerializeField]
	private GameObject breakEffect;

	private bool checkingForBreak;

	private bool broken;

	public float damage;

	public float speed;

	public bool parry;

	[HideInInspector]
	public Sisyphus sisy;

	public bool ghostCollider;

	public bool canBreakBeforeLaunched;

	[Header("Physics Cannonball Settings")]
	public bool physicsCannonball;

	public AudioSource bounceSound;

	[HideInInspector]
	public List<EnemyIdentifier> hitEnemies;

	public int maxBounces;

	private int currentBounces;

	[HideInInspector]
	public bool hasBounced;

	[HideInInspector]
	public bool forceMaxSpeed;

	public int durability;

	[SerializeField]
	private GameObject interruptionExplosion;

	[SerializeField]
	private GameObject groundHitShockwave;

	[HideInInspector]
	public GameObject sourceWeapon;

	private TimeSince instaBreakDefence;

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}

	private void FixedUpdate()
	{
	}

	public void Launch()
	{
	}

	public void Unlaunch(bool relaunchable = true)
	{
	}

	private void OnTriggerEnter(Collider other)
	{
	}

	public void Collide(Collider other)
	{
	}

	public void Break()
	{
	}

	private void Bounce()
	{
	}

	public void Explode()
	{
	}

	public void InstaBreakDefenceCancel()
	{
	}
}
