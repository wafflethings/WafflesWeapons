using AtlasLib.Utils;
using HarmonyLib;
using UnityEngine;
using WafflesWeapons.Components;

namespace WafflesWeapons.Weapons.Conductor
{
    [PatchThis($"{Plugin.GUID}.StunExplosion")]
    public class StunExplosion : MonoBehaviour
    {
        public void HitEnemy(EnemyIdentifier enemy)
        {
            if (EnemyHitTracker.CheckAndHit(gameObject, enemy, 0.5f))
            {
                Stunner.EnsureAndStun(enemy, 1);
            }
        }
        
        [HarmonyPatch(typeof(Explosion), nameof(Explosion.Collide)), HarmonyPrefix]
        private static void StunEnemiesHitByExplosion(Explosion __instance, Collider other)
        {
            if (__instance.canHit == AffectedSubjects.PlayerOnly)
            {
                return;
            }

            EnemyIdentifier enemy = other.GetComponentInParent<EnemyIdentifierIdentifier>()?.eid;
            
            if (((LayerMask)LayerMask.GetMask("Limb", "BigCorpse")).Contains(other.gameObject.layer) 
                && __instance.TryGetComponent(out StunExplosion stunExplosion) && enemy != null)
            {
                stunExplosion.HitEnemy(enemy);
            }
        }
    }
}
