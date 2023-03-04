using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HomingType{
    None,
    Standard,
    Loose,
    Horizontal
}

public class Projectile : MonoBehaviour {

	// Token: 0x04001422 RID: 5154
	public GameObject sourceWeapon;

	// Token: 0x04001423 RID: 5155
	private Rigidbody rb;

	// Token: 0x04001424 RID: 5156
	public float speed;

	// Token: 0x04001425 RID: 5157
	public float turnSpeed;

	// Token: 0x04001426 RID: 5158
	public float speedRandomizer;

	// Token: 0x04001427 RID: 5159
	private AudioSource aud;

	// Token: 0x04001428 RID: 5160
	public GameObject explosionEffect;

	// Token: 0x04001429 RID: 5161
	public float damage;

	// Token: 0x0400142A RID: 5162
	public float enemyDamageMultiplier = 1f;

	// Token: 0x0400142B RID: 5163
	public bool friendly;

	// Token: 0x0400142C RID: 5164
	public bool playerBullet;

	// Token: 0x0400142D RID: 5165
	public string bulletType;

	// Token: 0x0400142E RID: 5166
	public string weaponType;

	// Token: 0x0400142F RID: 5167
	public bool decorative;

	// Token: 0x04001430 RID: 5168
	private Vector3 origScale;

	// Token: 0x04001431 RID: 5169
	private bool active = true;

	// Token: 0x04001432 RID: 5170
	public EnemyType safeEnemyType;

	// Token: 0x04001433 RID: 5171
	public bool explosive;

	// Token: 0x04001434 RID: 5172
	public bool bigExplosion;

	// Token: 0x04001435 RID: 5173
	public HomingType homingType;

	// Token: 0x04001436 RID: 5174
	public float turningSpeedMultiplier = 1f;

	// Token: 0x04001437 RID: 5175
	public Transform target;

	// Token: 0x04001438 RID: 5176
	private float maxSpeed;

	// Token: 0x04001439 RID: 5177
	private Quaternion targetRotation;

	// Token: 0x0400143A RID: 5178
	public bool hittingPlayer;

	// Token: 0x0400143C RID: 5180
	public bool boosted;

	// Token: 0x0400143D RID: 5181
	private Collider col;

	// Token: 0x0400143E RID: 5182
	private float radius;

	// Token: 0x0400143F RID: 5183
	public bool undeflectable;

	// Token: 0x04001440 RID: 5184
	public bool keepTrail;

	// Token: 0x04001441 RID: 5185
	public bool strong;

	// Token: 0x04001442 RID: 5186
	public bool spreaded;

	// Token: 0x04001443 RID: 5187
	private int difficulty;

	// Token: 0x04001444 RID: 5188
	public bool precheckForCollisions;

	// Token: 0x04001445 RID: 5189
	public bool canHitCoin;

	// Token: 0x04001446 RID: 5190
	public bool ignoreExplosions;

	// Token: 0x04001447 RID: 5191
	private List<Collider> alreadyDeflectedBy = new List<Collider>();

	public void Explode()
{}}
