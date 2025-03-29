using System;
using System.Collections.Generic;
using HarmonyLib;
using UnityEngine;

namespace WafflesWeapons.Weapons.Revolvers;

[HarmonyPatch]
public class BaseRevolver : MonoBehaviour
{
    internal static Dictionary<Revolver, BaseRevolver> VanillaToModded = new();

    public ChargeModule? ChargeModule;
    
    private Revolver? _rev;

    protected virtual void Awake()
    {
        if (!TryGetComponent(out _rev) || _rev == null)
        {
            Plugin.Log.LogError($"{gameObject.name} lacks Revolver script - this will not work!!");
            Destroy(this);
            return;
        }
        
        VanillaToModded.Add(_rev, this);
    }

    private void OnDestroy()
    {
        if (_rev != null)
        {
            VanillaToModded.Remove(_rev);
        }
    }

    [HarmonyPatch(typeof(GunSetter), nameof(GunSetter.Start)), HarmonyPrefix]
    private static void FixCharges()
    {
        WeaponCharges.Instance.revaltpickupcharges = new float[7];
    }
}
