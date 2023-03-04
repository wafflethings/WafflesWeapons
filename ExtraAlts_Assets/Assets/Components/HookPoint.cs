using UnityEngine;

public class HookPoint : MonoBehaviour
{
    public bool active = true;
    public bool slingShot;
    public MeshRenderer[] renderers;
    public Transform outerOrb;
    public Transform innerOrb;
    public Material disabledMaterial;
    public ParticleSystem activeParticle;
    public GameObject grabParticle;
    public GameObject reachParticle;
    
    [Header("Events")]
    public UltrakillEvent onHook;
    public UltrakillEvent onUnhook;
    public UltrakillEvent onReach;
    

    public void Activate() { }

    public void Deactivate() { }
}
