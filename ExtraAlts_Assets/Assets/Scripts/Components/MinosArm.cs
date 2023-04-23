using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MinosArm : MonoBehaviour
{
    public Transform hand;
    public GameObject slamWave;
    public ObjectSpawner rubbleSpawner;
    public GameObject shakeEffect;
    public GameObject impactSound;

    public GameObject hurtSound;
    public GameObject bigHurtSound;

    public UnityEvent encounterStart;
    public UnityEvent encounterEnd;

     
    void Start() { }
    void UpdateBuff() { }
    void SetSpeed() { }
     
    void Update() { }
    public void Slam(int type) { }
    public void BigImpact(float shakeAmount = 2) { }
    public void Retreat() { }
    public void EndEncounter() { }
    public void IntroEnd() { }
    public void StopAction() { }
    public void StartShaking() { }
    public void StopShaking() { }
    public void StartEncounter() { }}
