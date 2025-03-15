using UnityEngine;

public class CancerousRodent : MonoBehaviour
{
	private Rigidbody rb;

	private Machine mach;

	private Statue stat;

	private EnemyIdentifier eid;

	public bool harmless;

	public GameObject[] activateOnDeath;

	public Transform shootPoint;

	public GameObject projectile;

	private float coolDown;

	public int projectileAmount;

	private int currentProjectiles;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void OnDisable()
	{
	}

	private void Update()
	{
	}

	private void FireBurst()
	{
	}
}
