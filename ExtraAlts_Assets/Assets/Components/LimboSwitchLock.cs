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

    public UnityEvent onAllLocksOpen;

    public void OpenLock(int num)
{}}
