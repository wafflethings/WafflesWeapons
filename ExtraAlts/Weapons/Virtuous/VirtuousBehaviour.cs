using AtlasLib.Utils;
using UnityEngine;
using WafflesWeapons.Components;
using WafflesWeapons.Utils;

namespace WafflesWeapons.Weapons.Virtuous
{
    public class VirtuousBehaviour : GunBehaviour<VirtuousBehaviour>
    {
        public GameObject VirtueBeam;
        public GameObject VirtueBeamSmall;

        public void CreateBeam(Vector3 pos, bool isSmall = false)
        {
            GameObject beam = Instantiate((isSmall ? VirtueBeamSmall : VirtueBeam), NewMovement.Instance.transform.position, Quaternion.identity);
            var vi = beam.GetComponent<VirtueInsignia>();
            var t = new GameObject().transform;
            vi.target = new EnemyTarget(t);
            t.position = pos;
            beam.GetChild("Capsule").AddComponent<VirtueCannonBeam>().MyGun = gameObject;
            StartCoroutine(DestroyVi(vi.target.targetTransform));
        }

        public static System.Collections.IEnumerator DestroyVi(Transform t)
        {
            yield return new WaitForSeconds(5f);
            Destroy(t.gameObject);
        }
    }
}
