using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace WafflesWeapons.Components
{
    public class EnemyHitTracker : MonoBehaviour
    {
        public static bool CheckAndHit(GameObject obj, EnemyIdentifier eid, float cooldown = -1)
        {
            EnemyHitTracker eht = obj.TryGetComponent(out EnemyHitTracker e) ? e : obj.gameObject.AddComponent<EnemyHitTracker>();

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

        private List<EnemyIdentifier> enemies = new List<EnemyIdentifier>();

        public void AddEnemy(EnemyIdentifier eid)
        {
            enemies.Add(eid);
        }

        public bool Contains(EnemyIdentifier eid)
        {
            return enemies.Contains(eid);
        }

        public System.Collections.IEnumerator RemoveAfterCooldown(EnemyIdentifier eid, float cooldown)
        {
            yield return new WaitForSeconds(cooldown);
            enemies.Remove(eid);
        }
    }
}
