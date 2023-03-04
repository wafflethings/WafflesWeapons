using UnityEngine;

public class AlwaysLookAtCamera : MonoBehaviour {
    public float speed;
    public bool easeIn;
    public Transform overrideTarget;
    public float maxAngle;
    [Space] public bool useXAxis = true;
    public bool useYAxis = true;
    public bool useZAxis = true;
}
