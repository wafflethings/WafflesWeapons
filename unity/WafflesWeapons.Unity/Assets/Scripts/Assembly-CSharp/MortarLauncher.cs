using UnityEngine;

public class MortarLauncher : MonoBehaviour
{
	private EnemyIdentifier eid;

	public Transform shootPoint;

	public Projectile mortar;

	private float cooldown;

	public float firingDelay;

	public float firstFireDelay;

	public float projectileForce;

	public UltrakillEvent onFire;

	private Animator anim;

	private int difficulty;

	private float difficultySpeedModifier;

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void ShootHoming()
	{
	}

	public void ChangeFiringDelay(float target)
	{
	}
}
