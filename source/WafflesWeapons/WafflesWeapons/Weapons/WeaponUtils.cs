using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace WafflesWeapons.Weapons;

public static class WeaponUtils
{
    public static EnemyIdentifier? ClosestEnemy(Vector3 point, float cutoffDistance = float.MaxValue, List<EnemyIdentifier> ignore = null!)
    {
        ignore ??= [];
        EnemyIdentifier? current = null;
        float lastDistance = float.MaxValue;
        float cutoffSqrMagnitude = cutoffDistance * cutoffDistance;
        
        foreach (EnemyIdentifier enemy in EnemyTracker.Instance.enemies)
        {
            if (enemy == null || enemy.dead)
            {
                continue;
            }
            
            Vector3 enemyPoint = (enemy.weakPoint?.transform.position ?? enemy.transform.position);
            float enemyDistance = (enemyPoint - point).sqrMagnitude;
            
            if (enemyDistance > lastDistance || enemyDistance > cutoffSqrMagnitude || ignore.Contains(enemy))
            {
                continue;
            }

            lastDistance = enemyDistance;
            current = enemy;
        }

        return current;
    }
}
