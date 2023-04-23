using UnityEngine;
using UnityEngine.Events;

[DisallowMultipleComponent]
public sealed class ComponentEvents : MonoBehaviour
{
    [SerializeField]
    UnityEvent onEnable;

    [SerializeField]
    UnityEvent onDisable;

    void OnEnable() { }
    void OnDisable() { }}
