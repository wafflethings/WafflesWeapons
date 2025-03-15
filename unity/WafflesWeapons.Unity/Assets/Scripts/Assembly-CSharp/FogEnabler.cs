using UnityEngine;

public class FogEnabler : MonoBehaviour
{
	public bool disable;

	public bool oneTime;

	private bool activated;

	private bool colliderless;

	public bool gradual;

	public float gradualFadeSpeed;

	[Space]
	public bool changeFogSettings;

	public Color fogColor;

	public float fogMinimum;

	public float fogMaximum;

	[Space]
	public bool changeLimboSkyboxFogSettings;

	public Color limboSkyboxFogColor;

	public float limboSkyboxFogMinimum;

	public float limboSkyboxFogMaximum;

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
	}

	private void Activate()
	{
	}
}
