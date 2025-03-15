using UnityEngine;

public class SwitchOnBeat : MonoBehaviour
{
	[HideInInspector]
	public BeatInfo currentBeatInfo;

	private float timer;

	private float nextMeasure;

	private bool switching;

	private int target;

	public BeatInfo[] switches;

	private bool initialized;

	private void Awake()
	{
	}

	private void Initialize()
	{
	}

	private void Update()
	{
	}

	private void Switch()
	{
	}

	public void SetTarget(int newTarget)
	{
	}
}
