using System.Collections.Generic;
using UnityEngine;

namespace WafflesWeapons.Weapons.Virtuous
{
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
}
