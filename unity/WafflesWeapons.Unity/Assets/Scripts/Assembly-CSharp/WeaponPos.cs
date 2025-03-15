using System.Collections.Generic;
using UnityEngine;

public class WeaponPos : MonoBehaviour
{
	private bool ready;

	public Vector3 currentDefault;

	private Vector3 defaultPos;

	private Vector3 defaultRot;

	private Vector3 defaultScale;

	public Vector3 middlePos;

	public Vector3 middleRot;

	public Vector3 middleScale;

	public Transform[] moveOnMiddlePos;

	public Vector3[] middlePosValues;

	private List<Vector3> defaultPosValues;

	public Vector3[] middleRotValues;

	private List<Vector3> defaultRotValues;

	private void Start()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnPrefChanged(string key, object value)
	{
	}

	public void CheckPosition()
	{
	}
}
