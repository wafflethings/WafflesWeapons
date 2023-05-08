using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum SwitchLockType
{
    None,
    Limbo,
    PRank
}

public class LimboSwitchLock : MonoBehaviour
{
    public SwitchLockType type;
    public MeshRenderer[] locks;
    public MeshRenderer[] primeBossLocks;

    public UnityEvent onAllLocksOpen;
    public int minimumOrderNumber;
    public int primeBossLockNumber = 1;

     
    void Start() { }
     
    void Update() { }
    void CheckLocks() { }
    public void OpenLock(int num) { }}
