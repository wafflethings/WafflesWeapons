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

        public float AirblastCharge = 0;

        public float SLFCharge = 0;

        public void Charge(float amount)
        {
            MalRevCharge = Mathf.MoveTowards(MalRevCharge, 100, 20 * (MalAlt ? 0.5f : 1) * amount);
            SingularityShoCharge = Mathf.MoveTowards(SingularityShoCharge, SingularityBehaviour.HEALTH_NEEDED, 5 * amount);
            AirblastCharge = Mathf.MoveTowards(AirblastCharge, 1, Time.deltaTime * (NewMovement.Instance.gc.touchingGround ? 0.1f : 0.05f));
        }

        [HarmonyPatch(typeof(WeaponCharges), nameof(WeaponCharges.Charge)), HarmonyPostfix]
        public static void ChargeWW(float amount)
        {
            Instance.Charge(amount);
        }
    }
}
