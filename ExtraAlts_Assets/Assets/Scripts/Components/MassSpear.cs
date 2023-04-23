using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassSpear : MonoBehaviour
{

    public bool hitPlayer;
    public bool beenStopped;

    public Transform originPoint;

    public float spearHealth;
    public GameObject breakMetalSmall;
    public AudioClip hit;
    public AudioClip stop;
    public float speedMultiplier = 1;
    public float damageMultiplier = 1;

     
    void Start() { }
    void OnDisable() { }
     
    void Update() { }
    public void GetHurt(float damage) { }
    public void Deflected() { }
    void CheckForDistance() { }}
