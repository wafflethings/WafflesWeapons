using System.Collections.Generic;
using HarmonyLib;

namespace WafflesWeapons.Weapons.Charging;

[HarmonyPatch]
public static class WafflesWeaponsCharges
{
    public static List<IChargeable> Chargeables = new();
    
    [HarmonyPatch(typeof(GunSetter), nameof(GunSetter.ResetWeapons)), HarmonyPostfix]
    private static void ResetAll()
    {
        foreach (IChargeable chargeable in Chargeables)
        {
            chargeable.ResetCharge();
        }
    }
    
    [HarmonyPatch(typeof(WeaponCharges), nameof(WeaponCharges.Charge)), HarmonyPostfix]
    private static void Charge(float amount)
    {
        foreach (IChargeable chargeable in Chargeables)
        {
            chargeable.ChargeOverTime(amount);
        }
    }
    
    [HarmonyPatch(typeof(WeaponCharges), nameof(WeaponCharges.MaxCharges)), HarmonyPostfix]
    private static void MaxCharges()
    {
        foreach (IChargeable chargeable in Chargeables)
        {
            chargeable.MaxCharges();
        }
    }
}
