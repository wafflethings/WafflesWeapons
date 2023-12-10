using Atlas.Modules.Guns;
using HarmonyLib;
using UnityEngine;
using WafflesWeapons.Components;

namespace WafflesWeapons.Weapons.Mindrender
{
    public class Mindrender : Gun
    {
        public static GameObject RendNail;
        public static GameObject RendSaw;

        static Mindrender()
        {
            RendNail = Core.Assets.LoadAsset<GameObject>("Nailgun Mindrender.prefab");
            RendSaw = Core.Assets.LoadAsset<GameObject>("Sawblade Launcher Mindrender.prefab");
            Core.Harmony.PatchAll(typeof(Mindrender));
        }

        public override GameObject Create(Transform parent)
        {
            base.Create(parent);

            GameObject thing;
            if (Enabled() == 2)
            {
                thing = GameObject.Instantiate(RendSaw, parent);
            }
            else
            {
                thing = GameObject.Instantiate(RendNail, parent);
            }

            OrderInSlot = GunSetter.Instance.CheckWeaponOrder("nai")[4];
            StyleHUD.Instance.weaponFreshness.Add(thing, 10);
            return thing;
        }

        public override int Slot()
        {
            return 2;
        }

        public override string Pref()
        {
            return "nai4";
        }

        [HarmonyPatch(typeof(StyleCalculator), nameof(StyleCalculator.HitCalculator))]
        [HarmonyPrefix]
        public static bool ReduceBeamCripplingStyle(StyleCalculator __instance, string hitter, bool dead, EnemyIdentifier eid = null, GameObject sourceWeapon = null)
        {
            if (hitter == "mindrend beam :3")
            {
                StyleHUD.Instance.SetFreshness(sourceWeapon, StyleHUD.Instance.GetFreshness(sourceWeapon) - 0.125f);

                // have to do this bc addpoints is an int (cringe)
                float old = StyleHUD.Instance.GetFreshness(sourceWeapon);
                __instance.AddPoints(2, "", eid, sourceWeapon);

                // adding points decay style, so we add it back
                StyleHUD.Instance.SetFreshness(sourceWeapon, old);

                if (dead)
                {
                    __instance.AddToMultiKill(sourceWeapon);
                }

                return false;
            }

            return true;
        }

        [HarmonyPatch(typeof(Nail), nameof(Nail.HitEnemy))]
        [HarmonyPostfix]
        public static void AddStuff(Nail __instance, EnemyIdentifierIdentifier eidid = null)
        {
            if (eidid != null && eidid.eid != null && !eidid.eid.dead)
            {
                float amount;

                if (__instance.sawblade)
                {
                    amount = 0.05f;
                }
                else
                {
                    amount = 0.025f;
                }

                if (!__instance.sourceWeapon.GetComponent<MindrenderBehaviour>())
                {
                    amount /= 3;
                }

                foreach (MindrenderBehaviour mr in MindrenderBehaviour.Instances)
                {
                    mr.Charge = Mathf.MoveTowards(mr.Charge, MindrenderBehaviour.MAX_CHARGE, amount);
                    WaffleWeaponCharges.Instance.MindrenderCharge = Mathf.MoveTowards(WaffleWeaponCharges.Instance.MindrenderCharge, MindrenderBehaviour.MAX_CHARGE, amount);
                }
            }
        }
    }
}
