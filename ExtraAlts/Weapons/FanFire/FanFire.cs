using AtlasLib.Utils;
using AtlasLib.Weapons;
using HarmonyLib;
using UnityEngine;
using WafflesWeapons.Assets;
using WafflesWeapons.Components;

namespace WafflesWeapons.Weapons.FanFire
{
    [PatchThis($"{Plugin.GUID}.FanFire")]
    public class FanFire : Weapon
    {
        public static WeaponAssets Assets;

        static FanFire()
        {
            Assets = AddressableManager.Load<WeaponAssets>("Assets/ExtraAlts/Fan Fire/Fan Fire Assets.asset");
        }

        public override WeaponInfo Info => Assets.GetAsset<WeaponInfo>("Info");

        [HarmonyPatch(typeof(RevolverBeam), nameof(RevolverBeam.ExecuteHits))]
        [HarmonyPrefix]
        public static void Patch_ExecuteHits(RevolverBeam __instance, RaycastHit currentHit)
        {
            // something causes this to error, and i cant be fucking bothered to fix it
            // fuck it, we ball.
            try
            {
                if (currentHit.collider != null && !FanFireBehaviour.BeamsUsed.Contains(__instance))
                {
                    FanFireBehaviour.BeamsUsed.Add(__instance);
                    float amount = 0.5f;
                    if (__instance.sourceWeapon.GetComponent<FanFireBehaviour>() != null)
                    {
                        amount = 1f;
                    }

                    if (__instance.beamType == BeamType.Revolver &&
                        currentHit.collider.gameObject.GetComponent<EnemyIdentifierIdentifier>() != null &&
                        !currentHit.collider.gameObject.GetComponent<EnemyIdentifierIdentifier>().eid.dead &&
                        !__instance.gameObject.name.Contains("FanShot"))
                    {
                        foreach (FanFireBehaviour ffb in FanFireBehaviour.Instances)
                        {
                            ffb.Charge += amount;
                        }
                        WaffleWeaponCharges.Instance.FanRevCharge += amount;
                    }
                }
            } catch { }
        }

        [HarmonyPatch(typeof(StyleHUD), nameof(StyleHUD.DecayFreshness))]
        [HarmonyPostfix]
        public static void StyleMult(StyleHUD __instance, GameObject sourceWeapon, string pointID, bool boss)
        {
            if (sourceWeapon.GetComponent<FanFireBehaviour>() != null)
            {
                var dict = __instance.weaponFreshness;
                if (!dict.ContainsKey(sourceWeapon))
                {
                    return;
                }
                float num = __instance.freshnessDecayPerMove;
                if (__instance.freshnessDecayMultiplierDict.ContainsKey(pointID))
                {
                    num *= __instance.freshnessDecayMultiplierDict[pointID];
                }
                if (boss)
                {
                    num *= __instance.bossFreshnessDecayMultiplier;
                }

                __instance.AddFreshness(sourceWeapon, num * 0.15f);
            }
        }


        [HarmonyPatch(typeof(Coin), nameof(Coin.DelayedReflectRevolver))]
        [HarmonyPrefix]
        public static bool BounceIfFan(Coin __instance, GameObject beam)
        {
            if(beam != null && beam.name.Contains("FanShot"))
            {
                __instance.CancelInvoke("ReflectRevolver");
                beam.GetComponent<RevolverBeam>().hitAmount++;
                beam.GetComponent<RevolverBeam>().maxHitsPerTarget++;
                MyCoolBounce(__instance);
                __instance.Invoke("ReflectRevolver", 1f);
                return false;
            }

            return true;
        }

        public static void MyCoolBounce(Coin coin)
        {
            GameObject NewCoin = GameObject.Instantiate(coin.gameObject, coin.transform.position, Quaternion.identity);
            NewCoin.name = "NewCoin+" + (coin.power - 2f);
            NewCoin.SetActive(false);

            NewCoin.transform.position = coin.transform.position;
            NewCoin.SetActive(true);
            coin.GetComponent<SphereCollider>().enabled = false;
            coin.shot = true;

            Coin NewCoinCoin = NewCoin.GetComponent<Coin>();
            if (NewCoinCoin)
            {
                NewCoinCoin.shot = false;
            }
            Rigidbody NewCoinRb = NewCoin.GetComponent<Rigidbody>();
            if (NewCoinRb)
            {
                NewCoinRb.isKinematic = false;
                NewCoinRb.velocity = Vector3.zero;

                // if the player is looking up, make it go forwards so it isnt too ez
                float mult = 0;
                float rot = CameraController.Instance.transform.localRotation.eulerAngles.x;
                if (rot <= 280 && rot >= 270)
                {
                    mult = 7.5f;
                }

                NewCoinRb.AddForce((Vector3.up * 15f) + (NewMovement.Instance.transform.forward * mult), ForceMode.VelocityChange);
            }

            coin.gameObject.SetActive(false);
            new GameObject().AddComponent<CoinCollector>().coin = coin.gameObject;
            coin.CancelInvoke("GetDeleted");
        }
    }
}
