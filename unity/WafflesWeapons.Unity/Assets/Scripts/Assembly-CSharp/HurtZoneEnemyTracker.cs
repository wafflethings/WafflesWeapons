using System.Collections.Generic;
using UnityEngine;

public class HurtZoneEnemyTracker
{
	public EnemyIdentifier target;

	public List<Collider> limbs;

	public float timer;

	public HurtZoneEnemyTracker(EnemyIdentifier eid, Collider limb, float hurtCooldown)
	{
	}

	public bool HasLimbs(Collider colliderToCheck)
	{
		return false;
	}
}
