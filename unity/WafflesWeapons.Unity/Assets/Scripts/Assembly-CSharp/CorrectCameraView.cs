using UnityEngine;

public class CorrectCameraView : MonoBehaviour
{
	private Camera mainCam;

	private Camera hudCam;

	private Vector3 lastpos;

	private Quaternion lastrot;

	public Transform targetObject;

	public bool canModifyTarget;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void LateUpdate()
	{
	}

	private void OnPostRenderCallback(Camera cam)
	{
	}
}
