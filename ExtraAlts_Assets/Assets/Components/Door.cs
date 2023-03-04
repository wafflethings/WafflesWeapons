using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public enum DoorType
{
    Normal,
    BigDoorController,
    SubDoorController
}

public class Door : MonoBehaviour {

    public DoorType doorType;

    public bool open;

    public bool gotPos;
    public Vector3 closedPos;
    public Vector3 openPos;
    public bool startOpen;
    public float speed;
    public bool reverseDirection;
    public int requests;
    public AudioClip openSound;
    public AudioClip closeSound;

    public bool locked;
    public GameObject noPass;

    public GameObject[] activatedRooms;
    public GameObject[] deactivatedRooms;

    public Light openLight;
    public UnityEvent onFullyOpened;
    public bool screenShake;
    public bool dontCloseWhenAnotherDoorOpens;
    public Color defaultLightsColor;
    public Color currentLightsColor;

    public void AltarControlled() {}    
    public void SimpleOpenOverride() {}
    public void Open(bool enemy = false, bool skull = false) {}
    public void Optimize() {}
    public void Close(bool force = false) {}
    public void Lock() {}
    public void Unlock() {}
    public void ChangeColor(Color targetColor) {}
    public void LockOpen() {}
    public void LockClose() {}
    public void BigDoorClosed() {}
}
