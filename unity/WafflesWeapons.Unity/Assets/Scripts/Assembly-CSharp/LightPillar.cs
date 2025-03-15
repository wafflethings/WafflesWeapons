using System.Collections.Generic;
using UnityEngine;

public class LightPillar : MonoBehaviour
{
	[HideInInspector]
	public bool gotValues;

	[HideInInspector]
	public bool activated;

	[HideInInspector]
	public bool completed;

	[HideInInspector]
	public Light[] lights;

	[HideInInspector]
	public AudioSource aud;

	[HideInInspector]
	public Vector3 origScale;

	[HideInInspector]
	public float lightRange;

	[HideInInspector]
	public float origPitch;

	public float speed;

	public GameObject tipGlow;

	public Renderer[] emissivesToLightUp;

	[HideInInspector]
	public List<float> emissiveStrengths;

	private MaterialPropertyBlock block;

	private bool heightDone;

	public UltrakillEvent onHeightDone;

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void SetEmissives(float lerpAmount)
	{
	}

	public void ActivatePillar()
	{
	}
}
