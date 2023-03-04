using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ToDo
{
    Nothing,
    Disable,
    Destroy
}

public class GoToTarget : MonoBehaviour
{
    public ToDo onTargetReach;
    public float speed;
    public Transform target;
}
