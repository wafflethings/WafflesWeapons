using AtlasLib.Utils;
using UnityEngine;
using WafflesWeapons.Components;

namespace WafflesWeapons.Weapons.FerryOar
{
    public class FerryOarBehaviour : GunBehaviour<FerryOarBehaviour>
    {
        public GameObject OarInHand;
        public ParticleSystem ExposeParticleSystem;
        [HideInInspector] public bool CanPunch;
        [HideInInspector] public bool ExposeThisHit;
        private int _punchesDone;
        private float _timeHeld;
        private Punch _punch;
        private bool _hasSpear = true;
        private Boomerang _currentBoomerang;
        private float _lastSwingTime;

        public void Start()
        {
            _punch = GetComponent<Punch>();
        }

        public void OnDisable()
        {
            if (_punch.anim != null)
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
                    cooldownReal = 0.5f;
                    break;
                case 2:
                    cooldownReal = 0.5f;
                    break;
                case 3:
                    cooldownReal = 2f;
                    break;
            }

            _punch.damage = 0f;
            _punch.screenShakeMultiplier = 0f;
            _punch.force = 0f;
            _punch.tryForExplode = false;

            _punch.ActiveStart();
            _punch.Invoke("ActiveEnd", 3f / 30f);
            Invoke("ReadyToPunch_WithoutHolding", 10f / 30f);
            _punch.Invoke("PunchEnd", 28f / 30f);
            _punch.fc.weightCooldown = cooldownReal;
            _punch.fc.fistCooldown = cooldownReal;
            _lastSwingTime = Time.time;

            if (_punchesDone == 3)
            {
                ExposeParticleSystem.Play();
                Invoke("DisableParticles", 0.5f);
            }
        }

        private void DisableParticles()
        {
            ExposeParticleSystem.Stop();
        }

        private void ReadyToPunch_WithoutHolding()
        {
            _punch.returnToOrigRot = true;
            _punch.ready = true;
            _punch.alreadyBoostedProjectile = false;
            _punch.ignoreDoublePunch = false;
        }

        public void Update()
        {
            if (GunControl.Instance.activated)
            {
                _punch.ready = _hasSpear;

                if (_hasSpear)
                {
                    if (Inputs.PunchHeld)
                    {
                        _timeHeld += Time.deltaTime;
                    }
                    else
                    {
                        if (_timeHeld > 0.3f && Time.time - _lastSwingTime < 1)
                        {
                            ThrowBoomerang();
                        }
                        _timeHeld = 0;
                    }
                }
            }
        }

        public void ThrowBoomerang()
        {
            GameObject throwOar = Instantiate(FerryOar.ThrowableOar, CameraController.Instance.transform.position, CameraController.Instance.transform.rotation);
            _currentBoomerang = throwOar.GetComponent<Boomerang>();

            _currentBoomerang.Target = GetRaycastPoint(out _currentBoomerang.HitSomething);
            _currentBoomerang.Speed = 50;
            OarInHand.SetActive(false);
            _hasSpear = false;
        }

        public void Return()
        {
            OarInHand.SetActive(true);
            _hasSpear = true;
        }

        public static Vector3 GetRaycastPoint(out bool hitSomething)
        {
            Debug.Log("getting point");
            hitSomething = true;

            if (Physics.Raycast(CameraController.Instance.transform.position, CameraController.Instance.transform.forward, out RaycastHit hit, 10000, LayerMaskDefaults.Get(LMD.EnemiesAndEnvironment)))
            {
                return hit.point;
            }

            if (Physics.Raycast(CameraController.Instance.transform.position, CameraController.Instance.transform.forward, out RaycastHit hit2, 10000, LayerMaskDefaults.Get(LMD.Environment)))
            {
                return hit2.point;
            }

            Debug.Log("somehow hit nothing");
            hitSomething = false;
            return CameraController.Instance.transform.position + CameraController.Instance.transform.forward * 100;
        }
    }
}
