using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class BloodCheckerManager : MonoSingleton<BloodCheckerManager>
{
	public Canvas washingCanvas;

	public GameObject painterGUITemplate;

	public TextMeshProUGUI roomName;

	public TextMeshProUGUI activePainter;

	public TextMeshProUGUI toDoText;

	public TextMeshProUGUI cleanText;

	public TextMeshProUGUI litterCount;

	public Slider activePercentSlider;

	private string activePainterName;

	public GameObject finalDoorOpener;

	public List<GameObject> trackedRooms;

	public int[] roomLitterForgiveness;

	private Dictionary<GameObject, List<BloodAbsorber>> rooms;

	private Dictionary<GameObject, HashSet<GoreSplatter>> roomGore;

	private Dictionary<GameObject, HashSet<EnemyIdentifierIdentifier>> roomGibs;

	public Dictionary<BloodAbsorber, GameObject> toDoEntries;

	public Cubemap[] cleanedMaps;

	private GameObject pondToDoEntry;

	public Pond pond;

	public HashSet<GameObject> pondLitter;

	public bool startedWashing;

	private int litterCheckIndex;

	public int[] roomLitterCounts;

	public bool[] roomCompletions;

	private int totalLitterCount;

	public List<GameObject> completedRoomStates;

	[HideInInspector]
	public bool playerInPond;

	public bool higherAccuracy;

	public void HigherAccuracy(bool useHigherAccuracy)
	{
	}

	private void Start()
	{
	}

	private void RemoveNullLitters()
	{
	}

	private void CheckLevelStates()
	{
	}

	private void CheckLitterCounts()
	{
	}

	public void StartCheckingBlood()
	{
	}

	private void ToggleHigherAccuracy(bool isTrue)
	{
	}

	private void Update()
	{
	}

	private void CheckLevelCompletion()
	{
	}

	private bool IsRoomCompleted(GameObject roomToCheck)
	{
		return false;
	}

	public void StoreBlood()
	{
	}

	public void RestoreBlood()
	{
	}

	public void UpdateDisplay(BloodAbsorber bA)
	{
	}

	public void AddPondGore(GoreSplatter litter)
	{
	}

	public void AddPondGib(EnemyIdentifierIdentifier litter)
	{
	}

	public void AddGoreToRoom(BloodAbsorber absorber, GoreSplatter litter)
	{
	}

	public void AddGibToRoom(BloodAbsorber absorber, EnemyIdentifierIdentifier litter)
	{
	}
}
