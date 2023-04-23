using System;
using JetBrains.Annotations;
using UnityEngine;

public class GameState
{
    public string key;
    [CanBeNull] public GameObject trackedObject {get;}    [CanBeNull] public GameObject[] trackedObjects {get;}    
    public LockMode playerInputLock;
    public LockMode cameraInputLock;
    public LockMode cursorLock;

    public int priority = 1;

    public GameState(string key, GameObject trackedObject) { }
    public GameState(string key, GameObject[] trackedObjects) { }
    public GameState(string key) { }}

public enum LockMode { None, Lock, Unlock }