using UnityEngine;

public class VirtueInsignia : MonoBehaviour
{
	public EnemyTarget target;

	public GameObject explosion;

	public int damage;

	private bool hasHitTarget;

	private float offset;

	private SpriteRenderer[] sprites;

	private bool activating;

	private float activationTime;

	private float currentDistance;

	public float windUpSpeedMultiplier;

	public float explosionLength;

	public int charges;

	private float explosionWidth;

	private AudioSource explAud;

	private Light lit;

	[HideInInspector]
	public Drone parentDrone;

	[HideInInspector]
	public Transform otherParent;

	public bool hadParent;

	public bool predictive;

	public bool noTracking;

	public Sprite predictiveVersion;

	public Sprite multiVersion;

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void Activating()
	{
	}

	private void Explode()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
	}
}
