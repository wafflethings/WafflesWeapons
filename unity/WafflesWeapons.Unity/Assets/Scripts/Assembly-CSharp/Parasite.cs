using UnityEngine;

public class Parasite : MonoBehaviour
{
	public EnemyIdentifier parent;

	private EnemyTarget localTarget;

	public Transform projectileSpawnPos;

	private Animator anim;

	public GameObject[] decProjectiles;

	public GameObject[] projectiles;

	private GameObject currentDecProjectile;

	private bool inAction;

	private float cooldown;

	public GameObject windUpSound;

	private int shootType;

	private GoreZone gz;

	private int difficulty;

	public float speedMultiplier;

	public float damageMultiplier;

	private EnemyTarget target => null;

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void Shoot1()
	{
	}

	private void Shoot2()
	{
	}

	public void SpawnProjectile()
	{
	}

	public void ShootProjectile()
	{
	}

	public void StopAction()
	{
	}
}
