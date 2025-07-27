using HarmonyLib;
using UnityEngine;

namespace WafflesWeapons.Weapons.Nailguns;

[HarmonyPatch]
public class BaseNailgun : MonoBehaviour
{
    [HarmonyPatch(typeof(Nailgun), nameof(Nailgun.Start)), HarmonyPostfix]
    private static void AddNailProjectileTypes(Nailgun __instance)
    {
        __instance.projectileVariationTypes = new[] 
        {
            "nailgun0",
            "nailgun1",
            "nailgun2",
            "nailgun3",
            "nailgun4",
            "nailgun5",
            "nailgun6",
            "nailgun7"
        };
    }
}
