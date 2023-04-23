using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ToDo
{
    Nothing,
    Disable,
    Destroy
}

public class GoToTarget : MonoBehaviour
{
    public ToDo onTargetReach;
    public float speed;
    public bool easeIn;
    public float easeInSpeed;
    public Transform target;
    public UltrakillEvent events;

     
    void Start() { }
    private void FixedUpdate() { }
    void Activate() { }}
