using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class RailcannonMeter : MonoSingleton<RailcannonMeter>
{
    public Image meterBackground;
    public Image[] meters;
    public Image colorlessMeter;
    public GameObject[] altHudPanels;
    public GameObject miniVersion;

     
    void Start() { }
    private void OnEnable() { }
     
    void Update() { }
    public void CheckStatus() { }}
