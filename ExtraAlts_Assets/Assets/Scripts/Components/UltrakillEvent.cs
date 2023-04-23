using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class UltrakillEvent
{
    public GameObject[] toActivateObjects;
    public GameObject[] toDisActivateObjects;
    public UnityEvent onActivate;
    public UnityEvent onDisActivate;

    public void Invoke() { }
    public void Revert() { }}

 
 