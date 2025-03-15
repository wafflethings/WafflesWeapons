using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomManager : MonoBehaviour
{
	public List<int> visitedRooms;

	private int nextRoom;

	private int newRoomChance;

	private int newRoomMinChance;

	public int totalLevels;

	public int rooms;

	public int clearedHallways;

	public int clearedRooms;

	public bool allClear;

	private Text roomAmount;

	private RandomSoundPlayer rsp;

	private bool fadeToFin;

	private void Awake()
	{
	}

	private void Update()
	{
	}

	public void SwitchRooms(string roomType)
	{
	}

	private void RoomSwitched()
	{
	}

	private void EndingStart()
	{
	}
}
