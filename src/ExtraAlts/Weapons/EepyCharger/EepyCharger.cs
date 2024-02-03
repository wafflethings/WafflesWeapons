using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using AtlasLib.Utils;
using AtlasLib.Weapons;
using HarmonyLib;
using UnityEngine;
using WafflesWeapons.Assets;
using WafflesWeapons.Components;

namespace WafflesWeapons.Weapons.EepyCharger;

[PatchThis($"{Plugin.GUID}.EepyCharger")]
public class EepyCharger : Weapon
{
    public static WeaponAssets Assets;

    static EepyCharger()
    {
        Assets = AddressableManager.Load<WeaponAssets>("Assets/ExtraAlts/E.P. Charger/Eepy Assets.asset");
    }

    public override WeaponInfo Info => Assets.GetAsset<WeaponInfo>("Info");

    [HarmonyPatch(typeof(Grenade), nameof(Grenade.Explode)), HarmonyPostfix]
    public static void IncreaseIfBig(Grenade __instance, bool harmless, bool super = false, GameObject exploderWeapon = null)
    {
        if (!harmless && __instance.rocket && exploderWeapon == null && !__instance.GetComponent<HomingRocket>()) //null is if it is exploded by an enemy
        {
            float change = super ? 2 : 1;
            change /= EepyChargerBehaviour.ChargeDivide;

            foreach (EepyChargerBehaviour epc in EepyChargerBehaviour.Instances)
            {
                epc.WindUp += change;
            }

            WaffleWeaponCharges.Instance.EepyCharge += change;
        }
    }

    [HarmonyPatch(typeof(Grenade), nameof(Grenade.Collision)), HarmonyPrefix]
    public static bool MakeEepyIgnore(Grenade __instance, Collider other)
    {
        if (!other.TryGetComponent(out EnemyIdentifierIdentifier eidid))
        {
            return true;
        }

        if (__instance.GetComponent<EepyRocket>() != null)
        {
            __instance.StartCoroutine(IgnoreThenUnignore(__instance, other));
            bool had = EnemyHitTracker.CheckAndHit(__instance.gameObject, eidid.eid, 0.5f);
            Debug.Log(had);
            return had;
        }

        return true;
    }

    public static IEnumerator IgnoreThenUnignore(Grenade gren, Collider col)
    {
        Physics.IgnoreCollision(gren.GetComponent<Collider>(), col);
        yield return new WaitForSeconds(0.5f);

        if (gren != null && col != null)
        {
            Physics.IgnoreCollision(gren.GetComponent<Collider>(), col, false);
        }
    }

    private static MethodInfo m_Object_Destroy = typeof(UnityEngine.Object).GetMethod(nameof(UnityEngine.Object.Destroy), new Type[] { typeof(UnityEngine.Object) } );
    private static MethodInfo m_EepyCharger_DestroyCheck = typeof(EepyCharger).GetMethod(nameof(DestroyCheck));

    [HarmonyPatch(typeof(Grenade), nameof(Grenade.Explode)), HarmonyTranspiler]
    public static IEnumerable<CodeInstruction> DontDestroyIfEepy(IEnumerable<CodeInstruction> instructions)
    {
        foreach (CodeInstruction instruction in instructions)
        {
            if (instruction.OperandIs(m_Object_Destroy))
            {
                yield return new CodeInstruction(OpCodes.Pop);
                yield return new CodeInstruction(OpCodes.Ldarg_0);
                yield return new CodeInstruction(OpCodes.Ldarg_2);
                instruction.opcode = OpCodes.Call;
                instruction.operand = m_EepyCharger_DestroyCheck;
            }

            yield return instruction;
        }
    }

    public static void DestroyCheck(Grenade grenade, bool harmless)
    {
        if (!grenade.GetComponent<EepyRocket>())
        {
            UnityEngine.Object.Destroy(grenade.gameObject);
            return;
        }

        if (harmless)
        {
            UnityEngine.Object.Destroy(grenade.gameObject);
            return;
        }

        grenade.exploded = false;
    }

    private static MethodInfo m_EepyCharger_ScaleRocket = typeof(EepyCharger).GetMethod(nameof(ScaleRocket));

    [HarmonyPatch(typeof(RocketLauncher), nameof(RocketLauncher.Shoot)), HarmonyTranspiler]
    public static IEnumerable<CodeInstruction> ScaleEepyRockets(IEnumerable<CodeInstruction> instructions)
    {
        List<CodeInstruction> list = instructions.ToList();
        list.RemoveAt(list.Count - 1); //remove ret
        list.Add(new CodeInstruction(OpCodes.Ldarg_0)); // the launcher
        list.Add(new CodeInstruction(OpCodes.Ldloc_0)); // the rocket
        list.Add(new CodeInstruction(OpCodes.Call, m_EepyCharger_ScaleRocket));
        list.Add(new CodeInstruction(OpCodes.Ret)); // add the ret back

        return list;
    }

    public static void ScaleRocket(RocketLauncher launcher, GameObject rocket)
    {
        if (launcher?.GetComponent<EepyChargerBehaviour>() != null)
        {
            if (rocket.TryGetComponent(out EepyRocket eepy))
            {
                eepy.Charge = EepyChargerBehaviour.PreviousHeldTime;
                rocket.transform.localScale *= 0.25f + (eepy.Charge * 0.75f);
            }
        }
    }

    private static MethodInfo m_EepyCharger_AffectExplosion = typeof(EepyCharger).GetMethod(nameof(AffectExplosion));

    [HarmonyPatch(typeof(Grenade), nameof(Grenade.Explode)), HarmonyTranspiler]
    public static IEnumerable<CodeInstruction> ChangeExplosionByCharge(IEnumerable<CodeInstruction> instructions)
    {
        List<CodeInstruction> list = instructions.ToList();
        list.RemoveAt(list.Count - 1); //remove ret
        list.Add(new CodeInstruction(OpCodes.Ldarg_0));
        list.Add(new CodeInstruction(OpCodes.Ldloc_0)); // the explosion
        list.Add(new CodeInstruction(OpCodes.Call, m_EepyCharger_AffectExplosion));
        list.Add(new CodeInstruction(OpCodes.Ret)); // add the ret back

        return list;
    }

    public static void AffectExplosion(Grenade grenade, GameObject explosion)
    {
        if (grenade.TryGetComponent(out EepyRocket eepy))
        {
            foreach (Explosion explo in explosion.GetComponentsInChildren<Explosion>())
            {
                explo.damage = (int)(explo.damage * (0.5f + (eepy.Charge * 0.5f)));
                explosion.transform.localScale *= 0.25f + (eepy.Charge * 0.75f);
                explo.maxSize *= 0.25f + (eepy.Charge * 0.75f);
            }
        }
    }
}