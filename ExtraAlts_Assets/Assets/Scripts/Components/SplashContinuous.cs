using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SplashContinuous : MonoBehaviour
{
    [SerializeField] ParticleSystem particles;
    [SerializeField] GameObject wadingSound;
    [SerializeField] AudioClip[] wadingSounds;
    [SerializeField] float wadingSoundPitch = 0.8f;

    [SerializeField] float movingEmissionRate = 20;
    [SerializeField] float stillEmissionRate = 2;

     
    void FixedUpdate() { }
    public void DestroySoon() { }
    void DestroyNow() { }}
