using System;
using AtlasLib.Utils;
using AtlasLib.Weapons;
using HarmonyLib;
using UnityEngine;
using WafflesWeapons.Assets;
using WafflesWeapons.Components;

namespace WafflesWeapons.Weapons.Singularity;

[PatchThis($"{Plugin.GUID}.Singularity")]
public class Singularity : Weapon
{
    public static WeaponAssets Assets;
        
    static Singularity()
    {
        Assets = AddressableManager.Load<WeaponAssets>("Assets/ExtraAlts/Singularity/Singularity Assets.asset");
    }

    public override WeaponInfo Info => Assets.GetAsset<WeaponInfo>("Info");

    [HarmonyPatch(typeof(RevolverBeam), nameof(RevolverBeam.Shoot)), HarmonyPostfix]
    public static void ShootBall(RevolverBeam __instance)
    {
        if (Physics.Raycast(__instance.transform.position, __instance.transform.forward, out RaycastHit hit, float.PositiveInfinity, LayerMask.GetMask("Projectile")))
        {
            if (hit.transform.TryGetComponent(out SingularityBallBehaviour sbb))
            {
                sbb.GetHit(__instance);
            }
        }
    }

    [HarmonyPatch(typeof(Coin), nameof(Coin.ReflectRevolver)), HarmonyPrefix]
    public static bool ReflectToBall(Coin __instance)
    {
        SingularityBallBehaviour[] balls = GameObject.FindObjectsOfType<SingularityBallBehaviour>();

        if (balls.Length > 0)
        {
            float closestCoin = float.MaxValue;
            Vector3 nmPos = NewMovement.Instance.transform.position;

            foreach (Coin coin in CoinList.Instance.revolverCoinsList)
            {
                if (coin != __instance && (!coin.shot || coin.shotByEnemy))
                {
                    if (closestCoin > Vector3.Distance(nmPos, coin.transform.position) 
                        && !Physics.Raycast(nmPos, coin.transform.position - nmPos, out RaycastHit raycastHit, Vector3.Distance(nmPos, coin.transform.position) - 0.5f, __instance.lmask))
                    {
                        closestCoin = (coin.transform.position - nmPos).sqrMagnitude;
                    }
                }
            }

            int closestIndex = -1;
            for (int i = 0; i < balls.Length; i++)
            {
                Vector3 directionToTarget = balls[i].transform.position - __instance.transform.position;
                if (Physics.Raycast(__instance.transform.position, directionToTarget, out RaycastHit rayHit, directionToTarget.magnitude, LayerMask.GetMask("Projectile", "Limb", "BigCorpse", "Outdoors", "Environment", "Default")))
                {
                    if (rayHit.collider.GetComponent<SingularityBallBehaviour>() == null && rayHit.collider.GetComponentInParent<SingularityBallBehaviour>() == null)
                    {
                        balls[i] = null;
                    }
                    else if (directionToTarget.sqrMagnitude < closestCoin)
                    {
                        closestIndex = i;
                    }
                }
            }

            if (closestIndex != -1)
            {
                LineRenderer beam = GameObject.Instantiate<GameObject>(__instance.refBeam, __instance.transform.position, Quaternion.identity).GetComponent<LineRenderer>();
                beam.gameObject.GetComponent<RevolverBeam>().sourceWeapon = __instance.sourceWeapon;


                if (__instance.hitPoint == Vector3.zero)
                {
                    beam.SetPosition(0, __instance.transform.position);
                }
                else
                {
                    beam.SetPosition(0, __instance.hitPoint);
                }
                beam.SetPosition(1, balls[closestIndex].transform.position);
                balls[closestIndex].GetHit(beam.GetComponent<RevolverBeam>());

                __instance.GetComponent<SphereCollider>().enabled = false;
                __instance.hitTimes--;
                __instance.gameObject.SetActive(false);
                new GameObject().AddComponent<CoinCollector>().coin = __instance.gameObject;
                __instance.CancelInvoke("GetDeleted");
                return false;
            }
        }

        return true;
    }

    [HarmonyPatch(typeof(Bloodsplatter), nameof(Bloodsplatter.OnTriggerEnter)), HarmonyPostfix]
    public static void ChargeGauge(Bloodsplatter __instance, Collider other)
    {
        if (__instance.ready && other.gameObject.CompareTag("Player"))
        {
            float charge = 0;
            if (__instance.hpAmount < 50)
            {
                charge += __instance.hpAmount;
            }
            else
            {
                charge += 50 + (__instance.hpAmount / 5);
            }

            foreach (SingularityBehaviour sb in SingularityBehaviour.Instances)
            {
                sb.charge += charge;
            }

            WaffleWeaponCharges.Instance.SingularityShoCharge += charge;
        }
    }

    public static SingularityBallBehaviour GrabbedBall;

    [HarmonyPatch(typeof(HookArm), nameof(HookArm.FixedUpdate)), HarmonyPostfix]
    public static void GrabBall(HookArm __instance)
    {
        if (__instance.state == HookState.Throwing)
        {
            if (!InputManager.Instance.InputSource.Hook.IsPressed && (__instance.cooldown <= 0.1f || __instance.caughtObjects.Count > 0))
            {
                __instance.StopThrow(0f, false);
            }
            else
            {
                RaycastHit[] array = Physics.SphereCastAll(__instance.hookPoint, Mathf.Min(Vector3.Distance(__instance.transform.position, __instance.hookPoint) / 15f, 5f), __instance.throwDirection, 250f * Time.fixedDeltaTime, __instance.throwMask, QueryTriggerInteraction.Collide);
                Array.Sort(array, (RaycastHit x, RaycastHit y) => x.distance.CompareTo(y.distance));

                foreach (RaycastHit hit in array)
                {
                    if (hit.transform.gameObject.layer == 14 && hit.transform.gameObject.TryGetComponent(out SingularityBallBehaviour sbb))
                    {
                        GrabbedBall = sbb;
                        __instance.caughtTransform = sbb.transform;
                        __instance.caughtCollider = sbb.GetComponent<Collider>();
                        __instance.state = HookState.Caught;
                    }
                }
            }
        }
    }

    [HarmonyPatch(typeof(HookArm), nameof(HookArm.Cancel)), HarmonyPostfix]
    public static void Cancel()
    {
        GrabbedBall = null;
    }
}