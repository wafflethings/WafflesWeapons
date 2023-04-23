using System.Collections;
using UnityEngine;

public class TimeBomb : MonoBehaviour
{
    public bool dontStartOnAwake;
    public float timer;
    public GameObject beepLight;
    public float beeperSize;
    public Color beeperColor = Color.white;
    public float beeperPitch = 0.65f;

    public GameObject explosion;
    public bool dontExplode;

     
    void Start() { }
    private void OnEnable() { }
     
    void Update() { }
    public void StartCountdown() { }}
