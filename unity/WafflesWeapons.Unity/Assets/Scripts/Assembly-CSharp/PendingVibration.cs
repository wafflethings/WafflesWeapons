using UnityEngine;

public class PendingVibration
{
	public TimeSince timeSinceStart;

	public RumbleKey key;

	public float intensityMultiplier;

	public bool isTracking;

	public GameObject trackedObject;

	public float Duration => 0f;

	public float Intensity => 0f;

	public bool IsFinished => false;
}
