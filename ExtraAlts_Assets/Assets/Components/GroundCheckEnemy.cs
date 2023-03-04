using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheckEnemy : MonoBehaviour {

    public bool onGround = false;
    public List<Collider> cols = new List<Collider>();
    public bool dontCheckTags;
}
