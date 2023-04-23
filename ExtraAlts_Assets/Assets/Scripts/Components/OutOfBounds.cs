using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OutOfBounds : MonoBehaviour
{
    public AffectedSubjects targets = AffectedSubjects.All;
    public Vector3 overrideResetPosition;
    public GameObject[] toActivate;
    public GameObject[] toDisactivate;
    public Door[] toUnlock;
    public UnityEvent toEvent;
}
