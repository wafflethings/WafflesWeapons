using Atlas.Modules.Guns;
using HarmonyLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using WafflesWeapons.Components;

namespace WafflesWeapons.Weapons
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

            if (GunControl.Instance != null && GunControl.Instance.currentWeapon != null && GunControl.Instance.currentWeapon.TryGetComponent(out db) && db.shouldMove)
            {
                __instance.transform.localPosition = Vector3.MoveTowards(__instance.transform.localPosition, __instance.originalPos, Time.deltaTime);
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

                Debug.Log($"hit {__instance.hit.collider.gameObject} => {hitEnemy}");

                DesperadoBehaviour db;
                if (hitEnemy)
                {
                    if (__instance.sourceWeapon.TryGetComponent(out db))
                    {
                        if (__instance.gameObject.name.StartsWith("BouncyDesperado"))
                        {
                            EnemyIdentifier eid = __instance.hit.collider.gameObject.GetComponent<EnemyIdentifier>();
                            if (eid == null)
                            {
                                eid = __instance.hit.collider.gameObject.GetComponent<EnemyIdentifierIdentifier>().eid;
                            }

                            Debug.Log("checking nearest");
                            Vector3 nearest = UltrakillUtils.NearestEnemyPoint(__instance.hit.transform.position, 1000, eid);
                            Debug.Log($"{db.PerfectCurrentDamage} - {db.PerfectStepDecrease} = {db.PerfectCurrentDamage - db.PerfectStepDecrease}");
                            if (nearest != __instance.hit.transform.position && db.PerfectCurrentDamage - db.PerfectStepDecrease > 0)
                            {
                                db.PerfectCurrentDamage -= db.PerfectStepDecrease;
                                Debug.Log("success getting in"); // make nearest check if its not the same enemy
                                __instance.lr.SetPosition(1, __instance.hit.transform.position);
                                __instance.StartCoroutine(CreateNewBeam(db.PerfectBeam, __instance.hit.transform.position, eid));
                            }
                            Debug.Log("all done");
                        }
                    }
                }
            }
            catch (Exception ex) { Debug.LogWarning(ex.ToString()); }
        }

        public static IEnumerator CreateNewBeam(GameObject beam, Vector3 hitPos, EnemyIdentifier eid)
        {
            yield return new WaitForSeconds(0.1f);

            GameObject newBeam = GameObject.Instantiate(beam, hitPos, Quaternion.identity);
            Debug.Log("created");
            newBeam.transform.LookAt(UltrakillUtils.NearestEnemyPoint(hitPos, 1000, eid));
            Debug.Log("looked");
            newBeam.GetComponent<AudioSource>().enabled = false;
            Debug.Log("sr");
            newBeam.GetComponentInChildren<SpriteRenderer>().enabled = false;
            Debug.Log("sw");
            newBeam.GetComponent<RevolverBeam>().sourceWeapon = DesperadoBehaviour.Instances[0].gameObject;
            Debug.Log(":3");
        }

        [HarmonyPatch(typeof(Revolver), nameof(Revolver.Update))]
        [HarmonyPrefix] // i blame hakita
        public static bool AAAAAAAAAAAAAAAA(Revolver __instance)
        {
            return __instance.gunVariation != 6;
        }
    }

    public class DesperadoBehaviour : GunBehaviour<DesperadoBehaviour>
    {
        private Revolver rev;
        private float currentSlider = 0;
        private float leftLimit = 0.4f;
        private float rightLimit = 0.6f;

        private float size = 0.35f;
        [Header("Bar Size")]
        public float minSize = 0.025f;
        public float maxSize = 0.35f;
        public float sizeGainRate = 0.03f;
        public float perfectSizeDecrease = 0.1f;

        private float sliderSpeed = 1.5f;
        [Header("Bar Speed")]
        public float maxSpeed = 5;
        public float minSpeed = 1.5f;
        public float speedDecayRate = 0.5f;
        public float PerfectIncrease = 0.75f;
        public float BadIncrease = 1f;

        private bool goingRight = true;
        [HideInInspector] public bool shouldMove = false;
        private bool shouldAdd = false;
        private float toAdd = 0;

        [Header("Beams")]
        public GameObject PerfectBeam;
        public float PerfectDamage = 2.5f;
        public float PerfectStepDecrease = 0.5f;
        public float PerfectCurrentDamage;

        public GameObject BadBeam;

        [Header("Sliders")]
        public AudioSource SoundEffect;
        public Slider slider;
        public Slider left;
        public Slider right;
        public RectTransform perfectBar;

        public void Start()
        {
            rev = GetComponent<Revolver>();
            Desperado.Guns.Add(this);
        }

        public void OnEnable()
        {
            RandomizeBar();
        }

        public void OnDestroy()
        {
            Desperado.Guns.Remove(this);
        }

        public void Charge()
        {
            if (!rev.shootReady)
            {
                if (rev.shootCharge + 200f * Time.deltaTime < 100f)
                {
                    rev.shootCharge += 200f * Time.deltaTime;
                }
                else
                {
                    rev.shootCharge = 100f;
                    rev.shootReady = true;
                }
            }

            size = Mathf.Clamp(size, minSize, maxSize);
            sliderSpeed = Mathf.Clamp(sliderSpeed, minSpeed, maxSpeed);

            if (shouldMove)
            {
                if (!SoundEffect.isPlaying)
                {
                    SoundEffect.Play();
                }
                SoundEffect.pitch = 1 - GetProximityToBar();
                if (SoundEffect.pitch == 1)
                {
                    SoundEffect.pitch = 2;
                }

                Debug.Log($"{goingRight} gr, {leftLimit} {rightLimit} {currentSlider}");
                if (goingRight)
                {
                    currentSlider += sliderSpeed * Time.deltaTime;
                }
                else
                {
                    currentSlider -= sliderSpeed * Time.deltaTime;
                }

                if ((currentSlider > 1 && goingRight) || (currentSlider < 0 && !goingRight))
                {
                    goingRight = !goingRight;
                    RandomizeBar();

                    if (shouldAdd)
                    {
                        sliderSpeed += toAdd;
                        toAdd = 0;
                        shouldAdd = false;
                    }

                    if (currentSlider > 1)
                    {
                        currentSlider = 1;
                    }
                    if (currentSlider < 0)
                    {
                        currentSlider = 0;
                    }

                    shouldMove = Gun.OnAltFireHeld() && gameObject.activeInHierarchy;
                }
            }
            else
            {
                if (SoundEffect.isPlaying)
                {
                    SoundEffect.Stop();
                }

                sliderSpeed += toAdd;
                toAdd = 0;
                sliderSpeed -= speedDecayRate * Time.deltaTime;
                size += sizeGainRate * Time.deltaTime;
                shouldMove = Gun.OnAltFireHeld() && gameObject.activeInHierarchy;
            }
        }

        public void Update()
        {
            rev.pierceShotCharge = 0;
            
            if (rev.gc.activated)
            {
                Charge();
                slider.value = currentSlider;

                if (rev.shootReady && rev.gunReady)
                {
                    if (Gun.OnFireHeld())
                    {
                        if ((rev.altVersion && WeaponCharges.Instance.revaltpickupcharges[rev.gunVariation] == 0) || !rev.altVersion)
                        {
                            Debug.Log($"Just shot: {leftLimit} < {currentSlider} < {rightLimit}");
                            shouldAdd = true;

                            if (currentSlider > leftLimit && currentSlider <= rightLimit) 
                            {
                                TimeController.Instance.SlowDown(0.25f);
                                rev.revolverBeam = PerfectBeam;
                                PerfectCurrentDamage = PerfectDamage;
                                toAdd = PerfectIncrease;
                                size -= perfectSizeDecrease;
                            }
                            else
                            {
                                rev.revolverBeam = BadBeam;
                                toAdd = BadIncrease;
                            }
                            rev.Shoot();
                        }
                    }
                }
            }
        }

        public void RandomizeBar()
        {
            if (goingRight)
            {
                leftLimit = UnityEngine.Random.Range(0.5f, 0.95f - size);
            }
            else
            {
                leftLimit = UnityEngine.Random.Range(0.05f, 0.5f - size);
            }            

            rightLimit = leftLimit + size;
            perfectBar.anchoredPosition = new Vector2(leftLimit * 200, 0);
            perfectBar.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, size * 200);
            left.value = leftLimit;
            right.value = rightLimit;
        }

        public float GetProximityToBar()
        {
            if (currentSlider > leftLimit && currentSlider < rightLimit)
            {
                return 0;
            }

            float closest = Mathf.Abs(currentSlider - leftLimit) < Mathf.Abs(currentSlider - rightLimit) ? leftLimit : rightLimit;
            return Mathf.Abs(currentSlider - closest);
        }
    }
}
