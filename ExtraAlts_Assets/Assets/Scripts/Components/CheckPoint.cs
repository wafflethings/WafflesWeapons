using System.Collections.Generic;
using Logic;
using UnityEngine;
using UnityEngine.Events;

public class CheckPoint : MonoBehaviour {
    public bool forceOff;
    public GameObject toActivate;
    public GameObject[] rooms;

     
      public List<GameObject> roomsToInherit = new List<GameObject>();
    public Door[] doorsToUnlock;
    public GameObject graphic;
    public GameObject activateEffect;

    public bool multiUse;
    public bool dontAutoReset;
    public bool startOff;
    public bool unteleportable;

    [Space]
    public UnityEvent onRestart;

    private void Start() { }
    private void Update() { }
    public void ActivateCheckPoint() { }
    public void OnRespawn() { }
    public void ResetRoom() { }
    public void UpdateRooms() { }
    public void InheritRoom(GameObject targetRoom) { }
    public void ReactivateCheckpoint() { }
    public void ReactivationEffect() { }
    public void ApplyCurrentStyleAndKills() { }
    public void ApplyCurrentKills() { }
    public void ApplyCurrentStyle() { }
    public void AddCustomKill() { }
    public void ChangeSpawnRotation(float degrees) { }}
