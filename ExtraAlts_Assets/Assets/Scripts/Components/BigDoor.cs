using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigDoor : MonoBehaviour
{
    public bool open;
    public Vector3 openRotation;
    public float speed;
    public bool screenShake;
    public AudioClip openSound;
    public AudioClip closeSound;

    public Light openLight;
    public bool reverseDirection;

    public bool playerSpeedMultiplier;

     
    void Awake() { }
     
    void Update() { }
    public void Open() { }
    public void Close() { }}
