using System.Collections.Generic;
using AtlasLib.Utils;
using HarmonyLib;
using UnityEngine;

namespace WafflesWeapons.Utils;

[PatchThis($"{Plugin.GUID}.UltrakillUtils")]
public class UltrakillUtils
{
    public static GameObject NearestEnemy(Vector3 point, float maxDistance, EnemyIdentifier exclude = null)
    {
        float max = maxDistance * maxDistance;
        GameObject nearestEnemy = null;

        foreach (EnemyIdentifier enemy in AllEnemies)
        {
            if (!enemy.dead && enemy != exclude && Vector3.SqrMagnitude(enemy.transform.position - point) < max)
            {
                max = Vector3.SqrMagnitude(enemy.transform.position - point);
                nearestEnemy = enemy.gameObject;
            }
        }

        return nearestEnemy;
    }

    public static Vector3 NearestEnemyPoint(Vector3 point, float maxDistance, EnemyIdentifier exclude = null)
    {
        float max = maxDistance * maxDistance;
        Transform enemyFinal = null;

        foreach (EnemyIdentifier enemy in AllEnemies)
        {
            Transform enemyTransform = null;

            if (!enemy.dead && enemy != exclude && Vector3.SqrMagnitude(enemy.transform.position - point) < max)
            {
                if (enemy.weakPoint != null && enemy.weakPoint.activeInHierarchy)
                {
                    enemyTransform = enemy.weakPoint.transform;
                }
                else
                {
                    EnemyIdentifierIdentifier eidid = enemy.GetComponentInChildren<EnemyIdentifierIdentifier>();
                    if (eidid != null)
                    {
                        enemyTransform = eidid.transform;
                    }
                    else
                    {
                        enemyTransform = enemy.transform;
                    }
                }

                max = Vector3.SqrMagnitude(enemyTransform.position - point);
                enemyFinal = enemyTransform;
            }
        }

        return (enemyFinal != null ? enemyFinal.position : point);
    }

    public static List<EnemyIdentifier> AllEnemies
    {
        get
        {
            _allEnemies.RemoveAll(eid => !(bool)eid);
            return _allEnemies;
        }
    }

    private static List<EnemyIdentifier> _allEnemies = new();

    [HarmonyPatch(typeof(EnemyIdentifier), nameof(EnemyIdentifier.Awake)), HarmonyPostfix]
    private static void AddEnemy(EnemyIdentifier __instance)
    {
        _allEnemies.Add(__instance);
        __instance.onDeath.AddListener(() => _allEnemies.Remove(__instance));
    }
}
