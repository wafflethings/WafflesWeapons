using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtlasLib.Utils;
using UnityEngine;
using WafflesWeapons.Weapons;
using WafflesWeapons.Weapons.Malevolent;
using WafflesWeapons.Weapons.Singularity;

namespace WafflesWeapons.Components
{
    [PatchThis($"{Plugin.GUID}.WaffleWeaponCharges")]
    public class WaffleWeaponCharges : MonoSingleton<WaffleWeaponCharges>
    {
        public float FanRevCharge = 0;

        public bool MalAlt => MalevolentBehaviour.Instances.Count > 0 ? (MalevolentBehaviour.Instances[0].rev?.altVersion ?? false) : false;
        public float MalRevCharge = 0;

        public float DemoShoCooldown;
        public float SingularityShoCharge = 0;

        public float ConductorCharge = 0;
        public float MindrenderCharge = 0;

        public float EepyCharge = 0;

        public void Charge(float amount)
        {
            MalRevCharge = Mathf.MoveTowards(MalRevCharge, 100, 20 * (MalAlt ? 0.5f : 1) * amount);
            DemoShoCooldown = Mathf.MoveTowards(DemoShoCooldown, 0, Time.deltaTime);
            SingularityShoCharge = Mathf.MoveTowards(SingularityShoCharge, SingularityBehaviour.HEALTH_NEEDED, 5 * amount);
            ConductorCharge = Mathf.MoveTowards(ConductorCharge, 1, Time.deltaTime * 0.1f);
        }

        [HarmonyPatch(typeof(WeaponCharges), nameof(WeaponCharges.Charge)), HarmonyPostfix]
        public static void ChargeWW(float amount)
        {
            Instance.Charge(amount);
        }

        [HarmonyPatch(typeof(WeaponCharges), nameof(WeaponCharges.MaxCharges)), HarmonyPostfix]
        public static void MaxChargesWW()
        {
            Instance.ConductorCharge = 1;
            Instance.MindrenderCharge = 1;
            Instance.MalRevCharge = 100;
            Instance.EepyCharge = 1;
            Instance.FanRevCharge = 6;
            Instance.SingularityShoCharge = SingularityBehaviour.HEALTH_NEEDED;
        }
    }
}
