using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using WafflesWeapons.Weapons;

namespace WafflesWeapons
{
    public class WaffleWeaponCharges : MonoSingleton<WaffleWeaponCharges>
    {
        public float FanRevCharge = 0;

        public bool MalAlt;
        public float MalRevCharge = 0;

        public float SingularityShoCharge = 0;

        public float ConductorCharge = 0;

        public float SLFCharge = 0;

        public void Charge(float amount)
        {
            MalRevCharge = Mathf.MoveTowards(MalRevCharge, 100, 20 * (MalAlt ? 0.5f : 1) * amount);
            SingularityShoCharge = Mathf.MoveTowards(SingularityShoCharge, SingularityBehaviour.HEALTH_NEEDED, 5 * amount);
            ConductorCharge = Mathf.MoveTowards(ConductorCharge, 1, Time.deltaTime * 0.1f);
        }

        [HarmonyPatch(typeof(WeaponCharges), nameof(WeaponCharges.Charge)), HarmonyPostfix]
        public static void ChargeWW(float amount)
        {
            Instance.Charge(amount);
        }
    }
}
