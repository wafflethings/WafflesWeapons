using UnityEngine;
using UnityEngine.Events;

class BackSelectEvent : MonoBehaviour
{
    [SerializeField]
    UnityEvent m_OnBack;

    public void InvokeOnBack() { }}
