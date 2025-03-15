using UnityEngine;
using UnityEngine.Events;

public class LimboSwitchLock : MonoBehaviour
{
	public SwitchLockType type;

	public MeshRenderer[] locks;

	public MeshRenderer[] primeBossLocks;

	private MaterialPropertyBlock block;

	private float[] lockIntensities;

	private bool[] lockStates;

	private int openedLocks;

	public UnityEvent onAllLocksOpen;

	public int minimumOrderNumber;

	public int primeBossLockNumber;

	private void Start()
	{
	}

	public void CheckSaves()
	{
	}

	private void Update()
	{
	}

	private void CheckLocks()
	{
	}

	public void OpenLock(int num)
	{
	}
}
