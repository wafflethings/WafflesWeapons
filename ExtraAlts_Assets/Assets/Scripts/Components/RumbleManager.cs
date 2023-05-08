using System;
using System.Collections.Generic;
using UnityEngine;

[ConfigureSingleton(SingletonFlags.PersistAutoInstance)]
public class RumbleManager : MonoSingleton<RumbleManager>
{
    public readonly Dictionary<string, PendingVibration> pendingVibrations = new Dictionary<string, PendingVibration>();
    public float currentIntensity {get;set;}    
    public void StopVibration(string key) { }    
    public void StopAllVibrations() { }
    private void Update() { }
    private void OnDisable() { }}

public class PendingVibration
{
    public TimeSince timeSinceStart;
    public string key;

    public float intensityMultiplier = 1f;
    public bool isTracking;
    public GameObject trackedObject;
    
     
    public float Duration {get;set;}    public float Intensity {get;set;}    
    public bool IsFinished {get;set;}}
