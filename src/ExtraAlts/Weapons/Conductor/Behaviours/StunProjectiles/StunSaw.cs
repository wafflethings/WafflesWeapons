using AtlasLib.Utils;
using HarmonyLib;
using UnityEngine;
using WafflesWeapons.Components;

namespace WafflesWeapons.Weapons.Conductor.StunProjectiles;

[PatchThis($"{Plugin.GUID}.StunSaw")]
public class StunSaw : MonoBehaviour, IStunProjectile
{
    [HideInInspector] public float ChargeLength;
    [HideInInspector] public Nail ThisNail;
        
    public void Initialize(ConductorBehaviour source, float chargeLength)
    {
        ChargeLength = chargeLength;
        ThisNail = GetComponent<Nail>();
            
        if (chargeLength == 1)
        {
            ThisNail.sawBounceEffect = Conductor.SawExplosion;
        }
            
        ThisNail.weaponType = source.Nailgun.projectileVariationTypes[source.Nailgun.variation];
        ThisNail.sourceWeapon = source.gameObject;
        ThisNail.damage *= chargeLength;
        transform.forward = CameraController.Instance.transform.forward;
        ThisNail.ForceCheckSawbladeRicochet();
        ThisNail.rb.velocity = ThisNail.transform.forward * 200;
            
        Vector3 newScale = Vector3.one * 0.1f * chargeLength * 2;
        newScale.y = 0.1f;
        transform.localScale = newScale;
        transform.position -= transform.forward * chargeLength * 2;
    }

    public void HitEnemy(EnemyIdentifier enemy)
    {
        Stunner.EnsureAndStun(enemy, ChargeLength * 1.25f);

        if (ChargeLength == 1)
        {
            // at chargelength 1, sawBounceEffect is the stun explosion.
            Instantiate(ThisNail.sawBounceEffect, transform.position, transform.rotation);
        }
    }
        
    [HarmonyPatch(typeof(Nail), nameof(Nail.HitEnemy)), HarmonyPostfix]
    private static void StunSaws(Nail __instance, EnemyIdentifierIdentifier eidid)
    {
        if (__instance.TryGetComponent(out StunSaw stunSaw) && EnemyHitTracker.CheckAndHit(__instance.gameObject, eidid.eid))
        {
            stunSaw.HitEnemy(eidid.eid);
        }
    }
}
