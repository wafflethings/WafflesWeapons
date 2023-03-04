using UnityEngine;

public class ObjectActivator : MonoBehaviour
{
    public bool oneTime;
    public bool disableOnExit;
    public bool dontActivateOnEnable;
    public bool reactivateOnEnable;
    public float delay;
    public ObjectActivationCheck obac;
    [SerializeField] private UltrakillEvent events;

    public bool forEnemies;

    public void Activate() { }
    
    public void ActivateIfActive() { }

    public void Deactivate() { }
}
