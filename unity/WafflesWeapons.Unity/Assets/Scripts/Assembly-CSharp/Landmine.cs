using UnityEngine;

public class Landmine : MonoBehaviour
{
	private bool valuesSet;

	private Rigidbody rb;

	private AudioSource aud;

	[SerializeField]
	private GameObject lightCylinder;

	private Light lit;

	private Renderer[] rends;

	private SpriteRenderer sr;

	private MaterialPropertyBlock block;

	[SerializeField]
	private AudioClip activatedBeep;

	[SerializeField]
	private GameObject explosion;

	[SerializeField]
	private GameObject superExplosion;

	[SerializeField]
	private GameObject parryZone;

	private bool activated;

	private bool parried;

	private bool exploded;

	private Vector3 movementDirection;

	public EnemyIdentifier originEnemy;

	private void Start()
	{
	}

	private void SetValues()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
	}

	private void OnCollisionEnter(Collision collision)
	{
	}

	private void FixedUpdate()
	{
	}

	public void Activate(float forceMultiplier = 1f)
	{
	}

	public void Parry()
	{
	}

	private void Explode()
	{
	}

	private void Explode(bool super = false)
	{
	}

	public void SetColor(Color newColor)
	{
	}
}
