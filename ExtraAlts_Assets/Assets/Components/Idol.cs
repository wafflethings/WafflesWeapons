using UnityEngine;

public class Idol : MonoBehaviour
{
    public EnemyIdentifier overrideTarget;
    public bool activeWhileWaitingForOverride;
    [HideInInspector] public EnemyIdentifier target;
    [SerializeField] LineRenderer beam;
    [SerializeField] GameObject deathParticle;

    void Update() { }

    public void Death() { }
    
    public void ChangeOverrideTarget(EnemyIdentifier eid) { }
}
