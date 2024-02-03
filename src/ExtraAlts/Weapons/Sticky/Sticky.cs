using AtlasLib.Utils;
using AtlasLib.Weapons;
using HarmonyLib;
using UnityEngine;
using WafflesWeapons.Assets;

namespace WafflesWeapons.Weapons.Sticky;

[PatchThis($"{Plugin.GUID}.Sticky")]
public class Sticky : Weapon
{
    public static WeaponAssets Assets;

    static Sticky()
    {
        Assets = AddressableManager.Load<WeaponAssets>("Assets/ExtraAlts/Sticky/Sticky Assets.asset");
    }

    public override WeaponInfo Info => Assets.GetAsset<WeaponInfo>("Info");

    public static Collider _other;

    [HarmonyPatch(typeof(Projectile), nameof(Projectile.Collided))]
    [HarmonyPrefix]
    public static bool Patch_Col(Projectile __instance, Collider other)
    {
        _other = other;
        if (__instance.bulletType == "silly_sticky")
        {
            if (!__instance.boosted)
            {
                return !(other.gameObject.layer == 8 || other.gameObject.layer == 24 || (other.gameObject.GetComponentInParent<StickyBombBehaviour>()?.Frozen ?? false));
            }
        }
        return true;
    }

    [HarmonyPatch(typeof(Projectile), nameof(Projectile.Explode))]
    [HarmonyPrefix]
    public static bool Patch_Explosion(Projectile __instance)
    {
        if(__instance.bulletType == "silly_sticky")
        {
            if (!__instance.GetComponent<StickyBombBehaviour>().Frozen)
            {
                if (_other.GetComponent<EnemyIdentifierIdentifier>() != null)
                {
                    StyleCalculator.Instance.AddPoints(150, "<color=cyan>KABLOOIE</color>", _other.GetComponent<EnemyIdentifierIdentifier>().eid, __instance.sourceWeapon);
                }

                return (_other.gameObject.CompareTag("Head") || _other.gameObject.CompareTag("Body") || _other.gameObject.CompareTag("Limb") ||
                        _other.gameObject.CompareTag("EndLimb")) && !_other.gameObject.CompareTag("Armor");
            }
            else
            {
                __instance.CreateExplosionEffect();
                GameObject.Destroy(__instance.gameObject);
                return false;
            }
        }
        return true;
    }
}