using AtlasLib.Utils;
using HarmonyLib;
using UnityEngine;
using WafflesWeapons.Components;

namespace WafflesWeapons.Weapons.Conductor.StunProjectiles;

[HarmonyPatch]
public class StunSaw : MonoBehaviour, IStunProjectile
{
    [SerializeField] private GameObject _fullChargeExplosion;
    private float _chargeLength;
    private Nail _nail;

    public void Initialize(ConductorBehaviour source, float chargeLength)
    {
        _chargeLength = chargeLength;
        _nail = GetComponent<Nail>();

        if (Mathf.Approximately(chargeLength, 1))
        {
            _nail.sawBounceEffect = _fullChargeExplosion;
        }

        _nail.weaponType = source.Nailgun.projectileVariationTypes[source.Nailgun.variation];
        _nail.sourceWeapon = source.gameObject;
        _nail.damage *= chargeLength;
        transform.forward = CameraController.Instance.transform.forward;
        _nail.ForceCheckSawbladeRicochet();
        _nail.rb.velocity = _nail.transform.forward * 200;

        Vector3 newScale = Vector3.one * (0.1f * chargeLength * 2);
        newScale.y = 0.1f;
        transform.localScale = newScale;
        transform.position -= transform.forward * (chargeLength * 2);
    }

    public void HitEnemy(EnemyIdentifier enemy)
    {
        Stunner.EnsureAndStun(enemy, _chargeLength * 1.25f);

        if (Mathf.Approximately(_chargeLength, 1))
        {
            // at chargelength 1, sawBounceEffect is the stun explosion.
            Instantiate(_nail.sawBounceEffect, transform.position, transform.rotation);
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
