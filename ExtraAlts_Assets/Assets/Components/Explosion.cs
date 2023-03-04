using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

	// Token: 0x04000887 RID: 2183
	public static float globalSizeMulti = 1f;

	// Token: 0x04000888 RID: 2184
	public GameObject sourceWeapon;

	// Token: 0x04000889 RID: 2185
	public bool enemy;

	// Token: 0x0400088A RID: 2186
	public bool harmless;

	// Token: 0x0400088B RID: 2187
	public bool lowQuality;


	// Token: 0x0400088D RID: 2189
	private Light light;

	// Token: 0x0400088E RID: 2190
	private MeshRenderer mr;

	// Token: 0x0400088F RID: 2191
	private Color materialColor;

	// Token: 0x04000890 RID: 2192
	private bool fading;

	// Token: 0x04000891 RID: 2193
	public float speed;

	// Token: 0x04000892 RID: 2194
	public float maxSize;

	// Token: 0x04000893 RID: 2195
	private LayerMask lmask;

	// Token: 0x04000894 RID: 2196
	public int damage;

	// Token: 0x04000895 RID: 2197
	public float enemyDamageMultiplier;

	// Token: 0x04000896 RID: 2198
	[HideInInspector]
	public int playerDamageOverride = -1;

	// Token: 0x04000897 RID: 2199
	public GameObject explosionChunk;

	// Token: 0x04000898 RID: 2200
	public bool ignite;

	// Token: 0x04000899 RID: 2201
	public bool friendlyFire;

	// Token: 0x0400089A RID: 2202
	private List<Collider> hitColliders = new List<Collider>();

	// Token: 0x0400089B RID: 2203
	public string hitterWeapon;

	// Token: 0x0400089C RID: 2204
	public bool halved;

	// Token: 0x0400089D RID: 2205
	private SphereCollider scol;

	// Token: 0x0400089E RID: 2206
	public AffectedSubjects canHit;

	// Token: 0x0400089F RID: 2207
	private bool hasHitPlayer;

	// Token: 0x040008A0 RID: 2208
	public bool rocketExplosion;

	// Token: 0x040008A1 RID: 2209
	public List<EnemyType> toIgnore;

	// Token: 0x040008A2 RID: 2210
	[HideInInspector]
	public EnemyIdentifier interruptedEnemy;

	// Token: 0x040008A3 RID: 2211
	private RaycastHit neoRhit;

	// Token: 0x040008A4 RID: 2212
	[HideInInspector]
	public bool ultrabooster;

	// Token: 0x040008A5 RID: 2213
	public bool unblockable;
}

// Token: 0x020000E9 RID: 233
public enum AffectedSubjects
{
	// Token: 0x040005D3 RID: 1491
	All,
	// Token: 0x040005D4 RID: 1492
	PlayerOnly,
	// Token: 0x040005D5 RID: 1493
	EnemiesOnly
}
