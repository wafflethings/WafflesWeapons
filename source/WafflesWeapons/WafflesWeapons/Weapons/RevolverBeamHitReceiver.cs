using HarmonyLib;
using UnityEngine;
using UnityEngine.Events;

namespace WafflesWeapons.Weapons;

[HarmonyPatch]
public class RevolverBeamHitReceiver : MonoBehaviour
{
    public UnityEvent<RevolverBeam>? OnHit;
    
    [HarmonyPatch(typeof(RevolverBeam), nameof(RevolverBeam.Start)), HarmonyPrefix]
    private static void AddHitLogger(RevolverBeam __instance)
    {
        __instance.AddOnAnyHit((_, hitObject) => hitObject.GetComponent<RevolverBeamHitReceiver>()?.OnHit?.Invoke(__instance));
    }
}
