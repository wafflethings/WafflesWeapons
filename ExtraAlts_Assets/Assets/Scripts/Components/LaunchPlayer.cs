using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchPlayer : MonoBehaviour
{
    public Vector3 direction;
    public bool relative;
    public bool oneTime;
    public bool dontLaunchOnEnable;

    void Awake() { }
    void OnEnable() { }
    void OnTriggerEnter(Collider other) { }
    public void Launch() { }}
