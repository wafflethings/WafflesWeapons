using UnityEngine;

public class HUDPos : MonoBehaviour
{
	private bool ready;

	public bool active;

	private Vector3 defaultPos;

	private Vector3 defaultRot;

	public Vector3 reversePos;

	public Vector3 reverseRot;

	[Header("Rect Transform")]
	public bool rectTransform;

	private RectTransform rect;

	private Vector2 anchorsMaxDefault;

	public Vector2 anchorsMax;

	private Vector2 anchorsMinDefault;

	public Vector2 anchorsMin;

	private Vector2 pivotDefault;

	public Vector2 pivot;

	private Vector2 anchoredPositionDefault;

	public Vector2 anchoredPosition;

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

	public void CheckPos()
	{
	}
}
