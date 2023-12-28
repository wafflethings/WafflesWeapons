using AtlasLib.Utils;
using AtlasLib.Weapons;
using HarmonyLib;
using UnityEngine;
using WafflesWeapons.Assets;

namespace WafflesWeapons.Weapons.Virtuous
{
    [PatchThis($"{Plugin.GUID}.Virtuous")]
    public class Virtuous : Weapon
    {
        public static WeaponAssets Assets;

        static Virtuous()
        {
            Assets = Plugin.Assets.LoadAsset<WeaponAssets>("Virtuous Assets.asset");
        }

        public override WeaponInfo Info => Assets.GetAsset<WeaponInfo>("Info");

        [HarmonyPatch(typeof(RevolverBeam), nameof(RevolverBeam.ExecuteHits))]
        [HarmonyPrefix]
        public static void Patch_ExecuteHits(RevolverBeam __instance, RaycastHit currentHit)
        {
            // something causes this to error, and i cant be fucking bothered to fix it
            // fuck it, we ball.
            try
            {
                VirtuousBehaviour vb;

                if (currentHit.collider != null)
                {
                    if (__instance.sourceWeapon.TryGetComponent(out vb))
                    {
                        var eidid = currentHit.collider.gameObject.GetComponent<EnemyIdentifierIdentifier>();
                        if (eidid != null && !eidid.eid.dead)
                        {
                            vb.CreateBeam(eidid.eid.transform.position);
                        } 
                        else if (currentHit.collider.gameObject.layer == 8 || currentHit.collider.gameObject.layer == 24)
                        {
                            if (__instance.hitEids.Count == 0)
                            {
                                vb.CreateBeam(currentHit.point, true);
                            }
                        }
                    }
                }
            }
            catch { }
        }

        [HarmonyPatch(typeof(StyleHUD), nameof(StyleHUD.DecayFreshness))]
        [HarmonyPostfix]
        public static void StyleMult(StyleHUD __instance, GameObject sourceWeapon, string pointID, bool boss)
        {
            if (sourceWeapon.GetComponent<VirtuousBehaviour>() != null)
            {
                var dict = __instance.weaponFreshness;
                if (!dict.ContainsKey(sourceWeapon))
                {
                    return;
                }
                float num = __instance.freshnessDecayPerMove;
                if (__instance.freshnessDecayMultiplierDict.ContainsKey(pointID))
                {
                    num *= __instance.freshnessDecayMultiplierDict[pointID];
                }
                if (boss)
                {
                    num *= __instance.bossFreshnessDecayMultiplier;
                }

                __instance.AddFreshness(sourceWeapon, num * 1f);
            }
        }
    }
}
