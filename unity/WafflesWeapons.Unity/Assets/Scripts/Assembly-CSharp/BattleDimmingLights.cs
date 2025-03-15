using UnityEngine;

public class BattleDimmingLights : MonoBehaviour
{
	private Light[] lights;

	private float[] intensities;

	private float lerp;

	public float speedMultiplier;

	public bool disabledUnlessAlwaysDark;

	[Header("Ambient Color")]
	public bool dimAmbientLight;

	private Color originalAmbientLightColor;

	public Color dimmedAmbientLightColor;

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void Active(bool stuff)
	{
	}
}
