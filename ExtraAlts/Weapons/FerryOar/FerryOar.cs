using System.Collections;
using System.Collections.Generic;
using AtlasLib.Weapons;
using AtlasLib.Utils;
using HarmonyLib;
using UnityEngine;
using WafflesWeapons.Assets;

namespace WafflesWeapons.Weapons.FerryOar
{
    [PatchThis($"{Plugin.GUID}.FerryOar")]
    public class FerryOar : Weapon
    {
        public static WeaponAssets Assets;
        public static GameObject LightningIndicator;
        public static GameObject LightningExplosion;
        public static GameObject ThrowableOar;

        static FerryOar()
        {
            Assets = Plugin.Assets.LoadAsset<WeaponAssets>("Ferry Oar Assets.asset");
            LightningIndicator = Plugin.Assets.LoadAsset<GameObject>("Ferry Expose Indicator.prefab");
            LightningExplosion = Plugin.Assets.LoadAsset<GameObject>("Ferry Lightning Explosion.prefab");
            ThrowableOar = Plugin.Assets.LoadAsset<GameObject>("Ferry Throw Oar.prefab");
        }

        public override WeaponInfo Info => Assets.GetAsset<WeaponInfo>("Info");
        
        [HarmonyPatch(typeof(FistControl), nameof(FistControl.UpdateFistIcon)), HarmonyPostfix]
        public static void FixColour(FistControl __instance)
        {
            try
            {
                if (__instance.currentArmObject?.GetComponent<FerryOarBehaviour>() != null)
                {
                    __instance.fistIcon.color = ColorBlindSettings.Instance.variationColors[4];
                }
            }
            catch
            {
                Debug.LogError($"whar? {ColorBlindSettings.Instance.variationColors.Length}");
            }
        }

        [HarmonyPatch(typeof(Punch), nameof(Punch.PunchStart)), HarmonyPrefix]
        public static bool DoRealPunch(Punch __instance)
        {
            if (__instance.TryGetComponent(out FerryOarBehaviour fo))
            {
                if (fo.CanPunch)
                {
                    return false;
                }

                if (__instance.ready)
                {
                    // lb.anim.Play("Armature|ES_HookPunch", 0, 0);
                    fo.Punch();
                }
            }

            return true;
        }

        [HarmonyPatch(typeof(Punch), nameof(Punch.PunchSuccess)), HarmonyPrefix]
        public static void ExposePunchedEnemy(Punch __instance, ref string __state, Transform target)
        {
            if (__instance.TryGetComponent(out FerryOarBehaviour fo))
            {
                if (fo.ExposeThisHit && (target.gameObject.tag == "Enemy" || target.gameObject.tag == "Armor" || target.gameObject.tag == "Head" || target.gameObject.tag == "Body" || target.gameObject.tag == "Limb" || target.gameObject.tag == "EndLimb"))
                {
                    if (target.TryGetComponent(out EnemyIdentifierIdentifier eidid))
                    {
                        if (eidid.eid.gameObject.GetComponent<ExposeTag>() == null)
                        {
                            eidid.eid.gameObject.AddComponent<ExposeTag>();
                        }

                        if (eidid.eid.enemyType != EnemyType.Idol)
                        {
                            __state = __instance.hitter;
                            __instance.hitter = "exposalpunch"; //dont want to break idols
                        }
                    }
                }
            }
        }

        [HarmonyPatch(typeof(Punch), nameof(Punch.AltHit)), HarmonyPatch(typeof(Punch), nameof(Punch.PunchSuccess)), HarmonyPrefix]
        public static void SwingReflect(Punch __instance, Transform target)
        {
            if (__instance.TryGetComponent(out FerryOarBehaviour fo))
            {
                NewMovement nm = NewMovement.Instance;

                Debug.Log("checking: " + target.gameObject.layer);
                if (LayerMaskDefaults.Get(LMD.Environment).Contains(target.gameObject.layer) || (!nm.gc.touchingGround && LayerMaskDefaults.Get(LMD.Enemies).Contains(target.gameObject.layer)))
                {
                    nm.jumpPower /= 4;
                    nm.Jump();
                    nm.jumpPower *= 4;
                    Debug.Log("jump");
                    nm.rb.AddForce(-CameraController.Instance.transform.forward * 1000, ForceMode.Impulse);
                }
            }
        }

        [HarmonyPatch(typeof(Punch), nameof(Punch.PunchSuccess)), HarmonyPostfix]
        public static void ResetHitter(Punch __instance, string __state)
        {
            if (__instance.hitter == "exposalpunch")
            {
                __instance.hitter = __state;
            }
        }

        public static List<EnemyIdentifier> HitRecently = new List<EnemyIdentifier>();
        public static IEnumerator Ensure(EnemyIdentifier eid)
        {
            HitRecently.Add(eid);
            yield return new WaitForSeconds(0.01f);
            HitRecently.Remove(eid);
        }

        [HarmonyPatch(typeof(EnemyIdentifier), nameof(EnemyIdentifier.DeliverDamage)), HarmonyPrefix]
        public static void ExplodeExposed(EnemyIdentifier __instance)
        {
            if (!__instance.dead && !HitRecently.Contains(__instance) && __instance.TryGetComponent(out ExposeTag et) && !et.Done)
            {
                if (__instance.hitter == "exposalpunch") 
                {
                    return;
                }

                et.Done = true;
                Object.Instantiate(LightningExplosion, __instance.transform.position, __instance.transform.rotation);
                Object.Destroy(et);
            }

            __instance.StartCoroutine(Ensure(__instance)); //TODO fix this it sucks
        }

        [HarmonyPatch(typeof(EnemyIdentifier), nameof(EnemyIdentifier.DeliverDamage)), HarmonyPostfix]
        public static void UnexposeIfDead(EnemyIdentifier __instance)
        {
            if (__instance.TryGetComponent(out ExposeTag et) && !et.Done && __instance.dead)
            {
                et.Done = true;
                Object.Destroy(et);
            }
        }
    }
}
