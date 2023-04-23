using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuousBeam : MonoBehaviour
{

	// Token: 0x04000404 RID: 1028
	private LineRenderer lr;

	// Token: 0x04000405 RID: 1029
	private LayerMask environmentMask;

	// Token: 0x04000406 RID: 1030
	private LayerMask hitMask;

	// Token: 0x04000407 RID: 1031
	public bool canHitPlayer = true;

	// Token: 0x04000408 RID: 1032
	public bool canHitEnemy = true;

	// Token: 0x04000409 RID: 1033
	public float beamWidth = 0.35f;

	// Token: 0x0400040A RID: 1034
	public bool enemy;

	// Token: 0x0400040B RID: 1035
	public EnemyType safeEnemyType;

	// Token: 0x0400040C RID: 1036
	public float damage;

	// Token: 0x0400040D RID: 1037
	private float playerCooldown;

	// Token: 0x0400040E RID: 1038
	private List<EnemyIdentifier> hitEnemies = new List<EnemyIdentifier>();

	// Token: 0x0400040F RID: 1039
	private List<float> enemyCooldowns = new List<float>();

	// Token: 0x04000410 RID: 1040
	public GameObject impactEffect;
}
