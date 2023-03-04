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

    public UnityEvent OnPressed => onPressed;

    public UnityEvent OnReleased => onReleased;

    public UnityEvent OnEnter => onEnter;

    public UnityEvent OnExit => onExit;

    public static GraphicRaycaster raycaster;
}
