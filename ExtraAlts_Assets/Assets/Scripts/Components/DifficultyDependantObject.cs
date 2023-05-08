using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DifficultyDependantObject : MonoBehaviour
{
    public bool autoDeactivate = true;

     

    [Header("Active in difficulties:")]
    public bool veryEasy = true;
    public bool easy = true;
    public bool normal = true;
    public bool hard = true;
    public bool veryHard = true;
    public bool UKMD = true;

    [Header("Optional events: ")]
    
    public UnityEvent onRightDifficulty;
    public UnityEvent onWrongDifficulty;

     
    void Awake() { }}
