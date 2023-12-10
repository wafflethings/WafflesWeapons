using System.Collections.Generic;
using Atlas.Modules.Guns;
using HarmonyLib;
using UnityEngine;

namespace WafflesWeapons.Weapons.Malevolent
{
public class Malevolent : Gun
    {
        public static GameObject Mal;
        public static GameObject MalAlt;

        static Malevolent()
        {
            Mal = Core.Assets.LoadAsset<GameObject>("Revolver Malevolent.prefab");
            MalAlt = Core.Assets.LoadAsset<GameObject>("Alternative Revolver Malevolent.prefab");
            Core.Harmony.PatchAll(typeof(Malevolent));
        }

        public override GameObject Create(Transform parent)
        {
            base.Create(parent);

            GameObject thing;
            if (Enabled() == 2)
            {
                thing = GameObject.Instantiate(MalAlt, parent);
            }
            else
            {
                thing = GameObject.Instantiate(Mal, parent);
            }

            OrderInSlot = GunSetter.Instance.CheckWeaponOrder("rev")[4];
            StyleHUD.Instance.weaponFreshness.Add(thing, 10);
            return thing;
        }

        public override int Slot()
        {
            return 0;
        }

        public override string Pref()
        {
            return "rev4";
        }

        [HarmonyPatch(typeof(StyleHUD), nameof(StyleHUD.DecayFreshness))]
        [HarmonyPostfix]
        public static void StyleMult(StyleHUD __instance, GameObject sourceWeapon, string pointID, bool boss)
        {
            if (sourceWeapon.GetComponent<MalevolentBehaviour>() != null)
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

                if(pointID == "ultrakill.explosionhit")
                {
                    num *= 0.33f;
                } else
                {
                    num *= 0.5f;
                }

                __instance.AddFreshness(sourceWeapon, num);
            }
        }

        public static List<MalevolentBehaviour> Guns = new List<MalevolentBehaviour>();

        [HarmonyPatch(typeof(Revolver), nameof(Revolver.Update))]
        [HarmonyPrefix] // i blame hakita
        public static bool AAAAAAAAAAAAAAAA(Revolver __instance)
        {
            return __instance.gunVariation != 5;
        }
    }
}
