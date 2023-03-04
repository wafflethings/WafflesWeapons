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

    public bool specialFlammable;
    public UnityEvent onSpecialActivate;

    public void Burn(float newHeat)
{}
    public void PutOut()
{}}
