using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerCameraSetter : MonoBehaviour
{
    public Vector3 position = new Vector3(0, 7, -5.5f);
    public Vector3 rotation = new Vector3(20, 0, 0);

    void OnTriggerEnter(Collider other) { }
    void OnTriggerExit(Collider other) { }}
