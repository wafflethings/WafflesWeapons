using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace WafflesWeapons.Components
{
    public class EnemyHitTracker : MonoBehaviour
    {
        /// <summary>
        /// Returns true if this object didn't hit the enemy in a time period.
        /// </summary>
        /// <param name="objectThatHit">The object that hit the enemy.</param>
        /// <param name="eid">The enemy that was hit.</param>
        /// <param name="cooldown">The time period.</param>
        /// <returns></returns>
        public static bool CheckAndHit(GameObject objectThatHit, EnemyIdentifier eid, float cooldown = -1)
        {
            EnemyHitTracker eht = objectThatHit.TryGetComponent(out EnemyHitTracker e) ? e : objectThatHit.gameObject.AddComponent<EnemyHitTracker>();

            bool doesntContain = !eht.Contains(eid);
            if (doesntContain)
            {
                eht.AddEnemy(eid);
            }

            if (cooldown > 0)
            {
                eht.StartCoroutine(eht.RemoveAfterCooldown(eid, cooldown));
            }

            return doesntContain;
        }

        private readonly List<EnemyIdentifier> _enemies = new List<EnemyIdentifier>();

        public void AddEnemy(EnemyIdentifier eid)
        {
            _enemies.Add(eid);
        }

        public bool Contains(EnemyIdentifier eid)
        {
            return _enemies.Contains(eid);
        }

        public IEnumerator RemoveAfterCooldown(EnemyIdentifier eid, float cooldown)
        {
            yield return new WaitForSeconds(cooldown);
            _enemies.Remove(eid);
        }
    }
}
