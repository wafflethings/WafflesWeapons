using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class UnderwaterController : MonoSingleton<UnderwaterController>
{
    public Image overlay;
    public bool inWater;
    public AudioClip underWater;
    public AudioClip surfacing;

    void OnDisable() { }
     
    void Start() { }
    public void InWater(Color clr) { }
    public void OutWater() { }}
