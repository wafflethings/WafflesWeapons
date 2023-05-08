using System.Collections.Generic;
using Sandbox;
using UnityEngine;
using Physics = UnityEngine.Physics;

public enum HookState
{
    Ready,
    Throwing,
    Caught,
    Pulling
}

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class HookArm : MonoSingleton<HookArm>
{
    public bool equipped = false;
    [SerializeField] private GameObject model;

    public Transform hand;
    public Transform hook;
    public GameObject hookModel;
    [SerializeField] private LineRenderer inspectLr;
    [Header("Sounds")]
    public GameObject throwSound;
    public GameObject hitSound;
    public GameObject pullSound;
    public GameObject pullDoneSound;
    public GameObject catchSound;
    public GameObject errorSound;
    public AudioClip throwLoop;
    public AudioClip pullLoop;
    public GameObject wooshSound;

    public GameObject clinkSparks;
    public GameObject clinkObjectSparks;

     
    void Start() { }
    public void Inspect() { }
    private void Update() { }
    private void LateUpdate() { }
    private void FixedUpdate() { }
    void SolveDeadIgnore() { }
    void ItemGrabError(RaycastHit rhit) { }
    public void StopThrow(float animationTime = 0, bool sparks = false) { }
    public void Cancel() { }
    public void CatchOver() { }
    void ForceGroundCheck() { }
    void StopForceGroundCheck() { }
    void SemiBlockCheck() { }}
