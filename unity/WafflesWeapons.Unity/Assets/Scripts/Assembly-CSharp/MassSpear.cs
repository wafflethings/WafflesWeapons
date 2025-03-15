using UnityEngine;

public class MassSpear : MonoBehaviour
{
	public EnemyTarget target;

	private LineRenderer lr;

	private Rigidbody rb;

	public bool hittingPlayer;

	public bool hitPlayer;

	public bool beenStopped;

	private bool returning;

	private bool deflected;

	public Transform originPoint;

	private NewMovement nmov;

	public float spearHealth;

	private int difficulty;

	public GameObject breakMetalSmall;

	private AudioSource aud;

	public AudioClip hit;

	public AudioClip stop;

	private Mass mass;

	public float speedMultiplier;

	public float damageMultiplier;

	private void Start()
	{
	}

	private void OnDisable()
	{
	}

	private void Update()
	{
	}

	private void HurtEnemy(GameObject target, EnemyIdentifier eid = null)
	{
	}

	private void OnTriggerEnter(Collider other)
	{
	}

	private void DelayedPlayerCheck()
	{
	}

	public void GetHurt(float damage)
	{
	}

	public void Deflected()
	{
	}

	private void Return()
	{
	}

	private void CheckForDistance()
	{
	}
}
