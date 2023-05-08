using System.Collections.Generic;
using UnityEngine;

public class Idol : MonoBehaviour
{
    public EnemyIdentifier overrideTarget;
    public bool activeWhileWaitingForOverride;
    [SerializeField] LineRenderer beam;
    [SerializeField] GameObject deathParticle;

     
    void Start() { }
    void UpdateBuff() { }
    void OnDisable() { }
    void OnEnable() { }
    void Update() { }
    void SlowUpdate() { }
    public void Death() { }
    void ChangeTarget(EnemyIdentifier newTarget) { }
    public void ChangeOverrideTarget(EnemyIdentifier eid) { }}
