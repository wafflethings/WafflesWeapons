using UnityEngine;

namespace WafflesWeapons.Weapons.Mindrender;

public class HomingProjectile : MonoBehaviour
{
    private LayerMask enemyLayerMask;
    private LayerMask pierceLayerMask;
    private LayerMask ignoreEnemyTrigger;
    public float speed = 1;

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
            RaycastHit hit;
            Quaternion startRotation = transform.rotation;

            if (Physics.Raycast(CameraController.Instance.transform.position, CameraController.Instance.transform.forward, out hit, float.PositiveInfinity, ignoreEnemyTrigger))
            {
                transform.LookAt(hit.point);
            }
            else
            {
                transform.LookAt(CameraController.Instance.transform.forward * 10000);
            }

            transform.rotation = Quaternion.Lerp(startRotation, transform.rotation, Time.deltaTime * speed);
        }
    }
}