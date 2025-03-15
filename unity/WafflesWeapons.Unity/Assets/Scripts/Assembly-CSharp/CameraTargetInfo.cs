using UnityEngine;

public class CameraTargetInfo
{
	public Vector3 position;

	public Vector3 rotation;

	public GameObject caller;

	public CameraTargetInfo(Vector3 newPosition, GameObject newCaller)
	{
	}

	public CameraTargetInfo(Vector3 newPosition, Vector3 newRotation, GameObject newCaller)
	{
	}
}
