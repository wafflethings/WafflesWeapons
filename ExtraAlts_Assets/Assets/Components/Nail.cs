using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020001C7 RID: 455
public class Nail : MonoBehaviour
{

	// Token: 0x04000F87 RID: 3975
	public GameObject sourceWeapon;

	// Token: 0x04000F88 RID: 3976
	[HideInInspector]
	public bool hit;

	// Token: 0x04000F89 RID: 3977
	public float damage;

	// Token: 0x04000F8A RID: 3978
	private AudioSource aud;

	// Token: 0x04000F8B RID: 3979
	[HideInInspector]
	public Rigidbody rb;

	// Token: 0x04000F8C RID: 3980
	public AudioClip environmentHitSound;

	// Token: 0x04000F8D RID: 3981
	public AudioClip enemyHitSound;

	// Token: 0x04000F8E RID: 3982
	public Material zapMaterial;

	// Token: 0x04000F8F RID: 3983
	public GameObject zapParticle;

	// Token: 0x04000F90 RID: 3984
	private bool zapped;

	// Token: 0x04000F91 RID: 3985
	public bool fodderDamageBoost;

	// Token: 0x04000F92 RID: 3986
	public string weaponType;

	// Token: 0x04000F93 RID: 3987
	public bool heated;

	// Token: 0x04000F94 RID: 3988
	[HideInInspector]
	public List<Magnet> magnets = new List<Magnet>();

	// Token: 0x04000F95 RID: 3989
	private bool launched;


	// Token: 0x04000F97 RID: 3991
	public bool enemy;

	// Token: 0x04000F98 RID: 3992
	public EnemyType safeEnemyType;

	// Token: 0x04000F99 RID: 3993
	private Vector3 startPosition;

	// Token: 0x04000F9A RID: 3994
	[Header("Sawblades")]
	public bool sawblade;

	// Token: 0x04000F9B RID: 3995
	public float hitAmount = 3.9f;

	// Token: 0x04000F9C RID: 3996
	private EnemyIdentifier currentHitEnemy;

	// Token: 0x04000F9D RID: 3997
	private float sameEnemyHitCooldown;

	// Token: 0x04000F9E RID: 3998
	[SerializeField]
	private GameObject sawBreakEffect;

	// Token: 0x04000F9F RID: 3999
	[SerializeField]
	private GameObject sawBounceEffect;

	// Token: 0x04000FA0 RID: 4000
	[HideInInspector]
	public int magnetRotationDirection;

	// Token: 0x04000FA1 RID: 4001
	private List<Transform> hitLimbs = new List<Transform>();

	// Token: 0x04000FA2 RID: 4002
	private float removeTimeMultiplier = 1f;

	// Token: 0x04000FA3 RID: 4003
	public bool bounceToSurfaceNormal;

	// Token: 0x04000FA4 RID: 4004
	[HideInInspector]
	public bool stopped;

	// Token: 0x04000FA5 RID: 4005
	public int multiHitAmount = 1;

	// Token: 0x04000FA6 RID: 4006
	private int currentMultiHitAmount;

	// Token: 0x04000FA7 RID: 4007
	private float multiHitCooldown;

	// Token: 0x04000FA8 RID: 4008
	private Transform hitTarget;

	// Token: 0x04000FA9 RID: 4009
	[HideInInspector]
	public Vector3 originalVelocity;

	// Token: 0x04000FAA RID: 4010
	public AudioSource stoppedAud;

	// Token: 0x04000FAB RID: 4011
	[HideInInspector]
	public bool punchable;

	// Token: 0x04000FAC RID: 4012
	[HideInInspector]
	public bool punched;

	// Token: 0x04000FAD RID: 4013
	[HideInInspector]
	public float punchDistance;
}
