using TMPro;
using UnityEngine;

public class Speedometer : MonoBehaviour
{
	public TextMeshProUGUI textMesh;

	public Vector3 lastPos;

	public bool classicVersion;

	private TimeSince lastUpdate;

	public RectTransform rect;

	private int type;

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnPrefChanged(string id, object value)
	{
	}

	private void FixedUpdate()
	{
	}
}
