using System.Collections;
using System.Collections.Generic;
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

     
    void Start() { }
    private void Update() { }
    public void Hooked() { }
    public void Unhooked() { }
    public void Reached() { }    public void Reached(Vector3 direction) { }
    public void Activate() { }
    public void Deactivate() { }
    void SetValues() { }}
