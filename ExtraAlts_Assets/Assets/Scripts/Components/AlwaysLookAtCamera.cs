using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlwaysLookAtCamera : MonoBehaviour {
    public bool faceScreenInsteadOfCamera;  
    public float speed;
    public bool easeIn;
    public Transform overrideTarget;
    public float maxAngle;
    [Space] public bool useXAxis = true;
    public bool useYAxis = true;
    public bool useZAxis = true;
    [Space] public Vector3 rotationOffset;
    [Space] public float maxXAxisFromParent;
    public float maxYAxisFromParent;
    public float maxZAxisFromParent;

	 
	void Start () {}
    void SlowUpdate() { }	
	 
	void LateUpdate ()  { }
    public void ChangeOverrideTarget(Transform newTarget) { }

    public void SnapToTarget() { }}
