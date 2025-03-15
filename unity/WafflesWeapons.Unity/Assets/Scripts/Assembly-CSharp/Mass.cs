using System.Collections.Generic;
using UnityEngine;

public class Mass : MonoBehaviour
{
	private Animator anim;

	private bool battleMode;

	private Vector3 targetPos;

	private Quaternion targetRot;

	private float transformCooldown;

	private bool walking;

	private float walkWeight;

	public bool inAction;

	private bool inSemiAction;

	public Transform[] shootPoints;

	public GameObject homingProjectile;

	private float homingAttackChance;

	public float attackCooldown;

	public GameObject explosiveProjectile;

	public GameObject slamExplosion;

	private SwingCheck2[] swingChecks;

	private float swingCooldown;

	private bool attackedOnce;

	private float playerDistanceCooldown;

	public Transform tailEnd;

	private GameObject tailSpear;

	private float spearCooldown;

	public GameObject spear;

	public bool spearShot;

	public GameObject spearFlash;

	public GameObject tempSpear;

	public List<GameObject> tailHitboxes;

	public GameObject regurgitateSound;

	public GameObject bigPainSound;

	public GameObject windupSound;

	public bool dead;

	public bool crazyMode;

	public float crazyModeHealth;

	private Statue stat;

	private EnemyIdentifier eid;

	private int crazyPoint;

	public GameObject enrageEffect;

	public GameObject currentEnrageEffect;

	public Material enrageMaterial;

	public Material highVisShockwave;

	public GameObject[] activateOnEnrage;

	private int difficulty;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void UpdateBuff()
	{
	}

	private void SetSpeed()
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

	private void LateUpdate()
	{
	}

	public void HomingAttack()
	{
	}

	public void ExplosiveAttack()
	{
	}

	public void SwingAttack()
	{
	}

	public void ToScout()
	{
	}

	public void ToBattle()
	{
	}

	public void SlamImpact()
	{
	}

	public void ShootHoming(int arm)
	{
	}

	public void ShootExplosive(int arm)
	{
	}

	private void ReadySpear()
	{
	}

	public void ShootSpear()
	{
	}

	public void SpearParried()
	{
	}

	public void SpearReturned()
	{
	}

	public void StopAction()
	{
	}

	public void BattleSlam()
	{
	}

	public void SwingStart()
	{
	}

	public void SwingEnd()
	{
	}

	public void Enrage()
	{
	}

	public void CrazyReady()
	{
	}

	public void CrazyShoot()
	{
	}
}
