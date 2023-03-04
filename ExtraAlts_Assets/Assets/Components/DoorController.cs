using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {

    public int type;
    public bool enemyIn;
    public bool reverseDirection;
    public bool dontDeactivateOnAltarControl;

    public List<EnemyIdentifier> doorUsers = new List<EnemyIdentifier>();

    public void Close() {}

    private void OnDrawGizmos()
    {
        var col = GetComponent<Collider>();
        if (!col) return;
        var bounds = col.bounds;
        Gizmos.color = new Color(0.2f, 0.2f, 1, 1f);
        Gizmos.DrawWireCube(bounds.center, bounds.size);
        Gizmos.color = new Color(0.2f, 0.2f, 1, 0.15f);
        Gizmos.DrawCube(bounds.center, bounds.size);
    }
}
