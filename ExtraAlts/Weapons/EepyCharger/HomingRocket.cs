using UnityEngine;

namespace WafflesWeapons.Weapons.EepyCharger
{
    public class HomingRocket : MonoBehaviour
    {
        public GameObject ToIgnore;
        private LayerMask enemyLayerMask;
        private LayerMask pierceLayerMask;
        private LayerMask ignoreEnemyTrigger;

        public void Start()
        {
            enemyLayerMask |= 1024;
            enemyLayerMask |= 2048;
            pierceLayerMask |= 256;
            pierceLayerMask |= 16777216;
            pierceLayerMask |= 67108864;

            ignoreEnemyTrigger = enemyLayerMask | pierceLayerMask;
        }

        public void Update()
        {
            if (GunControl.Instance.activated)
            {
                Quaternion oldRot = transform.rotation;
                Quaternion newRot;

                int oldLayer = ToIgnore.layer;
                ToIgnore.layer = 2; //ignore raycast;

                if (Physics.Raycast(CameraController.Instance.transform.position, CameraController.Instance.transform.forward, out RaycastHit hit, float.PositiveInfinity, ignoreEnemyTrigger))
                {
                    transform.LookAt(hit.point);
                    newRot = transform.rotation;
                }
                else
                {
                    transform.LookAt(CameraController.Instance.transform.forward * 10000);
                    newRot = transform.rotation;
                }

                ToIgnore.layer = oldLayer;

                transform.rotation = Quaternion.RotateTowards(oldRot, newRot, Time.deltaTime * 360 * 4);
            }
        }
    }
}
