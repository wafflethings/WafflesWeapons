using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheckEnemy : MonoBehaviour {

    public bool onGround = false;
    public bool touchingGround = false;
    public List<Collider> cols = new List<Collider>();
    public bool dontCheckTags;
    public List<Collider> toIgnore = new List<Collider>();

    private void Start() { }
    void OnEnable() { }
    void CheckCols() { }
    void CheckColsOnce() { }
    public void ForceOff() { }
    public void StopForceOff() { }}
