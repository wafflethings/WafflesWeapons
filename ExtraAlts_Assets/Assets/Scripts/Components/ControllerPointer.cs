using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections.Generic;

[DisallowMultipleComponent]
class ControllerPointer : MonoBehaviour
{

    [SerializeField]
    UnityEvent onPressed;

    [SerializeField]
    UnityEvent onReleased;

    [SerializeField]
    UnityEvent onEnter;

    [SerializeField]
    UnityEvent onExit;

    public UnityEvent OnPressed {get;set;}
    public UnityEvent OnReleased {get;set;}
    public UnityEvent OnEnter {get;set;}
    public UnityEvent OnExit {get;set;}
    void Awake() { }
    void UpdateSlider() { }
    void UpdateScrollbars() { }
    void UpdateScrollbar(Scrollbar scroll) { }
    void Update() { }
    void UpdateEvents() { }}
