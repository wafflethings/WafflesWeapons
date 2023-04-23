using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Stalker : MonoBehaviour
{
    public GameObject explosion;
    public Color[] lightColors;
    public AudioClip[] lightSounds;
    public SkinnedMeshRenderer canRenderer;
    public GameObject stepSound;
    public GameObject screamSound;

    public float prepareTime = 5;
    public float prepareWarningTime = 3;

     
    void Start() { }
    void UpdateBuff() { }
    void SetSpeed() { }
    void OnDisable() { }
    void NavigationUpdate() { }
    void SlowUpdate() { }
     
    void Update() { }
    public void Countdown() { }
    public void SandExplode(int onDeath = 1) { }
    public void StopAction() { }
    public void Step() { }}
