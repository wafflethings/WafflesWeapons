using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Serialization;

[DefaultExecutionOrder(1000)]
public class GamepadObjectSelector : MonoBehaviour
{

    [SerializeField]
    bool selectOnEnable = true;

    [SerializeField]
    bool firstChild;

    [SerializeField]
    bool allowNonInteractable;

    [SerializeField]
    bool topOnly;

    [SerializeField]
    bool dontMarkTop;

    [SerializeField] [FormerlySerializedAs("target")]
    GameObject mainTarget;

    [SerializeField]
    GameObject fallbackTarget;
    
    GameObject target {get;set;}    
    void OnEnable() { }
    void OnDisable() { }
    void Update() { }
    public void Activate() { }
    public void PopTop() { }
    public void SetTop() { }}
