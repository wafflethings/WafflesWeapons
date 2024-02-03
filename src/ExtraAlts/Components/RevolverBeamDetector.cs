using AtlasLib.Utils;
using HarmonyLib;
using UnityEngine;

namespace WafflesWeapons.Components;

[PatchThis($"{Plugin.GUID}.RevolverBeamDetector")]
public class RevolverBeamDetector : MonoBehaviour
{
    [Header("The object's layer needs to be hittable by the beam, so probably use Limb.")]
    public UltrakillEvent OnHit;

    [HarmonyPatch(typeof(RevolverBeam), nameof(RevolverBeam.ExecuteHits)), HarmonyPostfix]
    private static void ExecuteHits(RevolverBeam __instance, RaycastHit currentHit)
    {
        Debug.Log($"Just hit {currentHit.transform.gameObject.name}!!");
        if (currentHit.transform.TryGetComponent(out RevolverBeamDetector rbd))
        {
            rbd.OnHit.Invoke();
        }
    }
}
