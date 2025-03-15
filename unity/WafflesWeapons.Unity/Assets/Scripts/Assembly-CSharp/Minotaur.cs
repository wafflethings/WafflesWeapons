using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Minotaur : MonoBehaviour, IHitTargetCallback
{
	private Rigidbody rb;

	private EnemyIdentifier eid;

	private Animator anim;

	private Machine mach;

	private NavMeshAgent nma;

	private int difficulty;

	private bool gotValues;

	private bool dead;

	private float cooldown;

	private int previousAttack;

	private int currentAttacks;

	private float ramCooldown;

	private bool inAction;

	private bool moveForward;

	private float moveSpeed;

	private float moveBreakSpeed;

	private bool trackTarget;

	private float trackSpeed;

	private Transform tempTarget;

	private bool chaseTarget;

	[SerializeField]
	private AudioSource roar;

	[SerializeField]
	private AudioClip roarClip;

	[SerializeField]
	private AudioClip roarShortClip;

	[SerializeField]
	private AudioClip squealClip;

	[SerializeField]
	private AudioClip longGruntClip;

	[SerializeField]
	private AudioClip exhaleClip;

	[SerializeField]
	private SwingCheck2[] hammerSwingChecks;

	[SerializeField]
	private TrailRenderer hammerTrail;

	[SerializeField]
	private Transform hammerPoint;

	[SerializeField]
	private GameObject hammerImpact;

	[SerializeField]
	private GameObject hammerExplosion;

	[SerializeField]
	private GameObject hammerBigExplosion;

	public bool tantrumOnSpawn;

	[SerializeField]
	private GameObject meatInHand;

	[SerializeField]
	private GameObject handBlood;

	[SerializeField]
	private GameObject toxicCloud;

	[SerializeField]
	private GameObject toxicCloudLong;

	[SerializeField]
	private GameObject goop;

	[SerializeField]
	private GameObject goopLong;

	[HideInInspector]
	public float ramTimer;

	[SerializeField]
	private GameObject ramStuff;

	[SerializeField]
	private GameObject fallEffect;

	private Vector3 deathPosition;

	private List<Transform> deathTransforms;

	private float deathTimer;

	private GoreZone gz;

	public UltrakillEvent onDeath;

	private float playerAirBias;

	private void Start()
	{
	}

	private void GetValues()
	{
	}

	private void UpdateBuff()
	{
	}

	private void SetSpeed()
	{
	}

	private void Update()
	{
	}

	private void FixedUpdate()
	{
	}

	private void SlowUpdate()
	{
	}

	private void Ram()
	{
	}

	private void RamStart()
	{
	}

	private void RamBonk(Vector3 point)
	{
	}

	private void StopRam()
	{
	}

	private void MeatCloud()
	{
	}

	private void MeatPool()
	{
	}

	private void HandBlood()
	{
	}

	private void MeatSpawn()
	{
	}

	private void MeatExplode()
	{
	}

	private void MeatSplash()
	{
	}

	private void MeatThrowThrow()
	{
	}

	private void HammerSmash()
	{
	}

	private void HammerTantrum()
	{
	}

	public void QuickTantrum()
	{
	}

	private void HammerSwingStart()
	{
	}

	private void HammerImpact()
	{
	}

	private void HammerExplosion(int size = 0)
	{
	}

	private void HammerSwingStop(int startTrackingTarget = 0)
	{
	}

	private void HammerSwingStopImpact(int startTrackingTarget = 0)
	{
	}

	private void StartTracking()
	{
	}

	private void StopMoving()
	{
	}

	private void GotParried()
	{
	}

	public void GotSlammed()
	{
	}

	private void StopAction()
	{
	}

	public void TargetBeenHit()
	{
	}

	public void Death()
	{
	}

	private void BloodExplosion()
	{
	}

	private void Roar()
	{
	}

	private void Roar(float pitch = 1f)
	{
	}

	private void Roar(AudioClip clip, float pitch = 1f)
	{
	}

	private void BodyImpact()
	{
	}
}
