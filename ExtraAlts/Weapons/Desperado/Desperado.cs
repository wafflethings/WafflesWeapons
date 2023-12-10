using System;
using System.Collections;
using System.Collections.Generic;
using Atlas.Modules.Guns;
using HarmonyLib;
using UnityEngine;
using WafflesWeapons.Utils;

namespace WafflesWeapons.Weapons.Desperado
{
    public class Desperado : Gun
    {
        public static GameObject Desp;
        public static GameObject DespAlt;
        public static List<DesperadoBehaviour> Guns = new List<DesperadoBehaviour>();

        static Desperado()
        {
            Desp = Core.Assets.LoadAsset<GameObject>("Revolver Desperado.prefab");
            DespAlt = Core.Assets.LoadAsset<GameObject>("Alternative Revolver Desperado.prefab");
            Core.Harmony.PatchAll(typeof(Desperado));
        }

        public override GameObject Create(Transform parent)
        {
            base.Create(parent);

            GameObject thing;
            if (Enabled() == 2)
            {
                thing = GameObject.Instantiate(DespAlt, parent);
            }
            else
            {
                thing = GameObject.Instantiate(Desp, parent);
            }

            OrderInSlot = GunSetter.Instance.CheckWeaponOrder("rev")[5];
            StyleHUD.Instance.weaponFreshness.Add(thing, 10);
            return thing;
        }

        public override int Slot()
        {
            return 0;
        }

        public override string Pref()
        {
            return "rev5";
        }

        [HarmonyPatch(typeof(WalkingBob), nameof(WalkingBob.Update))]
        [HarmonyPostfix]
        public static void DecreaseBobForDesp(WalkingBob __instance)
        {
            DesperadoBehaviour db;

            if (GunControl.Instance != null && GunControl.Instance.currentWeapon != null &&
                GunControl.Instance.currentWeapon.TryGetComponent(out db) && db.shouldMove)
            {
                __instance.transform.localPosition = Vector3.MoveTowards(__instance.transform.localPosition,
                    __instance.originalPos, Time.deltaTime);
            }
        }

        [HarmonyPatch(typeof(RevolverBeam), nameof(RevolverBeam.ExecuteHits))]
        [HarmonyPostfix]
        public static void Patch_ExecuteHits(RevolverBeam __instance, RaycastHit currentHit)
        {
            // something causes this to error, and i cant be fucking bothered to fix it
            // fuck it, we ball.
            try
            {
                bool hitEnemy = __instance.hit.collider.gameObject.GetComponent<EnemyIdentifierIdentifier>() != null ||
                                __instance.hit.collider.gameObject.GetComponent<EnemyIdentifier>() != null;

                if (hitEnemy)
                {
                    if (__instance.sourceWeapon.TryGetComponent(out DesperadoBehaviour db))
                    {
                        if (__instance.gameObject.name.StartsWith("BouncyDesperado"))
                        {
                            EnemyIdentifier eid = __instance.hit.collider.gameObject.GetComponent<EnemyIdentifier>();
                            if (eid == null)
                            {
                                eid = __instance.hit.collider.gameObject.GetComponent<EnemyIdentifierIdentifier>().eid;
                            }

                            Vector3 nearest =
                                UltrakillUtils.NearestEnemyPoint(__instance.hit.transform.position, 1000, eid);
                            Debug.Log(
                                $"{db.PerfectCurrentDamage} - {db.PerfectStepDecrease} = {db.PerfectCurrentDamage - db.PerfectStepDecrease}");
                            db.PerfectCurrentDamage -= db.PerfectStepDecrease;
                            if (nearest != __instance.hit.transform.position && db.PerfectCurrentDamage > 0)
                            {
                                __instance.lr.SetPosition(1, __instance.hit.transform.position);
                                __instance.StartCoroutine(CreateNewBeam(db.PerfectBeam,
                                    __instance.hit.transform.position, eid, db.PerfectCurrentDamage));
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { Debug.LogWarning(ex.ToString()); }
        }

        public static IEnumerator CreateNewBeam(GameObject beam, Vector3 hitPos, EnemyIdentifier eid, float dmg)
        {
            yield return new WaitForSeconds(0.1f);

            GameObject newBeam = GameObject.Instantiate(beam, hitPos, Quaternion.identity);
            newBeam.transform.LookAt(UltrakillUtils.NearestEnemyPoint(hitPos, 1000, eid));
            newBeam.GetComponent<AudioSource>().enabled = false;
            newBeam.GetComponentInChildren<SpriteRenderer>().enabled = false;
            newBeam.GetComponent<RevolverBeam>().sourceWeapon = DesperadoBehaviour.Instances[0].gameObject;
            newBeam.GetComponent<RevolverBeam>().damage = dmg;
            Debug.Log(":3");
        }

        [HarmonyPatch(typeof(Revolver), nameof(Revolver.Update))]
        [HarmonyPrefix] // i blame hakita
        public static bool AAAAAAAAAAAAAAAA(Revolver __instance)
        {
            return __instance.gunVariation != 6;
        }
    }
}
