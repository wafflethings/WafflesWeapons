using System.Collections.Generic;
using TriInspector;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Events;

public class CheckPoint : MonoBehaviour
{
	[HideInInspector]
	public StatsManager sm;

	[HideInInspector]
	public bool activated;

	private bool firstTime;

	public GameObject graphic;

	public AssetReference activateEffect;

	[Required]
	public GameObject toActivate;

	[Header("Targets")]
	public bool inheritAllRooms;

	public bool unlockAllDoors;

	public GameObject[] rooms;

	public List<GameObject> roomsToInherit;

	private List<string> inheritNames;

	private List<Transform> inheritParents;

	[HideInInspector]
	public List<GameObject> defaultRooms;

	[HideInInspector]
	public List<GameObject> newRooms;

	public Door[] doorsToUnlock;

	public Door[] doorsToIgnore;

	private int i;

	private GameObject player;

	private NewMovement nm;

	private float tempRot;

	[HideInInspector]
	public int restartKills;

	[HideInInspector]
	public int stylePoints;

	[HideInInspector]
	public bool challengeAlreadyFailed;

	[HideInInspector]
	public bool challengeAlreadyDone;

	private StyleHUD shud;

	[Header("Automatic Resets")]
	public bool resetOnGetOtherCheckpoint;

	public bool resetOnDistance;

	public float autoResetDistance;

	private float resetSafetyTimer;

	private bool inDuringResetSafety;

	[Space]
	public bool startOff;

	public bool forceOff;

	public bool disableDuringCombat;

	public bool unteleportable;

	public bool invisible;

	[HideInInspector]
	public List<int> succesfulHitters;

	[Space]
	public UnityEvent onRestart;

	[HideInInspector]
	public float additionalSpawnRotation;

	private void Start()
	{
	}

	private void OnDisable()
	{
	}

	private bool ShouldBeOff()
	{
		return false;
	}

	private void Update()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
	}

	private void OnTriggerExit(Collider other)
	{
	}

	public void ActivateCheckPoint()
	{
	}

	public void OnRespawn()
	{
	}

	public void ResetRoom()
	{
	}

	public void UpdateRooms()
	{
	}

	public void InheritRoom(GameObject targetRoom)
	{
	}

	public void ReactivateCheckpoint()
	{
	}

	public void ReactivationEffect()
	{
	}

	public void ApplyCurrentStyleAndKills()
	{
	}

	public void ApplyCurrentKills()
	{
	}

	public void ApplyCurrentStyle()
	{
	}

	public void AddCustomKill()
	{
	}

	public void ChangeSpawnRotation(float degrees)
	{
	}

	public void SetInvisibility(bool state)
	{
	}

	public void SetForceOff(bool state)
	{
	}
}
