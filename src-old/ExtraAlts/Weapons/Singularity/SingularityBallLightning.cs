using UnityEngine;

namespace WafflesWeapons.Weapons.Singularity;

public class SingularityBallLightning : MonoBehaviour
{
    [HideInInspector] public GameObject ball;
    [HideInInspector] public GameObject enemy;
    public LineRenderer lr;

    public void Update()
    {
        if (enemy == null || ball == null)
        {
            Destroy(gameObject);
            return;
        }

        lr?.SetPosition(0, ball?.transform.position ?? lr.GetPosition(0));
        lr?.SetPosition(1, enemy?.transform.position ?? lr.GetPosition(1));
    }
}