using System.Collections.Generic;
using UnityEngine;

public class ContinuousBeam : MonoBehaviour
{
	public EnemyTarget target;

	private LineRenderer lr;

	private LayerMask environmentMask;

	private LayerMask hitMask;

	public bool canHitPlayer;

	public bool canHitEnemy;

	public bool ignoreInvincibility;

	public float beamWidth;

	public bool enemy;

	public EnemyType safeEnemyType;

	public float damage;

	public float parryMultiplier;

	private float playerCooldown;

	private List<EnemyIdentifier> hitEnemies;

	private List<float> enemyCooldowns;

	public GameObject impactEffect;

	public GameObject trackOnBeamToPlayer;

	[Header("End Point")]
	public Transform endPoint;

	private bool hasHadEndPoint;

	public bool cancelIfEndPointBlocked;

	public bool destroyIfEndPointDestroyed;

	private void Start()
	{
	}

	public void SetPlayerCooldown(float cooldown)
	{
	}

	private void Update()
	{
	}
}
