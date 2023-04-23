using System;
using UnityEngine;
using UnityEngine.Events;

public sealed class RefCountedEvent : MonoBehaviour
{

    [SerializeField]
    UnityEvent m_Activate;

    [SerializeField]
    UnityEvent m_Deactivate;

    public void AddRef() { }
    public void Release() { }}
