using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour {

    public Vector3 spinDirection;
    public float speed;
    public bool inLateUpdate;
    public bool notRelative;

    public bool gradual;
    public float gradualSpeed;
    public bool off;

    private void Start() { }
    void FixedUpdate () {}
    private void LateUpdate() { }
    public void ChangeState(bool on) { }
    public void ChangeSpeed(float newSpeed) { }
    public void ChangeGradualSpeed(float newGradualSpeed) { }
    public void ChangePitchMultiplier(float newPitch) { }
    public void ChangeSpinDirection(Vector3 newDirection) { }}
