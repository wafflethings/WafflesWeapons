using UnityEngine;

public class TrailRendererAutoScaler : MonoBehaviour
{
	private TrailRenderer tr;

	[SerializeField]
	private bool setDefaultSizeOnAwake;

	[SerializeField]
	private Vector3 defaultSize;

	private void Awake()
	{
	}

	private void Update()
	{
	}

	private float SizeAverage(Vector3 size)
	{
		return 0f;
	}
}
