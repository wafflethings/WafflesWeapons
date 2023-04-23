using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {

    public int type;
    public bool enemyIn;
    public bool reverseDirection;
    public bool dontDeactivateOnAltarControl;

    public List<EnemyIdentifier> doorUsers = new List<EnemyIdentifier>();

	 
	void Start () {}    
    private void OnDrawGizmos() { }
    private void OnDisable() { }
    private void Update() { }
    public void Close() { }
    public void ForcePlayerOut() { }}
