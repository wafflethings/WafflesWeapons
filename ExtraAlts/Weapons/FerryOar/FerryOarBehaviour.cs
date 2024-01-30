using System.Collections;
using System.Diagnostics;
using AtlasLib.Utils;
using UnityEngine;
using WafflesWeapons.Components;

namespace WafflesWeapons.Weapons.FerryOar
{
    public class FerryOarBehaviour : GunBehaviour<FerryOarBehaviour>
    {
        public GameObject OarInHand;
        public ParticleSystem ExposeParticleSystem;
        public Renderer ExposeOutlineEffect;
        public Renderer WholeArmOutline;
        [Header("Sounds")]
        public AudioSource CatchSound;
        public AudioSource RainSound;
        public AudioSource ThrowSound;
        [HideInInspector] public bool HasSpear = true;
        [HideInInspector] public bool ExposeThisHit;
        private int _punchesDone;
        private float _timeHeld;
        private Punch _punch;
        private Boomerang _currentBoomerang;
        private Vector3 _startPos;

        public void Start()
        {
            _punch = GetComponent<Punch>();
            _startPos = transform.localPosition;
        }

        public void OnDisable()
        {
            if (_punch?.anim != null)
            {
                _punch.anim.Play("Idle");
            }
        }

        public void Punch()
        {
            _punchesDone++;

            ExposeThisHit = _punchesDone == 3;

            if (_punchesDone > 3)
            {
                _punchesDone = 1;
            }

            float cooldownReal = 0;

            switch (_punchesDone)
            {
                case 1:
                    cooldownReal = 0.2f;
                    break;
                case 2:
                    cooldownReal = 0.2f;
                    break;
                case 3:
                    cooldownReal = 1f;
                    break;
            }

            _punch.damage = 2f;
            _punch.screenShakeMultiplier = 0f;
            _punch.force = 0f;
            _punch.tryForExplode = false;
            
            _punch.ActiveStart();
            _punch.activeFrames = 0;
            _punch.Invoke("ActiveEnd", 3f / 30f);
            _punch.Invoke("ReadyToPunch", 10f / 30f);
            _punch.Invoke("PunchEnd", 28f / 30f);
            _punch.fc.weightCooldown = cooldownReal;
            _punch.fc.fistCooldown = cooldownReal;

            if (_punchesDone == 3)
            {
                StartCoroutine(CreateExposeEffects());
            }
        }

        private IEnumerator CreateExposeEffects()
        {
            if (_punchesDone == 3)
            {
                StartCoroutine(SlowAnimator());
            }
            ExposeParticleSystem.Play();
            yield return FadeElectricityOutline(0.5f);
            yield return new WaitForSeconds(0.5f);
            ExposeParticleSystem.Stop();
            yield return FadeElectricityOutline(0f);
        }

        private IEnumerator SlowAnimator()
        {
            _punch.anim.speed = 0.25f;

            while (_punch.anim.speed != 1)
            {
                _punch.anim.speed = Mathf.MoveTowards(_punch.anim.speed, 1, Time.deltaTime);
                yield return null;
            }
        }
        private IEnumerator FadeElectricityOutline(float targetOpacity)
        {
            while (!Mathf.Approximately(ExposeOutlineEffect.material.color.a, targetOpacity))
            {
                Color oldCol = ExposeOutlineEffect.material.color;
                oldCol.a = Mathf.MoveTowards(oldCol.a, targetOpacity, Time.deltaTime * 10);
                ExposeOutlineEffect.material.color = oldCol;
                WholeArmOutline.material.color = oldCol;
                yield return null;
            }
        }

        public void Update()
        {
            if (GunControl.Instance.activated)
            {
                // _punch.ready = _hasSpear;

                if (HasSpear)
                {
                    if (Inputs.PunchHeld)
                    {
                        if (_timeHeld < 0.3f && _timeHeld + Time.deltaTime > 0.3)
                        {
                            _punch.anim.SetBool("ChargingOar", true);
                            CatchSound.PlayDelayed(0.16f);
                        }

                        if (_timeHeld > 1f)
                        {
                            transform.localPosition = _startPos + new Vector3(Random.Range(-0.05f, 0.05f), Random.Range(-0.05f, 0.05f), Random.Range(-0.05f, 0.05f)) * 0.25f;
                            RainSound.volume = Mathf.MoveTowards(RainSound.volume, 0.5f, Time.deltaTime);
                            if (!RainSound.isPlaying)
                            {
                                RainSound.Play();
                            }
                        }
                        
                        _timeHeld += Time.deltaTime;
                    }
                    else
                    {
                        if (_timeHeld > 0.6f && Inputs.PunchReleased)
                        {
                            _punch.anim.SetTrigger("Throw");
                            Invoke("ThrowBoomerang", 0.05f);

                        }

                        RainSound.volume = 0;
                        RainSound.Stop();
                        transform.localPosition = _startPos;
                        _punch.anim.SetBool("ChargingOar", false);
                        _timeHeld = 0;
                    }
                }
            }
        }

        public void ThrowBoomerang()
        {
            ThrowSound.Play();
            GameObject throwOar = Instantiate(FerryOar.ThrowableOar, CameraController.Instance.transform.position, CameraController.Instance.transform.rotation);
            _currentBoomerang = throwOar.GetComponent<Boomerang>();

            _currentBoomerang.Target = GetRaycastPoint(out _currentBoomerang.HitSomething);
            _currentBoomerang.Speed = 50;
            OarInHand.SetActive(false);
            HasSpear = false;
        }

        public void Return()
        {
            OarInHand.SetActive(true);
            HasSpear = true;
        }

        public static Vector3 GetRaycastPoint(out bool hitSomething)
        {
            UnityEngine.Debug.Log("getting point");
            hitSomething = true;

            if (Physics.Raycast(CameraController.Instance.transform.position, CameraController.Instance.transform.forward, out RaycastHit hit, 10000, LayerMaskDefaults.Get(LMD.EnemiesAndEnvironment)))
            {
                return hit.point;
            }

            if (Physics.Raycast(CameraController.Instance.transform.position, CameraController.Instance.transform.forward, out RaycastHit hit2, 10000, LayerMaskDefaults.Get(LMD.Environment)))
            {
                return hit2.point;
            }

            UnityEngine.Debug.Log("somehow hit nothing");
            hitSomething = false;
            return CameraController.Instance.transform.position + CameraController.Instance.transform.forward * 100;
        }
    }
}
