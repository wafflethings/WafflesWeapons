using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamgunBeam : MonoBehaviour
{
    public bool active = true;
    [SerializeField] private LineRenderer line;
    [SerializeField] private ParticleSystem hitParticle;
    public bool canHitPlayer;
    public float beamCheckSpeed = 1;

    public float beamWidth = 0.1f;

     
    void Start() { }
    void FixedUpdate() { }
     
    void Update() { }}
