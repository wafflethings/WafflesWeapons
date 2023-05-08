using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeviathanTail : MonoBehaviour
{
    public Vector3[] spawnPositions;
    [SerializeField] AudioSource swingSound;
    [SerializeField] AudioSource[] spawnAuds;
    [SerializeField] AudioClip swingHighSound;
    [SerializeField] AudioClip swingLowSound;

     
    void Awake() { }
    void Update() { }
    public void PlayerBeenHit() { }
    void SwingStart() { }
    public void SwingEnd() { }
    void ActionOver() { }
    public void ChangePosition() { }
    void BigSplash() { }}
