using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Flammable : MonoBehaviour
{
    public float heat;
    public GameObject fire;
    public GameObject simpleFire;
    public bool burning;
    public bool secondary;
    public bool wet;

    public bool playerOnly;
    public bool specialFlammable;
    public UnityEvent onSpecialActivate;

     
    void Start() { }
    void OnEnable() { }
    void OnDisable() { }
    public void Burn(float newHeat, bool noInstaDamage = false) { }
    void Pulse() { }
    public void PutOut(bool getWet = true) { }}
