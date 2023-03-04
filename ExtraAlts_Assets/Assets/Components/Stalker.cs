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
    
    void Update() { }

    public void Countdown() { }

    public void SandExplode(int onDeath = 1) { }

    public void Step() { }
}
