using UnityEngine;

namespace WafflesWeapons.Utils
{
    public class UltrakillUtils
    {
        public static GameObject NearestEnemy(Vector3 point, float maxDistance, EnemyIdentifier exclude = null)
        {
            float max = maxDistance;
            GameObject nearestEnemy = null;

            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            foreach (GameObject enemy in enemies)
            {
                if (enemy.GetComponent<EnemyIdentifier>() != null && !enemy.GetComponent<EnemyIdentifier>().dead && 
                    enemy.GetComponent<EnemyIdentifier>() != exclude && Vector3.Distance(point, enemy.transform.position) < max)
                {
                    max = Vector3.Distance(point, enemy.transform.position);
                    nearestEnemy = enemy;
                }
            }

            return nearestEnemy;
        }

        public static Vector3 NearestEnemyPoint(Vector3 point, float maxDistance, EnemyIdentifier exclude = null)
        {
            float max = maxDistance;
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            Transform enemyFinal = null;

            foreach (GameObject enemy in enemies)
            {
                EnemyIdentifier eid = enemy.GetComponent<EnemyIdentifier>();
                Transform enemyTransform = null;

                if (eid != null && !eid.dead && eid != exclude && Vector3.Distance(point, enemy.transform.position) < max)
                {
                    if (eid.weakPoint != null && eid.weakPoint.activeInHierarchy)
                    {
                        enemyTransform = eid.weakPoint.transform;
                    }
                    else
                    {
                        EnemyIdentifierIdentifier eidid = eid.GetComponentInChildren<EnemyIdentifierIdentifier>();
                        if (eidid != null)
                        {
                            enemyTransform = eidid.transform;
                        }
                        else
                        {
                            enemyTransform = enemy.transform;
                        }
                    }

                    max = Vector3.Distance(point, enemyTransform.position);
                    enemyFinal = enemyTransform;
                }
            }

            return (enemyFinal != null ? enemyFinal.position : point);
        }
    }
}