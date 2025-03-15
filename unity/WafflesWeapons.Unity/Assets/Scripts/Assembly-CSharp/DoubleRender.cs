using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DoubleRender : MonoBehaviour
{
	public List<int> subMeshesToIgnore;

	public Material radiantMat;

	public Renderer thisRend;

	private CommandBuffer cb;

	private CameraController cc;

	private Camera currentCam;

	public int shouldOutline;

	private bool isActive;

	private void Awake()
	{
	}

	public void Reinitialize(bool forceReinitialize = false)
	{
	}

	private void LateUpdate()
	{
	}

	public void OnDisable()
	{
	}

	public void RemoveEffect()
	{
	}

	public void SetOutline(int showOultine)
	{
	}
}
