using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimeOfDayChanger : MonoBehaviour
{
    public bool oneTime;
    
    public Light[] oldLights;
    public Light[] newLights;

    public Material oldWalls;
    public Material oldSky;
    public Material newWalls;
    public Material newSky;

    public bool toBattleMusic;
    public bool toBossMusic;
    public bool musicWaitsUntilChange;
    public bool revertValuesOnFinish;

    public Material newSkybox;
    public SpriteRenderer sunSprite;
    public Color sunSpriteColor;
    
    [Header("Fog")]
    public Color fogColor;
    public bool overrideFogSettings;
    public float fogStart = 450f;
    public float fogEnd = 600f;

    [Header("Lighting")]
     
    public Color ambientLightingColor;

    [Header("Events")]
    public UnityEvent onMaterialChange;

    private void OnEnable() { }
    private void OnDisable() { }

    void Update() { }}
