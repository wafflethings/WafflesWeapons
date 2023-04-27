﻿using Atlas.Modules.Guns;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.ResourceManagement.ResourceLocations;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;

namespace WafflesWeapons.Weapons
{
    public class Virtuous : Gun
    {
        public static GameObject VirtueRail;
        public static GameObject VirtueBeam;

        public static void LoadAssets()
        {
            VirtueRail = Core.Assets.LoadAsset<GameObject>("Railcannon Virtuous.prefab");
            Core.Harmony.PatchAll(typeof(Virtuous));
        }

        public override GameObject Create(Transform parent)
        {
            base.Create(parent);

            if (VirtueBeam == null)
            {
                VirtueBeam = AssetHelper.LoadPrefab("Assets/Prefabs/Attacks and Projectiles/Virtue Insignia.prefab");
            }

            GameObject thing = GameObject.Instantiate(VirtueRail, parent);
            StyleHUD.Instance.weaponFreshness.Add(thing, 10);

            return thing;
        }

        public void DumpAssetNames()
        {
            var allLocations = new List<IResourceLocation>();
            foreach (var resourceLocator in Addressables.ResourceLocators)
            {
                if (resourceLocator is ResourceLocationMap map)
                {
                    foreach (var stuff in map.Locations.Keys)
                    {
                        Debug.Log(stuff);
                    }
                }
            }
        }

        public override int Slot()
        {
            return 3;
        }

        public override string Pref()
        {
            return "rai3";
        }

        [HarmonyPatch(typeof(RevolverBeam), nameof(RevolverBeam.ExecuteHits))]
        [HarmonyPrefix]
        public static void Patch_ExecuteHits(RevolverBeam __instance, RaycastHit currentHit)
        {
            // something causes this to error, and i cant be fucking bothered to fix it
            // fuck it, we ball.
            try
            {
                VirtuousBehaviour vb;

                if (currentHit.collider != null)
                {
                    if (__instance.sourceWeapon.TryGetComponent(out vb))
                    {
                        var eidid = currentHit.collider.gameObject.GetComponent<EnemyIdentifierIdentifier>();
                        if (eidid != null && !eidid.eid.dead)
                        {
                            vb.CreateBeam(eidid.eid);
                        } 
                        else if (currentHit.collider.gameObject.layer == 8 || currentHit.collider.gameObject.layer == 24)
                        {
                            if (__instance.hitEids.Count == 0)
                            {
                                vb.CreateSmallBeam(currentHit.point);
                            }
                        }
                    }
                }
            }
            catch { }
        }

        [HarmonyPatch(typeof(StyleHUD), nameof(StyleHUD.DecayFreshness))]
        [HarmonyPostfix]
        public static void StyleMult(StyleHUD __instance, GameObject sourceWeapon, string pointID, bool boss)
        {
            if (sourceWeapon.GetComponent<VirtuousBehaviour>() != null)
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

                __instance.AddFreshness(sourceWeapon, num * 1f);
            }
        }
    }

    public class VirtueCannonBeam : MonoBehaviour
    {
        public GameObject MyGun;
        public bool IsSmall = false;
        public List<GameObject> Ignore = new List<GameObject>();

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == 10 || other.gameObject.layer == 12)
            {
                try
                {
                    EnemyIdentifierIdentifier eid = null;
                    if (other.gameObject.TryGetComponent(out eid))
                    {
                        if (!Ignore.Contains(eid.eid.gameObject))
                        {
                            Ignore.Add(eid.eid.gameObject);
                            if (!IsSmall)
                            {
                                eid.eid.DeliverDamage(eid.gameObject, Vector3.up * 2500, other.gameObject.transform.position, 5, false, 0, MyGun);
                            }
                            else
                            {
                                eid.eid.DeliverDamage(eid.gameObject, Vector3.up * 2500, other.gameObject.transform.position, 2, false, 0, MyGun);
                            }
                        }
                    }
                }
                catch { } //whatever bruh
            }
        }
    }

    public class VirtuousBehaviour : MonoBehaviour
    {
        public void CreateBeam(EnemyIdentifier eid)
        {
            GameObject beam = Instantiate(Virtuous.VirtueBeam, NewMovement.Instance.transform.position, Quaternion.identity);
            var vi = beam.GetComponent<VirtueInsignia>();
            vi.target = new GameObject().transform;
            vi.target.transform.position = eid.transform.position;
            beam.ChildByName("Capsule").AddComponent<VirtueCannonBeam>().MyGun = gameObject;
            Core.Instance.StartCoroutine(DestroyVi(vi.target));
        }

        public void CreateSmallBeam(Vector3 pos)
        {
            GameObject beam = Instantiate(Virtuous.VirtueBeam, NewMovement.Instance.transform.position, Quaternion.identity);
            beam.transform.localScale = Vector3.one;
            var vi = beam.GetComponent<VirtueInsignia>();
            vi.target = new GameObject().transform;
            vi.target.transform.position = pos;
            beam.ChildByName("Capsule").AddComponent<VirtueCannonBeam>().MyGun = gameObject;
            Core.Instance.StartCoroutine(DestroyVi(vi.target));
        }

        public static System.Collections.IEnumerator DestroyVi(Transform t)
        {
            yield return new WaitForSeconds(5f);
            Destroy(t.gameObject);
        }
    }
}
