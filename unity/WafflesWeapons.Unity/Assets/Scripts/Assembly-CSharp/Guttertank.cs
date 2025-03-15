using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Guttertank : MonoBehaviour, IHitTargetCallback
{
	private bool gotValues;

	private EnemyIdentifier eid;

	private NavMeshAgent nma;

	private Machine mach;

	private Rigidbody rb;

	private Animator anim;

	private AudioSource aud;

	private Collider col;

	private int difficulty;

	public bool stationary;

	private Vector3 stationaryPosition;

	private NavMeshPath path;

	private bool walking;

	private Vector3 walkTarget;

	private bool dead;

	[SerializeField]
	private SwingCheck2 sc;

	private bool inAction;

	private bool moveForward;

	private bool trackInAction;

	private bool overrideTarget;

	private bool lookAtTarget;

	private bool punching;

	private Vector3 overrideTargetPosition;

	private float aimRotationLerp;

	private float punchCooldown;

	private bool punchHit;

	public Transform shootPoint;

	public Grenade rocket;

	public GameObject rocketParticle;

	public Transform aimBone;

	private Quaternion torsoDefaultRotation;

	private float shootCooldown;

	private float lineOfSightTimer;

	public Landmine landmine;

	private float mineCooldown;

	private List<Landmine> placedMines;

	private GoreZone gz;

	public AudioSource punchPrepSound;

	public AudioSource rocketPrepSound;

	public AudioSource minePrepSound;

	public AudioSource fallImpactSound;

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

	private void LateUpdate()
	{
	}

	private void FixedUpdate()
	{
	}

	private void SlowUpdate()
	{
	}

	private bool CheckMines()
	{
		return false;
	}

	private void PrepMine()
	{
	}

	private void PlaceMine()
	{
	}

	private void PrepRocket()
	{
	}

	private void PredictTarget()
	{
	}

	private void FireRocket()
	{
	}

	private void Death()
	{
	}

	private void Punch()
	{
	}

	private void PunchActive()
	{
	}

	public void TargetBeenHit()
	{
	}

	private void PunchStop()
	{
	}

	private void FallImpact()
	{
	}

	private void GotParried()
	{
	}

	private void StopParryable()
	{
	}

	private void StopAction()
	{
	}
}
