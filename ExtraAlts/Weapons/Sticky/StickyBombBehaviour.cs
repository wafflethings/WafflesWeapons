using UnityEngine;
using AtlasLib.Utils;

namespace WafflesWeapons.Weapons.Sticky
{
    public class StickyBombBehaviour : MonoBehaviour
    {
        [HideInInspector] public bool Frozen = false;
        [HideInInspector] public StickyBehaviour myBehaviour;
        public GameObject FrozenExplosion;
        public Collider NonTriggerCollider;

        public void Start()
        {
            Physics.IgnoreCollision(NewMovement.Instance.GetComponent<Collider>(), NonTriggerCollider);

            GetComponent<Rigidbody>().AddForce(CameraController.Instance.transform.forward * 12f +
               (NewMovement.Instance.ridingRocket ? MonoSingleton<NewMovement>.Instance.ridingRocket.rb.velocity : NewMovement.Instance.rb.velocity)
               + (Vector3.up * 10), ForceMode.VelocityChange);

            GetComponent<Projectile>().undeflectable = true;
            Invoke("MakeParriable", 0.25f);
        }

        public void MakeParriable()
        {
            GetComponent<Projectile>().undeflectable = false;
        }

        public void OnDisable()
        {
            Destroy(gameObject);
        }

        public void OnTriggerEnter(Collider c)
        {
            if (c.gameObject.layer == 8 || c.gameObject.layer == 24 || (c.GetComponent<StickyBombBehaviour>()?.Frozen ?? false))
            {
                transform.parent = c.transform;
                Frozen = true;
                CancelInvoke("MakeParriable");
                GetComponent<Projectile>().undeflectable = true;
                GetComponent<Projectile>().enabled = false;
                GetComponent<Projectile>().explosionEffect = FrozenExplosion;
                Destroy(GetComponent<RemoveOnTime>());
                Invoke("Kinematic", 0.01f);
                Destroy(gameObject.GetChild("ChargeEffect"));
            }

            if (Frozen)
            {
                if (c.gameObject.layer == 23)
                {
                    GetComponent<Projectile>().Explode();
                }
            }
        }

        public void Kinematic()
        {
            GetComponent<Rigidbody>().isKinematic = true;
        }

        public void OnDestroy()
        {
            if (!myBehaviour.fromGreed)
            {
                StickyBehaviour.Charges -= 1;

                if (StickyBehaviour.Charges < 0)
                {
                    StickyBehaviour.Charges = 0;
                }
            }
        }
    }
}
