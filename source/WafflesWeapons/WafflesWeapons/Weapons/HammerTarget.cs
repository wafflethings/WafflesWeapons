using HarmonyLib;
using UnityEngine;
using UnityEngine.Events;

namespace WafflesWeapons.Weapons;

[HarmonyPatch]
public class HammerTarget : MonoBehaviour
{
    [HarmonyPatch(typeof(ShotgunHammer), nameof(ShotgunHammer.Impact)), HarmonyPostfix]
    private static void Impact(ShotgunHammer __instance)
    {
        Collider[] collisions = Physics.OverlapSphere(CameraController.Instance.GetDefaultPos(), 2.5f);

        foreach (Collider collision in collisions)
        {
            if (!collision.TryGetComponent(out HammerTarget target))
            {
                continue;
            }
            
            target.GetHit();
        }
    }

    public UnityEvent? OnHit;
    
    private void GetHit() => OnHit?.Invoke();
}
