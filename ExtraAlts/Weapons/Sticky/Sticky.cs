using Atlas.Modules.Guns;
using HarmonyLib;
using UnityEngine;

namespace WafflesWeapons.Weapons.Sticky
{
    public class Sticky : Gun
    {
        public static GameObject StickyShotgun;

        static Sticky()
        {
            StickyShotgun = Core.Assets.LoadAsset<GameObject>("Shotgun Sticky.prefab");
            Core.Harmony.PatchAll(typeof(Sticky));
        }

        public override GameObject Create(Transform parent)
        {
            base.Create(parent);
            StickyBehaviour.Charges = 0;

            GameObject thing = GameObject.Instantiate(StickyShotgun, parent);
            OrderInSlot = GunSetter.Instance.CheckWeaponOrder("sho")[3];
            StyleHUD.Instance.weaponFreshness.Add(thing, 10);

            return thing;
        }

        public override int Slot()
        {
            return 1;
        }

        public override string Pref()
        {
            return "sho3";
        }

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
}
