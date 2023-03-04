using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GetPlayerPref : MonoBehaviour
{
    public string pref;
    public int valueToCheckFor;
    public UnityEvent onCheckSuccess;
}
