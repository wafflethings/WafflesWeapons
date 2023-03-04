using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flicker : MonoBehaviour {
    public float delay;
    public bool onlyOnce;

    public bool quickFlicker;
    public float rangeRandomizer;
    public float intensityRandomizer;
    public float timeRandomizer;
    public bool stopAudio;

    public GameObject[] flickerDisableObjects;
}
