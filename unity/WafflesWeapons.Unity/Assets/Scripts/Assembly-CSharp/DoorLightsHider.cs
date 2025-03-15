using UnityEngine;

public class DoorLightsHider : MonoBehaviour
{
	public GameObject[] sideA;

	public GameObject[] sideB;

	private Door parentDoor;

	private bool currentSideIsA;

	private bool overridePreviousSide;

	private void Start()
	{
	}

	private void SlowUpdate()
	{
	}

	public void SetSide(bool targetSideIsA)
	{
	}
}
