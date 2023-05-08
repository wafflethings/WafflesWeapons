using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Water : MonoBehaviour
{

    public GameObject bubblesParticle;
    public GameObject splash;
    public GameObject smallSplash;

    public Color clr = new Color(0, 0.5f, 1);
    public bool notWet;

    public List<Collider> enteredColliders = new List<Collider>();
    [Header("Optional, for fishing")]
    public FishDB fishDB;
    public Transform overrideFishingPoint;
     
    public FishObject[] attractFish;

    private void Start() { }
    private void FixedUpdate() { }
    private void OnDisable() { }    
     
     
     
     
     
     

    void Enter(Collider other) { }
    public void Exit(Collider other) { }
    public void EnterDryZone(Collider other) { }
    public void ExitDryZone(Collider other) { }}
