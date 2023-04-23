using System.Collections.Generic;
using UnityEngine;

public class ComplexSplasher : MonoBehaviour
{
    [SerializeField] private ParticleCluster splashParticles;
    [SerializeField] private float maxSplashDistance = 80f;
    [SerializeField] private float keepAliveFor = 3f;

    private void OnDrawGizmosSelected() { }
    private void FixedUpdate() { }}
