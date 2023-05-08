using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeviathanHead : MonoBehaviour
{
    [SerializeField] Transform shootPoint;
    public float projectileSpreadAmount;

    public Transform tracker;
    [SerializeField] Transform tailBone;

    public bool lookAtPlayer;

    [SerializeField] SwingCheck2 biteSwingCheck;

    public Vector3[] spawnPositions;

    [SerializeField] UltrakillEvent onRoar;

    [SerializeField] AudioSource projectileWindupSound;
    [SerializeField] AudioSource biteWindupSound;
    [SerializeField] AudioSource swingSound;
    [SerializeField] GameObject warningFlash;

    void Start() { }
    public void SetSpeed() { }
    void OnEnable() { }
    void ResetDefaults() { }
    void OnDisable() { }
    void LateUpdate() { }
    void Update() { }
    void FixedUpdate() { }
    void Descend() { }
    void DescendEnd() { }
    public void ChangePosition() { }
    void Ascend() { }
    void StartHeadTracking() { }
    void StartBodyTracking() { }
    void Bite() { }
    void BiteStopTracking() { }
    void BiteDamageStart() { }
    public void BiteDamageStop() { }
    void BiteResetRotation() { }
    void BiteEnd() { }
    void ProjectileBurst() { }
    void ProjectileBurstStart() { }
    void StopAction() { }
    void Roar() { }
    void BigSplash() { }}
