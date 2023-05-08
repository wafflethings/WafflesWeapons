using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Vector3[] relativePoints;
    public float speed;
    public bool ease;
    public bool reverseAtEnd;
    public bool stopAtEnd;
    public float startOffset;
    public float moveDelay;
    public AudioClip moveSound;
    public AudioClip stopSound;

    public UltrakillEvent[] onReachPoint;

     
    void Start() { }
     
    void FixedUpdate() { }
    void NextPoint() { }}
