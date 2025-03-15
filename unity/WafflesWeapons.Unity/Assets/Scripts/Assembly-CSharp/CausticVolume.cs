using UnityEngine;

[ExecuteInEditMode]
public class CausticVolume : MonoBehaviour
{
	public Color color;

	public float intensity;

	public float nearRadius;

	public float farRadius;

	[HideInInspector]
	public CausticVolumeManager manager;

	private void OnValidate()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnDestroy()
	{
	}
}
